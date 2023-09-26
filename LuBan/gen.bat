
set LUBAN_DLL=Tools\Luban\Luban.dll

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-simple-json ^
    -d json  ^
    --conf luban.conf ^
    -x inputDataDir=DataTables ^
    -x outputCodeDir=..\Assets\Scripts\Script_DataTables ^
    -x outputDataDir=..\Assets\Scripts\Json_DataTables

pause