namespace AdventTests.Days.Day1

module Part2Tests =

    open NUnit.Framework
    open Days.Day1

    [<Test>]
    let ``findExpenseTriplet should solve example`` () =
        // arrange
        let target = 2020
        let expenseReport = [ 1721; 979; 366; 299; 675; 1456 ]

        // act
        let result = findExpenseTriplet target expenseReport

        // assert
        Assert.AreEqual(Some(979, 366, 675), result)

        let (a, b, c) = result.Value
        Assert.AreEqual(241861950, a * b * c)
