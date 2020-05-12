Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Threading

Public Class Form1
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Dim bConn As Boolean
    Dim Excel As String
    Dim TextBoxMsg As String
    Dim BarThread As Thread

    Private Delegate Sub WriteExcel(ByVal HisDataList As List(Of List(Of String)), ByVal objImportSheet As Excel.Worksheet)


    'Button 选择文件
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            If IsFileReady(Excel) = False Then
                MsgBox("目标Excel文件被占用。")
                Exit Sub
            Else
                Excel = OpenFileDialog1.FileName 'Excel文件路径
                Try
                    System.Diagnostics.Process.Start(Excel)
                Catch ex As Exception
                    MsgBox("打开文件失败！")
                End Try
                TextBoxMsg = TextBoxMsg + "当前文件：" + Excel.ToString + Chr(13) + Chr(10)
                TextBox1.Text = TextBoxMsg
            End If
        End If
    End Sub

    Private Sub CreateTread4Bar()
        BarThread = New Thread(AddressOf ProgressStep)
        CheckForIllegalCrossThreadCalls = False
        BarThread.Start()
    End Sub
    Private Sub ProgressStep()
        ProgressBar1.Value = ProgressBar1.Value + 10
        BarThread.Abort()
    End Sub

    'Button 读取数据
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If bConn = True Then
            Dim StartTime As Date = Date.Now '记录程序开始时间
            If Excel = Nothing Or Excel = "" Then
                MsgBox("请先选择文件")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            '进度条推进
            CreateTread4Bar()
            If IsFileReady(Excel) = False Then
                MsgBox("目标Excel文件被占用")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            Dim objExcelFile As Excel.Application
            Dim objWorkBook As Excel.Workbook
            Dim objImportSheet As Excel.Worksheet
            '创建Excel进程, 并打开目标Excel文件
            objExcelFile = New Excel.Application
            objExcelFile.DisplayAlerts = False
            objExcelFile.Visible = False
            objWorkBook = objExcelFile.Workbooks.Open(Excel)
            objImportSheet = objWorkBook.Sheets(1) '取第1个工作表
            Dim LastColNum As Integer = objImportSheet.UsedRange.Columns.Count '最后有数据的列号
            Dim LastRowNum As Integer = objImportSheet.UsedRange.Rows.Count '最后有数据的行号
            '清空原有数据
            Dim Range = objImportSheet.Range(objImportSheet.Cells(2, 3), objImportSheet.Cells(LastRowNum, LastColNum))
            Range.ClearContents()
            '取出开始结束时间以及时间间隔
            Dim StartDate As Date = objImportSheet.Cells(2, 1).Value()
            Dim EndDate As Date = objImportSheet.Cells(4, 1).Value()
            Dim StartDateStamp As Integer = objImportSheet.Cells(2, 2).Value()
            Dim EndDateStamp As Integer = objImportSheet.Cells(4, 2).Value()
            Dim Interval As Double = objImportSheet.Cells(6, 1).Value()
            '计算目标查询数据数量
            Dim DataCount As Integer
            DataCount = 1 + (EndDateStamp - StartDateStamp) \ (Interval * 60)
            '生成时间列表
            For IntervalCount As Integer = 0 To DataCount - 1 Step 1
                objImportSheet.Cells(IntervalCount + 2, 3) = StartDate.AddMinutes(IntervalCount * Interval)
            Next
            '进度条推进
            CreateTread4Bar()
            '开始查询历史数据
            Dim HisDataList As New List(Of List(Of String))
            If LastColNum > 3 Then
                Try
                    '顺序取出Tag并根据Tag查询历史数据，将返回数据放入HisDataList中备用
                    For ColNum As Integer = 4 To LastColNum Step 1
                        Dim Tag As String
                        Dim HisData As New List(Of String)
                        Dim DescData As New List(Of String)
                        Tag = objImportSheet.Cells(1, ColNum).Value()
                        If Tag = Nothing Then
                            HisDataList.Add(HisData)
                            Continue For
                        End If
                        Tag = Trim(Tag)
                        Dim ifDesc As Boolean = InStr(Tag, "DESC") > 0
                        Select Case ifDesc
                            Case False
                                HisData = GetHisData(StartDate, EndDate, Tag, DataCount)
                                HisDataList.Add(HisData)
                            Case True
                                Dim Desc As String = GetCurrentData(Tag)
                                For k As Integer = 0 To DataCount - 1 Step 1
                                    DescData.Add(Desc)
                                Next
                                HisDataList.Add(DescData)
                        End Select
                    Next
                    '从HisDataList中顺序取出历史数据并写入Excel
                    '@i:列
                    '@j:行
                    For i As Integer = 0 To HisDataList.Count - 1 Step 1
                        If HisDataList.ElementAt(i).Count = 0 Then
                            Continue For
                        End If
                        Dim ColData As New List(Of String)
                        ColData = HisDataList.ElementAt(i)
                        For j As Integer = 0 To ColData.Count - 1 Step 1
                            objImportSheet.Cells(j + 2, i + 4) = ColData.ElementAt(j)
                        Next
                        '进度条推进
                        If ProgressBar1.Value + 80 / HisDataList.Count <= ProgressBar1.Maximum Then
                            ProgressBar1.Value = ProgressBar1.Value + 80 / HisDataList.Count
                            ProgressBar1.PerformStep()
                        End If
                    Next
                    If ProgressBar1.Value < ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Maximum
                        ProgressBar1.PerformStep()
                    End If
                    '关闭Excel进程并释放资源
                    objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
                    objExcelFile.Quit()
                    objWorkBook = Nothing
                    objImportSheet = Nothing
                    objExcelFile = Nothing
                    Dim EndTime As Date = Date.Now '记录程序结束时间
                    MsgBox("完成！" + Chr(10) + Chr(13) + StartTime.ToString + Chr(10) + Chr(13) + EndTime.ToString)
                    TextBoxMsg = TextBoxMsg + "文件：" + Excel.ToString + "写入完成" + Chr(13) + Chr(10)
                    TextBox1.Text = TextBoxMsg
                    Try
                        System.Diagnostics.Process.Start(Excel)
                    Catch ex As Exception
                        MsgBox("打开文件失败！")
                    End Try
                Catch ex As Exception
                    objExcelFile.ActiveWorkbook.Close(SaveChanges:=False)
                    objExcelFile.Quit()
                    MsgBox("出现未知错误" + ex.ToString)
                End Try
            Else
                objExcelFile.ActiveWorkbook.Close(SaveChanges:=False)
                objExcelFile.Quit()
                MsgBox("请填写Tag。")
            End If
        Else
            MsgBox("数据库未连接！")
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    'Button 远程连接
    Private Sub CmdRemotConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRemotConn.Click
        Dim nConnStatus As Integer
        Dim cLocal As String
        Dim cRemote As String
        nConnStatus = 0
        cLocal = ""
        cRemote = TxtIPAddress.Text
        If bConn = False Then
            nConnStatus = DbCommOcxFC7.OpenRemoteConnect(cRemote, CLng(TxtPort.Text), cLocal, 0)
            If nConnStatus > 0 Then
                Sleep(1000)
                bConn = DbCommOcxFC7.IsConnected()
                If bConn = True Then
                    ConnResult.Text = "Success!"
                Else
                    ConnResult.Text = "NoLink!"
                End If
            End If
        Else
        End If
    End Sub

    'Button 关闭连接
    Private Sub CmdDisconn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDisconn.Click
        If bConn = True Then
            DbCommOcxFC7.CloseConnect()
            bConn = False
            ConnResult.Text = "Disconnected!"
        Else
        End If
    End Sub

    '@StartDate 开始时间
    '@EndDate 结束时间
    '@Tag 数据点名
    '@DataCount 查询数据数量
    '查询历史数据
    Private Function GetHisData(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Tag As String, ByVal DataCount As Integer)
        Dim HisData As Object
        Dim DataCell As String
        Dim DataList As New List(Of String)
        '判断是否连接数据库
        bConn = DbCommOcxFC7.IsConnected()
        If bConn = True Then
            '调用力控接口查询历史数据
            HisData = DbCommOcxFC7.GetHisData(StartDate, EndDate, DataCount, Tag)
            If HisData Is Nothing Then
                MsgBox("请检查参数：" + Tag.ToString)
                TextBoxMsg = TextBoxMsg + "请检查参数：" + Tag.ToString + Chr(13) + Chr(10)
                Return DataList
            End If
            '取出查询到的历史数据
            For i = 0 To UBound(HisData, 1) Step 1
                DataCell = HisData(i).ToString
                DataList.Add(DataCell)
            Next
            Return DataList
        Else
            MsgBox("数据库未连接！")
            Return Nothing
        End If
    End Function

    '@Tag 数据点名
    '查询实时数据
    Private Function GetCurrentData(ByVal Tag As String)
        Dim GetData As Object
        '判断是否连接数据库
        bConn = DbCommOcxFC7.IsConnected
        If bConn = True Then
            GetData = DbCommOcxFC7.GetData(Tag)
            Return GetData(0).ToString()
            If GetData Is Nothing Then
                Return "  "
            End If
        Else
            MsgBox("数据库未连接！")
            Return "  "
        End If
    End Function

    '@filepath 文件路径
    '检查文件是否正在被使用
    Public Function IsFileReady(ByVal filepath As String) As Boolean
        If File.Exists(filepath) = False Then
            Return True
            Exit Function '如果filpath文件不存在，也就不没有被占用，应该返回true
        End If
        Try
            File.Open(filepath, FileMode.Open).Close()
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    '初始化
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bConn = False
        Excel = ""
        TextBoxMsg = ""
        '初始化进度条
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        '初始化程序的基目录。
        Dim Directory1 As String = Application.StartupPath
        OpenFileDialog1.InitialDirectory = Directory1
    End Sub

End Class
