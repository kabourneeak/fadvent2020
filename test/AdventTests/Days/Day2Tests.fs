namespace AdventTests.Days.Day2

module Day2Tests =

    open NUnit.Framework
    open FsUnit
    open Days.Day2

    [<SetUp>]
    let Setup () = ()
    
    [<Test>]
    let ``matchesPasswordCountPolicy should determine valid password`` () =
        // arrange
        let example1 = {
            Min = 1
            Max = 3
            Char = 'a'
            Password = "abcde"
        }

        let example2 = {
            Min = 2
            Max = 9
            Char = 'c'
            Password = "ccccccccc"
        }

        // act
        // assert
        matchesPasswordCountPolicy example1 |> should equal true
        matchesPasswordCountPolicy example2 |> should equal true

    [<Test>]
    let ``matchesPasswordCountPolicy should determine invalid password`` () =
        // arrange
        let example1 = {
            Min = 1
            Max = 3
            Char = 'b'
            Password = "cdefg"
        }

        // act
        // assert
        matchesPasswordCountPolicy example1 |> should equal false

    [<Test>]
    let ``stringToPasswordModel should create model`` () =
        // arrange
        let s = "1-3 a: abcde"

        // act
        let result = stringToPasswordModel s

        // assert
        result |> should equal {
            Min = 1
            Max = 3
            Char = 'a'
            Password = "abcde"
        }

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