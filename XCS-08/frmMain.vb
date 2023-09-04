Imports System.IO
Imports System.Threading
Imports System.Net
Imports EasyModbus

Public Class FrmMain

    Dim ModbusQuery(11) As Byte 'Buffer used by Winsock to prepare data before sending
    Dim ModbusByteArray(1024) As Byte
    Dim ModbusReceive As Boolean
    Dim ReadInputs As Boolean
    Dim DataReceiveComplete As Boolean

    Dim BitTests(7) As Byte
    Dim ReadWord(500) As Long
    Dim W300(10) As Long '%MW300~%MW307
    Dim ErrorIndexNumber As Integer
    Dim MW200(9) As Double
    Dim BoardCount As Integer
    Dim PCBAFLAG(5) As Boolean

    Dim SendAck As String
    Dim Write2PLC As Boolean
    Dim AssyBuf As String
    Dim BarcodeRead As String
    Dim ReadTagFlag As Boolean
    Dim SlideCount As Integer

    Dim ReTryScan As Integer
    Dim CheckWO As String
    Dim EnableCount As Boolean

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SlideCount = 1
        Timer3.Enabled = True

        Dim fullPath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim projectFolder As String = fullPath.Replace("\XCS-08\bin\Debug\", "").Replace("\XCS-08\bin\Release\", "")

        If Dir(projectFolder & "\Config\Config.INI") = "" Then
            MsgBox("Config.INI is missing")
            End
        End If

        If Dir(projectFolder & "\Setup\Setup.INI") = "" Then
            MsgBox("Setup.INI is missing")
            End
        End If
        ReadINI(projectFolder & "\Config\Config.INI")


        GetLastConfig()

        FrmMsg.Show()
        FrmMsg.Label1.Text = "Establishing connection with PLC..."
        FrmModbus.Show()
        FrmModbus.Hide()

        If FrmModbus.lbl_status.Text <> "Connected" Then
            Ethernet.BackColor = Color.Red
            Exit Sub
        End If
        FrmMsg.Label1.Text = "Connection to PLC established"
        FrmMsg.Hide()
        Ethernet.BackColor = Color.Green

        Dim strHostName As String = Dns.GetHostName()
        Dim hostname As IPHostEntry = Dns.GetHostByName(strHostName)
        Dim ip As IPAddress() = hostname.AddressList
        lbl_localhostname.Text = "PC Name : " & strHostName
        lbl_localip.Text = "PC IP Address : " & ip(0).ToString

        Thread.Sleep(10)
        Reset_PLC()
        FrmMsg.Label1.Text = "Loading parameters..."

        If Not LoadParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load parameters...")
            End
        End If
        If Not LoadParameterToPLC() Then
            MsgBox("Unable to communicate with PLC...")
            End
        End If

        lbl_WOnos.Text = LoadWOfrRFID.JobNos
        lbl_currentref.Text = LoadWOfrRFID.JobModelName
        lbl_wocounter.Text = CStr(LoadWOfrRFID.JobQTy)
        lbl_currcounter.Text = CStr(LoadWOfrRFID.JobUnitaryCount)
        lbl_tagnos.Text = LoadWOfrRFID.JobRFIDTag
        lbl_ArticleNos.Text = LoadWOfrRFID.JobArticle

        'Load Rack Material List
        If Not LoadRackMaterial() Then
            MsgBox("Unable to load Rack Materials")
            End
        End If

        'Load Model Material
        If Not LoadModelMaterial(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Model Material")
            End
        End If
        FrmMsg.Label1.Text = "Refreshing indicators..."

        'Update Rack indicator
        If Not ActivateRackLED() Then
            MsgBox("Unable to communicate with PLC")
            End
        End If


        'RFID_Comm.Open()
        'Barcode_Comm.Open()
        FrmMsg.Close()
        'Timer1.Enabled = True


    End Sub

    Private Function ActivateRackLED() As Boolean
        Dim i As Integer
        Dim N As Integer

        For i = 0 To LoadWOfrRFID.JobModelMaterial.Length - 1
            If LoadWOfrRFID.JobModelMaterial(i) <> "" Then
                For N = 0 To Unitmaterial.PartNos.Length - 1
                    If LoadWOfrRFID.JobModelMaterial(i) = Unitmaterial.PartNos(N) Then
                        If Not FrmModbus.Tulismodbus(Unitmaterial.PartPLCWord(N), 1) Then
                            GoTo ErrorHandler
                        End If
                    End If
                Next
            End If
        Next

        Return True
        Exit Function
ErrorHandler:
        Return False
    End Function

    Private Function LoadParameter(csmodel As String) As Boolean
        Try
            Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & csmodel & "'"
            Dim dt = Connection.ReadData(query).Tables(0)

            LoadWOfrRFID.JobArticle = dt.Rows(0).Item("ArticleNos")
            LoadWOfrRFID.JobModelFW = dt.Rows(0).Item("ProductVer")
            LoadWOfrRFID.JobProductMaterial = dt.Rows(0).Item("MaterialType")

            Return True
            Exit Function
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function LoadParameterToPLC() As Boolean
        If LoadWOfrRFID.JobProductMaterial = "Zamak" Then
            If Not FrmModbus.Tulismodbus(40100, 1) Then
                Return False
                Exit Function
            End If
        Else
            If Not FrmModbus.Tulismodbus(40100, 0) Then
                Return False
                Exit Function
            End If
        End If

        FrmModbus.Tulismodbus(40600, 1)
        Return True
        Exit Function
    End Function

    Private Function LoadModelMaterial(Unitname As String) As Boolean
        Dim filePath As String = INIMATERIALPATH & "\Station1\" & Unitname & ".Txt"

        If File.Exists(filePath) Then
            Dim lines As String() = File.ReadAllLines(filePath)
            Dim lineArray As New List(Of String)()

            For Each line As String In lines
                lineArray.Add(line)
            Next
            LoadWOfrRFID.JobModelMaterial = lineArray.ToArray()
            Return True
        Else
            Return False
        End If
    End Function

    Private Function LoadRackMaterial() As Boolean
        Dim filePath As String = INIMATERIALPATH & "Rack\" & "Station1"

        If File.Exists(filePath) Then
            Dim lines As String() = File.ReadAllLines(filePath)
            Dim lineArray As New List(Of String)()

            For Each line As String In lines
                lineArray.Add(line)
            Next
            Unitmaterial.PartNos = lineArray.ToArray()

            ReDim Unitmaterial.PartPLCWord(lines.Length - 1)
            For i As Integer = 0 To lines.Length - 1
                Unitmaterial.PartPLCWord(i) = 40200 + i
            Next

            Return True
        Else
            Return False
        End If
    End Function

    Private Function ValidiateWONos(strName As String) As String

        Try
            Dim temp As String
            Dim query = "SELECT * FROM TESE.dbo.CSUNIT WHERE WONOS = '" & strName & "'"
            Dim dt = Connection.ReadData(query).Tables(0)

            temp = dt.Rows(0).Item("STATUS")
            Return temp
        Catch ex As Exception
            Return "NOK"
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Tagref As String
        Dim Tagnos As String
        Dim TagQty As String
        Dim Tagid As String

        Ethernet.BackColor = Color.Black
        ReadTagFlag = True
        Tagnos = RD_MULTI_RFID("0000", 10)

        If Tagnos = "NOK" Then GoTo NoChange
        Tagid = RD_MULTI_RFID("0040", 3) 'Read Tag ID
        Dim CheckWO As String
        If Tagnos = "MASTER" Then
            If Tagid = lbl_tagnos.Text Then GoTo NoChange
            If lbl_WOnos.Text <> "MASTER" Then
                'update the Current WO into the database before changing
                If CheckWOExist((lbl_WOnos.Text)) Then
                    UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                Else
                    AddWO((lbl_WOnos.Text))
                    UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                End If
                GoTo WOChange
            ElseIf lbl_WOnos.Text = "MASTER" Then
                GoTo WOChange
            End If
        ElseIf Tagnos <> LoadWOfrRFID.JobNos Then
Master:
            If lbl_WOnos.Text <> "MASTER" Then
                'Checking Current WO first b4 Change Series is allowed. If WO status is open, check Quantity
                CheckWO = ValidiateWONos(lbl_WOnos.Text)
                If CheckWO = "NOK" Then
                    Txt_Msg.Text = "Invalid WO - WO is not registered in Server"
                    GoTo NoChange
                ElseIf CheckWO = "OPEN" Then

                ElseIf CheckWO = "CLOSED" Then

                ElseIf CheckWO = "FORCED" Then

                ElseIf CheckWO = "DISTRUP" Then

                End If
                'update the Current WO into the database before changing
                If CheckWOExist(lbl_WOnos.Text) Then
                    Call UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                Else
                    Call AddWO(lbl_WOnos.Text)
                    Call UpdateWO(lbl_WOnos.Text, lbl_currcounter.Text)
                End If
            End If
WOChange:
            Txt_Msg.Text = "Changing Series..." & vbCrLf
            Txt_Msg.Text = Txt_Msg.Text & "Reading info from RFID Tag..." & vbCrLf
            LoadWOfrRFID.JobNos = Tagnos
            Tagref = RD_MULTI_RFID("0014", 10) 'Read WO Reference from Tag
            If Tagref = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            TagQty = RD_MULTI_RFID("0028", 10) 'Read WO Qty from Tag
            If TagQty = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            Tagid = RD_MULTI_RFID("0040", 3) 'Read Tag ID
            If Tagid = "NOK" Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to read from RFID Tag" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            'Check if reference is valid from the database
            If Not RefCheck(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Invalid Reference" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            Txt_Msg.Text = Txt_Msg.Text & "loading parameters of new reference..." & vbCrLf
            If Not LoadModelMaterial(Tagref) Then
                Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load Model parameter" & vbCrLf
                Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                ReadTagFlag = False
                Exit Sub
            End If
            'Load parameters
            Txt_Msg.Text = Txt_Msg.Text & "loading parameters to PLC..." & vbCrLf
            If Not LoadParameter(Tagref) Then
                MsgBox("Unable to load parameters...")
                End
            End If
            If Not LoadParameterToPLC() Then
                MsgBox("Unable to communicate with PLC...")
                End
            End If
            Reset_PLC()
                If Not ActivateRackLED() Then
                    Txt_Msg.Text = Txt_Msg.Text & "--> Unable to communicate with PLC" & vbCrLf
                    Txt_Msg.Text = Txt_Msg.Text & "--> Change Series fail" & vbCrLf
                    ReadTagFlag = False
                    Exit Sub
                End If

                lbl_WOnos.Text = Tagnos
                LoadWOfrRFID.JobNos = Tagnos
                lbl_currentref.Text = Tagref
                LoadWOfrRFID.JobModelName = Tagref
                lbl_wocounter.Text = TagQty
                LoadWOfrRFID.JobQTy = CShort(TagQty)
                lbl_tagnos.Text = Tagid
                LoadWOfrRFID.JobRFIDTag = Tagid
                lbl_ArticleNos.Text = LoadWOfrRFID.JobArticle

                If Tagnos <> "MASTER" Then
                    If CheckWOExist(Tagnos) Then
                        LoadWOfrRFID.JobUnitaryCount = Val(RetrieveWOQty(Tagnos))
                        lbl_currcounter.Text = CStr(LoadWOfrRFID.JobUnitaryCount)
                    Else
                        Call AddWO(Tagnos)
                        LoadWOfrRFID.JobUnitaryCount = 0 'Reset output counter
                        lbl_currcounter.Text = "0"
                    End If
                Else
                    lbl_currcounter.Text = "0"
                    LoadWOfrRFID.JobUnitaryCount = 0
                End If


                UpdateStnStatus()
                Txt_Msg.Text = Txt_Msg.Text & "Change Series completed" & vbCrLf
                'ErasePSNFileInfo() 'clearing all variable
                PSNFileInfo.ModelName = LoadWOfrRFID.JobModelName
                PSNFileInfo.WONos = LoadWOfrRFID.JobNos
            End If
            ReadTagFlag = False

NoChange:
        Dim Station_status As Integer
        Dim Failcode As Integer
        Dim Verifydata As String
        Dim Verifypsn As String

        Station_status = FrmModbus.Bacamodbus(40101)
        TextBox4.Text = CStr(Station_status)
        Ethernet.BackColor = Color.Lime
        Select Case Station_status
            Case 0 'Waiting for new product
                lbl_msg.Text = "Please scan the PSN barcode..."
            Case 1 'PSN scan and verified, waiting for start button to be depressed
                lbl_msg.Text = "Please load product and start process..."
            Case 2 'Testing in progress
                PictureBox1.Image = Nothing
                Txt_Msg.BackColor = System.Drawing.ColorTranslator.FromOle(&HE0E0E0)
                lbl_msg.Text = "Please wait, in progress..."
                If Command1.Text = "Eye Close" Then
                    Txt_Msg.Text = ""
                End If
                Label10.Text = CStr(FrmModbus.Bacamodbus(40400))
                Label9.Text = RFID.Dec2Bin(CDbl(Label10.Text))
            Case 3 'Testing completed, waiting for screwing sequence to be completed
                lbl_msg.Text = "Please proceed with the screwing process..."
            Case 4 'PLC inform PC about completion of process, read test outcome
                If FrmModbus.Bacamodbus(40102) = 1 Then 'Pass
                    EnableCount = False
                    If PSNFileInfo.ScrewStnStatus = "" Or PSNFileInfo.ScrewStnStatus = "FAIL" Then
                        EnableCount = True
                    End If
                    PSNFileInfo.ScrewStnStatus = "PASS"
                    PictureBox1.Image = Image.FromFile(INIPHOTOPATH & "\Icons\Pass.gif")
                Else 'Fail
                    PSNFileInfo.ScrewStnStatus = "FAIL"
                    PictureBox1.Image = Image.FromFile(INIPHOTOPATH & "\Icons\Fail.gif")
                    Txt_Msg.BackColor = System.Drawing.Color.Red

                    Failcode = FrmModbus.Bacamodbus(40110)
                    If Failcode = 5 Then
                        Txt_Msg.Text = "--> Mis-Match of Head and Body" & vbCrLf
                    ElseIf Failcode = 6 Then
                        Txt_Msg.Text = "--> Wrong Body or Head Orientation" & vbCrLf
                    ElseIf Failcode = 7 Then
                        Txt_Msg.Text = "--> Missing Mechanism Cover screw" & vbCrLf
                    ElseIf Failcode = 8 Then
                        Txt_Msg.Text = "--> Missing CMS Cover" & vbCrLf
                    ElseIf Failcode = 9 Then
                        Txt_Msg.Text = "--> Missing Insulation Base" & vbCrLf
                    End If
                End If

                'Updating the PSN text file
                If Command1.Text = "Eye Open" Then
                    PSNFileInfo.ScrewStnCheckOut = Today & "," & TimeOfDay

                    Txt_Msg.Text = Txt_Msg.Text & "Updating " & PSNFileInfo.PSN & ".Txt..." & vbCrLf
                    lbl_msg.Text = "Please wait..."
ReWrite:
                    Verifydata = PSNFileInfo.ScrewStnStatus
                    Verifypsn = PSNFileInfo.PSN
                    If Not WRITEPSNFILE(PSNFileInfo.PSN) Then
                        Txt_Msg.Text = Txt_Msg.Text & "--> Unable to access " & PSNFileInfo.PSN & ".Txt in the server" & vbCrLf
                        Txt_Msg.BackColor = Color.Red
                        GoTo 500
                    End If
                    If Not LOADPSNFILE(Verifypsn) Then
                        Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load " & Verifypsn & ".Txt again" & vbCrLf
                        Txt_Msg.BackColor = Color.Red
                        GoTo 500
                    End If
                    If PSNFileInfo.ScrewStnStatus <> Verifydata Then
                        Txt_Msg.Text = Txt_Msg.Text & "Rewriting PSN.Txt file again..." & vbCrLf
                        GoTo ReWrite
                    End If
                    'Skip increment if repeated
                    If PSNFileInfo.ScrewStnStatus = "PASS" Then
                        If EnableCount = True Then
                            lbl_currcounter.Text = CStr(Val(lbl_currcounter.Text) + 1)
                        End If
                        LoadWOfrRFID.JobUnitaryCount = Val(lbl_currcounter.Text)
                    End If
                    If Val(lbl_currcounter.Text) >= Val(lbl_wocounter.Text) Then
                        Txt_Msg.Text = "WO Quantity Reached - WO Completed"
                        lbl_msg.Text = "STOP PROCESS"
                    End If
                    Txt_Msg.Text = Txt_Msg.Text & PSNFileInfo.PSN & ".Txt updated." & vbCrLf
                    UpdateStnStatus()
                End If
500:

                If Not FrmModbus.Tulismodbus(40101, 10) Then 'Inform PLC that PC already read result
                    Txt_Msg.Text = Txt_Msg.Text & "--> Unable to communicate with PLC - MW105" & vbCrLf
                    Txt_Msg.BackColor = Color.Red
                    Exit Sub
                End If
        End Select
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs)
        'PictureBox2.Image = Image.FromFile(INISLIDEPATH & "Network_Data\Presentation\Slide" & SlideCount & ".JPG")
        'SlideCount = SlideCount + 1
        'If SlideCount = 6 Then SlideCount = 1
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        PictureBox2.Image = Image.FromFile(INISLIDEPATH & "Slide" & SlideCount & ".JPG")

        SlideCount = SlideCount + 1
        If SlideCount = 6 Then SlideCount = 1
    End Sub

    Private Function RefCheck(strName As String) As Boolean

        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & strName & "'"
        Dim dt = Connection.ReadData(query).Tables(0)

        If dt.Rows(0).Item("ModelName") = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub cmd_database_Click(sender As Object, e As EventArgs) Handles cmd_database.Click
        'Load FrmLogin
        'FrmLogin.Show vbModal
        'If Login = True Then
        FrmDatabase.Show()
        'Else
        '   MsgBox "Invalid username or password"
        'End If
    End Sub

    Private Sub Cmd_material_Click(sender As Object, e As EventArgs) Handles cmd_material.Click
        'Load FrmLogin
        'FrmLogin.Show vbModal
        'If Login = True Then
        FrmMaterial.Show()
        'Else
        '    MsgBox "Invalid username or password"
        'End If
    End Sub

    Public Sub Reset_PLC()
        FrmModbus.Tulismodbus(40500, 1)
    End Sub

    Private Sub Cmd_Refresh_Click(sender As Object, e As EventArgs) Handles Cmd_Refresh.Click
        Cmd_Refresh.Enabled = True
        Timer1.Enabled = False
        GetLastConfig()

        If Not LoadParameter(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load parameters...")
            Cmd_Refresh.Enabled = True
        End If
        If Not LoadParameterToPLC() Then
            MsgBox("Unable to communicate with PLC...")
            End
        End If

        Reset_PLC()

        'If Not Write_PLC_Word(100, CLng(LoadWOfrRFID.JobUnitaryCount)) Then
        '    MsgBox("Unable to communicate wwith PLC - %MW100")
        '    Timer1.Enabled = True
        '    Cmd_Refresh.Enabled = True
        '    Exit Sub
        'End If
        'Load Rack Material List
        If Not LoadRackMaterial() Then
            MsgBox("Unable to load Rack Materials")
            Timer1.Enabled = True
            Cmd_Refresh.Enabled = True
            Exit Sub
        End If

        'Load Model Material
        If Not LoadModelMaterial(LoadWOfrRFID.JobModelName) Then
            MsgBox("Unable to load Model Material")
            Timer1.Enabled = True
            Cmd_Refresh.Enabled = True
            Exit Sub
        End If

        If Not ActivateRackLED() Then
            MsgBox("Unable to communicate with PLC")
            Timer1.Enabled = True
            Cmd_Refresh.Enabled = True
            Exit Sub
        End If

        lbl_WOnos.Text = LoadWOfrRFID.JobNos
        lbl_currentref.Text = LoadWOfrRFID.JobModelName
        lbl_wocounter.Text = CStr(LoadWOfrRFID.JobQTy)
        lbl_currcounter.Text = CStr(LoadWOfrRFID.JobUnitaryCount)
        lbl_tagnos.Text = LoadWOfrRFID.JobRFIDTag
        lbl_ArticleNos.Text = LoadWOfrRFID.JobArticle

        Timer1.Enabled = True
        Cmd_Refresh.Enabled = True
    End Sub

    Private Sub cmd_quit_Click(sender As Object, e As EventArgs) Handles cmd_quit.Click
        RFID_Comm.Close()
        Barcode_Comm.Close()
        End
    End Sub

    Private Sub Command1_Click(sender As Object, e As EventArgs) Handles Command1.Click
        If Command1.Text = "Eye Open" Then
            Command1.Text = "Eye Close"
        Else
            Command1.Text = "Eye Open"
        End If
    End Sub

    Private Sub CMD_Read_Inputs_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtTimeOut_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_modbus_Click(sender As Object, e As EventArgs) Handles Btn_modbus.Click
        FrmModbus.Show()
    End Sub

    Private Sub Barcode_Comm_Load(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles Barcode_Comm.DataReceived
        AssyBuf = Barcode_Comm.ReadExisting()
        If InStr(1, AssyBuf, vbCrLf) <> 0 Then
            Me.Invoke(Sub()
                          Txt_Msg.BackColor = Color.LightGray
                          Txt_Msg.Text = ""
                          Label9.Text = ""
                          AssyBuf = Mid(AssyBuf, 1, InStr(1, AssyBuf, vbCr) - 1)
                          PictureBox1.Image = Nothing

                          If lbl_WOnos.Text <> "MASTER" Then
                              'Checking Current WO first b4 Change Series is allowed. If WO status is open, check Quantity
                              CheckWO = ValidiateWONos(lbl_WOnos.Text)
                              If CheckWO = "NOK" Then
                                  Txt_Msg.Text = "Invalid WO - WO is not registered in Server"
                                  lbl_msg.Text = "Ask for technical assistance"
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                              If CheckWO <> "DISTRUP" Then
                                  'If Command1.Caption = "Eye Open" Then
                                  '   If Val(lbl_currcounter.Caption) >= Val(lbl_wocounter.Caption) Then
                                  '      Txt_Msg.Text = "Quantity Reached. WO Completed"
                                  '     lbl_msg.Caption = "STOP PROCESS"
                                  '       AssyBuf = ""
                                  '      Exit Sub
                                  ' End If
                                  'End If
                              Else
                                  Txt_Msg.Text = "WO Distrupted"
                                  lbl_msg.Text = "PLEASE CHANGE SERIES"
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                          Else 'If MASTER TAG in use
                              If Val(lbl_currcounter.Text) >= Val(lbl_wocounter.Text) Then
                                  Txt_Msg.Text = "Quantity reached. WO Completed"
                                  lbl_msg.Text = "STOP PROCESS"
                                  AssyBuf = ""
                                  Exit Sub
                              End If
                          End If
                          'Check Article Nos
                          If Microsoft.VisualBasic.Left(AssyBuf, 6) <> LoadWOfrRFID.JobArticle Then
                              Txt_Msg.Text = "--> PSN - " & AssyBuf & " = wrong reference"
                              Txt_Msg.BackColor = Color.Red
                              AssyBuf = ""
                              Exit Sub
                          Else
                              Txt_Msg.Text = "PSN - " & AssyBuf & vbCrLf
                              PSNFileInfo.PSN = AssyBuf
                          End If
                          Txt_Msg.Text = Txt_Msg.Text & "Loading " & AssyBuf & ".Txt..." & vbCrLf
                          If Dir(INIPSNFOLDERPATH & AssyBuf & ".Txt") = "" Then
                              Txt_Msg.Text = Txt_Msg.Text & "--> Unable to find " & AssyBuf & ".Txt" & vbCrLf
                              Txt_Msg.BackColor = Color.Red
                              AssyBuf = ""
                              Exit Sub
                          End If
                          If Not LOADPSNFILE(AssyBuf) Then
                              Txt_Msg.Text = Txt_Msg.Text & "--> Unable to load " & AssyBuf & ".Txt" & vbCrLf
                              Txt_Msg.BackColor = Color.Red
                              AssyBuf = ""
                              Exit Sub
                          End If
                          Txt_Msg.Text = "PSN - " & AssyBuf & " verified" & vbCrLf

                          PSNFileInfo.ScrewStnCheckIn = Today & "," & TimeOfDay

                          If Not FrmModbus.Tulismodbus(40105, 1) Then 'Inform PLC, PSN is verified
                              Txt_Msg.Text = "--> Unable to communicate with PLC - MW105" & vbCrLf
                              Txt_Msg.BackColor = Color.Red
                              AssyBuf = ""
                              Exit Sub
                          End If
                          lbl_msg.Text = "Please proceed with process..."
                          AssyBuf = ""
                          Exit Sub
                      End Sub)
        End If
    End Sub

    Private Sub RFID_Comm_Load(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles RFID_Comm.DataReceived

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
