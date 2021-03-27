namespace AdventTests.Days.Day3

module Day3Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day3

    [<SetUp>]
    let Setup () = ()

    [<Test>]
    let ``stringToForestModel should throw for unhandled character`` () =
        // arrange
        // act
        // assert
        (fun () -> stringToForestModel ("!") |> Seq.iter ignore)
        |> should (throwWithMessage "unexpected char in forest string") typeof<System.Exception>

    [<Test>]
    let ``stringToForestModel should create forest sequence`` () =
        // arrange
        let forestLine = ".##."

        // act
        let result = stringToForestModel forestLine

        // assert
        result 
        |> should equal ([ Open; Tree; Tree; Open ] |> Seq.ofList)

    [<Test>]
    let ``Should solve part 1 example`` () =

        // arrange
        let example = [
            "..##......."
            "#...#...#.."
            ".#....#..#."
            "..#.#...#.#"
            ".#...##..#."
            "..#.##....."
            ".#.#.#....#"
            ".#........#"
            "#.##...#..."
            "#...##....#"
            ".#..#...#.#"
        ]

        // act
        // assert
        ()