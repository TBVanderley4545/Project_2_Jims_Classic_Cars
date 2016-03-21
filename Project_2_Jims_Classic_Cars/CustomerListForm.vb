' Programmer:     Ty Vanderley
' Due Date:       4/29/2015
' Course:         CIS 3680-101 Spring 2015
' Description:    Project 2 Jim's Classic Car application. 
'                 This is the Customer List form for the application.

Public Class CustomerListForm

    Private Sub CustomerListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CustomerDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.CustomerDataSet.Customers)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Saves the data into the database
        Me.CustomersTableAdapter.Update(CustomerDataSet.Customers)

        ' Display a message to the user that their changes have been saved
        MessageBox.Show("Your changes have been saved.")
    End Sub
End Class