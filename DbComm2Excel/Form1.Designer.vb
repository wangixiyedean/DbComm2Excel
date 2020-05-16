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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.DbCommOcxFC7 = New AxDBCOMMOCXLibFC7.AxDbCommOcxFC7()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 21)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "连接结果"
        '
        'ConnResult
        '
        Me.ConnResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.ConnResult.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ConnResult.Location = New System.Drawing.Point(130, 134)
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
        Me.TxtPort.Location = New System.Drawing.Point(130, 78)
        Me.TxtPort.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(140, 26)
        Me.TxtPort.TabIndex = 10
        Me.TxtPort.Text = "2006"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtIPAddress.Location = New System.Drawing.Point(130, 31)
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
        Me.Label2.Location = New System.Drawing.Point(26, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "端口"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 31)
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
        Me.CmdDisconn.Location = New System.Drawing.Point(19, 181)
        Me.CmdDisconn.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.CmdDisconn.Name = "CmdDisconn"
        Me.CmdDisconn.Size = New System.Drawing.Size(120, 50)
        Me.CmdDisconn.TabIndex = 5
        Me.CmdDisconn.Text = "关闭连接"
        Me.CmdDisconn.UseVisualStyleBackColor = True
        '
        'CmdRemotConn
        '
        Me.CmdRemotConn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdRemotConn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdRemotConn.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdRemotConn.Location = New System.Drawing.Point(164, 181)
        Me.CmdRemotConn.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.CmdRemotConn.Name = "CmdRemotConn"
        Me.CmdRemotConn.Size = New System.Drawing.Size(120, 50)
        Me.CmdRemotConn.TabIndex = 1
        Me.CmdRemotConn.Text = "远程连接"
        Me.CmdRemotConn.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 278)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(918, 238)
        Me.TextBox1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(42, 28)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 50)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "选择文件"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button2.Location = New System.Drawing.Point(42, 103)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 50)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "读取历史数据"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 530)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(918, 35)
        Me.ProgressBar1.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button3.Location = New System.Drawing.Point(36, 181)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(125, 50)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "写入边界点值"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button4.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button4.Location = New System.Drawing.Point(36, 103)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(125, 50)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "获取边界点名"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button5.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button5.Location = New System.Drawing.Point(36, 28)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(125, 50)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "生成边界点表"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'DbCommOcxFC7
        '
        Me.DbCommOcxFC7.Enabled = True
        Me.DbCommOcxFC7.Location = New System.Drawing.Point(80, 106)
        Me.DbCommOcxFC7.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.DbCommOcxFC7.Name = "DbCommOcxFC7"
        Me.DbCommOcxFC7.OcxState = CType(resources.GetObject("DbCommOcxFC7.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DbCommOcxFC7.Size = New System.Drawing.Size(32, 32)
        Me.DbCommOcxFC7.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPort)
        Me.GroupBox1.Controls.Add(Me.CmdRemotConn)
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
        Me.GroupBox1.Size = New System.Drawing.Size(300, 250)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "连接属性"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(730, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(200, 250)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "读取数据"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button6.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button6.Location = New System.Drawing.Point(42, 181)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(120, 50)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "读取实时数据"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(318, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox3.Size = New System.Drawing.Size(200, 250)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "边界数值"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DbCommOcxFC7)
        Me.GroupBox4.Location = New System.Drawing.Point(524, 15)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 250)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "经营数值"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(944, 581)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AP-MASCOT接口管理工具"
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ConnResult As System.Windows.Forms.TextBox
    Friend WithEvents TxtPort As System.Windows.Forms.TextBox
    Friend WithEvents TxtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdDisconn As System.Windows.Forms.Button
    Friend WithEvents CmdRemotConn As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DbCommOcxFC7 As AxDBCOMMOCXLibFC7.AxDbCommOcxFC7
    Friend WithEvents Button3 As Button
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents Button4 As Button
    Friend WithEvents OpenFileDialog3 As OpenFileDialog
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents GroupBox4 As GroupBox
End Class
