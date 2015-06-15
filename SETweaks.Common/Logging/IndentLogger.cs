/**
* Indent support in log4net, based on a StackOverflow post.
* 
* Copyright (c) 2015 Rob "N3X15" Nelson <nexisentertainment@gmail.com>
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.

*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace SETweak.Logging
{
    public static class ILogExtensions
    {
        /// <summary>
        /// Begin an indented debug-level block (if debug is enabled)
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static LogIndent BeginDebug(this ILog log, object message, params object[] args)
        {
            return log.Begin(Level.Debug, message, args);
        }

        /// <summary>
        /// Begin an indented info-level block.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static LogIndent BeginInfo(this ILog log, object message, params object[] args)
        {
            return log.Begin(Level.Info, message, args);
        }

        /// <summary>
        /// Begin an indented warning-level block.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static LogIndent BeginWarn(this ILog log, object message, params object[] args)
        {
            return log.Begin(Level.Warn, message, args);
        }

        /// <summary>
        /// Begin an indented error-level block.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static LogIndent BeginError(this ILog log, object message, params object[] args)
        {
            return log.Begin(Level.Error, message, args);
        }

        /// <summary>
        /// Begin an indented block with an arbitrary logging level.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static LogIndent Begin(this ILog log, Level level, object message, params object[] args)
        {
            if (level == Level.Debug)
            {
                if (log.IsDebugEnabled)
                {
                    if (args.Length == 0)
                        log.Debug(message);
                    else
                        log.DebugFormat((string)message, args);
                }
                else
                {
                    return null;
                }
            }
            if (level == Level.Info)
            {
                if (args.Length == 0)
                    log.Info(message);
                else
                    log.InfoFormat((string)message, args);
            }
            else if (level == Level.Warn)
            {
                if (args.Length == 0)
                    log.Warn(message);
                else
                    log.WarnFormat((string)message, args);
            }
            else if (level == Level.Error)
            {
                if (args.Length == 0)
                    log.Error(message);
                else
                    log.ErrorFormat((string)message, args);
            }
            return new LogIndent();
        }
    }
    public class LogIndent : IDisposable
    {
        public static uint IndentLevel = 0;

        public static void Configure()
        {
            string xmlf = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "log4net.xml");
            Console.WriteLine("Configuring log4net with {0}", xmlf);
            XmlConfigurator.Configure(new FileInfo(xmlf));
        }

        public LogIndent()
        {
            IndentLevel++;
        }
        public void Dispose()
        {
            IndentLevel--;
        }
    }
    /// <summary>
    /// Converts %indentation to string
    /// </summary>
    public class IndentationPatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            // do nothing - %indentation is used for indentation, so nothing should be written
        }
    }

    public class IndentationPatternLayout : PatternLayout
    {
        private PatternConverter m_head;

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (loggingEvent == null)
            {
                throw new ArgumentNullException("loggingEvent");
            }

            PatternConverter c = m_head;

            IndentationWriter indentationWriter = new IndentationWriter(writer);
            // loop through the chain of pattern converters
            while (c != null)
            {
                if (c is IndentationPatternConverter)
                {
                    // N3X - Added indentation.
                    indentationWriter.Write("  ".Repeat((int)LogIndent.IndentLevel));
                    indentationWriter.SetIndentation();
                }
                c.Format(indentationWriter, loggingEvent);
                c = c.Next;
            }
            indentationWriter.Finish();
        }

        override public void ActivateOptions()
        {
            PatternParser patternParser = CreatePatternParser(ConversionPattern);

            ConverterInfo converterInfo = new ConverterInfo()
            {
                Name = "indentation",
                Type = typeof(IndentationPatternConverter)
            };

            patternParser.PatternConverters.Add("indentation", converterInfo);
            m_head = patternParser.Parse();

            PatternConverter curConverter = m_head;
            this.IgnoresException = false;
        }
    }

    public class IndentationWriter : TextWriter
    {
        TextWriter writer;
        int indentation = 0;
        List<string> lines = new List<string>();

        public IndentationWriter(TextWriter writer)
        {
            this.writer = writer;
        }
        public override Encoding Encoding
        {
            get { return writer.Encoding; }
        }

        public override void Write(string value)
        {
            string[] values = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) values[i] = Environment.NewLine + values[i];
            }
            lines.AddRange(values);
        }

        public void Finish()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                if (i < lines.Count - 1) line = lines[i].Replace(Environment.NewLine, Environment.NewLine + new string(' ', indentation));
                writer.Write(line);
            }
            lines.Clear();
        }
        public override void WriteLine(string value)
        {
            this.Write(value + Environment.NewLine);
        }

        public void SetIndentation()
        {
            foreach (string line in lines)
            {
                indentation += line.Length;
            }
            // N3X
            indentation += (int)LogIndent.IndentLevel;
        }
    }
}
