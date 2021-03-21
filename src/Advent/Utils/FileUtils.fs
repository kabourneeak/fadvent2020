namespace Utils

open System.IO

module FileUtils =
    let getLines (filePath: string) =
        seq {
            use sr = new StreamReader(filePath)
            while not sr.EndOfStream do
                yield sr.ReadLine()
        }