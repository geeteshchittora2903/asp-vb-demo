Module Program
    Sub Main()
        Dim age As Integer

        ' User input for age
        Console.WriteLine("Enter your age:")
        age = Convert.ToInt32(Console.ReadLine())

        ' Check if the user is eligible to vote
        If age >= 18 Then
            Console.WriteLine("You are eligible to vote!")
        Else
            Console.WriteLine("You are not eligible to vote.")
        End If

        Console.ReadKey()
    End Sub
End Module
