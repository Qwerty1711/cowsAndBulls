Module Module1
    Function random(min, max)
        Randomize()
        Return Int(((max - (min - 1)) * Rnd()) + min)
    End Function

    Dim num, guess As String
    Dim guesses As New List(Of String)
    Dim cows, bulls As Integer

    Sub createNum()
        Dim x As String
        num = random(1, 9).ToString
        For i = 1 To 3
            x = random(0, 9).ToString
            Do While num.Contains(x)
                x = random(0, 9).ToString
            Loop
            num &= x
        Next
        num.Remove(0)
    End Sub

    Sub countCows()
        cows = 0
        bulls = 0
        For i = 0 To 3
            For j = 0 To 3
                If num(i) = guess(j) Then
                    cows += 1
                End If
            Next
            If num(i) = guess(i) Then
                bulls += 1
            End If
        Next
        'cows -= bulls
    End Sub

    Sub input()
        Dim guessValid As Boolean = False
        Dim n As Integer
        Do Until guessValid
            Console.WriteLine("input guess")
            guess = Console.ReadLine()
            If Len(guess) = 4 Then 'checks if is right length
                guessValid = True
            End If
            For i = 0 To 3 'checks if all characters are valid
                Select Case guess(i)
                    Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    Case Else
                        guessValid = False
                End Select
            Next
            If guessValid Then
                If guess(0) = "0" Then ' checks if start is 0
                    guessValid = False
                End If
                For i = 0 To 9 'checks for repeating chars
                    n = 0
                    For j = 0 To 3
                        If Int(guess(j).ToString) = i Then
                            n += 1
                        End If
                    Next
                    If n > 1 Then
                        guessValid = False
                    End If
                Next
            End If

            If Not guessValid Then
                Console.WriteLine("invalid input try again")
            End If
        Loop
        countCows()
        guesses.Add(guess & cows.ToString & bulls.ToString)

    End Sub

    Sub displayGuesses()
        If guesses.Count <> 0 Then
            Console.WriteLine("cows|guess|bulls")
            For Each item In guesses
                Console.WriteLine(item(4) & "|" & item(0) & item(1) & item(2) & item(3) & "|" & item(5))
            Next
            Console.WriteLine()
        End If

    End Sub
    Sub Main()
        Dim play As Boolean = True
        Dim playValid As Boolean = False
        While play
            guesses.Clear()
            createNum()
            Do Until bulls = 4
                displayGuesses()
                input()
                Console.Clear()
            Loop
            Console.WriteLine(guesses.Count & " guesses")
            Console.WriteLine()
            Do Until playValid
                Console.WriteLine("play again?(Y/N)")
                Select Case Console.ReadLine
                    Case "Y"
                        play = True
                        playValid = True
                    Case "N"
                        play = False
                        playValid = True
                    Case Else
                        Console.WriteLine("invalid input try again")
                End Select
            Loop
        End While
    End Sub

End Module
