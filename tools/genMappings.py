import yaml
import json
import xmltodict
import os
import sys
import subprocess
import collections

XSD = 'c:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.0A\\Bin\\x64\\xsd.exe'

CommonReplacements = {
    'id': 'ID',
    'url': 'URL',
    'hcontent': 'HContent'
}


_mapping_tag = yaml.resolver.BaseResolver.DEFAULT_MAPPING_TAG


def dict_representer(dumper, data):
  return dumper.represent_dict(data.iteritems())


def dict_constructor(loader, node):
  return collections.OrderedDict(loader.construct_pairs(node))

yaml.add_representer(collections.OrderedDict, dict_representer)
yaml.add_constructor(_mapping_tag, dict_constructor)


def camelize(string):
  splittified = []
  buf = ''
  for c in string:
    if c in "_- ":
      splittified.append(buf)
      buf = ''
    else:
      buf += c
  splittified.append(buf)
  return ''.join(CommonReplacements.get(x, x.title()) for x in splittified)


def tryConvert(data):
  try:
    return float(data)
  except:
    pass
  try:
    return long(data)
  except:
    pass
  return data


class Class:

  def __init__(self, name, config={}):
    self.name = name
    self.config = config
    self.realname = config.get('realname', name)
    self.properties = {}
    for name, data in config.get('properties', {}).items():
      self.properties[name] = PropertyDef(name, data)
    self.namespaces = []

  def using(self, namespace):
    if namespace not in self.namespaces:
      self.namespaces.append(namespace)

  def addProperty(self, prop):
    self.properties[prop.name] = prop

  def toCS(self, REST, indent):
    indentOuter = '    ' * indent
    indentInner = '    ' * (indent + 1)
    o = ''
    if not REST:
      self.using('System')
      o += indentOuter + '[Serializable]\n'
    o += indentOuter + 'public'
    if self.config.get('partial', False):
      o += ' partial'
    o += ' class {}\n'.format(name)
    o += indentOuter + '{\n'
    idx = 0
    for prop in reversed(self.properties.values()):
      o += prop.toCS(self, REST, indent + 1, idx)
      idx += 1
    o += indentOuter + '}\n'
    return o


class PropertyDef:

  def __init__(self, name, config={}):
    self.name = name
    self.realname = config.get('realname', name)
    self.type = config.get('type', None)
    self.default = config.get('default', None)

  def setRealName(self, realname):
    self.realname = realname

  def setType(self, _type):
    self.type = _type

  def setDefault(self, default):
    self.default = default

  def isAttribute(self):
    return self.realname.startswith('@')

  def toCS(self, _class, REST, indent, index=None):
    indent = '    ' * indent
    o = ''
    t = self.type
    if REST:
      _class.using('RestSharp.Serializers')
      o += indent + '[SerializeAs(Name="{}")]\n'.format(self.realname)
    else:
      _class.using('System.Xml.Serialization')
      o += indent + '[Xml{}("{}"'.format('Attribute' if self.isAttribute() else 'Element', self.realname)
      if self.default is not None:
        o += ', IsNullable = true'
        if t in ('int', 'long', 'float', 'bool'):
          _class.using('System')
          t = 'Nullable<{}>'.format(t)
      if index is not None:
        o += ', Order = {}'.format(index)
      o += ')]\n'
    o += indent + 'public {} {}'.format(t, self.name)
    if self.default is not None:
      o += ' = {}'.format(self.default)
    o += ';\n\n'
    return o

  def toDict(self):
    data = {}
    if self.realname != self.name:
      data['realname'] = self.realname
    if self.type:
      data['type'] = self.type
    if self.default:
      data['default'] = self.default
    return data


