namespace AdventTests.Days.Day1

module Part1Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day1

    [<Test>]
    let ``findExpensePair should solve example`` () =
        // arrange
        let target = 2020
        let expenseReport = [ 1721; 979; 366; 299; 675; 1456 ]

        // act
        let result = findExpensePair target expenseReport

        // assert
        result |> should equal (Some(1721, 299))

        let (a, b) = result.Value
        a * b |> should equal 514579
