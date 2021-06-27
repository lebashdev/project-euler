open System

// Represents the Fibonacci sequence.
let fibonacci = Seq.unfold (fun (a, b) -> Some (a, (b, a + b))) (1, 2)

let printInt (x: int) = Console.WriteLine("{0:#,#}", x)
let isEven (x: int) = (x % 2) = 0
let under limit x = x < limit

[<EntryPoint>]
let main argv =

    // Take the even integers from the Fibonacci sequence
    // that are under 4,000,000 and add them up.
    // Print the result.
    fibonacci
    |> Seq.filter isEven
    |> Seq.takeWhile (under 4_000_000)
    |> Seq.sum
    |> printInt

    0 // return an integer exit code
