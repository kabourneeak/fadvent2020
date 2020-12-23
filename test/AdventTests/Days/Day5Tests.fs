namespace AdventTests.Days

module Day5Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day5

    [<Test>]
    let ``getSeatId should solve part1 examples`` () =
        // arrange
        // act
        // assert
        getSeatId "FBFBBFFRLR" |> should equal 357
        getSeatId "BFFFBBFRRR" |> should equal 567
        getSeatId "FFFBBBFRRR" |> should equal 119
        getSeatId "BBFFBBFRLL" |> should equal 820

    [<Test>]
    let ``getRow should get 0 for all F`` () =
        // arrange

        // act
        let result = getRow "FFFFFFF"

        // assert
        result |> should equal 0

    [<Test>]
    let ``getRow should get 127 for all B`` () =
        // arrange

        // act
        let result = getRow "BBBBBBB"

        // assert
        result |> should equal 127
