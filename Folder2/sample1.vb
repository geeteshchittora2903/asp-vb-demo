Module Program
    Function Factorial(n As Integer) As Integer
        If n = 0 Then
            Return 1
        Else
            Return n * Factorial(n - 1)
        End If
    End Function

    Sub Main()
        Dim num As Integer

        ' User input for the number
        Console.WriteLine("Enter a number to find its factorial:")
        num = Convert.ToInt32(Console.ReadLine())

        ' Call the factorial function and display the result
        Console.WriteLine("The factorial of " & num & " is: " & Factorial(num))
        Console.ReadKey()
    End Sub
End Module
