@echo Off

REM Set ENV Vars
call build-env

REM Localize Vars
setlocal

REM Set Params
set MSBuildSDKsPath=%RepoDir%\Source

set "BuildFile=%~dp1"
if "%BuildFile%" == "" (
	set BuildFile=MSBuild-SDKs.slnx
)

if "%Configuration%" == "" set Configuration=Release

if not "%BuildCounter%" == "" (
	REM Remove Leading Zeros from BuildCounter
	for /f "tokens=* delims=0" %%A in ("%BuildCounter%") do set BuildCounter=%%A
	REM Set Version
	set VersionMeta=dev.%BuildCounter%
)

REM Build
call msbuild %BuildFile%

REM Reset CMD
endlocal

REM Done