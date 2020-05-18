Imports System.IO
Imports System.Threading
Imports Microsoft.Office.Interop

Public Class Form1
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    'Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal SectionName As String,
    '                                                                                                  ByVal KeyName As String,
    '                                                                                                  ByVal KeyNameDefault As String,
    '                                                                                                  ByVal ReturnedString As String,
    '                                                                                                  ByVal BufferSize As Integer,
    '                                                                                                  ByVal CfgPath As String) As Integer

    Private ConnStatus As Boolean
    Private ExcelPath As String '读取数据Excel文件路径
    Private ManageExcelPath As String '经营数据Excel文件路径
    'Private CfgPath As String
    Private TextBoxMsg As String
    Private BarThread As Thread
    Private HisOrReal As Integer '读取数据操作标签，1为读取历史数据，2为读取实时数据，3为初始值

    Public AdminMode As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnStatus = False
        AdminMode = False
        ExcelPath = ""
        TextBoxMsg = ""
        HisOrReal = 3
        '初始化进度条
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        '初始化程序的基目录。
        Dim StartPath As String = System.Windows.Forms.Application.StartupPath + "\Resources"
        OpenFileDialog1.InitialDirectory = StartPath
        OpenFileDialog2.InitialDirectory = StartPath
        OpenFileDialog3.InitialDirectory = StartPath
        OpenFileDialog4.InitialDirectory = StartPath
    End Sub

    'Button 远程连接
    Private Sub CmdRemotConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdRemotConn.Click
        Dim nConnStatus As Integer
        Dim cLocal As String
        Dim cRemote As String
        cLocal = ""
        cRemote = TxtIPAddress.Text
        If ConnStatus = False Then
            nConnStatus = DbCommOcxFC7.OpenRemoteConnect(cRemote, CLng(TxtPort.Text), cLocal, 0)
            If nConnStatus > 0 Then
                Sleep(1000)
                ConnStatus = DbCommOcxFC7.IsConnected()
                If ConnStatus = True Then
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
        If ConnStatus = True Then
            DbCommOcxFC7.CloseConnect()
            ConnStatus = False
            ConnResult.Text = "Disconnected!"
        Else
        End If
    End Sub

    'Button 选择文件
    Private Sub SelectReadDataExcel(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            If IsFileReady(ExcelPath) = False Then
                MsgBox("目标Excel文件被占用。")
                Exit Sub
            Else
                ExcelPath = OpenFileDialog1.FileName 'Excel文件路径
                Try
                    System.Diagnostics.Process.Start(ExcelPath)
                Catch ex As Exception
                    MsgBox("打开文件失败！")
                End Try
                TextBoxMsg = TextBoxMsg + "当前文件：" + ExcelPath.ToString + Chr(13) + Chr(10)
                TextBox1.Text = TextBoxMsg
            End If
        End If
    End Sub

    'Button 读取历史数据
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ConnStatus = True Then
            If ExcelPath = Nothing Or ExcelPath = "" Then
                MsgBox("请先选择文件")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            If HisOrReal = 3 Then
                Dim r As MsgBoxResult = MsgBox("确定读取历史数据到" + ExcelPath + "中吗？", MsgBoxStyle.OkCancel, "读取数据")
                If r = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            ElseIf HisOrReal = 2 Then
                Dim r As MsgBoxResult = MsgBox("上次操作为读取实时数据，请先更改目标文件", MsgBoxStyle.OkOnly, "读取数据")
                Exit Sub
            End If
            Dim StartTime As Date = Date.Now '记录程序开始时间

            '进度条推进
            CreateTread4Bar()
            If IsFileReady(ExcelPath) = False Then
                MsgBox("目标Excel文件被占用")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            Dim objExcelFile As Excel.Application
            Dim objWorkBook As Excel.Workbook
            Dim objImportSheet As Excel.Worksheet
            '创建Excel进程, 并打开目标Excel文件
            objExcelFile = New Excel.Application With {
                .DisplayAlerts = False,
                .Visible = False
            }
            objWorkBook = objExcelFile.Workbooks.Open(ExcelPath)
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
                        If ProgressBar1.Value + 80 \ HisDataList.Count <= ProgressBar1.Maximum Then
                            ProgressBar1.Value = ProgressBar1.Value + 80 \ HisDataList.Count
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
                    TextBoxMsg = TextBoxMsg + "文件：" + ExcelPath.ToString + "历史数据写入完成" + Chr(13) + Chr(10)
                    TextBox1.Text = TextBoxMsg
                    Try
                        Process.Start(ExcelPath)
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
            '设置标签为读取实时数据
            HisOrReal = 1
        Else
            MsgBox("数据库未连接！")
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    Private Sub ReadRealData(sender As Object, e As EventArgs) Handles Button6.Click
        If ConnStatus = True Then
            If HisOrReal = 3 Then
                Dim r As MsgBoxResult = MsgBox("确定读取实时数据到" + ExcelPath + "中吗？", MsgBoxStyle.OkCancel, "读取数据")
                If r = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            ElseIf HisOrReal = 1 Then
                Dim r As MsgBoxResult = MsgBox("上次操作为读取历史数据，请先更改目标文件", MsgBoxStyle.OkOnly, "读取数据")
                Exit Sub
            End If
            Dim StartTime As Date = Date.Now '记录程序开始时间
            If ExcelPath = Nothing Or ExcelPath = "" Then
                MsgBox("请先选择文件")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            '进度条推进
            CreateTread4Bar()
            If IsFileReady(ExcelPath) = False Then
                MsgBox("目标Excel文件被占用")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            Dim objExcelFile As Excel.Application
            Dim objWorkBook As Excel.Workbook
            Dim objImportSheet As Excel.Worksheet
            '创建Excel进程, 并打开目标Excel文件
            objExcelFile = New Excel.Application With {
                .DisplayAlerts = False,
                .Visible = False
            }
            objWorkBook = objExcelFile.Workbooks.Open(ExcelPath)
            objImportSheet = objWorkBook.Sheets(1) '取第1个工作表
            Dim LastColNum As Integer = objImportSheet.UsedRange.Columns.Count '最后有数据的列号
            Dim LastRowNum As Integer = objImportSheet.UsedRange.Rows.Count '最后有数据的行号
            '清空原有数据
            Dim Range = objImportSheet.Range(objImportSheet.Cells(2, 2), objImportSheet.Cells(LastRowNum, LastColNum))
            Range.ClearContents()
            '进度条推进
            CreateTread4Bar()
            '开始查询历史数据
            If LastRowNum >= 2 Then
                Try
                    '顺序取出Tag并根据Tag查询实时数据，将返回数据插入Excel中
                    For RolNum As Integer = 2 To LastRowNum Step 0
                        Dim Tag As String
                        Dim RealTimeData As String = ""
                        Tag = objImportSheet.Cells(RolNum, 1).Value().ToString
                        If Tag = Nothing Then
                            RolNum += 1
                            Continue For
                        End If
                        Tag = Trim(Tag)
                        RealTimeData = GetCurrentData(Tag).ToString
                        objImportSheet.Cells(RolNum, 2) = RealTimeData
                        If ProgressBar1.Value + 80 \ LastRowNum <= ProgressBar1.Maximum Then
                            ProgressBar1.Value = ProgressBar1.Value + 80 \ LastRowNum
                            ProgressBar1.PerformStep()
                        End If
                        RolNum += 1
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
                    TextBoxMsg = TextBoxMsg + "文件：" + ExcelPath.ToString + "实时数据写入完成" + Chr(13) + Chr(10)
                    TextBox1.Text = TextBoxMsg
                    Try
                        Process.Start(ExcelPath)
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
            '设置标签为读取实时数据
            HisOrReal = 2
        Else
            MsgBox("数据库未连接！")
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    '读取BoundAries.xlsx，将边界值写入力控数据库
    Private Sub UpdateBoundaries2EFC(sender As Object, e As EventArgs) Handles Button3.Click
        '判断是否已连接力控数据库
        If ConnStatus = True Then
            If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
                '获取文件名
                Dim FilePath = OpenFileDialog2.FileName
                ProgressBar1.Maximum = 10000
                ProgressBar1.Value += 1000
                '判断文件是否被占用
                If IsFileReady(FilePath) = False Then
                    MsgBox("目标文件被占用")
                    ProgressBar1.Value = 0
                    Exit Sub
                End If
                '初始化Excel实例
                Dim objExcelFile As Excel.Application = Nothing
                Dim objWorkBook As Excel.Workbook = Nothing
                Dim ModelList As New List(Of EFCTagData)
                '封装Excel数据
                GetModelList(FilePath, objExcelFile, objWorkBook, ModelList)
                '循环ModelList，写入EFC_DB
                For Each TagData As EFCTagData In ModelList
                    Dim Desc_Key = TagData.Desc_Key + "_X" + TagData.Index.ToString + ".DESC"
                    Dim Desc_Value = TagData.Desc_Value
                    Dim H_PC1_Key = TagData.Desc_Key + "_H_PC1_X" + TagData.Index.ToString + ".PV"
                    Dim H_PC1_Value = TagData.PC1_H
                    Dim L_PC1_Key = TagData.Desc_Key + "_L_PC1_X" + TagData.Index.ToString + ".PV"
                    Dim L_PC1_Value = TagData.PC1_L
                    Dim H_PC2_Key = TagData.Desc_Key + "_H_PC2_X" + TagData.Index.ToString + ".PV"
                    Dim H_PC2_Value = TagData.PC2_H
                    Dim L_PC2_Key = TagData.Desc_Key + "_L_PC2_X" + TagData.Index.ToString + ".PV"
                    Dim L_PC2_Value = TagData.PC2_L
                    Dim H_PC3_Key = TagData.Desc_Key + "_H_PC3_X" + TagData.Index.ToString + ".PV"
                    Dim H_PC3_Value = TagData.PC3_H
                    Dim L_PC3_Key = TagData.Desc_Key + "_L_PC3_X" + TagData.Index.ToString + ".PV"
                    Dim L_PC3_Value = TagData.PC3_L
                    Try
                        UpdatePcValue2EFC(Desc_Key, Desc_Value, H_PC1_Key, H_PC1_Value, L_PC1_Key, L_PC1_Value, H_PC2_Key, H_PC2_Value, L_PC2_Key, L_PC2_Value, H_PC3_Key, H_PC3_Value, L_PC3_Key, L_PC3_Value)
                        If ProgressBar1.Value + (9000 \ ModelList.Count) <= ProgressBar1.Maximum Then
                            ProgressBar1.Value = ProgressBar1.Value + (9000 \ ModelList.Count)
                            ProgressBar1.PerformStep()
                        End If
                    Catch ex As Exception
                        objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
                        objExcelFile.Quit()
                        objWorkBook = Nothing
                        objExcelFile = Nothing
                    End Try
                Next
                If ProgressBar1.Value < ProgressBar1.Maximum Then
                    ProgressBar1.Value = ProgressBar1.Maximum
                    ProgressBar1.PerformStep()
                End If
                objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
                objExcelFile.Quit()
                objWorkBook = Nothing
                objExcelFile = Nothing
                MsgBox("边界值写入完成！")
                TextBoxMsg = TextBoxMsg + "文件：" + FilePath.ToString + "中边界值已写入力控数据库" + Chr(13) + Chr(10)
                TextBox1.Text = TextBoxMsg
            End If
        Else
            MsgBox("数据库未连接！")
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    Private Sub GenerateBoundariesTagCsv(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog3.ShowDialog() = DialogResult.OK Then
            '获取文件名
            Dim FilePath = OpenFileDialog3.FileName
            ProgressBar1.Maximum = 10000
            ProgressBar1.Value += 1000
            '判断文件是否被占用
            If IsFileReady(FilePath) = False Then
                MsgBox("目标文件被占用")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            '初始化Excel实例
            Dim objExcelFile As Excel.Application = Nothing
            Dim objWorkBook As Excel.Workbook = Nothing
            Dim ModelList As New List(Of EFCTagData)
            '封装Excel数据
            GetModelList(FilePath, objExcelFile, objWorkBook, ModelList)
            '循环ModelList，将点位名写入csv文件
            Dim TagDescList As String = ""
            Dim TagPVList As String = ""
            Dim PathUserData As String = System.Windows.Forms.Application.StartupPath & "\Resources\BoundaryTags.csv"
            Dim fi As FileInfo = New FileInfo(PathUserData)
            If fi.Exists Then
                fi.Delete()
            End If
            Dim t As System.IO.StreamWriter = New System.IO.StreamWriter(PathUserData, True, System.Text.Encoding.UTF8)
            For Each TagData As EFCTagData In ModelList
                Dim Desc_Key = TagData.Desc_Key + "_X" + TagData.Index.ToString + ".DESC"
                Dim H_PC1_Key = TagData.Desc_Key + "_H_PC1_X" + TagData.Index.ToString + ".PV"
                Dim L_PC1_Key = TagData.Desc_Key + "_L_PC1_X" + TagData.Index.ToString + ".PV"
                Dim H_PC2_Key = TagData.Desc_Key + "_H_PC2_X" + TagData.Index.ToString + ".PV"
                Dim L_PC2_Key = TagData.Desc_Key + "_L_PC2_X" + TagData.Index.ToString + ".PV"
                Dim H_PC3_Key = TagData.Desc_Key + "_H_PC3_X" + TagData.Index.ToString + ".PV"
                Dim L_PC3_Key = TagData.Desc_Key + "_L_PC3_X" + TagData.Index.ToString + ".PV"

                TagDescList = TagDescList + Desc_Key.ToString + Chr(10)
                TagPVList = TagPVList + H_PC1_Key.ToString + Chr(10)
                TagPVList = TagPVList + L_PC1_Key.ToString + Chr(10)
                TagPVList = TagPVList + H_PC2_Key.ToString + Chr(10)
                TagPVList = TagPVList + L_PC2_Key.ToString + Chr(10)
                TagPVList = TagPVList + H_PC3_Key.ToString + Chr(10)
                TagPVList = TagPVList + L_PC3_Key.ToString + Chr(10)
                If ProgressBar1.Value + (9000 \ ModelList.Count) <= ProgressBar1.Maximum Then
                    ProgressBar1.Value = ProgressBar1.Value + (9000 \ ModelList.Count)
                    ProgressBar1.PerformStep()
                End If

            Next
            If ProgressBar1.Value < ProgressBar1.Maximum Then
                ProgressBar1.Value = ProgressBar1.Maximum
                ProgressBar1.PerformStep()
            End If
            t.Write(TagDescList + Chr(10))
            t.Write(TagPVList)
            t.Close()
            objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
            objExcelFile.Quit()
            objWorkBook = Nothing
            objExcelFile = Nothing
            MsgBox("边界点名文件已生成！")
            TextBoxMsg = TextBoxMsg + "文件：" + PathUserData.ToString + "边界点名文件已生成" + Chr(13) + Chr(10)
            TextBox1.Text = TextBoxMsg
            Try
                Process.Start(PathUserData)
            Catch ex As Exception
                MsgBox("打开文件失败！")
            End Try
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    Private Sub GetModelList(FilePath As String,
                             ByRef objExcelFile As Excel.Application,
                             ByRef objWorkBook As Excel.Workbook,
                             ByRef ModelList As List(Of EFCTagData))
        '创建Excel对象
        'Dim objImportSheet As Excel.Worksheet
        '创建Excel进程, 并打开目标Excel文件
        objExcelFile = New Excel.Application With {
            .DisplayAlerts = False,
            .Visible = False
        }
        objWorkBook = objExcelFile.Workbooks.Open(FilePath)
        '获取工作表总数量
        Dim SheetCount As Integer = objWorkBook.Sheets.Count
        '@ModelFlag 模型标记，递增为6，最大值为工作表总数量，6个数据表(PC1-3,H\L)属于一个模型
        '@PcFlag PC标记，递增为1，最大值为6，每个模型有3个PC，每个PC有High和Low两个值
        For ModelFlag As Integer = 1 To SheetCount Step 0
            Dim ModelName As String = ""
            Dim TagNameList As New List(Of String)
            Dim PC1_H_PVList As New List(Of Double)
            Dim PC1_L_PVList As New List(Of Double)
            Dim PC2_H_PVList As New List(Of Double)
            Dim PC2_L_PVList As New List(Of Double)
            Dim PC3_H_PVList As New List(Of Double)
            Dim PC3_L_PVList As New List(Of Double)
            For PcFlag As Integer = 0 + ModelFlag To ModelFlag + 5 Step 0
                Dim objImportSheet As Excel.Worksheet = objWorkBook.Sheets(PcFlag)
                Dim LastRowNum As Integer = objImportSheet.UsedRange.Rows.Count '最后有数据的行号
                'PcFlag==ModelFlag时，取点位的描述，后面5张表的描述均相同，所以只取一次
                If PcFlag = ModelFlag Then
                    Dim SheetName As String = objImportSheet.Name
                    ModelName = SheetName.Substring(0, SheetName.LastIndexOf("_")) '工作表名去掉后缀就是模型名，例:DHU_T3001_pc1High
                    For i As Integer = 2 To LastRowNum Step 0
                        Dim TagName As String = objImportSheet.Cells(i, 1).Value().ToString
                        TagNameList.Add(TagName)
                        i += 1
                    Next
                End If
                Dim PVList As New List(Of Double)
                PVList = GetPVList(objImportSheet, LastRowNum, PVList) '获取点位的PV值
                Select Case PcFlag - ModelFlag'根据工作表的次序分别放到不同的List中
                    Case 0
                        PC1_H_PVList = PVList
                    Case 1
                        PC1_L_PVList = PVList
                    Case 2
                        PC2_H_PVList = PVList
                    Case 3
                        PC2_L_PVList = PVList
                    Case 4
                        PC3_H_PVList = PVList
                    Case 5
                        PC3_L_PVList = PVList
                End Select
                PcFlag += 1
            Next
            '按位号的循序，依次拿取对应的PC值，并封装
            For Each TagName As String In TagNameList
                Dim Index As Integer = TagNameList.IndexOf(TagName)
                Dim PC1_H_PV As Double = PC1_H_PVList.ElementAt(Index)
                Dim PC1_L_PV As Double = PC1_L_PVList.ElementAt(Index)
                Dim PC2_H_PV As Double = PC2_H_PVList.ElementAt(Index)
                Dim PC2_L_PV As Double = PC2_L_PVList.ElementAt(Index)
                Dim PC3_H_PV As Double = PC3_H_PVList.ElementAt(Index)
                Dim PC3_L_PV As Double = PC3_L_PVList.ElementAt(Index)
                '封装拿取到的数据
                Dim TagData As New EFCTagData With {
                    .Index = Index + 1,
                    .Desc_Key = ModelName,
                    .Desc_Value = TagName,
                    .PC1_H = PC1_H_PV,
                    .PC1_L = PC1_L_PV,
                    .PC2_H = PC2_H_PV,
                    .PC2_L = PC2_L_PV,
                    .PC3_H = PC3_H_PV,
                    .PC3_L = PC3_L_PV
                }
                ModelList.Add(TagData)
            Next
            ModelFlag += 6
        Next
    End Sub

    '调用力控接口，更新实时数据
    Private Sub UpdatePcValue2EFC(Desc_Key As String,
                           Desc_Value As String,
                           H_PC1_Key As String,
                           H_PC1_Value As String,
                           L_PC1_Key As String,
                           L_PC1_Value As String,
                           H_PC2_Key As String,
                           H_PC2_Value As String,
                           L_PC2_Key As String,
                           L_PC2_Value As String,
                           H_PC3_Key As String,
                           H_PC3_Value As String,
                           L_PC3_Key As String,
                           L_PC3_Value As String)
        Dim Result1 As Integer = DbCommOcxFC7.SetData(Desc_Key, Desc_Value)
        Dim Result2 As Integer = DbCommOcxFC7.SetData(H_PC1_Key, H_PC1_Value)
        Dim Result3 As Integer = DbCommOcxFC7.SetData(L_PC1_Key, L_PC1_Value)
        Dim Result4 As Integer = DbCommOcxFC7.SetData(H_PC2_Key, H_PC2_Value)
        Dim Result5 As Integer = DbCommOcxFC7.SetData(L_PC2_Key, L_PC2_Value)
        Dim Result6 As Integer = DbCommOcxFC7.SetData(H_PC3_Key, H_PC3_Value)
        Dim Result7 As Integer = DbCommOcxFC7.SetData(L_PC3_Key, L_PC3_Value)

        If Result1 = 0 Then
            MsgBox("请检查参数：" + Desc_Key.ToString)
            TextBoxMsg += "请检查参数：" + Desc_Key.ToString + Chr(10)
        End If
        If Result2 = 0 Then
            MsgBox("请检查参数：" + H_PC1_Key.ToString)
            TextBoxMsg += "请检查参数：" + H_PC1_Key.ToString + Chr(10)
        End If
        If Result3 = 0 Then
            MsgBox("请检查参数：" + L_PC1_Key.ToString)
            TextBoxMsg += "请检查参数：" + L_PC1_Key.ToString + Chr(10)
        End If
        If Result4 = 0 Then
            MsgBox("请检查参数：" + H_PC2_Key.ToString)
            TextBoxMsg += "请检查参数：" + H_PC2_Key.ToString + Chr(10)
        End If
        If Result5 = 0 Then
            MsgBox("请检查参数：" + L_PC2_Key.ToString)
            TextBoxMsg += "请检查参数：" + L_PC2_Key.ToString + Chr(10)
        End If
        If Result6 = 0 Then
            MsgBox("请检查参数：" + H_PC3_Key.ToString)
            TextBoxMsg += "请检查参数：" + H_PC3_Key.ToString + Chr(10)
        End If
        If Result7 = 0 Then
            MsgBox("请检查参数：" + L_PC3_Key.ToString)
            TextBoxMsg += "请检查参数：" + L_PC3_Key.ToString + Chr(10)
        End If
    End Sub

    Private Sub GenerateBoundariesExcel(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pid As Integer = RunBoundaries2Excel()
        If pid <= 0 Then
            MsgBox("边界值Excel文件生成错误，请检查文件后重试。")
            Exit Sub
        End If
        ProgressBar1.Value += 50
        ProgressBar1.PerformStep()
        Dim path As String = System.Windows.Forms.Application.StartupPath + "\Boundaries_toExcel\Boundaries_Output.xlsx"
        Dim path2 As String = System.Windows.Forms.Application.StartupPath + "\Resources\Boundaries_Output.xlsx"
        Dim fi1 As FileInfo = New FileInfo(path)
        Dim fi2 As FileInfo = New FileInfo(path2)
        Try
            If fi2.Exists Then
                fi2.Delete()
            End If
            fi1.CopyTo(path2)
            fi1.Delete()
            If ProgressBar1.Value < ProgressBar1.Maximum Then
                ProgressBar1.Value = ProgressBar1.Maximum
                ProgressBar1.PerformStep()
            End If
            ProgressBar1.PerformStep()
            MsgBox("边界值Excel文件已生成。")
            TextBoxMsg = TextBoxMsg + "文件：" + path2.ToString + "边界值Excel文件已生成" + Chr(13) + Chr(10)
            TextBox1.Text = TextBoxMsg
            Try
                Process.Start(path2)
            Catch ex As Exception
                MsgBox("打开文件失败！")
            End Try
        Catch ex As Exception
            MsgBox("边界值Excel文件生成错误，请检查文件后重试。")
            TextBoxMsg = TextBoxMsg + "边界值Excel文件生成错误，请检查文件后重试。" + Chr(13) + Chr(10)
            TextBox1.Text = TextBoxMsg
            '进度条重置
            ProgressBar1.Value = 0
            Exit Sub
        End Try
        '重置进度条
        ProgressBar1.Value = 0
    End Sub

    '调用Boundaries_toExcel.exe
    Private Function RunBoundaries2Excel() As Integer
        Dim pid As Long
        Try
            Dim filepath As String = System.Windows.Forms.Application.StartupPath + "\Boundaries_toExcel\Boundaries_toExcel.exe"
            Dim pyprocess As New Process
            pyprocess.StartInfo.FileName = filepath
            pyprocess.StartInfo.WorkingDirectory = Path.GetDirectoryName(filepath)
            pyprocess.StartInfo.UseShellExecute = True
            pyprocess.Start()
            pyprocess.WaitForExit()
            pid = pyprocess.Id
        Catch ex As Exception
            MsgBox("调用Boundaries_toExcel.exe失败，请检查后重试")
            TextBoxMsg = TextBoxMsg + "调用Boundaries_toExcel.exe失败，请检查后重试" + Chr(13) + Chr(10)
            TextBox1.Text = TextBoxMsg
            Return 0
        End Try
        Return pid
    End Function


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
        ConnStatus = DbCommOcxFC7.IsConnected()
        If ConnStatus = True Then
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
        ConnStatus = DbCommOcxFC7.IsConnected()
        If ConnStatus = True Then
            GetData = DbCommOcxFC7.GetData(Tag)
            If GetData Is Nothing Then
                Return "  "
            Else
                Return GetData(0).ToString()
            End If
        Else
            MsgBox("数据库未连接！")
            Return "  "
        End If
    End Function

    '封装边界点的PV值
    Private Function GetPVList(objImportSheet As Excel.Worksheet, LastRowNum As Integer, PVList As List(Of Double)) As List(Of Double)
        For i As Integer = 2 To LastRowNum Step 0
            Dim PV As Double = CDbl(objImportSheet.Cells(i, 2).Value().ToString)
            PVList.Add(PV)
            i += 1
        Next
        Return PVList
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

    '创建推进进度条线程
    Private Sub CreateTread4Bar()
        BarThread = New Thread(AddressOf ProgressStep)
        CheckForIllegalCrossThreadCalls = False
        BarThread.Start()
    End Sub

    '推进进度条
    Private Sub ProgressStep()
        ProgressBar1.Value = ProgressBar1.Value + 10
        BarThread.Abort()
    End Sub


    Private Sub SelectManageExcel(sender As Object, e As EventArgs) Handles Button7.Click
        If OpenFileDialog4.ShowDialog() = DialogResult.OK Then
            If IsFileReady(ManageExcelPath) = False Then
                MsgBox("目标Excel文件被占用。")
                Exit Sub
            Else
                ManageExcelPath = OpenFileDialog4.FileName 'Excel文件路径
                Try
                    System.Diagnostics.Process.Start(ManageExcelPath)
                Catch ex As Exception
                    MsgBox("打开文件失败！")
                End Try
                TextBoxMsg = TextBoxMsg + "当前经营数据文件：" + ManageExcelPath.ToString + Chr(13) + Chr(10)
                TextBox1.Text = TextBoxMsg
            End If
        End If
    End Sub

    Private Sub UpdateManageData2EFC(sender As Object, e As EventArgs) Handles Button8.Click
        '判断是否已连接力控数据库
        If ConnStatus = True Then
            '文件名
            If ManageExcelPath = Nothing Or ManageExcelPath = "" Then
                MsgBox("请先选择经营数据文件")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            ProgressBar1.Maximum = 1000
            ProgressBar1.Value += 100
            '判断文件是否被占用
            If IsFileReady(ManageExcelPath) = False Then
                MsgBox("目标文件被占用")
                ProgressBar1.Value = 0
                Exit Sub
            End If
            '初始化Excel实例
            Dim objExcelFile As Excel.Application = Nothing
            Dim objWorkBook As Excel.Workbook = Nothing
            '创建Excel对象
            Dim objImportSheet As Excel.Worksheet
            '创建Excel进程, 并打开目标Excel文件
            objExcelFile = New Excel.Application With {
            .DisplayAlerts = False,
            .Visible = False
            }
            objWorkBook = objExcelFile.Workbooks.Open(ManageExcelPath)
            '获取工作表总数量
            Dim SheetCount As Integer = objWorkBook.Sheets.Count
            '获取最后一个工作表
            objImportSheet = objWorkBook.Sheets(SheetCount)
            Dim LastColNum As Integer = objImportSheet.UsedRange.Columns.Count '最后有数据的列号
            Dim LastRowNum As Integer = objImportSheet.UsedRange.Rows.Count '最后有数据的行号
            Try
                For RowNum As Integer = 3 To LastRowNum Step 1
                    Dim TagName As String = objImportSheet.Cells(RowNum, 6).value
                    If TagName = Nothing Or TagName = "" Then
                        Continue For
                    End If
                    TagName.Trim()
                    Dim TagPV As Double = objImportSheet.Cells(RowNum, 3).value
                    Dim TagUnit As String = objImportSheet.Cells(RowNum, 4).value
                    Dim Result1 As Integer = DbCommOcxFC7.SetData(TagName + ".PV", TagPV)
                    Dim Result2 As Integer = DbCommOcxFC7.SetData(TagName + ".UNIT", TagUnit)
                    If ProgressBar1.Value + (900 \ LastRowNum) <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + (900 \ LastRowNum)
                        ProgressBar1.PerformStep()
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
                objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
                objExcelFile.Quit()
                objWorkBook = Nothing
                objExcelFile = Nothing
            End Try
            If ProgressBar1.Value < ProgressBar1.Maximum Then
                ProgressBar1.Value = ProgressBar1.Maximum
                ProgressBar1.PerformStep()
            End If
            objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
            objExcelFile.Quit()
            objWorkBook = Nothing
            objExcelFile = Nothing
            MsgBox("运营数据写入完成！")
            TextBoxMsg = TextBoxMsg + "文件：" + ManageExcelPath.ToString + "中运营数据已写入力控数据库" + Chr(13) + Chr(10)
            TextBox1.Text = TextBoxMsg
        Else
            MsgBox("数据库未连接！")
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim FormDlg As Form2
        FormDlg = New Form2 With {
            .Owner = Me
        }
        FormDlg.ShowDialog()
        If AdminMode = True Then
            MsgBox("已进入管理员模式")
        End If
    End Sub

    '打开ModelConfig文件，并根据@name和@inTagsData字段生成Boundaries.xlsx模板文件
    '<Obsolete("此方法弃用，使用Boundaries_2Excel.exe生成边界值表格")>
    'Private Function ModelCfg2Excel()
    'If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
    '    Dim CfgDataList As New List(Of CfgSectionData)
    '    Dim SectionList As List(Of String)
    '    CfgPath = OpenFileDialog2.FileName 'cfg文件路径
    '    SectionList = GetCfgAllSections() '获取所有Section，即model1、model2……
    '    '从每个section中获取对应的@name和@inTagsData值
    '    For Each Section As String In SectionList
    '        Dim ModelName As String = GetKey(Section, "name").ElementAt(0)
    '        Dim Tags As List(Of String) = GetKey(Section, "inTagsData")
    '        Dim SectionData As New CfgSectionData(Section, ModelName, Tags)
    '        CfgDataList.Add(SectionData)
    '    Next
    '    '初始化Excel实例
    '    Dim ExcelFile As Excel.Application
    '    Dim WorkBook As Excel.Workbook
    '    ExcelFile = New Excel.Application With {
    '        .Visible = False,
    '        .DisplayAlerts = False
    '    }
    '    WorkBook = ExcelFile.Workbooks.Add
    '    '创建Excel工作表时是根据当前表向前创建，所以需要将CfgDataList倒序
    '    CfgDataList.Reverse()
    '    '根据@name建立新工作表，根据@inTagsData填充工作表
    '    For Each SectionData As CfgSectionData In CfgDataList
    '        Dim ModelName As String = SectionData.ModelName
    '        Dim Tags As List(Of String) = SectionData.Tags
    '        Dim WorkSheet_PC1_H As Excel.Worksheet
    '        Dim WorkSheet_PC1_L As Excel.Worksheet
    '        Dim WorkSheet_PC2_H As Excel.Worksheet
    '        Dim WorkSheet_PC2_L As Excel.Worksheet
    '        Dim WorkSheet_PC3_H As Excel.Worksheet
    '        Dim WorkSheet_PC3_L As Excel.Worksheet
    '        '从3-1的顺序建立新工作表
    '        WorkSheet_PC3_L = ExcelFile.ActiveWorkbook.Worksheets.Add
    '        WorkSheet_PC3_L.Name = ModelName + "_PC3_Low"
    '        '插入数据前先激活工作表
    '        WorkSheet_PC3_L.Activate()
    '        Dim Index As Integer = 1
    '        'PC3_L为第一个表，所以插入初始化数据，后续工作表依次复制
    '        For Each Tag As String In Tags
    '            WorkSheet_PC3_L.Cells(Index + 1, 1) = Tag
    '            WorkSheet_PC3_L.Cells(Index + 1, 2) = Index.ToString
    '            Index += 1
    '        Next
    '        WorkSheet_PC3_L.Cells(1, 1) = ModelName
    '        WorkSheet_PC3_L.Cells(1, 2) = "PV"
    '        WorkSheet_PC3_L.Range("A1:A" + Index.ToString).Font.Bold = True
    '        Dim CopyRange As String = "A1:B" + Index.ToString '复制区间
    '        '新建表，复制，重命名新表，激活新建的表为下一次复制做准备
    '        WorkSheet_PC3_H = ExcelFile.ActiveWorkbook.Worksheets.Add
    '        WorkSheet_PC3_L.Range(CopyRange).Copy(WorkSheet_PC3_H.Range("A1:A" + Index.ToString))
    '        WorkSheet_PC3_H.Name = ModelName + "_PC3_High"
    '        WorkSheet_PC3_H.Activate()

    '        WorkSheet_PC2_L = ExcelFile.ActiveWorkbook.Worksheets.Add
    '        WorkSheet_PC3_H.Range(CopyRange).Copy(WorkSheet_PC2_L.Range("A1:A" + Index.ToString))
    '        WorkSheet_PC2_L.Name = ModelName + "_PC2_Low"
    '        WorkSheet_PC2_L.Activate()

    '        WorkSheet_PC2_H = ExcelFile.ActiveWorkbook.Worksheets.Add
    '        WorkSheet_PC2_L.Range(CopyRange).Copy(WorkSheet_PC2_H.Range("A1:A" + Index.ToString))
    '        WorkSheet_PC2_H.Name = ModelName + "_PC2_High"
    '        WorkSheet_PC2_H.Activate()

    '        WorkSheet_PC1_L = ExcelFile.ActiveWorkbook.Worksheets.Add
    '        WorkSheet_PC2_H.Range(CopyRange).Copy(WorkSheet_PC1_L.Range("A1:A" + Index.ToString))
    '        WorkSheet_PC1_L.Name = ModelName + "_PC1_Low"
    '        WorkSheet_PC1_L.Activate()

    '        WorkSheet_PC1_H = ExcelFile.ActiveWorkbook.Worksheets.Add
    '        WorkSheet_PC1_L.Range(CopyRange).Copy(WorkSheet_PC1_H.Range("A1:A" + Index.ToString))
    '        WorkSheet_PC1_H.Name = ModelName + "_PC1_High"

    '    Next
    '    WorkBook.Worksheets("Sheet1").Delete() '删除新建Excel时的系统默认表
    '    WorkBook.SaveAs(OpenFileDialog2.InitialDirectory + "\test.xlsx") '另存为当前路径下
    '    '关闭Excel实例并释放资源
    '    ExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
    '    ExcelFile.Quit()
    '    WorkBook = Nothing
    '    ExcelFile = Nothing
    '    '打开新建的Excel模板
    '    Try
    '        System.Diagnostics.Process.Start(OpenFileDialog2.InitialDirectory + "\test.xlsx")
    '    Catch ex As Exception
    '        MsgBox("打开文件失败！")
    '    End Try
    'End If
    'Return Nothing
    'End Function
    'Private Function GetCfgAllSections() As List(Of String)
    '    Dim SectionList As List(Of String)
    '    Dim SectionBufferText As New String(" ", 2048)
    '    Dim Length As Integer = GetPrivateProfileString(Nothing, Nothing, Nothing, SectionBufferText, 2048, CfgPath)
    '    SectionList = SectionBufferText.Split(vbNullChar).ToList
    '    SectionList = RemoveNullString(SectionList)
    '    Return SectionList
    'End Function

    'Private Function GetKey(ByVal SectionName As String, ByVal KeyName As String) As List(Of String)
    '    Dim KeyBufferText As New String(" ", 2048)
    '    Dim Length As Integer = GetPrivateProfileString(SectionName, KeyName, vbNullString, KeyBufferText, 2048, CfgPath)
    '    Dim KeyList As List(Of String)
    '    KeyList = KeyBufferText.Split(vbNullChar).ToList.ElementAt(0).Split(",").ToList
    '    KeyList = RemoveNullString(KeyList)
    '    Return KeyList
    'End Function

    'Private Function RemoveNullString(ByRef OriginList As List(Of String)) As List(Of String)
    '    Dim NullStringList As New List(Of Integer)
    '    For Each Element As String In OriginList
    '        If Element Is Nothing Or Element = vbNullString Then
    '            NullStringList.Add(OriginList.IndexOf(Element))
    '        ElseIf Element.Trim = "" Then
    '            NullStringList.Add(OriginList.IndexOf(Element))
    '        End If
    '    Next
    '    NullStringList.Reverse()
    '    For Each NullStringIndex As Integer In NullStringList
    '        OriginList.RemoveAt(NullStringIndex)
    '    Next
    '    Return OriginList
    'End Function

    '初始化

End Class
