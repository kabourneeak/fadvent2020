namespace AdventTests.Days.Day1

module Part2Tests =

    open NUnit.Framework
    open Days.Day1

    [<SetUp>]
    let Setup () = ()

    [<Test>]
    let Test1 () =
        let (a, b, c) = findExpenseTriplet 2020 [1721; 979; 366; 299; 675; 1456]
        Assert.AreEqual(979,a)
        Assert.AreEqual(366, b)
        Assert.AreEqual(675, c)
