Imports System.IO

Public Class SetUp
    Dim ServerFolder As String
    Dim path As String
    Private Sub SetUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        path = "C:/MCSE/" & ServerFolder & "/"
        Try
            File.Copy("C:/temp_server/mcse.txt", "C:/temp_server/mcse_2.txt", True)
            ServerFolder = (ReadALine("C:/temp_server/mcse_2.txt", GetNumberOfLines("C:/temp_server/mcse_2.txt"), 0))
            My.Computer.FileSystem.CreateDirectory("C:/MCSE/" & ServerFolder & "/")
            File.Move("C:/temp_server/server.properties", "C:/MCSE/" & ServerFolder & "/server.properties")
            File.Move("C:/temp_server/mcse.txt", "C:/MCSE/" & ServerFolder & "/mcse.txt")
            My.Computer.FileSystem.DeleteDirectory("C:/temp_server", Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception

        End Try
        If My.Application.CommandLineArgs.ElementAt(1) = "1.6.4" Then
            File.Copy("C:/MCSEJars/16.jar", "C:/MCSE/" & ServerFolder & "/server.jar", True)
        ElseIf My.Application.CommandLineArgs.ElementAt(1) = "1.7.2" Then
            File.Copy("C:/MCSEJars/17.jar", "C:/MCSE/" & ServerFolder & "/server.jar", True)
        Else
            File.Copy("C:/MCSEJars/18.jar", "C:/MCSE/" & ServerFolder & "/server.jar", True)
        End If
        Dim srvpath = "C:/MCSE/" & ServerFolder & "/start.bat"
        Dim verWriter As New System.IO.StreamWriter(srvpath, True)
        verWriter.WriteLine("@echo off")
        verWriter.WriteLine("cd " & "C:/MCSE/" & ServerFolder & "/")
        verWriter.WriteLine("java -Xmx1024M -Xms1024M -jar server.jar")
        verWriter.WriteLine("pause >NUL")
        verWriter.Close()
        Dim conf = "C:/MCSE/" & ServerFolder & ".txt"
        Dim write As New System.IO.StreamWriter(conf, True)
        write.WriteLine("C:/MCSE/" & ServerFolder & "/start.bat")
        write.WriteLine("C:/MCSE/" & ServerFolder & "/mcse.txt")
        write.Close()
        System.Diagnostics.Process.Start("console.exe", "-MCSE_AUTHORIZE C:/MCSE/" & ServerFolder & "/start.bat C:/MCSE/" & ServerFolder & "/mcse.txt")
        Me.Close()
    End Sub
    Public Function ReadALine(ByVal File_Path As String, ByVal TotalLine As Integer, ByVal Line2Read As Integer) As String
        Dim Buffer As Array
        Dim Line As String
        If TotalLine <= Line2Read Then
            Return "Must be filled by Owner"
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