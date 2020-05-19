Public Class Form3
    Dim ConnStatus As Boolean
    Friend WithEvents DbCommOcxFC7 As AxDBCOMMOCXLibFC7.AxDbCommOcxFC7

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnStatus = False
    End Sub

    Public Sub SetDbCommOcxFC7(ByVal OcxFC7 As AxDBCOMMOCXLibFC7.AxDbCommOcxFC7)
        DbCommOcxFC7 = OcxFC7
    End Sub

    Private Sub SetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetRealDataButton.Click
        Dim RealData As Integer

        ConnStatus = DbCommOcxFC7.IsConnected
        If ConnStatus = True Then
            RealData = DbCommOcxFC7.SetData(TagNameBox.Text, RealDataBox.Text)
            If RealData = 0 Then
                MsgBox("请检查输入的两个参数是否正确!")
                Return
            End If
            TextResult.Text = "设置成功!" + Chr(13) + Chr(10) + TagNameBox.Text + " = " + RealDataBox.Text
        Else
            MsgBox("数据库未连接!")
        End If
    End Sub
End Class