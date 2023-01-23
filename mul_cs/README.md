
The blog entry for this sample is:

[http://ericsink.com/native_aot/mul_cs.html](http://ericsink.com/native_aot/mul_cs.html)

Example command to build a dynamic library, on Windows:

```
dotnet publish -r win-x64
```

Example command to build a static library, on Windows:

```
dotnet publish --property NativeLib=Static -r win-x64
```

