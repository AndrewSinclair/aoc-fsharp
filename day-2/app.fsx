module Day2 =
  // ================================================================
  // Calculate the required amount of wrapping paper and ribbons
  // ================================================================

  open System.IO
  open System.Text.RegularExpressions

  let filename = "input.txt"

  let presentDimensions = File.ReadAllLines filename
  let parseDimensions str =
    let regex = "(\d+)x(\d+)x(\d+)"
    let m = Regex(regex).Match(str)
    match [for x in m.Groups -> x.Value] with
    | [_;l;w;h] -> (int l, int w, int h)
    | _ -> failwithf "Either the code, the regex, or the input was wrong..."

  let area (l, w, h) = 2 * ((l * w) + (l * h) + (h * w))
  let slack (l, w, h) = List.min [l * w; l * h; h * w]

  let part1 =
    presentDimensions
    |> Seq.map parseDimensions
    |> Seq.map (fun dimension -> area dimension + slack dimension)
    |> Seq.sum

  let perimeterOfSmallestSide (l, w, h) =
    match [l;w;h] |> List.sort with
    | [a;b;_] -> 2 * (a + b)
    | _ -> failwithf "List.sort returned too many or too few items..."

  let volume (l, w, h) = l * w * h

  let part2 =
    presentDimensions
    |> Seq.map parseDimensions
    |> Seq.map (fun dimension -> perimeterOfSmallestSide dimension + volume dimension)
    |> Seq.sum

  printf "Part 1: %d\n" part1
  printf "Part 2: %d\n" part2
