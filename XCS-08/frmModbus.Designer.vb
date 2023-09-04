<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModbus
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.bDisconnect = New System.Windows.Forms.Button()
        Me.bRead = New System.Windows.Forms.Button()
        Me.bWrite = New System.Windows.Forms.Button()
        Me.Textip = New System.Windows.Forms.TextBox()
        Me.Textport = New System.Windows.Forms.TextBox()
        Me.Textaddress = New System.Windows.Forms.TextBox()
        Me.Textvalue = New System.Windows.Forms.TextBox()
        Me.Textnewval = New System.Windows.Forms.TextBox()
        Me.comboreg = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.bBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bConnect
        '
        Me.bConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConnect.Location = New System.Drawing.Point(76, 82)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(160, 42)
        Me.bConnect.TabIndex = 0
        Me.bConnect.Text = "Connect"
        Me.bConnect.UseVisualStyleBackColor = True
        '
        'bDisconnect
        '
        Me.bDisconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDisconnect.Location = New System.Drawing.Point(283, 82)
        Me.bDisconnect.Name = "bDisconnect"
        Me.bDisconnect.Size = New System.Drawing.Size(160, 42)
        Me.bDisconnect.TabIndex = 1
        Me.bDisconnect.Text = "Disconnect"
        Me.bDisconnect.UseVisualStyleBackColor = True
        '
        'bRead
        '
        Me.bRead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bRead.Location = New System.Drawing.Point(342, 225)
        Me.bRead.Name = "bRead"
        Me.bRead.Size = New System.Drawing.Size(99, 42)
        Me.bRead.TabIndex = 3
        Me.bRead.Text = "Read"
        Me.bRead.UseVisualStyleBackColor = True
        '
        'bWrite
        '
        Me.bWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bWrite.Location = New System.Drawing.Point(342, 273)
        Me.bWrite.Name = "bWrite"
        Me.bWrite.Size = New System.Drawing.Size(99, 42)
        Me.bWrite.TabIndex = 4
        Me.bWrite.Text = "Write"
        Me.bWrite.UseVisualStyleBackColor = True
        '
        'Textip
        '
        Me.Textip.Location = New System.Drawing.Point(76, 28)
        Me.Textip.Name = "Textip"
        Me.Textip.Size = New System.Drawing.Size(160, 20)
        Me.Textip.TabIndex = 5
        Me.Textip.Text = "127.0.0.1"
        '
        'Textport
        '
        Me.Textport.Location = New System.Drawing.Point(342, 28)
        Me.Textport.Name = "Textport"
        Me.Textport.Size = New System.Drawing.Size(81, 20)
        Me.Textport.TabIndex = 6
        Me.Textport.Text = "502"
        '
        'Textaddress
        '
        Me.Textaddress.Location = New System.Drawing.Point(161, 243)
        Me.Textaddress.Name = "Textaddress"
        Me.Textaddress.Size = New System.Drawing.Size(153, 20)
        Me.Textaddress.TabIndex = 7
        '
        'Textvalue
        '
        Me.Textvalue.Location = New System.Drawing.Point(161, 269)
        Me.Textvalue.Name = "Textvalue"
        Me.Textvalue.Size = New System.Drawing.Size(153, 20)
        Me.Textvalue.TabIndex = 8
        '
        'Textnewval
        '
        Me.Textnewval.Location = New System.Drawing.Point(161, 295)
        Me.Textnewval.Name = "Textnewval"
        Me.Textnewval.Size = New System.Drawing.Size(153, 20)
        Me.Textnewval.TabIndex = 9
        '
        'comboreg
        '
        Me.comboreg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboreg.FormattingEnabled = True
        Me.comboreg.Items.AddRange(New Object() {"Coil Outputs      (00000)", "Digital Inputs    (10000)", "Analogue Inputs   (30000)", "Holding Registers (40000)"})
        Me.comboreg.Location = New System.Drawing.Point(133, 202)
        Me.comboreg.Name = "comboreg"
        Me.comboreg.Size = New System.Drawing.Size(181, 21)
        Me.comboreg.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Server Ip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(300, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Port"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Reg Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(94, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(94, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Value"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(94, 298)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "New Value"
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(129, 164)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(120, 20)
        Me.lbl_status.TabIndex = 11
        Me.lbl_status.Text = " Not Connected"
        '
        'bBack
        '
        Me.bBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBack.Image = Global.XCS_08.My.Resources.Resources.ARW09LT
        Me.bBack.Location = New System.Drawing.Point(491, 49)
        Me.bBack.Name = "bBack"
        Me.bBack.Size = New System.Drawing.Size(86, 66)
        Me.bBack.TabIndex = 2
        Me.bBack.Text = "Back"
        Me.bBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bBack.UseVisualStyleBackColor = True
        '
        'FrmModbus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(592, 350)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboreg)
        Me.Controls.Add(Me.Textnewval)
        Me.Controls.Add(Me.Textvalue)
        Me.Controls.Add(Me.Textaddress)
        Me.Controls.Add(Me.Textport)
        Me.Controls.Add(Me.Textip)
        Me.Controls.Add(Me.bWrite)
        Me.Controls.Add(Me.bRead)
        Me.Controls.Add(Me.bBack)
        Me.Controls.Add(Me.bDisconnect)
        Me.Controls.Add(Me.bConnect)
        Me.Name = "FrmModbus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modbus"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bConnect As Button
    Friend WithEvents bDisconnect As Button
    Friend WithEvents bBack As Button
    Friend WithEvents bRead As Button
    Friend WithEvents bWrite As Button
    Friend WithEvents Textip As TextBox
    Friend WithEvents Textport As TextBox
    Friend WithEvents Textaddress As TextBox
    Friend WithEvents Textvalue As TextBox
    Friend WithEvents Textnewval As TextBox
    Friend WithEvents comboreg As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl_status As Label
End Class
