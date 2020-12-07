namespace AdventTests.Days.Day1

module Part2Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day1

    [<SetUp>]
    let Setup () = ()
    
    [<Test>]
    let ``findExpenseTriplet should solve example`` () =
        // arrange
        let target = 2020
        let expenseReport = [ 1721; 979; 366; 299; 675; 1456 ]

        // act
        let result = findExpenseTriplet target expenseReport

        // assert
        result |> should equal (979, 366, 675)
