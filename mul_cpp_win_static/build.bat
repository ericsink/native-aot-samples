rem This must be run from a Visual Studio x64 Native Tools Command Prompt

rem Change the path below to match your .nuget packages directory
set ilcdir=../../../.nuget/packages/runtime.win-x64.microsoft.dotnet.ilcompiler/7.0.0/sdk

cl.exe mul_main.cpp /O1 /GL /Gy ../mul_cs/bin/Debug/net7.0/win-x64/publish/mul.lib %ilcdir%/bootstrapperdll.lib %ilcdir%/Runtime.WorkstationGC.lib %ilcdir%\System.Globalization.Native.Aot.lib %ilcdir%\System.IO.Compression.Native.Aot.lib ws2_32.lib advapi32.lib crypt32.lib bcrypt.lib ncrypt.lib user32.lib ole32.lib kernel32.lib secur32.lib mswsock.lib oleaut32.lib iphlpapi.lib version.lib /link /INCLUDE:NativeAOT_StaticInitialization /INCREMENTAL:no

