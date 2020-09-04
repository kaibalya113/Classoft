cd /d %~dp0
copy .\*.dll %windir%\system32\
copy .\*.dll %windir%\system32\SysWOW64
regsvr32 %windir%\system32\zkemkeeper.dll
regsvr32 %windir%\SysWOW64\zkemkeeper.dll