' Programmer:     Ty Vanderley
' Due Date:       4/29/2015
' Course:         CIS 3680-101 Spring 2015
' Description:    Project 2 Jim's Classic Car application. 
'                 This is the login form for the application.

Public Class LoginForm

    ' 2D array of usernames and passwords
    Private strLogin(,) As String = {
                                        {"cardealer1", "yesideal"},
                                        {"theboss", "imtheboss"},
                                        {"ty", "thatsmyname"},
                                        {"john", "thatsyourname"},
                                        {"easylogin", "123"},
                                        {"login", "abc"},
                                        {"difficult", "12345abcdef"}
                                    }

    ' The number of times the user attempts to login initialized to a value of 0
    Private intLoginAttempts As Integer = 0


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Create a variable to act as a subscript to loop through array
        Dim intSubscript As Integer

        ' Loop through the array of valid logins
        For intSubscript = 0 To strLogin.GetLength(0) - 1

            ' Compare this login with the login credentials the user entered
            If strLogin(intSubscript, 0) = txtUsername.Text _
            And strLogin(intSubscript, 1) = txtPassword.Text Then

                ' The user entered correct login credentials, so we show the InventoryListForm.
                Dim frmInventoryList As New InventoryListForm
                frmInventoryList.Show()

                ' Close the login form
                Me.Close()
                Exit Sub
            End If
        Next

        ' Keep track of login attemps
        intLoginAttempts += 1

        ' Keep track of remaining attempts
        Dim intRemainingAttempts As Integer
        intRemainingAttempts = 3 - intLoginAttempts

        ' Message if login attempt was failed
        MessageBox.Show("Inproper login credentials entered. " & intRemainingAttempts & " attemps remaining")

        ' If login fails three times, close the form
        If intLoginAttempts >= 3 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Close the form
        Me.Close()
    End Sub
End Class