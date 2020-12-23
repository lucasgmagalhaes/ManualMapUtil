# ManualMapUtil
A AutoMapper (but not auto) like map function. 

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.685 (2004/?/20H1)
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|        Method |     Mean |   Error |  StdDev |
|-------------- |---------:|--------:|--------:|
|     ManualMap | 177.9 ns | 3.57 ns | 6.79 ns |
| AutoMapperMap | 188.9 ns | 3.86 ns | 6.96 ns |
| ManualMapCall | 117.4 ns | 2.43 ns | 5.87 ns |
