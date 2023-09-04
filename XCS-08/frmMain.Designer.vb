<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_currcounter = New System.Windows.Forms.Label()
        Me.Txt_Msg = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_msg = New System.Windows.Forms.Label()
        Me.lbl_plcip = New System.Windows.Forms.Label()
        Me.lbl_localip = New System.Windows.Forms.Label()
        Me.lbl_localhostname = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Barcode_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.RFID_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.lbl_WOnos = New System.Windows.Forms.Label()
        Me.lbl_currentref = New System.Windows.Forms.Label()
        Me.lbl_wocounter = New System.Windows.Forms.Label()
        Me.lbl_tagnos = New System.Windows.Forms.Label()
        Me.lbl_ArticleNos = New System.Windows.Forms.Label()
        Me.Btn_modbus = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Cmd_Refresh = New System.Windows.Forms.Button()
        Me.cmd_database = New System.Windows.Forms.Button()
        Me.cmd_material = New System.Windows.Forms.Button()
        Me.cmd_quit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Ethernet = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Ethernet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1015, 815)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 410
        Me.LineShape3.X2 = 410
        Me.LineShape3.Y1 = 125
        Me.LineShape3.Y2 = 800
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 926
        Me.LineShape2.X2 = 926
        Me.LineShape2.Y1 = 8
        Me.LineShape2.Y2 = 800
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 11
        Me.LineShape1.X2 = 915
        Me.LineShape1.Y1 = 116
        Me.LineShape1.Y2 = 116
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(65, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Wok Order Nos :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(23, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Wok Order Reference :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(67, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Wok Order Qty :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(76, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "RFID Tag Nos :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(92, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Article Nos :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(672, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(182, 56)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "SC       "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(77, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Qty Output :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_currcounter
        '
        Me.lbl_currcounter.AutoSize = True
        Me.lbl_currcounter.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_currcounter.ForeColor = System.Drawing.Color.Green
        Me.lbl_currcounter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_currcounter.Location = New System.Drawing.Point(109, 51)
        Me.lbl_currcounter.Name = "lbl_currcounter"
        Me.lbl_currcounter.Size = New System.Drawing.Size(51, 56)
        Me.lbl_currcounter.TabIndex = 12
        Me.lbl_currcounter.Text = "0"
        Me.lbl_currcounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_Msg
        '
        Me.Txt_Msg.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Txt_Msg.Location = New System.Drawing.Point(16, 187)
        Me.Txt_Msg.Multiline = True
        Me.Txt_Msg.Name = "Txt_Msg"
        Me.Txt_Msg.Size = New System.Drawing.Size(373, 169)
        Me.Txt_Msg.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 162)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "System Information"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 374)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Operator's Instruction"
        '
        'lbl_msg
        '
        Me.lbl_msg.AutoSize = True
        Me.lbl_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_msg.ForeColor = System.Drawing.Color.Red
        Me.lbl_msg.Location = New System.Drawing.Point(16, 403)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(333, 24)
        Me.lbl_msg.TabIndex = 17
        Me.lbl_msg.Text = "Please load the PCBA onto the cavity..."
        Me.lbl_msg.UseWaitCursor = True
        '
        'lbl_plcip
        '
        Me.lbl_plcip.AutoSize = True
        Me.lbl_plcip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_plcip.ForeColor = System.Drawing.Color.Green
        Me.lbl_plcip.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_plcip.Location = New System.Drawing.Point(59, 87)
        Me.lbl_plcip.Name = "lbl_plcip"
        Me.lbl_plcip.Size = New System.Drawing.Size(103, 15)
        Me.lbl_plcip.TabIndex = 21
        Me.lbl_plcip.Text = "PLC IP Address : "
        Me.lbl_plcip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_localip
        '
        Me.lbl_localip.AutoSize = True
        Me.lbl_localip.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_localip.ForeColor = System.Drawing.Color.Green
        Me.lbl_localip.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_localip.Location = New System.Drawing.Point(59, 72)
        Me.lbl_localip.Name = "lbl_localip"
        Me.lbl_localip.Size = New System.Drawing.Size(46, 15)
        Me.lbl_localip.TabIndex = 21
        Me.lbl_localip.Text = "local ip"
        Me.lbl_localip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_localhostname
        '
        Me.lbl_localhostname.AutoSize = True
        Me.lbl_localhostname.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_localhostname.ForeColor = System.Drawing.Color.Green
        Me.lbl_localhostname.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_localhostname.Location = New System.Drawing.Point(59, 57)
        Me.lbl_localhostname.Name = "lbl_localhostname"
        Me.lbl_localhostname.Size = New System.Drawing.Size(88, 15)
        Me.lbl_localhostname.TabIndex = 20
        Me.lbl_localhostname.Text = "localhost name"
        Me.lbl_localhostname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Green
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(59, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Connect"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(8, 603)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(169, 20)
        Me.TextBox4.TabIndex = 27
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        Me.Timer3.Interval = 3000
        '
        'Barcode_Comm
        '
        '
        'RFID_Comm
        '
        Me.RFID_Comm.BaudRate = 19200
        '
        'lbl_WOnos
        '
        Me.lbl_WOnos.AutoSize = True
        Me.lbl_WOnos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WOnos.ForeColor = System.Drawing.Color.Green
        Me.lbl_WOnos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_WOnos.Location = New System.Drawing.Point(182, 15)
        Me.lbl_WOnos.Name = "lbl_WOnos"
        Me.lbl_WOnos.Size = New System.Drawing.Size(12, 16)
        Me.lbl_WOnos.TabIndex = 1
        Me.lbl_WOnos.Text = "-"
        Me.lbl_WOnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_currentref
        '
        Me.lbl_currentref.AutoSize = True
        Me.lbl_currentref.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_currentref.ForeColor = System.Drawing.Color.Green
        Me.lbl_currentref.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_currentref.Location = New System.Drawing.Point(182, 31)
        Me.lbl_currentref.Name = "lbl_currentref"
        Me.lbl_currentref.Size = New System.Drawing.Size(12, 16)
        Me.lbl_currentref.TabIndex = 40
        Me.lbl_currentref.Text = "-"
        Me.lbl_currentref.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_wocounter
        '
        Me.lbl_wocounter.AutoSize = True
        Me.lbl_wocounter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wocounter.ForeColor = System.Drawing.Color.Green
        Me.lbl_wocounter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_wocounter.Location = New System.Drawing.Point(182, 47)
        Me.lbl_wocounter.Name = "lbl_wocounter"
        Me.lbl_wocounter.Size = New System.Drawing.Size(12, 16)
        Me.lbl_wocounter.TabIndex = 41
        Me.lbl_wocounter.Text = "-"
        Me.lbl_wocounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_tagnos
        '
        Me.lbl_tagnos.AutoSize = True
        Me.lbl_tagnos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tagnos.ForeColor = System.Drawing.Color.Green
        Me.lbl_tagnos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_tagnos.Location = New System.Drawing.Point(182, 63)
        Me.lbl_tagnos.Name = "lbl_tagnos"
        Me.lbl_tagnos.Size = New System.Drawing.Size(12, 16)
        Me.lbl_tagnos.TabIndex = 42
        Me.lbl_tagnos.Text = "-"
        Me.lbl_tagnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ArticleNos
        '
        Me.lbl_ArticleNos.AutoSize = True
        Me.lbl_ArticleNos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ArticleNos.ForeColor = System.Drawing.Color.Green
        Me.lbl_ArticleNos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_ArticleNos.Location = New System.Drawing.Point(182, 79)
        Me.lbl_ArticleNos.Name = "lbl_ArticleNos"
        Me.lbl_ArticleNos.Size = New System.Drawing.Size(12, 16)
        Me.lbl_ArticleNos.TabIndex = 43
        Me.lbl_ArticleNos.Text = "-"
        Me.lbl_ArticleNos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Btn_modbus
        '
        Me.Btn_modbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_modbus.Image = Global.XCS_08.My.Resources.Resources.test
        Me.Btn_modbus.Location = New System.Drawing.Point(935, 339)
        Me.Btn_modbus.Name = "Btn_modbus"
        Me.Btn_modbus.Size = New System.Drawing.Size(68, 65)
        Me.Btn_modbus.TabIndex = 44
        Me.Btn_modbus.Text = "Modbus"
        Me.Btn_modbus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_modbus.UseVisualStyleBackColor = True
        '
        'Command1
        '
        Me.Command1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.Image = Global.XCS_08.My.Resources.Resources.EYE
        Me.Command1.Location = New System.Drawing.Point(935, 734)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(68, 67)
        Me.Command1.TabIndex = 30
        Me.Command1.Text = "Eye Open"
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Command1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(253, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 169)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Cmd_Refresh
        '
        Me.Cmd_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Refresh.Image = Global.XCS_08.My.Resources.Resources.MISC05
        Me.Cmd_Refresh.Location = New System.Drawing.Point(935, 266)
        Me.Cmd_Refresh.Name = "Cmd_Refresh"
        Me.Cmd_Refresh.Size = New System.Drawing.Size(68, 67)
        Me.Cmd_Refresh.TabIndex = 10
        Me.Cmd_Refresh.Text = " Refresh"
        Me.Cmd_Refresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_Refresh.UseVisualStyleBackColor = True
        '
        'cmd_database
        '
        Me.cmd_database.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_database.Image = Global.XCS_08.My.Resources.Resources.spec
        Me.cmd_database.Location = New System.Drawing.Point(935, 138)
        Me.cmd_database.Name = "cmd_database"
        Me.cmd_database.Size = New System.Drawing.Size(68, 67)
        Me.cmd_database.TabIndex = 9
        Me.cmd_database.Text = "Material"
        Me.cmd_database.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_database.UseVisualStyleBackColor = True
        '
        'cmd_material
        '
        Me.cmd_material.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_material.Image = Global.XCS_08.My.Resources.Resources.debug
        Me.cmd_material.Location = New System.Drawing.Point(935, 74)
        Me.cmd_material.Name = "cmd_material"
        Me.cmd_material.Size = New System.Drawing.Size(68, 67)
        Me.cmd_material.TabIndex = 8
        Me.cmd_material.Text = "Rack"
        Me.cmd_material.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_material.UseVisualStyleBackColor = True
        '
        'cmd_quit
        '
        Me.cmd_quit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_quit.Image = Global.XCS_08.My.Resources.Resources.EXITWIN
        Me.cmd_quit.Location = New System.Drawing.Point(935, 9)
        Me.cmd_quit.Name = "cmd_quit"
        Me.cmd_quit.Size = New System.Drawing.Size(68, 67)
        Me.cmd_quit.TabIndex = 7
        Me.cmd_quit.Text = "Quit"
        Me.cmd_quit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_quit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(420, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 677)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(8, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(482, 547)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(8, 578)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(169, 20)
        Me.TextBox5.TabIndex = 28
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.lbl_msg)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Txt_Msg)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.lbl_currcounter)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(403, 677)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_ArticleNos)
        Me.GroupBox4.Controls.Add(Me.lbl_tagnos)
        Me.GroupBox4.Controls.Add(Me.lbl_wocounter)
        Me.GroupBox4.Controls.Add(Me.lbl_currentref)
        Me.GroupBox4.Controls.Add(Me.lbl_WOnos)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(906, 115)
        Me.GroupBox4.TabIndex = 49
        Me.GroupBox4.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_plcip)
        Me.GroupBox1.Controls.Add(Me.Ethernet)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lbl_localip)
        Me.GroupBox1.Controls.Add(Me.lbl_localhostname)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 505)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 120)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Ethernet
        '
        Me.Ethernet.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Ethernet.Location = New System.Drawing.Point(36, 37)
        Me.Ethernet.Name = "Ethernet"
        Me.Ethernet.Size = New System.Drawing.Size(17, 15)
        Me.Ethernet.TabIndex = 0
        Me.Ethernet.TabStop = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 815)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Btn_modbus)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Cmd_Refresh)
        Me.Controls.Add(Me.cmd_database)
        Me.Controls.Add(Me.cmd_material)
        Me.Controls.Add(Me.cmd_quit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Station 1 - Developed by SESEA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Ethernet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents LineShape3 As PowerPacks.LineShape
    Friend WithEvents LineShape2 As PowerPacks.LineShape
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmd_quit As Button
    Friend WithEvents cmd_material As Button
    Friend WithEvents cmd_database As Button
    Friend WithEvents Cmd_Refresh As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_currcounter As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Txt_Msg As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl_msg As Label
    Friend WithEvents lbl_plcip As Label
    Friend WithEvents lbl_localip As Label
    Friend WithEvents lbl_localhostname As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Command1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Barcode_Comm As IO.Ports.SerialPort
    Friend WithEvents RFID_Comm As IO.Ports.SerialPort
    Friend WithEvents lbl_WOnos As Label
    Friend WithEvents lbl_currentref As Label
    Friend WithEvents lbl_wocounter As Label
    Friend WithEvents lbl_tagnos As Label
    Friend WithEvents lbl_ArticleNos As Label
    Friend WithEvents Btn_modbus As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Ethernet As PictureBox
End Class
