namespace AdventTests.Days.Day3

module Day3Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day3

    [<Test>]
    let ``countTrees should solve part1 example`` () =
        // arrange
        let map =
            [ "..##......."
              "#...#...#.."
              ".#....#..#."
              "..#.#...#.#"
              ".#...##..#."
              "..#.##....."
              ".#.#.#....#"
              ".#........#"
              "#.##...#..."
              "#...##....#"
              ".#..#...#.#" ]

        // act
        let result = countTrees map (3, 1)

        // assert
        result |> should equal 7

    [<Test>]
    let ``countTrees should solve part2 example`` () =
        // arrange
        let map =
            [ "..##......."
              "#...#...#.."
              ".#....#..#."
              "..#.#...#.#"
              ".#...##..#."
              "..#.##....."
              ".#.#.#....#"
              ".#........#"
              "#.##...#..."
              "#...##....#"
              ".#..#...#.#" ]

        // act
        let result =
            countTrees map (1, 1)
            * countTrees map (3, 1)
            * countTrees map (5, 1)
            * countTrees map (7, 1)
            * countTrees map (1, 2)

        // assert
        result |> should equal 336
