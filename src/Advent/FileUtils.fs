namespace Utils

open System.IO

module FileUtils =
    let getLines (filePath: string) =
        seq {
            use sr = new StreamReader(filePath)

            while not sr.EndOfStream do
                yield sr.ReadLine()
        }

    let splitWhen<'T> (condition: 'T -> bool) (seq: List<'T>) =

        let rec splitWhenRec (condition: 'T -> bool) inFlightseq =
            let nextSatifyingLineIndex =
                inFlightseq |> List.tryFindIndex condition

            match nextSatifyingLineIndex with
            | Some i ->
                let (chunck, restOfLines) = List.splitAt i inFlightseq

                (List.singleton chunck, splitWhenRec condition (List.tail restOfLines))
                ||> List.append
            | None -> List.singleton inFlightseq

        splitWhenRec condition seq
