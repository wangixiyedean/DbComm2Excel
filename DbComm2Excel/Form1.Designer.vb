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
        Me.ConnResultLabel = New System.Windows.Forms.Label()
        Me.ConnResult = New System.Windows.Forms.TextBox()
        Me.TxtPort = New System.Windows.Forms.TextBox()
        Me.TxtIPAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdDisconn = New System.Windows.Forms.Button()
        Me.CmdRemotConn = New System.Windows.Forms.Button()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.ReadDataOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.InsertBoundariesOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BoundariesTagOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DbCommOcxFC7 = New AxDBCOMMOCXLibFC7.AxDbCommOcxFC7()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ManageFileOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.InsertDataOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ModelConvOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ModelCsvSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PMReadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectReadDataFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadHisDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadRTDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PMInsertDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectInsertDataFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertHisDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertRTDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateBoundariesDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateBoundariesTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertBoundariesDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectManageFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertManageDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PMMdlConvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateMdlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveAdminModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminModeActivatedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConnResultLabel
        '
        Me.ConnResultLabel.AutoSize = True
        Me.ConnResultLabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ConnResultLabel.Location = New System.Drawing.Point(215, 26)
        Me.ConnResultLabel.Name = "ConnResultLabel"
        Me.ConnResultLabel.Size = New System.Drawing.Size(56, 21)
        Me.ConnResultLabel.TabIndex = 12
        Me.ConnResultLabel.Text = "Result"
        '
        'ConnResult
        '
        Me.ConnResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConnResult.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ConnResult.Location = New System.Drawing.Point(295, 23)
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
        Me.TxtPort.Location = New System.Drawing.Point(69, 74)
        Me.TxtPort.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(140, 26)
        Me.TxtPort.TabIndex = 10
        Me.TxtPort.Text = "2006"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtIPAddress.Location = New System.Drawing.Point(69, 26)
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
        Me.Label2.Location = New System.Drawing.Point(6, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "IP"
        '
        'CmdDisconn
        '
        Me.CmdDisconn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdDisconn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdDisconn.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdDisconn.Location = New System.Drawing.Point(235, 67)
        Me.CmdDisconn.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.CmdDisconn.Name = "CmdDisconn"
        Me.CmdDisconn.Size = New System.Drawing.Size(86, 35)
        Me.CmdDisconn.TabIndex = 1
        Me.CmdDisconn.Text = "Disconn"
        Me.CmdDisconn.UseVisualStyleBackColor = True
        '
        'CmdRemotConn
        '
        Me.CmdRemotConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdRemotConn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdRemotConn.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdRemotConn.Location = New System.Drawing.Point(349, 67)
        Me.CmdRemotConn.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.CmdRemotConn.Name = "CmdRemotConn"
        Me.CmdRemotConn.Size = New System.Drawing.Size(86, 35)
        Me.CmdRemotConn.TabIndex = 0
        Me.CmdRemotConn.Text = "Remote"
        Me.CmdRemotConn.UseVisualStyleBackColor = True
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Font = New System.Drawing.Font("微软雅黑", 10.0!)
        Me.OutputTextBox.Location = New System.Drawing.Point(9, 26)
        Me.OutputTextBox.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.OutputTextBox.Multiline = True
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.OutputTextBox.Size = New System.Drawing.Size(435, 253)
        Me.OutputTextBox.TabIndex = 13
        '
        'ReadDataOpenFileDialog
        '
        Me.ReadDataOpenFileDialog.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 466)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(450, 25)
        Me.ProgressBar1.TabIndex = 16
        '
        'InsertBoundariesOpenFileDialog
        '
        Me.InsertBoundariesOpenFileDialog.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'BoundariesTagOpenFileDialog
        '
        Me.BoundariesTagOpenFileDialog.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
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
        Me.GroupBox1.Controls.Add(Me.ConnResultLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox1.Size = New System.Drawing.Size(450, 122)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connect"
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.OutputTextBox)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 165)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(450, 291)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Output"
        '
        'ManageFileOpenFileDialog
        '
        Me.ManageFileOpenFileDialog.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'InsertDataOpenFileDialog
        '
        Me.InsertDataOpenFileDialog.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'ModelConvOpenFileDialog
        '
        Me.ModelConvOpenFileDialog.Filter = "文本文件|*.txt"
        Me.ModelConvOpenFileDialog.Multiselect = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PMReadDataToolStripMenuItem, Me.PMInsertDataToolStripMenuItem, Me.PMToolStripMenuItem, Me.PMMdlConvToolStripMenuItem, Me.AdminModeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(474, 28)
        Me.MenuStrip1.TabIndex = 30
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PMReadDataToolStripMenuItem
        '
        Me.PMReadDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectReadDataFileToolStripMenuItem, Me.ReadHisDataToolStripMenuItem, Me.ReadRTDataToolStripMenuItem})
        Me.PMReadDataToolStripMenuItem.Name = "PMReadDataToolStripMenuItem"
        Me.PMReadDataToolStripMenuItem.Size = New System.Drawing.Size(91, 24)
        Me.PMReadDataToolStripMenuItem.Text = "ReadData"
        '
        'SelectReadDataFileToolStripMenuItem
        '
        Me.SelectReadDataFileToolStripMenuItem.Image = CType(resources.GetObject("SelectReadDataFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectReadDataFileToolStripMenuItem.Name = "SelectReadDataFileToolStripMenuItem"
        Me.SelectReadDataFileToolStripMenuItem.Size = New System.Drawing.Size(171, 24)
        Me.SelectReadDataFileToolStripMenuItem.Text = "SelectFile"
        '
        'ReadHisDataToolStripMenuItem
        '
        Me.ReadHisDataToolStripMenuItem.Image = CType(resources.GetObject("ReadHisDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReadHisDataToolStripMenuItem.Name = "ReadHisDataToolStripMenuItem"
        Me.ReadHisDataToolStripMenuItem.Size = New System.Drawing.Size(171, 24)
        Me.ReadHisDataToolStripMenuItem.Text = "ReadHisData"
        '
        'ReadRTDataToolStripMenuItem
        '
        Me.ReadRTDataToolStripMenuItem.Image = CType(resources.GetObject("ReadRTDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReadRTDataToolStripMenuItem.Name = "ReadRTDataToolStripMenuItem"
        Me.ReadRTDataToolStripMenuItem.Size = New System.Drawing.Size(171, 24)
        Me.ReadRTDataToolStripMenuItem.Text = "ReadRTData"
        '
        'PMInsertDataToolStripMenuItem
        '
        Me.PMInsertDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectInsertDataFileToolStripMenuItem, Me.InsertHisDataToolStripMenuItem, Me.InsertRTDataToolStripMenuItem})
        Me.PMInsertDataToolStripMenuItem.Name = "PMInsertDataToolStripMenuItem"
        Me.PMInsertDataToolStripMenuItem.Size = New System.Drawing.Size(95, 24)
        Me.PMInsertDataToolStripMenuItem.Text = "InsertData"
        '
        'SelectInsertDataFileToolStripMenuItem
        '
        Me.SelectInsertDataFileToolStripMenuItem.Image = CType(resources.GetObject("SelectInsertDataFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectInsertDataFileToolStripMenuItem.Name = "SelectInsertDataFileToolStripMenuItem"
        Me.SelectInsertDataFileToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.SelectInsertDataFileToolStripMenuItem.Text = "SelectFile"
        '
        'InsertHisDataToolStripMenuItem
        '
        Me.InsertHisDataToolStripMenuItem.Enabled = False
        Me.InsertHisDataToolStripMenuItem.Image = CType(resources.GetObject("InsertHisDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsertHisDataToolStripMenuItem.Name = "InsertHisDataToolStripMenuItem"
        Me.InsertHisDataToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.InsertHisDataToolStripMenuItem.Text = "InsertHisData"
        '
        'InsertRTDataToolStripMenuItem
        '
        Me.InsertRTDataToolStripMenuItem.Enabled = False
        Me.InsertRTDataToolStripMenuItem.Image = CType(resources.GetObject("InsertRTDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsertRTDataToolStripMenuItem.Name = "InsertRTDataToolStripMenuItem"
        Me.InsertRTDataToolStripMenuItem.Size = New System.Drawing.Size(175, 24)
        Me.InsertRTDataToolStripMenuItem.Text = "InsertRTData"
        '
        'PMToolStripMenuItem
        '
        Me.PMToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateBoundariesDataToolStripMenuItem, Me.GenerateBoundariesTagsToolStripMenuItem, Me.InsertBoundariesDataToolStripMenuItem, Me.SelectManageFileToolStripMenuItem, Me.InsertManageDataToolStripMenuItem})
        Me.PMToolStripMenuItem.Name = "PMToolStripMenuItem"
        Me.PMToolStripMenuItem.Size = New System.Drawing.Size(61, 24)
        Me.PMToolStripMenuItem.Text = "Tools"
        '
        'GenerateBoundariesDataToolStripMenuItem
        '
        Me.GenerateBoundariesDataToolStripMenuItem.Image = CType(resources.GetObject("GenerateBoundariesDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GenerateBoundariesDataToolStripMenuItem.Name = "GenerateBoundariesDataToolStripMenuItem"
        Me.GenerateBoundariesDataToolStripMenuItem.Size = New System.Drawing.Size(260, 24)
        Me.GenerateBoundariesDataToolStripMenuItem.Text = "GenerateBoundariesData"
        '
        'GenerateBoundariesTagsToolStripMenuItem
        '
        Me.GenerateBoundariesTagsToolStripMenuItem.Image = CType(resources.GetObject("GenerateBoundariesTagsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GenerateBoundariesTagsToolStripMenuItem.Name = "GenerateBoundariesTagsToolStripMenuItem"
        Me.GenerateBoundariesTagsToolStripMenuItem.Size = New System.Drawing.Size(260, 24)
        Me.GenerateBoundariesTagsToolStripMenuItem.Text = "GenerateBoundariesTags"
        '
        'InsertBoundariesDataToolStripMenuItem
        '
        Me.InsertBoundariesDataToolStripMenuItem.Enabled = False
        Me.InsertBoundariesDataToolStripMenuItem.Image = CType(resources.GetObject("InsertBoundariesDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsertBoundariesDataToolStripMenuItem.Name = "InsertBoundariesDataToolStripMenuItem"
        Me.InsertBoundariesDataToolStripMenuItem.Size = New System.Drawing.Size(260, 24)
        Me.InsertBoundariesDataToolStripMenuItem.Text = "InsertBoundariesData"
        '
        'SelectManageFileToolStripMenuItem
        '
        Me.SelectManageFileToolStripMenuItem.Image = CType(resources.GetObject("SelectManageFileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SelectManageFileToolStripMenuItem.Name = "SelectManageFileToolStripMenuItem"
        Me.SelectManageFileToolStripMenuItem.Size = New System.Drawing.Size(260, 24)
        Me.SelectManageFileToolStripMenuItem.Text = "SelectManageFile"
        '
        'InsertManageDataToolStripMenuItem
        '
        Me.InsertManageDataToolStripMenuItem.Enabled = False
        Me.InsertManageDataToolStripMenuItem.Image = CType(resources.GetObject("InsertManageDataToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InsertManageDataToolStripMenuItem.Name = "InsertManageDataToolStripMenuItem"
        Me.InsertManageDataToolStripMenuItem.Size = New System.Drawing.Size(260, 24)
        Me.InsertManageDataToolStripMenuItem.Text = "InsertManageData"
        '
        'PMMdlConvToolStripMenuItem
        '
        Me.PMMdlConvToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateMdlToolStripMenuItem})
        Me.PMMdlConvToolStripMenuItem.Name = "PMMdlConvToolStripMenuItem"
        Me.PMMdlConvToolStripMenuItem.Size = New System.Drawing.Size(87, 24)
        Me.PMMdlConvToolStripMenuItem.Text = "MdlConv"
        '
        'GenerateMdlToolStripMenuItem
        '
        Me.GenerateMdlToolStripMenuItem.Image = CType(resources.GetObject("GenerateMdlToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GenerateMdlToolStripMenuItem.Name = "GenerateMdlToolStripMenuItem"
        Me.GenerateMdlToolStripMenuItem.Size = New System.Drawing.Size(174, 24)
        Me.GenerateMdlToolStripMenuItem.Text = "GenerateMdl"
        '
        'AdminModeToolStripMenuItem
        '
        Me.AdminModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiveAdminModeToolStripMenuItem, Me.AdminModeActivatedToolStripMenuItem})
        Me.AdminModeToolStripMenuItem.Name = "AdminModeToolStripMenuItem"
        Me.AdminModeToolStripMenuItem.Size = New System.Drawing.Size(113, 24)
        Me.AdminModeToolStripMenuItem.Text = "AdminMode"
        '
        'ActiveAdminModeToolStripMenuItem
        '
        Me.ActiveAdminModeToolStripMenuItem.Image = CType(resources.GetObject("ActiveAdminModeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActiveAdminModeToolStripMenuItem.Name = "ActiveAdminModeToolStripMenuItem"
        Me.ActiveAdminModeToolStripMenuItem.Size = New System.Drawing.Size(240, 24)
        Me.ActiveAdminModeToolStripMenuItem.Text = "ActiveAdminMode"
        '
        'AdminModeActivatedToolStripMenuItem
        '
        Me.AdminModeActivatedToolStripMenuItem.Enabled = False
        Me.AdminModeActivatedToolStripMenuItem.Image = CType(resources.GetObject("AdminModeActivatedToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdminModeActivatedToolStripMenuItem.Name = "AdminModeActivatedToolStripMenuItem"
        Me.AdminModeActivatedToolStripMenuItem.Size = New System.Drawing.Size(240, 24)
        Me.AdminModeActivatedToolStripMenuItem.Text = "AdminModeActivated"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(474, 501)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AP-MASCOT接口管理工具"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnResultLabel As System.Windows.Forms.Label
    Friend WithEvents ConnResult As System.Windows.Forms.TextBox
    Friend WithEvents TxtPort As System.Windows.Forms.TextBox
    Friend WithEvents TxtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdDisconn As System.Windows.Forms.Button
    Friend WithEvents CmdRemotConn As System.Windows.Forms.Button
    Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ReadDataOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DbCommOcxFC7 As AxDBCOMMOCXLibFC7.AxDbCommOcxFC7
    Friend WithEvents InsertBoundariesOpenFileDialog As OpenFileDialog
    Friend WithEvents BoundariesTagOpenFileDialog As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents ManageFileOpenFileDialog As OpenFileDialog
    Friend WithEvents InsertDataOpenFileDialog As OpenFileDialog
    Friend WithEvents ModelConvOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ModelCsvSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PMReadDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PMMdlConvToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveAdminModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectReadDataFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadHisDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReadRTDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PMInsertDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectInsertDataFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertHisDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertRTDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateBoundariesDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateBoundariesTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertBoundariesDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectManageFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertManageDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateMdlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminModeActivatedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
