Module Program
    Sub Main()
        Dim numbers() As Integer = {5, 10, 20, 35, 7, 3}
        Dim maxNumber As Integer = numbers(0)

        ' Loop through the array to find the largest number
        For Each num As Integer In numbers
            If num > maxNumber Then
                maxNumber = num
            End If
        Next

        ' Display the largest number
        Console.WriteLine("The largest number is: " & maxNumber)
        Console.ReadKey()
    End Sub
End Module
