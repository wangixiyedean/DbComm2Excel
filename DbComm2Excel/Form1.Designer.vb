<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ConnResult = New System.Windows.Forms.TextBox()
        Me.TxtPort = New System.Windows.Forms.TextBox()
        Me.TxtIPAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdDisconn = New System.Windows.Forms.Button()
        Me.CmdRemotConn = New System.Windows.Forms.Button()
        Me.TextResult = New System.Windows.Forms.TextBox()
        Me.SelectReadDataExcelButton = New System.Windows.Forms.Button()
        Me.ReadHisDataButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.UpdateBoundariesButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.GetBoundariesTagsButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.GenerateBoundariesButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DbCommOcxFC7 = New AxDBCOMMOCXLibFC7.AxDbCommOcxFC7()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ReadRealTimeDataButton = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.UpdateManageDataButton = New System.Windows.Forms.Button()
        Me.SelectManageExcelButton = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.OpenFileDialog4 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.AdminModeButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog5 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.InsertRealTimeData = New System.Windows.Forms.Button()
        Me.InsertHisDataButton = New System.Windows.Forms.Button()
        Me.SelectInsertHisDataExcelButton = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog6 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "连接结果"
        '
        'ConnResult
        '
        Me.ConnResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConnResult.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ConnResult.Location = New System.Drawing.Point(86, 106)
        Me.ConnResult.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.ConnResult.Name = "ConnResult"
        Me.ConnResult.ReadOnly = True
        Me.ConnResult.Size = New System.Drawing.Size(140, 29)
        Me.ConnResult.TabIndex = 9
        Me.ConnResult.Text = "NoLink"
        '
        'TxtPort
        '
        Me.TxtPort.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtPort.Location = New System.Drawing.Point(86, 66)
        Me.TxtPort.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(140, 26)
        Me.TxtPort.TabIndex = 10
        Me.TxtPort.Text = "2006"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtIPAddress.Location = New System.Drawing.Point(86, 26)
        Me.TxtIPAddress.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TxtIPAddress.Name = "TxtIPAddress"
        Me.TxtIPAddress.Size = New System.Drawing.Size(140, 26)
        Me.TxtIPAddress.TabIndex = 11
        Me.TxtIPAddress.Text = "192.168.154.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "端口"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "IP地址"
        '
        'CmdDisconn
        '
        Me.CmdDisconn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdDisconn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdDisconn.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdDisconn.Location = New System.Drawing.Point(6, 147)
        Me.CmdDisconn.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.CmdDisconn.Name = "CmdDisconn"
        Me.CmdDisconn.Size = New System.Drawing.Size(100, 40)
        Me.CmdDisconn.TabIndex = 1
        Me.CmdDisconn.Text = "关闭连接"
        Me.CmdDisconn.UseVisualStyleBackColor = True
        '
        'CmdRemotConn
        '
        Me.CmdRemotConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdRemotConn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdRemotConn.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdRemotConn.Location = New System.Drawing.Point(126, 147)
        Me.CmdRemotConn.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.CmdRemotConn.Name = "CmdRemotConn"
        Me.CmdRemotConn.Size = New System.Drawing.Size(100, 40)
        Me.CmdRemotConn.TabIndex = 0
        Me.CmdRemotConn.Text = "远程连接"
        Me.CmdRemotConn.UseVisualStyleBackColor = True
        '
        'TextResult
        '
        Me.TextResult.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextResult.Location = New System.Drawing.Point(9, 26)
        Me.TextResult.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TextResult.Multiline = True
        Me.TextResult.Name = "TextResult"
        Me.TextResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextResult.Size = New System.Drawing.Size(481, 253)
        Me.TextResult.TabIndex = 13
        '
        'SelectReadDataExcelButton
        '
        Me.SelectReadDataExcelButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SelectReadDataExcelButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SelectReadDataExcelButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SelectReadDataExcelButton.Location = New System.Drawing.Point(6, 26)
        Me.SelectReadDataExcelButton.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.SelectReadDataExcelButton.Name = "SelectReadDataExcelButton"
        Me.SelectReadDataExcelButton.Size = New System.Drawing.Size(120, 40)
        Me.SelectReadDataExcelButton.TabIndex = 2
        Me.SelectReadDataExcelButton.Text = "选择文件"
        Me.SelectReadDataExcelButton.UseVisualStyleBackColor = True
        '
        'ReadHisDataButton
        '
        Me.ReadHisDataButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReadHisDataButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ReadHisDataButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ReadHisDataButton.Location = New System.Drawing.Point(6, 86)
        Me.ReadHisDataButton.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.ReadHisDataButton.Name = "ReadHisDataButton"
        Me.ReadHisDataButton.Size = New System.Drawing.Size(120, 40)
        Me.ReadHisDataButton.TabIndex = 3
        Me.ReadHisDataButton.Text = "读取历史数据"
        Me.ReadHisDataButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 525)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(654, 25)
        Me.ProgressBar1.TabIndex = 16
        '
        'UpdateBoundariesButton
        '
        Me.UpdateBoundariesButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateBoundariesButton.Enabled = False
        Me.UpdateBoundariesButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UpdateBoundariesButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UpdateBoundariesButton.Location = New System.Drawing.Point(6, 147)
        Me.UpdateBoundariesButton.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.UpdateBoundariesButton.Name = "UpdateBoundariesButton"
        Me.UpdateBoundariesButton.Size = New System.Drawing.Size(120, 40)
        Me.UpdateBoundariesButton.TabIndex = 11
        Me.UpdateBoundariesButton.Text = "写入边界点值"
        Me.UpdateBoundariesButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'GetBoundariesTagsButton
        '
        Me.GetBoundariesTagsButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GetBoundariesTagsButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GetBoundariesTagsButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GetBoundariesTagsButton.Location = New System.Drawing.Point(6, 86)
        Me.GetBoundariesTagsButton.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.GetBoundariesTagsButton.Name = "GetBoundariesTagsButton"
        Me.GetBoundariesTagsButton.Size = New System.Drawing.Size(120, 40)
        Me.GetBoundariesTagsButton.TabIndex = 7
        Me.GetBoundariesTagsButton.Text = "获取边界点名"
        Me.GetBoundariesTagsButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'GenerateBoundariesButton
        '
        Me.GenerateBoundariesButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GenerateBoundariesButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GenerateBoundariesButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GenerateBoundariesButton.Location = New System.Drawing.Point(6, 26)
        Me.GenerateBoundariesButton.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.GenerateBoundariesButton.Name = "GenerateBoundariesButton"
        Me.GenerateBoundariesButton.Size = New System.Drawing.Size(120, 40)
        Me.GenerateBoundariesButton.TabIndex = 6
        Me.GenerateBoundariesButton.Text = "生成边界点表"
        Me.GenerateBoundariesButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPort)
        Me.GroupBox1.Controls.Add(Me.CmdRemotConn)
        Me.GroupBox1.Controls.Add(Me.DbCommOcxFC7)
        Me.GroupBox1.Controls.Add(Me.CmdDisconn)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtIPAddress)
        Me.GroupBox1.Controls.Add(Me.ConnResult)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(240, 200)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "连接属性"
        '
        'DbCommOcxFC7
        '
        Me.DbCommOcxFC7.Enabled = True
        Me.DbCommOcxFC7.Location = New System.Drawing.Point(0, 46)
        Me.DbCommOcxFC7.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.DbCommOcxFC7.Name = "DbCommOcxFC7"
        Me.DbCommOcxFC7.OcxState = CType(resources.GetObject("DbCommOcxFC7.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DbCommOcxFC7.Size = New System.Drawing.Size(32, 32)
        Me.DbCommOcxFC7.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ReadRealTimeDataButton)
        Me.GroupBox2.Controls.Add(Me.SelectReadDataExcelButton)
        Me.GroupBox2.Controls.Add(Me.ReadHisDataButton)
        Me.GroupBox2.Location = New System.Drawing.Point(534, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(132, 200)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "读取数据"
        '
        'ReadRealTimeDataButton
        '
        Me.ReadRealTimeDataButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReadRealTimeDataButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ReadRealTimeDataButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ReadRealTimeDataButton.Location = New System.Drawing.Point(6, 147)
        Me.ReadRealTimeDataButton.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.ReadRealTimeDataButton.Name = "ReadRealTimeDataButton"
        Me.ReadRealTimeDataButton.Size = New System.Drawing.Size(120, 40)
        Me.ReadRealTimeDataButton.TabIndex = 4
        Me.ReadRealTimeDataButton.Text = "读取实时数据"
        Me.ReadRealTimeDataButton.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GetBoundariesTagsButton)
        Me.GroupBox3.Controls.Add(Me.UpdateBoundariesButton)
        Me.GroupBox3.Controls.Add(Me.GenerateBoundariesButton)
        Me.GroupBox3.Location = New System.Drawing.Point(258, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox3.Size = New System.Drawing.Size(132, 200)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "边界数值"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.UpdateManageDataButton)
        Me.GroupBox4.Controls.Add(Me.SelectManageExcelButton)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 302)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(146, 129)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "经营数值"
        '
        'UpdateManageDataButton
        '
        Me.UpdateManageDataButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateManageDataButton.Enabled = False
        Me.UpdateManageDataButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.UpdateManageDataButton.Font = New System.Drawing.Font("微软雅黑", 12.5!)
        Me.UpdateManageDataButton.Location = New System.Drawing.Point(12, 77)
        Me.UpdateManageDataButton.Name = "UpdateManageDataButton"
        Me.UpdateManageDataButton.Size = New System.Drawing.Size(120, 40)
        Me.UpdateManageDataButton.TabIndex = 10
        Me.UpdateManageDataButton.Text = "写入经营数据"
        Me.UpdateManageDataButton.UseVisualStyleBackColor = True
        '
        'SelectManageExcelButton
        '
        Me.SelectManageExcelButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SelectManageExcelButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SelectManageExcelButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SelectManageExcelButton.Location = New System.Drawing.Point(12, 26)
        Me.SelectManageExcelButton.Name = "SelectManageExcelButton"
        Me.SelectManageExcelButton.Size = New System.Drawing.Size(120, 40)
        Me.SelectManageExcelButton.TabIndex = 5
        Me.SelectManageExcelButton.Text = "选择文件"
        Me.SelectManageExcelButton.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TextResult)
        Me.GroupBox5.Location = New System.Drawing.Point(170, 224)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(496, 291)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "输出结果"
        '
        'OpenFileDialog4
        '
        Me.OpenFileDialog4.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TextBox2)
        Me.GroupBox6.Controls.Add(Me.AdminModeButton)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 216)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(152, 80)
        Me.GroupBox6.TabIndex = 27
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "管理员模式"
        '
        'TextBox2
        '
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox2.Location = New System.Drawing.Point(6, 33)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(140, 27)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "当前为管理员模式"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox2.Visible = False
        '
        'AdminModeButton
        '
        Me.AdminModeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AdminModeButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.AdminModeButton.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AdminModeButton.Location = New System.Drawing.Point(6, 26)
        Me.AdminModeButton.Name = "AdminModeButton"
        Me.AdminModeButton.Size = New System.Drawing.Size(140, 40)
        Me.AdminModeButton.TabIndex = 9
        Me.AdminModeButton.Text = "进入管理员模式"
        Me.AdminModeButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog5
        '
        Me.OpenFileDialog5.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.InsertRealTimeData)
        Me.GroupBox7.Controls.Add(Me.InsertHisDataButton)
        Me.GroupBox7.Controls.Add(Me.SelectInsertHisDataExcelButton)
        Me.GroupBox7.Location = New System.Drawing.Point(396, 15)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(132, 200)
        Me.GroupBox7.TabIndex = 28
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "插入数据"
        '
        'InsertRealTimeData
        '
        Me.InsertRealTimeData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InsertRealTimeData.Enabled = False
        Me.InsertRealTimeData.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.InsertRealTimeData.Font = New System.Drawing.Font("微软雅黑", 12.5!)
        Me.InsertRealTimeData.Location = New System.Drawing.Point(6, 147)
        Me.InsertRealTimeData.Name = "InsertRealTimeData"
        Me.InsertRealTimeData.Size = New System.Drawing.Size(120, 40)
        Me.InsertRealTimeData.TabIndex = 13
        Me.InsertRealTimeData.Text = "插入实时数据"
        Me.InsertRealTimeData.UseVisualStyleBackColor = True
        '
        'InsertHisDataButton
        '
        Me.InsertHisDataButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InsertHisDataButton.Enabled = False
        Me.InsertHisDataButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.InsertHisDataButton.Font = New System.Drawing.Font("微软雅黑", 12.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.InsertHisDataButton.Location = New System.Drawing.Point(6, 86)
        Me.InsertHisDataButton.Name = "InsertHisDataButton"
        Me.InsertHisDataButton.Size = New System.Drawing.Size(120, 40)
        Me.InsertHisDataButton.TabIndex = 12
        Me.InsertHisDataButton.Text = "插入历史数据"
        Me.InsertHisDataButton.UseVisualStyleBackColor = True
        '
        'SelectInsertHisDataExcelButton
        '
        Me.SelectInsertHisDataExcelButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SelectInsertHisDataExcelButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SelectInsertHisDataExcelButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SelectInsertHisDataExcelButton.Location = New System.Drawing.Point(6, 26)
        Me.SelectInsertHisDataExcelButton.Name = "SelectInsertHisDataExcelButton"
        Me.SelectInsertHisDataExcelButton.Size = New System.Drawing.Size(120, 40)
        Me.SelectInsertHisDataExcelButton.TabIndex = 8
        Me.SelectInsertHisDataExcelButton.Text = "选择文件"
        Me.SelectInsertHisDataExcelButton.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Button1)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 437)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(146, 78)
        Me.GroupBox8.TabIndex = 29
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "模型文件"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "合并txt"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog6
        '
        Me.OpenFileDialog6.Filter = "文本文件|*.txt"
        Me.OpenFileDialog6.Multiselect = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(680, 561)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AP-MASCOT接口管理工具"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ConnResult As System.Windows.Forms.TextBox
    Friend WithEvents TxtPort As System.Windows.Forms.TextBox
    Friend WithEvents TxtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdDisconn As System.Windows.Forms.Button
    Friend WithEvents CmdRemotConn As System.Windows.Forms.Button
    Friend WithEvents TextResult As System.Windows.Forms.TextBox
    Friend WithEvents SelectReadDataExcelButton As System.Windows.Forms.Button
    Friend WithEvents ReadHisDataButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DbCommOcxFC7 As AxDBCOMMOCXLibFC7.AxDbCommOcxFC7
    Friend WithEvents UpdateBoundariesButton As Button
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents GetBoundariesTagsButton As Button
    Friend WithEvents OpenFileDialog3 As OpenFileDialog
    Friend WithEvents GenerateBoundariesButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ReadRealTimeDataButton As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents UpdateManageDataButton As Button
    Friend WithEvents SelectManageExcelButton As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents OpenFileDialog4 As OpenFileDialog
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents AdminModeButton As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents OpenFileDialog5 As OpenFileDialog
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents InsertHisDataButton As Button
    Friend WithEvents SelectInsertHisDataExcelButton As Button
    Friend WithEvents InsertRealTimeData As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog6 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
