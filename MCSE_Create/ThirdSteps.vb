Public Class ThirdSteps
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim diff As String
    Dim cblock As String
    Dim gamem As String
    Dim monster As String
    Dim struct As String
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = TextBox2.Text & "\u00A7c"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox2.Text = TextBox2.Text & "\u00A71"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox2.Text = TextBox2.Text & "\u00A7a"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox2.Text = TextBox2.Text & "\u00A73"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox2.Text = TextBox2.Text & "\u00A77"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox2.Text = TextBox2.Text & "\u00A7e"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox2.Text = TextBox2.Text & "\u00A76"
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ListBox1.SelectedItem = "Peaceful" Then
            diff = "difficulty=0"
        ElseIf ListBox1.SelectedItem = "Easy" Then
            diff = "difficulty=1"
        ElseIf ListBox1.SelectedItem = "Normal" Then
            diff = "difficulty=2"
        Else
            diff = "difficulty=3"
        End If
        If CheckBox1.Checked = False Then
            cblock = "enable-command-block=false"
        Else
            cblock = "enable-command-block=false"
        End If

        If ListBox2.SelectedItem = "Survival" Then
            gamem = "gamemode=0"
        ElseIf ListBox2.SelectedItem = "Creative" Then
            gamem = "gamemode=1"
        ElseIf ListBox2.SelectedItem = "Adventure" Then
            gamem = "difficulty=2"
        Else
            gamem = "gamemode=1"
        End If
        If CheckBox2.Checked = False Then
            monster = "spawn-monsters=false"
        Else
            monster = "spawn-monsters=true"
        End If

        If CheckBox3.Checked = False Then
            struct = "generate-structures=false"
        Else
            struct = "generate-structures=true"
        End If
        Dim tempVerPath = "C:/temp_server/server.properties"
        Dim Writer As New System.IO.StreamWriter(tempVerPath, True)
        Writer.WriteLine(diff)
        Writer.WriteLine(cblock)
        Writer.WriteLine(gamem)
        Writer.WriteLine("player-idle-timeout=0")
        Writer.WriteLine("max-players=" & TextBox1.Text)
        Writer.WriteLine(monster)
        Writer.WriteLine(struct)
        Writer.WriteLine("view-distance=10")
        Writer.WriteLine("spawn-protection=16")
        Writer.WriteLine("motd=" & TextBox2.Text)
        Writer.Close()
        MCSEConfig.Show()
        Me.Close()
    End Sub
End Class