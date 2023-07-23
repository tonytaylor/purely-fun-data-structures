// For more information see https://aka.ms/fsharp-console-apps
open System

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Jobs

open Chapter01

[<SimpleJob (RuntimeMoniker.Net70)>]
type Benchmarks() =
    [<Params(10, 100, 1000)>]
    member val size = 0 with get, set

    [<Benchmark>]
    member this.List() = [0 .. this.size] |> suffixes

BenchmarkRunner.Run<Benchmarks>() |> ignore
