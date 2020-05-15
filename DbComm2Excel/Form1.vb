Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports System.Threading

Imports IronPython.Hosting
Imports Microsoft.Scripting.Hosting


Public Class Form1
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal SectionName As String,
                                                                                                      ByVal KeyName As String,
                                                                                                      ByVal KeyNameDefault As String,
                                                                                                      ByVal ReturnedString As String,
                                                                                                      ByVal BufferSize As Integer,
                                                                                                      ByVal CfgPath As String) As Integer

    Private ConnStatus As Boolean
    Private ExcelPath As String
    Private CfgPath As String
    Private TextBoxMsg As String
    Private BarThread As Thread

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    'Button 读取数据
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ConnStatus = True Then
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
                    TextBoxMsg = TextBoxMsg + "文件：" + ExcelPath.ToString + "写入完成" + Chr(13) + Chr(10)
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
        Else
            MsgBox("数据库未连接！")
        End If
        '进度条重置
        ProgressBar1.Value = 0
    End Sub

    '写入数据至力控
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ConnStatus = True Then
            If OpenFileDialog3.ShowDialog() = DialogResult.OK Then
                '获取文件名
                Dim FilePath = OpenFileDialog3.FileName
                '判断文件是否被占用
                If IsFileReady(FilePath) = False Then
                    MsgBox("目标文件被占用")
                    ProgressBar1.Value = 0
                    Exit Sub
                End If
                '创建Excel对象
                Dim objExcelFile As Excel.Application
                Dim objWorkBook As Excel.Workbook
                'Dim objImportSheet As Excel.Worksheet
                '创建Excel进程, 并打开目标Excel文件
                objExcelFile = New Excel.Application With {
                    .DisplayAlerts = False,
                    .Visible = False
                }
                objWorkBook = objExcelFile.Workbooks.Open(FilePath)
                '获取工作表总数量
                Dim SheetCount As Integer = objWorkBook.Sheets.Count
                Dim ModelList As New List(Of EFCTagData)
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
                        If PcFlag = ModelFlag Then
                            Dim SheetName As String = objImportSheet.Name
                            ModelName = SheetName.Substring(0, SheetName.LastIndexOf("_"))
                            For i As Integer = 2 To LastRowNum Step 0
                                Dim TagName As String = objImportSheet.Cells(i, 1).Value().ToString
                                TagNameList.Add(TagName)
                                i += 1
                            Next
                        End If
                        Dim PVList As New List(Of Double)
                        PVList = GetPVList(objImportSheet, LastRowNum, PVList)
                        Select Case PcFlag - ModelFlag
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
                        'Dim SheetName As String = objImportSheet.Name
                    Next

                    For Each TagName As String In TagNameList
                        Dim Index As Integer = TagNameList.IndexOf(TagName)
                        Dim PC1_H_PV As Double = PC1_H_PVList.ElementAt(Index)
                        Dim PC1_L_PV As Double = PC1_L_PVList.ElementAt(Index)
                        Dim PC2_H_PV As Double = PC2_H_PVList.ElementAt(Index)
                        Dim PC2_L_PV As Double = PC2_L_PVList.ElementAt(Index)
                        Dim PC3_H_PV As Double = PC3_H_PVList.ElementAt(Index)
                        Dim PC3_L_PV As Double = PC3_L_PVList.ElementAt(Index)

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

                'TODO 循环ModelList，写入EFC_DB

                Dim TestText As String = ""
                Dim PathUserData As String = System.Windows.Forms.Application.StartupPath & "\test.txt"
                Dim t As System.IO.StreamWriter = New System.IO.StreamWriter(PathUserData, True, System.Text.Encoding.UTF8)
                For Each TagData As EFCTagData In ModelList

                    Dim Desc_Key = TagData.Desc_Key + "_X" + TagData.Index.ToString
                    Dim Desc_Value = TagData.Desc_Value

                    Dim H_PC1_Key = TagData.Desc_Key + "_H_PC1_X" + TagData.Index.ToString
                    Dim H_PC1_Value = TagData.PC1_H

                    Dim L_PC1_Key = TagData.Desc_Key + "_L_PC1_X" + TagData.Index.ToString
                    Dim L_PC1_Value = TagData.PC1_L

                    Dim H_PC2_Key = TagData.Desc_Key + "_H_PC2_X" + TagData.Index.ToString
                    Dim H_PC2_Value = TagData.PC2_H

                    Dim L_PC2_Key = TagData.Desc_Key + "_L_PC2_X" + TagData.Index.ToString
                    Dim L_PC2_Value = TagData.PC2_L

                    Dim H_PC3_Key = TagData.Desc_Key + "_H_PC3_X" + TagData.Index.ToString
                    Dim H_PC3_Value = TagData.PC3_H

                    Dim L_PC3_Key = TagData.Desc_Key + "_L_PC3_X" + TagData.Index.ToString
                    Dim L_PC3_Value = TagData.PC3_L

                    TestText = TestText + Desc_Key.ToString + " = " + Desc_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + H_PC1_Key.ToString + " = " + H_PC1_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + L_PC1_Key.ToString + " = " + L_PC1_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + H_PC2_Key.ToString + " = " + H_PC2_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + L_PC2_Key.ToString + " = " + L_PC2_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + H_PC3_Key.ToString + " = " + H_PC3_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + L_PC3_Key.ToString + " = " + L_PC3_Value.ToString + Chr(10) + Chr(13)
                    TestText = TestText + Chr(10) + Chr(13)


                    'Dim Result As Integer = 0 '数据库接口返回值
                    'Result = DbCommOcxFC7.SetData(TagName, TagValue)

                Next

                t.Write(TestText)
                t.Close()

                objExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
                objExcelFile.Quit()
                objWorkBook = Nothing
                objExcelFile = Nothing

            End If
        Else
            MsgBox("数据库未连接！")
        End If
    End Sub

    Private Function GetPVList(objImportSheet As Worksheet, LastRowNum As Integer, PVList As List(Of Double)) As List(Of Double)
        For i As Integer = 2 To LastRowNum Step 0
            Dim PV As Double = CDbl(objImportSheet.Cells(i, 2).Value().ToString)
            PVList.Add(PV)
            i += 1
        Next
        Return PVList
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
            Return GetData(0).ToString()
            If GetData Is Nothing Then
                Return "  "
            End If
        Else
            MsgBox("数据库未连接！")
            Return "  "
        End If
    End Function

    Private Function GetCfgAllSections() As List(Of String)
        Dim SectionList As List(Of String)
        Dim SectionBufferText As New String(" ", 2048)
        Dim Length As Integer = GetPrivateProfileString(Nothing, Nothing, Nothing, SectionBufferText, 2048, CfgPath)
        SectionList = SectionBufferText.Split(vbNullChar).ToList
        SectionList = RemoveNullString(SectionList)
        Return SectionList
    End Function

    Private Function GetKey(ByVal SectionName As String, ByVal KeyName As String) As List(Of String)
        Dim KeyBufferText As New String(" ", 2048)
        Dim Length As Integer = GetPrivateProfileString(SectionName, KeyName, vbNullString, KeyBufferText, 2048, CfgPath)
        Dim KeyList As List(Of String)
        KeyList = KeyBufferText.Split(vbNullChar).ToList.ElementAt(0).Split(",").ToList
        KeyList = RemoveNullString(KeyList)
        Return KeyList
    End Function

    Private Function RemoveNullString(ByRef OriginList As List(Of String)) As List(Of String)
        Dim NullStringList As New List(Of Integer)
        For Each Element As String In OriginList
            If Element Is Nothing Or Element = vbNullString Then
                NullStringList.Add(OriginList.IndexOf(Element))
            ElseIf Element.Trim = "" Then
                NullStringList.Add(OriginList.IndexOf(Element))
            End If
        Next
        NullStringList.Reverse()
        For Each NullStringIndex As Integer In NullStringList
            OriginList.RemoveAt(NullStringIndex)
        Next
        Return OriginList
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

    '初始化
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConnStatus = False
        ExcelPath = ""
        TextBoxMsg = ""
        '初始化进度条
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        '初始化程序的基目录。
        OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
        OpenFileDialog2.InitialDirectory = System.Windows.Forms.Application.StartupPath
        OpenFileDialog3.InitialDirectory = System.Windows.Forms.Application.StartupPath
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            Dim CfgDataList As New List(Of CfgSectionData)
            Dim SectionList As List(Of String)
            CfgPath = OpenFileDialog2.FileName
            SectionList = GetCfgAllSections()
            For Each Section As String In SectionList
                Dim ModelName As String = GetKey(Section, "name").ElementAt(0)
                Dim Tags As List(Of String) = GetKey(Section, "inTagsData")
                Dim SectionData As New CfgSectionData(Section, ModelName, Tags)
                CfgDataList.Add(SectionData)
            Next

            Dim ExcelFile As Excel.Application
            Dim WorkBook As Excel.Workbook

            ExcelFile = New Excel.Application With {
                .Visible = False,
                .DisplayAlerts = False
            }
            WorkBook = ExcelFile.Workbooks.Add

            CfgDataList.Reverse()

            For Each SectionData As CfgSectionData In CfgDataList
                Dim ModelName As String = SectionData.ModelName
                Dim Tags As List(Of String) = SectionData.Tags

                Dim WorkSheet_PC1_H As Excel.Worksheet
                Dim WorkSheet_PC1_L As Excel.Worksheet
                Dim WorkSheet_PC2_H As Excel.Worksheet
                Dim WorkSheet_PC2_L As Excel.Worksheet
                Dim WorkSheet_PC3_H As Excel.Worksheet
                Dim WorkSheet_PC3_L As Excel.Worksheet

                WorkSheet_PC3_L = ExcelFile.ActiveWorkbook.Worksheets.Add
                WorkSheet_PC3_L.Name = ModelName + "_PC3_Low"

                WorkSheet_PC3_L.Activate()
                Dim Index As Integer = 1
                For Each Tag As String In Tags
                    WorkSheet_PC3_L.Cells(Index + 1, 1) = Tag
                    WorkSheet_PC3_L.Cells(Index + 1, 2) = Index.ToString
                    Index += 1
                Next
                WorkSheet_PC3_L.Cells(1, 1) = ModelName
                WorkSheet_PC3_L.Cells(1, 2) = "PV"
                WorkSheet_PC3_L.Range("A1:A" + Index.ToString).Font.Bold = True
                Dim CopyRange As String = "A1:B" + Index.ToString
                WorkSheet_PC3_H = ExcelFile.ActiveWorkbook.Worksheets.Add
                WorkSheet_PC3_L.Range(CopyRange).Copy(WorkSheet_PC3_H.Range("A1:A" + Index.ToString))
                WorkSheet_PC3_H.Name = ModelName + "_PC3_High"

                WorkSheet_PC3_H.Activate()
                WorkSheet_PC2_L = ExcelFile.ActiveWorkbook.Worksheets.Add
                WorkSheet_PC3_H.Range(CopyRange).Copy(WorkSheet_PC2_L.Range("A1:A" + Index.ToString))
                WorkSheet_PC2_L.Name = ModelName + "_PC2_Low"

                WorkSheet_PC2_L.Activate()
                WorkSheet_PC2_H = ExcelFile.ActiveWorkbook.Worksheets.Add
                WorkSheet_PC2_L.Range(CopyRange).Copy(WorkSheet_PC2_H.Range("A1:A" + Index.ToString))
                WorkSheet_PC2_H.Name = ModelName + "_PC2_High"

                WorkSheet_PC2_H.Activate()
                WorkSheet_PC1_L = ExcelFile.ActiveWorkbook.Worksheets.Add
                WorkSheet_PC2_H.Range(CopyRange).Copy(WorkSheet_PC1_L.Range("A1:A" + Index.ToString))
                WorkSheet_PC1_L.Name = ModelName + "_PC1_Low"

                WorkSheet_PC1_L.Activate()
                WorkSheet_PC1_H = ExcelFile.ActiveWorkbook.Worksheets.Add
                WorkSheet_PC1_L.Range(CopyRange).Copy(WorkSheet_PC1_H.Range("A1:A" + Index.ToString))
                WorkSheet_PC1_H.Name = ModelName + "_PC1_High"

            Next
            WorkBook.Worksheets("Sheet1").Delete()
            WorkBook.SaveAs(OpenFileDialog2.InitialDirectory + "\test.xlsx")
            ExcelFile.ActiveWorkbook.Close(SaveChanges:=True)
            ExcelFile.Quit()
            WorkBook = Nothing
            ExcelFile = Nothing
            Try
                System.Diagnostics.Process.Start(OpenFileDialog2.InitialDirectory + "\test.xlsx")
            Catch ex As Exception
                MsgBox("打开文件失败！")
            End Try
        End If
    End Sub
End Class
