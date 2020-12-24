namespace Days

open Utils.FileUtils

module Day7 =

    let getData () =
        getLines "./inputs/day7part1.txt" |> Seq.toList

    type BagId = BagId of string

    type BagContent = { Color: BagId; Count: int }

    type BagRule =
        { Color: BagId
          Contents: BagContent list }

    let createBagRule (line: string) =
        let parts =
            line.Split " "
            |> List.ofArray
            |> splitWhen ((=) "contain")

        match parts with
        | part1 :: (part2 :: _) ->

            let id = BagId $"{part1.[0]} {part1.[1]}"

            let contents =
                part2
                |> splitWhen (fun p -> p = "bag," || p = "bags,")
                |> Seq.choose
                    (fun contentPiece ->
                        match contentPiece with
                        | first :: (second :: _) when first = "no" && second = "other" -> None
                        | first :: (second :: (third :: _)) ->
                            (Some
                                { Color = BagId $"{second} {third}"
                                  Count = first |> int })
                        | _ -> None)
                |> List.ofSeq

            { Color = id; Contents = contents }

        | badParts -> failwith $"Unextected content rule {badParts}"


    let rules lines =
        lines |> Seq.map createBagRule |> Set.ofSeq

    let countShinyGoldOptions lines =

        let rules = rules lines

        let rec countRulesLeadingToId (ids: Set<BagId>) =

            let idCount = ids.Count

            let newIds =
                rules
                |> Seq.choose
                    (fun rule ->
                        let intersect =
                            Set.intersect
                                (rule.Contents
                                 |> Seq.map (fun r -> r.Color)
                                 |> Set.ofSeq)
                                ids
                            |> Set.isEmpty
                            |> not

                        if intersect then Some(rule.Color) else None)
                |> Seq.append ids
                |> Set.ofSeq

            let newIdCount = newIds.Count

            if idCount = newIdCount then newIdCount else countRulesLeadingToId newIds

        countRulesLeadingToId (Set.ofList [ BagId "shiny gold" ])
        - 1 // uncount self rule

    let countShinyGoldBags lines =
        let rules = rules lines

        let rec countBagsInContents (rule: BagRule) =
            match rule.Contents with
            | [] -> 0
            | contents ->

                let contentsCount =
                    (contents |> Seq.sumBy (fun c -> c.Count))

                let subContentsCount =
                    contents
                    |> Seq.sumBy
                        (fun c ->
                            let nextRule =
                                rules |> Seq.find (fun r -> r.Color = c.Color)

                            let subCount = countBagsInContents (nextRule)

                            c.Count * subCount)


                contentsCount + subContentsCount

        let shinyGoldRule =
            rules
            |> Seq.find (fun r -> r.Color = BagId "shiny gold")

        countBagsInContents shinyGoldRule

    let part1 () =
        let result = getData () |> countShinyGoldOptions

        printf $"Day 7 Part 1 Answer: {result}\n"


    let part2 () =
        let result = getData () |> countShinyGoldBags

        printf $"Day 7 Part 2 Answer: {result}\n"
