module Day1 =
  // ========
  // Count the open and close parens
  // ========

  let filename = "input.txt"
  
  open System.IO

  let parens = Seq.head <| File.ReadAllLines filename
  let parensMap (paren:char) = if paren = '(' then 1 else -1
  
  let part1 = Seq.sumBy parensMap parens
  
  let part2 = parens
               |> Seq.scan (fun acc paren -> acc + (parensMap paren)) 0
               |> Seq.takeWhile ((<=) 0)
               |> Seq.length

  printf "Part 1: %d\n" part1
  printf "Part 2: %d\n" part2
