Public Class Form2

    Private frm1 As Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("密码不能为空！")
        ElseIf TextBox1.Text = "APMASCOT" Then
            frm1 = Me.Owner
            frm1.AdminMode = True
            frm1.ActiveAdminModeToolStripMenuItem.Enabled = False
            frm1.AdminModeActivatedToolStripMenuItem.Enabled = True
            frm1.InsertHisDataToolStripMenuItem.Enabled = True
            frm1.InsertRTDataToolStripMenuItem.Enabled = True
            frm1.InsertBoundariesDataToolStripMenuItem.Enabled = True
            frm1.InsertManageDataToolStripMenuItem.Enabled = True
            Me.Close()
        Else
            MsgBox("密码错误！")
        End If
    End Sub

    Private Sub Form2_KeyDown(ByVal sender As Object, ByVal ke As KeyEventArgs) Handles MyBase.KeyDown
        If ke.KeyCode = Keys.Enter Then
            Button1_Click(sender, ke)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class