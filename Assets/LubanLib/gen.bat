set LUBAN_DLL=<Luban.dll路径>
set CONF_ROOT=<DataTables路径>

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-simple-json ^
    -d json  ^
    --conf %CONF_ROOT%\luban.conf ^
    -x inputDataDir=%CONF_ROOT%\Datas ^
    -x outputCodeDir=<cs代码输出目录> ^
    -x outputDataDir=<json数据输出目录>

pause