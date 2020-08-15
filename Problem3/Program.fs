open System

let getFactors (x: int64) =
    seq {
        yield 1L

        // We can find the factors beyond sqrt(N)
        // simply by dividing N by each of the factors between 2L and sqrt(N).
        // Therefore we only need to compute the factors until sqrt(N)
        // which saves us a lot of processing.
        let limit = Math.Sqrt (float x) |> int64
        for n in 2L..limit do
            if (x % n) = 0L then
                yield n
                let m = x / n
                if n <> m then yield m

        yield x
    }

let isPrime (x: int64) =
    match x with
    // 1 is never a prime number.
    | 1L -> false
    // 2 is a prime number.
    | 2L -> true
    // Even numbers other than 2 are never prime numbers.
    | x when (x % 2L) = 0L -> false
    // Slow test.  Get all factors and if there are more than 2
    // the number is not a prime number.
    | x when (getFactors x |> Seq.toList).Length > 2 -> false
    // Any number that goes through the preceding tests is prime.
    | _ -> true

let largestPrimeFactorOf (x: int64) =
    getFactors x
    |> Seq.sortDescending
    |> Seq.pick (fun x -> if isPrime x then Some x else None)

[<EntryPoint>]
let main argv =

    printfn "%i" <| largestPrimeFactorOf 13195L
    printfn "%i" <| largestPrimeFactorOf 600851475143L

    0 // return an integer exit code
