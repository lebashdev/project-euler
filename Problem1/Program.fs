// Learn more about F# at http://fsharp.org

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running

[<MemoryDiagnoser>]
type Solutions () =

    [<Benchmark>]
    member this.solution1 () =

        // Get the multiples of three and five under 1000.
        let multipleOfThreeAndFive = seq { for x in 1..999 do if (x % 5) = 0 || (x % 3) = 0 then x }

        // Add them up.
        let result = multipleOfThreeAndFive |> Seq.sum

        result

    [<Benchmark>]
    member this.solution2 () =

        // This shoudl be marginally more efficient, sd iy only enumerates
        // the numbers we'll ultimately keep.
        let multipleOfthree = seq { for x in 3..3..999 -> x }
        let mulitpleOfFive = seq { for x in 5..5..999 do if (x % 15) <> 0 then x }
        let r2 = ((Seq.sum multipleOfthree) + (Seq.sum mulitpleOfFive))

        r2

[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run typeof<Solutions> |> ignore

    0 // return an integer exit code
