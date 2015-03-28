Imports System.IO

Public Class Form1
    Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
    Dim rdm As New Random()
    Public tempDir = "temp_server"
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    'argument 1 - version
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        drag = False
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CommandLineArgs.Any = False Then
            Me.Close()
        End If
        If Not CommandLineArgs.ElementAt(0) = "-MCSE_AUTHORIZE" Then
            Me.Close()
        End If
        If My.Computer.FileSystem.DirectoryExists("C:/temp-server/") Then
            My.Computer.FileSystem.DeleteDirectory("C:/temp_server/", Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory("C:/temp_server/")
        Label2.Text = "Creating a " & CommandLineArgs.ElementAt(1) & " server."
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tempVerPath = "C:/temp_server/version.temp"
        Dim verWriter As New System.IO.StreamWriter(tempVerPath, False)
        verWriter.Write(CommandLineArgs.ElementAt(1))
        verWriter.Close()
        Dim tempInfPath = "C:/temp_server/mcse.txt"
        Dim infWriter As New System.IO.StreamWriter(tempInfPath, False)
        infWriter.Close()
        FirstSteps.Show()
        Me.Close()
    End Sub
End Class
