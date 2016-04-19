module Day3 =
  // ================================================
  // Day 3 - Visit houses on 2d coordinate grid
  // ================================================

  open System.IO

  let filename = "input.txt"
  let input = File.ReadAllText filename

  let visitedHouses directions =
    directions
    |> Seq.scan (fun (x, y) direction ->
      match direction with
      | '>' -> (x + 1,   y  )
      | '<' -> (x - 1,   y  )
      | '^' -> (  x  , y + 1)
      | 'v' -> (  x  , y - 1)
      | ex   -> failwithf "ERROR: %c not a direction!" ex)
      (0,0)
  
  type Parity = Even|Odd

  let chooseEveryOther parity xs =
    let n = if parity = Even then 1 else 0
    xs
    |> Seq.mapi (fun i e -> if i % 2 = n then Some(e) else None)
    |> Seq.choose id

  let getEvenSeq = chooseEveryOther Even
  let getOddSeq = chooseEveryOther Odd

  let santaHousesPart2 =
    input
    |> getEvenSeq
    |> visitedHouses

  let robotHousesPart2 =
    input
    |> getOddSeq
    |> visitedHouses

  let part1 =
    input
    |> visitedHouses
    |> Seq.distinct
    |> Seq.length

  let part2 =
    Seq.append santaHousesPart2 robotHousesPart2
    |> Seq.distinct
    |> Seq.length

  printf "Part 1: %d\n" part1
  printf "Part 2: %d\n" part2
