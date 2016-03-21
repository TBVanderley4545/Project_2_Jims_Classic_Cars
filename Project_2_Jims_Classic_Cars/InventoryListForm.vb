' Programmer:     Ty Vanderley
' Due Date:       4/29/2015
' Course:         CIS 3680-101 Spring 2015
' Description:    Project 2 Jim's Classic Car application. 
'                 This is the Inventory List form for the application.

Imports System.IO

Public Class InventoryListForm

    ' Use a Try Catch to catch an exception if the file can't be found
    Private Sub InventoryListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Have cboInventory read all lines from the text file. 
            ' The ReadAllLines method opens the file, 
            ' reads all lines, and then closes the file
            cboInventory.Items.AddRange(File.ReadAllLines("CarInventory.txt"))
        Catch ex As Exception
            ' Notify the user that the text file can't be found
            MessageBox.Show("Can't find the file.")
        End Try
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ' Create a String Variable to hold the user's input into the combo box
        Dim strUserInput As String
        strUserInput = cboInventory.Text

        ' This if else statement checks for if the user entered input is already
        ' in the combo box.
        If Not cboInventory.Items.Contains(strUserInput) Then
            ' Add typed item into the combo box if it is not a duplicate
            cboInventory.Items.Add(strUserInput)
        Else
            ' Display Message to user that the item is already in the inventory
            MessageBox.Show(strUserInput & " is already in the inventory.")
        End If


        ' Clear the input box
        cboInventory.Text = String.Empty
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        ' Remove the selected item from the combo box
        cboInventory.Items.RemoveAt(cboInventory.SelectedIndex)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Create a StreamWriter Object Variable
        Dim outputFile As StreamWriter

        ' Recreate the file so that we can overwrite it with new data
        outputFile = File.CreateText("CarInventory.txt")

        ' Use a For Each loop to loop through the cboInventory's items
        ' and write the selected line to the file
        For Each item As String In cboInventory.Items
            outputFile.WriteLine(item)
        Next

        ' Close the file
        outputFile.Close()

        ' Notify the users that the changes have been saved.
        MessageBox.Show("Your changes to the inventory have been saved.")
    End Sub

    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        ' Close the form
        Me.Close()
    End Sub

    Private Sub mnuViewCustomers_Click(sender As Object, e As EventArgs) Handles mnuViewCustomers.Click
        ' Create an instance of the CustomerListForm
        Dim frmCustomerList As New CustomerListForm

        ' Dispay the form modally
        frmCustomerList.ShowDialog()
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click

        ' Create an instance of the AboutForm and display it modally
        Dim frmAbout As New AboutForm
        frmAbout.ShowDialog()
    End Sub
End Class

