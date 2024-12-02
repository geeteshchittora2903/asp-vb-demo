Module Calculator
    Sub Main()
        Dim num1 As Double
        Dim num2 As Double
        Dim result As Double
        Dim operation As String

        ' User input for two numbers
        Console.WriteLine("Enter the first number:")
        num1 = Convert.ToDouble(Console.ReadLine())

        Console.WriteLine("Enter the second number:")
        num2 = Convert.ToDouble(Console.ReadLine())

        ' User input for the operation
        Console.WriteLine("Enter the operation (+, -, *, /):")
        operation = Console.ReadLine()

        ' Perform the operation
        Select Case operation
            Case "+"
                result = num1 + num2
            Case "-"
                result = num1 - num2
            Case "*"
                result = num1 * num2
            Case "/"
                If num2 <> 0 Then
                    result = num1 / num2
                Else
                    Console.WriteLine("Cannot divide by zero.")
                    Exit Sub
                End If
            Case Else
                Console.WriteLine("Invalid operation.")
                Exit Sub
        End Select

        ' Display the result
        Console.WriteLine("The result is: " & result)
        Console.ReadKey()
    End Sub
End Module