def writeClass(name, members, settings, outf, indent=0, path=[]):
  indentOuter = '    ' * indent
  indentInner = '    ' * (indent + 1)

  if not settings.get('REST', False):
    outf.write(indentOuter + '[Serializable]\n')
  outf.write(indentOuter + "public class {}\n".format(name))
  outf.write(indentOuter + '{\n')
  types = {}
  for k, v in members.items():
    ftype = findtype(v, k)
    if ftype is None:
      writeClass(k, v, settings, outf, indent + 1)
      ftype = k
    types[k] = ftype
  for k, v in members.items():
    outf.write(indentInner + "// {}: {}\n".format(json.dumps(k), json.dumps(v)))
    if k.startswith('@xmlns:'):
      continue
    cleanName = camelize(k) if enableCapFixer else k
    if k != cleanName or True:
      if settings.get('REST', False):
        outf.write(indentInner + '[SerializeAs(Name = "{}")]\n'.format(k))
      else:
        outf.write(indentInner + '[Xml{}("{}")]\n'.format('Attribute' if k.startswith('@') else 'Element', k))
    outf.write(indentInner + 'public {} {} {{ get; set; }}\n\n'.format(types[k], cleanName))
  outf.write(indentOuter + "}\n")


def readClass(name, members, settings):
  allClasses = {}

  for k, v in members.items():
    ftype = findtype(v, k)
    if ftype is None:
      allClasses += Class(k, v)
      ftype = k
    types[k] = ftype


def findtype(data, key, firsttry=True):
  if isinstance(data, (str, unicode)):
    if firsttry:
      return findtype(tryConvert(data), key, False)
    return 'string'
  if isinstance(data, int):
    return 'int'
  if isinstance(data, float):
    return 'float'
  if isinstance(data, long):
    return 'long'
  if isinstance(data, bool):
    return 'bool'
  if isinstance(data, dict):
    if '@x' in data and '@y' in data and '@z' in data:
      return 'Vector3f'
    elif '@Yaw' in data:
      return 'EulerRot'
    else:
      return None
  if isinstance(data, list):
    return 'List<string>'
  return '{} /* py:{} */'.format(key, data.__class__.__name__)

index = {}
print('Reading index...')
with open(os.path.join('DataSamples', 'INDEX.json'), 'r') as indexf:
  index = json.load(indexf)

for namespace, files in index.items():
  settings = None
  if 'settings' in files:
    settings = files['settings']
    del files['settings']
  enableCapFixer = settings.get('enableCapFixer', True)
  for jsonfilename in sorted(files.keys()):
    csfilename = files[jsonfilename]
    basefilename = os.path.basename(jsonfilename)
    jsonfilename = os.path.join('DataSamples', os.path.normpath(jsonfilename))
    csfilename = os.path.join('NEW_BINDINGS', os.path.normpath(csfilename))
    outdir = os.path.dirname(csfilename)
    _id, ext = os.path.splitext(basefilename)
    if not os.path.isdir(outdir):
      os.makedirs(outdir)
      print('MKDIR ' + outdir)
    print('MKBIND {}'.format(csfilename))
    with open(csfilename, 'w') as outf:
      js = None
      with open(jsonfilename, 'r') as inf:
        if ext == ".json":
          js = json.load(inf)
        elif ext == ".xml":
          # for k, root in xmltodict.parse(inf, attr_prefix='').items():
          for k, root in xmltodict.parse(inf, attr_prefix='@').items():
            js = root
            break
        elif ext == ".yml":
          # for k, root in xmltodict.parse(inf, attr_prefix='').items():
          yml = yaml.load(inf)
          using = []
          classes = ''
          for name, clsData in yml.items():
            _class = Class(name, clsData)
            classes += _class.toCS(False, 1)
            using += _class.namespaces
          for ns in sorted(using):
            outf.write("using {};\n".format(ns))
          outf.write("\nnamespace {}\n".format(namespace))
          outf.write('{\n')
          outf.write(classes)
          outf.write('}\n')
          continue
        else:
          print('UNKNOWN EXT: {}'.format(ext))
      outf.write("using System;\n")
      outf.write("using System.Collections.Generic;\n")
      outf.write("using RestSharp.Serializers;\n")
      outf.write("using System.Xml;\n")
      outf.write('using System.ComponentModel;\n\n')
      outf.write("namespace {}\n".format(namespace))
      outf.write('{\n')
      writeClass(_id, js, settings, outf, 1)
      outf.write("}\n")
