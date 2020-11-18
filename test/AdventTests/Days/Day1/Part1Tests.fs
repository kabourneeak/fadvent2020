namespace AdventTests.Days.Day1

module Part1Tests =

    open NUnit.Framework
    open Days.Day1

    [<SetUp>]
    let Setup () = ()

    [<Test>]
    let Test1 () =
        let result = getRequiredFuel 12
        Assert.AreEqual(2, result)

    [<Test>]
    let Test2 () =
        let result = getRequiredFuel 14
        Assert.AreEqual(2, result)

    [<Test>]
    let Test3 () =
        let result = getRequiredFuel 1969
        Assert.AreEqual(654, result)

    [<Test>]
    let Test4 () =
        let result = getRequiredFuel 100756
        Assert.AreEqual(33583, result)
