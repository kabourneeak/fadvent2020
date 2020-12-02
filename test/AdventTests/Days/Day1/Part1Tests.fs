namespace AdventTests.Days.Day1

module Part1Tests =

    open NUnit.Framework
    open Days.Day1

    [<SetUp>]
    let Setup () = ()

    [<Test>]
    let Test1 () =
        let ep = findExpense [1721; 979; 366; 299; 675; 1456]
        Assert.AreEqual(1721, ep.Left)
        Assert.AreEqual(299, ep.Right)
