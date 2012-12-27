Public Class Form1
    Dim file As System.IO.File
    Dim fileReader As String
    Dim reader As System.IO.StreamReader
    Dim launchversion As String
    Dim line As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory + "\DSfix.ini") = False Then
            MsgBox("Dark Souls not found! Please move this file to your Dark Souls\Data folder (along with Dark souls.exe)")
            If (MsgBoxResult.Ok) Then
                Me.Close()
            End If
        Else
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory + "\DSfix.ini")
            'If (My.Settings.defaultsettingscollected = False) Then
            'TextBox11.Text = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory + "\DSfix.ini")
            'My.Settings.defaultsettingscollected = True
            ' My.Settings.defaultsettings = TextBox11.Text
            'End If

            ComboBox1.Text = My.Settings.Resolution
            ComboBox2.Text = My.Settings.AAQ
            ComboBox3.Text = My.Settings.AAT
            ComboBox4.Text = My.Settings.ssaoStrength
            ComboBox5.Text = My.Settings.ssaoScale
            ComboBox6.Text = My.Settings.ssaoType
            ComboBox7.Text = My.Settings.dofOverrideResolution
            ComboBox8.Text = My.Settings.disableDofScaling
            ComboBox9.Text = My.Settings.dofBlurAmount
            ComboBox10.Text = My.Settings.unlockFPS
            ComboBox11.Text = My.Settings.filteringOverride
            TextBox2.Text = My.Settings.FPSLimit
            ComboBox12.Text = My.Settings.enablehudmod
            ComboBox13.Text = My.Settings.enableMinimalHud
            TrackBar1.Value = My.Settings.hudScaleFactor
            TrackBar2.Value = My.Settings.hudTopLeftOpacity
            TrackBar3.Value = My.Settings.hudBottomLeftOpacity
            TrackBar4.Value = My.Settings.hudBottomRightOpacity
            TextBox3.Text = TrackBar1.Value * 0.01
            TextBox4.Text = TrackBar2.Value * 0.01
            TextBox5.Text = TrackBar3.Value * 0.01
            TextBox6.Text = TrackBar4.Value * 0.01
            ComboBox14.Text = My.Settings.borderlessFullscreen
            ComboBox15.Text = My.Settings.disableCursor
            ComboBox16.Text = My.Settings.captureCursor
            ComboBox17.Text = My.Settings.vsync
            ComboBox18.Text = My.Settings.enableBackups
            TextBox7.Text = My.Settings.backupInterval
            TextBox8.Text = My.Settings.maxBackups
            ComboBox19.Text = My.Settings.Language
            TextBox10.Text = My.Settings.FPSthreshold
            TextBox9.Text = My.Settings.screenshotdir
            If (My.Settings.advanced = True) Then
                Panel1.Visible = True
                CheckBox1.Checked = True

            Else
                Panel1.Visible = False
                CheckBox1.Checked = False
            End If
            If (My.Settings.enablehudmod = 1) Then
                Panel2.Visible = True
            Else
                Panel2.Visible = False
            End If
            If (My.Settings.enableBackups = 1) Then
                Panel3.Visible = True
            Else
                Panel3.Visible = False
            End If
        End If
        If (My.Settings.Skipintro = 1) Then
            CheckBox2.Checked = True
        ElseIf (My.Settings.Skipintro = 0) Then
            CheckBox2.Checked = False
        End If
        If (My.Settings.textureoverride = 1) Then
            CheckBox3.Checked = True
        ElseIf (My.Settings.textureoverride = 0) Then
            CheckBox3.Checked = False
        End If
        If (My.Settings.texturedumping = 1) Then
            CheckBox4.Checked = True
        ElseIf (My.Settings.texturedumping = 0) Then
            CheckBox4.Checked = False
        End If


    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ressplit As String() = ComboBox1.Text.Split("x")
        Dim width As String = ressplit(0)
        Dim height As String = ressplit(1)
        Dim lines() As String = TextBox1.Lines
        Dim langsplit As String() = ComboBox19.Text.Split(" ")
        Dim codelang As String = langsplit(0)
        Dim descriptlang As String = langsplit(1)
        lines(6) = "renderWidth " + width
        lines(7) = "renderHeight " + height
        lines(23) = "aaQuality " + ComboBox2.Text
        lines(27) = "aaType " + ComboBox3.Text
        lines(36) = "ssaoStrength " + ComboBox4.Text
        lines(42) = "ssaoScale " + ComboBox5.Text
        lines(50) = "ssaoType " + ComboBox6.Text
        lines(62) = "dofOverrideResolution " + ComboBox7.Text
        lines(67) = "disableDofScaling " + ComboBox8.Text
        lines(76) = "dofBlurAmount " + ComboBox9.Text
        lines(89) = "unlockFPS " + ComboBox10.Text
        lines(107) = "filteringOverride " + ComboBox11.Text
        lines(93) = "FPSlimit " + TextBox2.Text
        lines(116) = "enableHudMod " + ComboBox12.Text
        lines(120) = "enableMinimalHud " + ComboBox13.Text
        lines(125) = "hudScaleFactor " + TextBox3.Text
        lines(131) = "hudTopLeftOpacity " + TextBox4.Text + "f"
        lines(133) = "hudBottomLeftOpacity " + TextBox5.Text + "f"
        lines(135) = "hudBottomRightOpacity " + TextBox6.Text + "f"
        lines(145) = "borderlessFullscreen " + ComboBox14.Text
        lines(150) = "disableCursor " + ComboBox15.Text
        lines(156) = "captureCursor " + ComboBox16.Text
        lines(238) = "enableVsync " + ComboBox17.Text
        lines(166) = "enableBackups " + ComboBox18.Text
        lines(170) = "backupInterval " + TextBox7.Text
        lines(173) = "maxBackups " + TextBox8.Text
        lines(209) = "overrideLanguage " + codelang
        lines(98) = "FPSthreshold " + TextBox10.Text
        lines(196) = "skipIntro " + My.Settings.Skipintro
        lines(202) = "screenshotDir " + TextBox9.Text
        lines(187) = "enableTextureOverride " + My.Settings.textureoverride
        lines(182) = "enableTextureDumping " + My.Settings.texturedumping
        TextBox1.Text = Join(lines, vbCrLf)
        My.Settings.Resolution = ComboBox1.Text
        My.Settings.Language = ComboBox19.Text
        My.Settings.AAQ = ComboBox2.Text
        My.Settings.AAT = ComboBox3.Text
        My.Settings.ssaoStrength = ComboBox4.Text
        My.Settings.ssaoScale = ComboBox5.Text
        My.Settings.ssaoType = ComboBox6.Text
        My.Settings.dofOverrideResolution = ComboBox7.Text
        My.Settings.disableDofScaling = ComboBox8.Text
        My.Settings.dofBlurAmount = ComboBox9.Text
        My.Settings.unlockFPS = ComboBox10.Text
        My.Settings.filteringOverride = ComboBox11.Text
        My.Settings.enablehudmod = ComboBox12.Text
        My.Settings.FPSLimit = TextBox2.Text
        My.Settings.hudScaleFactor = TextBox3.Text
        My.Settings.hudTopLeftOpacity = TextBox4.Text
        My.Settings.hudBottomLeftOpacity = TextBox5.Text
        My.Settings.hudBottomRightOpacity = TextBox6.Text
        My.Settings.enableMinimalHud = ComboBox13.Text
        My.Settings.borderlessFullscreen = ComboBox14.Text
        My.Settings.disableCursor = ComboBox15.Text
        My.Settings.captureCursor = ComboBox16.Text
        My.Settings.vsync = ComboBox17.Text
        My.Settings.enableBackups = ComboBox18.Text
        My.Settings.backupInterval = TextBox7.Text
        My.Settings.maxBackups = TextBox8.Text
        My.Settings.Language = ComboBox19.Text
        My.Settings.FPSthreshold = TextBox10.Text
        My.Settings.screenshotdir = TextBox9.Text
        My.Settings.hudScaleFactor = TrackBar1.Value
        My.Settings.hudTopLeftOpacity = TrackBar2.Value
        My.Settings.hudBottomLeftOpacity = TrackBar3.Value
        My.Settings.hudBottomRightOpacity = TrackBar4.Value
        If (CheckBox1.Checked = True) Then
            My.Settings.advanced = True
            TextBox1.ReadOnly = False
        Else
            My.Settings.advanced = False
            My.Settings.FPSLimit = "0"
            TextBox1.ReadOnly = True
        End If
        My.Settings.Save()
        My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.CurrentDirectory + "\DSfix.ini", TextBox1.Text, False)

    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked = True) Then
            MsgBox("Enabling the following advanced options could risk your GFWL account for a BAN or cause game instablity!", MsgBoxStyle.OkOnly, "WARNING!")

        Else

        End If

        If (Panel1.Visible = False) Then
            Panel1.Visible = True
            TextBox1.Visible = True
        Else
            Panel1.Visible = False
            ComboBox10.Text = "0"
            TextBox1.Visible = False
        End If

    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox10.SelectedIndexChanged
        If (ComboBox10.Text = "1") Then
            TextBox2.Enabled = True
        Else
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        TextBox3.Text = TrackBar1.Value * 0.01
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        TextBox4.Text = TrackBar2.Value * 0.01
    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        TextBox5.Text = TrackBar3.Value * 0.01
    End Sub

    Private Sub TrackBar4_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar4.Scroll
        TextBox6.Text = TrackBar4.Value * 0.01
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox12.SelectedIndexChanged
        If (ComboBox12.Text = 1) Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If
    End Sub

    Private Sub ComboBox18_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox18.SelectedIndexChanged
        If (ComboBox18.Text = 1) Then
            Panel3.Visible = True
        Else
            Panel3.Visible = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If (CheckBox2.Checked = True) Then
            My.Settings.Skipintro = 1
        Else
            My.Settings.Skipintro = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        launchversion = My.Settings.LaunchGameVersion
        Process.Start(launchversion)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If (RadioButton1.Checked = True) Then
            My.Settings.LaunchGameVersion = "steam://rungameid/211420"
        End If
        My.Settings.Save()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If (RadioButton2.Checked = True) Then
            If (My.Settings.rememberretaillocation = False) Then
                Dim fd As OpenFileDialog = New OpenFileDialog()
                fd.Title = "Open File Dialog"
                fd.InitialDirectory = "C:\"
                fd.RestoreDirectory = True
                If fd.ShowDialog() = DialogResult.OK Then
                    My.Settings.retaillocation = fd.FileName
                    My.Settings.rememberretaillocation = True

                End If
            End If
        Else
            My.Settings.LaunchGameVersion = My.Settings.retaillocation

        End If
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Process.Start("http://blog.metaclassofnil.com/?tag=dsfix")
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If (CheckBox3.Checked = True) Then
            My.Settings.textureoverride = 1
        ElseIf (CheckBox3.Checked = False) Then
            My.Settings.textureoverride = 0
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If (CheckBox4.Checked = True) Then
            My.Settings.texturedumping = 1
        ElseIf (CheckBox4.Checked = False) Then
            My.Settings.texturedumping = 0
        End If
    End Sub
End Class
