namespace AdventTests.Days.Day2

module Part2Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day2

    [<SetUp>]
    let Setup () = ()
    
    [<Test>]
    let ``matchesPasswordPositionPolicy should determine valid password`` () =
        // arrange
        let example1 = {
            Min = 1
            Max = 3
            Char = 'a'
            Password = "abcde"
        }

        // act
        // assert
        matchesPasswordPositionPolicy example1 |> should equal true

    [<Test>]
    let ``matchesPasswordPositionPolicy should determine invalid password`` () =
        // arrange
        let example1 = {
            Min = 1
            Max = 3
            Char = 'b'
            Password = "cdefg"
        }

        let example2 = {
            Min = 2
            Max = 9
            Char = 'c'
            Password = "ccccccccc"
        }

        // act
        // assert
        matchesPasswordPositionPolicy example1 |> should equal false
        matchesPasswordPositionPolicy example2 |> should equal false
