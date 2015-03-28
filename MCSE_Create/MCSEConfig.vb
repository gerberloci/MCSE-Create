Imports System.IO

Public Class MCSEConfig
    Dim ip As String
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
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
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim mcse2 = "C:/temp_server/ip.txt"
        ip = (ReadALine(mcse2, GetNumberOfLines(mcse2), 0))
        Dim mcse = "C:/temp_server/mcse.txt"
        Dim verWriter As New System.IO.StreamWriter(mcse, True)
        verWriter.WriteLine(TextBox1.Text)
        verWriter.WriteLine(ip)
        verWriter.WriteLine(My.Application.CommandLineArgs.ElementAt(1))
        verWriter.WriteLine(TextBox2.Text)
        verWriter.Close()
        Dim servers = "C:/MCSE/server.txt"
        Dim write As New System.IO.StreamWriter(servers, True)
        write.WriteLine(TextBox1.Text)
        write.Close()
        SetUp.Show()
        Me.Close()
    End Sub
    Public Function ReadALine(ByVal File_Path As String, ByVal TotalLine As Integer, ByVal Line2Read As Integer) As String
        Dim Buffer As Array
        Dim Line As String
        If TotalLine <= Line2Read Then
            Return "No Such Line"
        End If
        Buffer = File.ReadAllLines(File_Path)
        Line = Buffer(Line2Read)
        Return Line
    End Function
    Public Function GetNumberOfLines(ByVal file_path As String) As Integer
        Dim sr As New StreamReader(file_path)
        Dim NumberOfLines As Integer
        Do While sr.Peek >= 0
            sr.ReadLine()
            NumberOfLines += 1
        Loop
        Return NumberOfLines
        sr.Close()
        sr.Dispose()
    End Function
End Class