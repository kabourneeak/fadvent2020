namespace Days

open Utils.FileUtils

module Day8 =

    let getData () =
        getLines "./inputs/day8part1.txt" |> Seq.toList

    type Instruction =
        { Label: string
          Value: int
          Index: int }

    type State =
        { Accumlator: int
          ExecutedIndecies: Set<int> }

    type Result =
        | Loop of State
        | Finished of State
        | Segfault of State

    let parseInstructions (lines: string list) =
        lines
        |> Seq.mapi
            (fun index line ->
                match line.Split(" ") with
                | [| label; value |] ->
                    (index,
                     { Label = label
                       Value = value |> int
                       Index = index })
                | failed -> failwith $"Unexpected instruction: {failed}")
        |> Map.ofSeq

    let execute (instructions: Map<int, Instruction>) =

        let rec executeRec (state: State) (instruction: Instruction) =
            if Set.contains instruction.Index state.ExecutedIndecies then
                Loop state
            else
                let (updatedAccumulator, nextInstructionIndex) =
                    match instruction.Label with
                    | "nop" -> (state.Accumlator, instruction.Index + 1)
                    | "acc" -> (state.Accumlator + instruction.Value, instruction.Index + 1)
                    | "jmp" -> (state.Accumlator, instruction.Index + instruction.Value)
                    | unexpected -> failwith $"Unexpected instruction: {unexpected}"

                let updatedState =
                    { state with
                          Accumlator = updatedAccumulator
                          ExecutedIndecies = Set.add instruction.Index state.ExecutedIndecies }

                if nextInstructionIndex = instructions.Count
                then Finished updatedState
                else if nextInstructionIndex > instructions.Count
                then Segfault updatedState
                else executeRec updatedState instructions.[nextInstructionIndex]

        let initialState =
            { Accumlator = 0
              ExecutedIndecies = Set.empty }

        executeRec initialState instructions.[0]

    let fixUp (instructions: Map<int, Instruction>) =

        let test index =
            let instructionToAdjust = instructions.[index]

            let adjustedInstruction =
                { instructionToAdjust with
                      Label = if instructionToAdjust.Label = "nop" then "jmp" else "nop" }

            let adjustedInstructions =
                Map.add index adjustedInstruction instructions

            execute adjustedInstructions

        instructions
        |> Seq.filter (fun kvp -> kvp.Value.Label = "nop" || kvp.Value.Label = "jmp")
        |> Seq.map ((fun kvp -> kvp.Key) >> test)
        |> Seq.find
            (function
            | Loop _ -> false
            | Finished _ -> true
            | Segfault _ -> false)

    let part1 () =
        let result =
            getData ()
            |> parseInstructions
            |> execute
            |> function
            | Loop x -> x.Accumlator
            | unexpected -> failwith $"Unexpected result {unexpected}"

        printf $"Day 8 Part 1 Answer: {result}\n"


    let part2 () =
        let result =
            getData ()
            |> parseInstructions
            |> fixUp
            |> function
            | Finished x -> x.Accumlator
            | unexpected -> failwith $"Unexpected result {unexpected}"

        printf $"Day 8 Part 2 Answer: {result}\n"
