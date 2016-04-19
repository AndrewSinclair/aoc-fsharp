module Day4 =
  // =============================================
  // Mine cryptocurrency with difficulty 5 and 6
  // =============================================
  open System.Security.Cryptography
  open System.Text

  // I found this on the internet somewhere
  let md5 (data : byte array) : string =
    use md5 = MD5.Create()
    (StringBuilder(), md5.ComputeHash(data))
    ||> Array.fold (fun sb b -> sb.Append(b.ToString("x2")))
    |> string

  let input = "yzbqklnj"
  let ints = Seq.initInfinite id

  let makeHash num =
    input + (string num)
    |> System.Text.Encoding.ASCII.GetBytes
    |> md5

  let succeedAtDifficulty n (hash:string) =
    let challenge = String.replicate n "0"
    hash.StartsWith(challenge)

  let inverse fn =
    fun x -> not (fn x)

  let doMine difficulty =
    ints
    |> Seq.map makeHash
    |> Seq.takeWhile (inverse (succeedAtDifficulty difficulty))
    |> Seq.length

  let part1 = doMine 5

  let part2 = doMine 6

  printf "Part 1: %d\n" part1
  printf "Part 2: %d\n" part2


