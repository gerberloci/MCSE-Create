Imports System.Net.Sockets

Public Class SecondSteps
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As String
    Dim npcs As String
    Dim whitelist As String
    Dim animals As String
    Dim online As String
    Dim pvp As String
    Dim ipadd As String
    Dim ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList(0).ToString()
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

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If CheckBox1.Checked = True Then
            PictureBox1.Image = My.Resources.check_off_raw
            CheckBox1.Checked = False
        Else
            PictureBox1.Image = My.Resources.check_on_raw
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox2.Text = ip
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("Shownig help for: 'Online Mode':" & vbNewLine & "When put to true, the server will authenticate UUIDs (Premium Server)." & vbNewLine & "When put to false, the server will not authenticate UUIDs (Cracked Server).")
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        If CheckBox5.Checked = True Then
            PictureBox5.Image = My.Resources.check_off_raw
            CheckBox5.Checked = False
        Else
            PictureBox5.Image = My.Resources.check_on_raw
            CheckBox5.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = False Then
            npcs = "spawn-npcs=false"
        Else
            npcs = "spawn-npcs=true"
        End If
        If CheckBox2.Checked = False Then
            whitelist = "white-list=false"
        Else
            whitelist = "white-list=true"
        End If
        If CheckBox3.Checked = False Then
            animals = "spawn-animals=false"
        Else
            animals = "spawn-animals=true"
        End If
        If CheckBox4.Checked = False Then
            online = "online-mode=false"
        Else
            online = "online-mode=true"
        End If
        If CheckBox5.Checked = False Then
            pvp = "pvp=false"
        Else
            pvp = "pvp=true"
        End If
        Dim props = "C:/temp_server/server.properties"
        Dim writer As New System.IO.StreamWriter(props, True)
        writer.WriteLine("level-seed=" & TextBox1.Text)
        writer.WriteLine("server-ip=" & TextBox2.Text)
        writer.WriteLine("max-build-height=256")
        writer.WriteLine(npcs)
        writer.WriteLine(whitelist)
        writer.WriteLine(animals)
        writer.WriteLine("hardcore=false")
        writer.WriteLine("snooper-enabled=true")
        writer.WriteLine(online)
        writer.WriteLine("resource-pack=")
        writer.WriteLine(pvp)
        writer.Close()
        Dim verWriter As New System.IO.StreamWriter("C:/temp_server/ip.txt", False)
        verWriter.Write(TextBox2.Text)
        verWriter.Close()
        ThirdSteps.Show()
        Me.Close()
    End Sub
End Class