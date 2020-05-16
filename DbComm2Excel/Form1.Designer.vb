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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 107)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "连接结果"
        '
        'ConnResult
        '
        Me.ConnResult.Location = New System.Drawing.Point(97, 107)
        Me.ConnResult.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.ConnResult.Name = "ConnResult"
        Me.ConnResult.ReadOnly = True
        Me.ConnResult.Size = New System.Drawing.Size(108, 21)
        Me.ConnResult.TabIndex = 9
        Me.ConnResult.Text = "NoLink"
        '
        'TxtPort
        '
        Me.TxtPort.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtPort.Location = New System.Drawing.Point(97, 63)
        Me.TxtPort.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(108, 23)
        Me.TxtPort.TabIndex = 10
        Me.TxtPort.Text = "2006"
        '
        'TxtIPAddress
        '
        Me.TxtIPAddress.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtIPAddress.Location = New System.Drawing.Point(97, 23)
        Me.TxtIPAddress.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtIPAddress.Name = "TxtIPAddress"
        Me.TxtIPAddress.Size = New System.Drawing.Size(108, 23)
        Me.TxtIPAddress.TabIndex = 11
        Me.TxtIPAddress.Text = "192.168.154.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "端口"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "IP地址"
        '
        'CmdDisconn
        '
        Me.CmdDisconn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdDisconn.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdDisconn.Location = New System.Drawing.Point(25, 147)
        Me.CmdDisconn.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.CmdDisconn.Name = "CmdDisconn"
        Me.CmdDisconn.Size = New System.Drawing.Size(80, 40)
        Me.CmdDisconn.TabIndex = 5
        Me.CmdDisconn.Text = "关闭连接"
        Me.CmdDisconn.UseVisualStyleBackColor = True
        '
        'CmdRemotConn
        '
        Me.CmdRemotConn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdRemotConn.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdRemotConn.Location = New System.Drawing.Point(127, 147)
        Me.CmdRemotConn.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.CmdRemotConn.Name = "CmdRemotConn"
        Me.CmdRemotConn.Size = New System.Drawing.Size(80, 40)
        Me.CmdRemotConn.TabIndex = 4
        Me.CmdRemotConn.Text = "远程连接"
        Me.CmdRemotConn.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(10, 219)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(565, 197)
        Me.TextBox1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(27, 23)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 35)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "选择文件"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(27, 83)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 35)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "读取历史数据"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Excel表格|*.xlsx;*.xls;*.csv"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 424)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(565, 24)
        Me.ProgressBar1.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(33, 147)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 35)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "写入边界点值"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(33, 83)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(98, 35)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "获取边界点名"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog3"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(33, 23)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(98, 35)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "生成边界点表"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'DbCommOcxFC7
        '
        Me.DbCommOcxFC7.Enabled = True
        Me.DbCommOcxFC7.Location = New System.Drawing.Point(307, 246)
        Me.DbCommOcxFC7.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
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
        Me.GroupBox1.Location = New System.Drawing.Point(176, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 200)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "连接属性"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(411, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(161, 200)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "读取数据"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 200)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "边界数值"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(27, 147)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(98, 35)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "读取实时数据"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.DbCommOcxFC7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DbComm2Excel"
        CType(Me.DbCommOcxFC7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
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
End Class
