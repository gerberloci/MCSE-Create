Public Class FirstSteps
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim nether As String
    Dim query As String
    Dim flight As String
    Dim achivement As String
    Dim level As String
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

    Private Sub FirstSteps_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'My.Computer.FileSystem.DeleteDirectory("C:/temp_server/", FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub
    Private Sub FirstSteps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tempPropertiesPath = "C:/temp_server/server.properties"
        Dim propWriter As New System.IO.StreamWriter(tempPropertiesPath, True)
        propWriter.WriteLine("#MCSE Server properties")
        propWriter.WriteLine("#Created using MCSE Beta.")
        propWriter.Close()
        Dim props = "C:/temp_server/server.properties"
        Dim props2 As New System.IO.StreamWriter(props, True)
        props2.WriteLine("generator-settings=")
        props2.WriteLine("op-permission-level=4")
        props2.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If CheckBox1.Checked = True Then
            PictureBox1.Image = My.Resources.check_off_raw
            CheckBox1.Checked = False
        Else
            PictureBox1.Image = My.Resources.check_on_raw
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If CheckBox2.Checked = True Then
            PictureBox2.Image = My.Resources.check_off_raw
            CheckBox2.Checked = False
        Else
            PictureBox2.Image = My.Resources.check_on_raw
            CheckBox2.Checked = True
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If CheckBox3.Checked = True Then
            PictureBox3.Image = My.Resources.check_off_raw
            CheckBox3.Checked = False
        Else
            PictureBox3.Image = My.Resources.check_on_raw
            CheckBox3.Checked = True
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If CheckBox4.Checked = True Then
            PictureBox4.Image = My.Resources.check_off_raw
            CheckBox4.Checked = False
        Else
            PictureBox4.Image = My.Resources.check_on_raw
            CheckBox4.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = False Then
            nether = "allow-nether=false"
        Else
            nether = "allow-nether=true"
        End If
        If CheckBox2.Checked = False Then
            query = "enable-query=false"
        Else
            query = "enable-query=true"
        End If
        If CheckBox3.Checked = False Then
            flight = "allow-flight=false"
        Else
            flight = "allow-flight=true"
        End If
        If CheckBox4.Checked = False Then
            achivement = "announce-player-achievements=false"
        Else
            achivement = "announce-player-achievements=true"
        End If
        If ListBox1.SelectedItem = "Default" Then
            level = "level-type=DEFAULT"
        ElseIf ListBox1.SelectedItem = "Superflat" Then
            level = "level-type=FLAT"
        Else
            level = "level-type=DEFAULT"
        End If
        Dim propPath = "C:/temp_server/server.properties"
        Dim writer As New System.IO.StreamWriter(propPath, True)
        writer.WriteLine(nether)
        writer.WriteLine("level-name=" & TextBox1.Text)
        writer.WriteLine(query)
        writer.WriteLine(flight)
        writer.WriteLine(achivement)
        writer.WriteLine("server-port=25565")
        writer.WriteLine(level)
        writer.WriteLine("enable-rcon=false")
        writer.WriteLine("force-gamemode=false")
        writer.Close()
        SecondSteps.Show()
        Me.Close()
    End Sub
End Class