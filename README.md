# SETweak

A toolchain for tweaking Space Engineers saves and mods.

[![Build Status](http://ci.nexisonline.net/buildStatus/icon?job=SETweak)](http://ci.nexisonline.net/job/SETweak/)

## Builds

* [Latest successful build](http://ci.nexisonline.net/job/SETweak/lastSuccessfulBuild/artifact/SETweaks.zip) (Always against master)

## Compiling

* Fire up VS2010 (or later) and open the solution.
  * If you don't have NuGet, install it.
* Open the Package Manager Console
* If it says "Click to restore packages", do so.
* Right-click on EnvFiddle.GUI > Set as Startup Project
* Mash F6

Your binaries are in `bin/debug/`.

## Usage

### EnvFiddle

EnvFiddle and EnvFiddle.GUI are used to download and automatically customize skybox mods.  At the moment, they only support Workshop `*.sbm`'s or directories.

**EnvFiddle** will spit out some documentation when you run it with `--help`.  

Example usage:
```bat
@echo off
:: This is a Windows batch file, by the way.
:: Save it as %APPDATA%\SpaceEngineers\Mods\DownloadSkybox.bat and run it.

:: Location of EnvFiddle
set ENVFIDDLE="C:\Users\Rob\Documents\Projects\SETweaks\bin\debug\EnvFiddle.exe"
:: Max large ship speed (m/s)
set MAX_LSPEED=200
:: Max small ship speed
set MAX_SSPEED=250
:: Workshop ID or path to the base Gallente skybox mod (you can also paste in the workshop mod's URL)
set MOD_LOCATION=302311569
:: Call EnvFiddle (-D means Dark Shadows)
call %ENVFIDDLE% %MOD_LOCATION% Gallente-Dark-250/ -D -s %MAX_SSPEED% -S %MAX_LSPEED%
pause
```

You can also simply download and extract a mod:
```bat
EnvFiddle.exe 302311569 Gallente-Stock\
```

**EnvFiddle.GUI** provides some of the same functionality, with a *slightly* more user-friendly user interface.  However, it is a work in progress and somewhat buggy.  Presets are not currently implemented.

### SETweak

The SETweak executable is currently unfinished and unusable.  It will eventually provide a far more advanced way to muck around with saves and mods.
