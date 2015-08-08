%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe WindowsService_luliu.exe
Net Start LuliuService
sc config LuliuService start= auto