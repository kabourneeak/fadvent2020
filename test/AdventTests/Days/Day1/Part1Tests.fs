namespace AdventTests.Days.Day1

module Part1Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day1

    [<SetUp>]
    let Setup () = ()
    
    [<Test>]
    let ``findExpensePair should solve example`` () =
        // arrange
        let target = 2020
        let expenseReport = [ 1721; 979; 366; 299; 675; 1456 ]

        // act
        let result = findExpensePair target expenseReport

        // assert
        result |> should equal { Left = 1721; Right = 299 }
        result.Left * result.Right |> should equal 514579
