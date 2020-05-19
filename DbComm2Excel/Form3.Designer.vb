<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SetRealDataButton = New System.Windows.Forms.Button()
        Me.TextResult = New System.Windows.Forms.TextBox()
        Me.RealDataBox = New System.Windows.Forms.TextBox()
        Me.TagNameBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.SetRealDataButton)
        Me.GroupBox1.Controls.Add(Me.TextResult)
        Me.GroupBox1.Controls.Add(Me.RealDataBox)
        Me.GroupBox1.Controls.Add(Me.TagNameBox)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(356, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "设置实时数据"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "数据"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 21)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "点名+参数"
        '
        'SetRealDataButton
        '
        Me.SetRealDataButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SetRealDataButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SetRealDataButton.Font = New System.Drawing.Font("微软雅黑", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SetRealDataButton.Location = New System.Drawing.Point(232, 154)
        Me.SetRealDataButton.Margin = New System.Windows.Forms.Padding(5)
        Me.SetRealDataButton.Name = "SetRealDataButton"
        Me.SetRealDataButton.Size = New System.Drawing.Size(100, 45)
        Me.SetRealDataButton.TabIndex = 2
        Me.SetRealDataButton.Text = "设置数据"
        Me.SetRealDataButton.UseVisualStyleBackColor = True
        '
        'TextResult
        '
        Me.TextResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextResult.Location = New System.Drawing.Point(10, 136)
        Me.TextResult.Margin = New System.Windows.Forms.Padding(5)
        Me.TextResult.Multiline = True
        Me.TextResult.Name = "TextResult"
        Me.TextResult.Size = New System.Drawing.Size(197, 87)
        Me.TextResult.TabIndex = 4
        '
        'RealDataBox
        '
        Me.RealDataBox.Location = New System.Drawing.Point(113, 86)
        Me.RealDataBox.Margin = New System.Windows.Forms.Padding(5)
        Me.RealDataBox.Name = "RealDataBox"
        Me.RealDataBox.Size = New System.Drawing.Size(219, 29)
        Me.RealDataBox.TabIndex = 1
        '
        'TagNameBox
        '
        Me.TagNameBox.Location = New System.Drawing.Point(113, 32)
        Me.TagNameBox.Margin = New System.Windows.Forms.Padding(5)
        Me.TagNameBox.Name = "TagNameBox"
        Me.TagNameBox.Size = New System.Drawing.Size(219, 29)
        Me.TagNameBox.TabIndex = 0
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "实时数据"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SetRealDataButton As Button
    Friend WithEvents TextResult As TextBox
    Friend WithEvents RealDataBox As TextBox
    Friend WithEvents TagNameBox As TextBox
End Class
