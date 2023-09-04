Imports System.Data.SqlClient

Module modGeneral

    Public Function CheckWOExist(WO As String) As Boolean

        Dim query = "SELECT * FROM TESE.dbo.STN4 WHERE WONOS = '" & WO & "'"
        Dim dt = Connection.ReadData(query).Tables(0)

        If dt.Rows(0).Item("WONOS") = "" Then
            Return False
        Else
            Return True
        End If
        Exit Function
    End Function

    Public Function AddWO(WO As String) As Boolean

        Dim konek As New SqlConnection(Database)

        Dim sql As String = "INSERT INTO TESE.dbo.STN4 (WONOS,OUTPUT) VALUES('" & WO & "',0)"

        konek.Open()
        Dim sc As New SqlCommand(sql, konek)
        Dim adapter As New SqlDataAdapter(sc)
        If adapter.SelectCommand.ExecuteNonQuery().ToString() = 1 Then
            Return True
            konek.Close()
        Else
            Return False
        End If
    End Function

    Public Function UpdateWO(WO As String, updateqty As String) As Boolean

        Dim konek As New SqlConnection(Database)

        Dim sql As String = "UPDATE TESE.dbo.STN1 SET OUTPUT='" & updateqty & "' WHERE WONOS='" & WO & "'"

        konek.Open()
        Dim sc As New SqlCommand(sql, konek)
        Dim adapter As New SqlDataAdapter(sc)
        If adapter.SelectCommand.ExecuteNonQuery().ToString() = 1 Then
            Return True
            konek.Close()
        Else
            Return False
        End If
    End Function

    Public Function RetrieveWOQty(WO As String) As String

        Dim readqty As String
        Dim query = "SELECT * FROM TESE.dbo.STN1 WHERE WONOS = '" & WO & "'"
        Dim dt = Connection.ReadData(query).Tables(0)

        readqty = dt.Rows(0).Item("OUTPUT")
        Return readqty
    End Function

    Public Function GetDateCode() As String
        Dim YY, WW As String

        YY = Right(Year(Date.Now), 2)
        WW = DatePart(Date.Now, "ww", FirstDayOfWeek.Sunday, vbFirstFullWeek)

        If Len(WW) = 1 Then
            WW = "0" & WW
        End If
        GetDateCode = YY & WW
    End Function

    Public Function CheckTotalPart(csmodel As String) As Integer

        Dim DBCheck As New SqlConnection(Database)
        DBCheck.Open() 'INIDATABASEPATH & "MaterialConfig.Mdb"

        Dim RSCheck As New SqlCommand("Select * FROM LOCATION WHERE MODELNAME = '" & csmodel & "'", DBCheck)
        Dim reader As SqlDataReader = RSCheck.ExecuteReader()
        Dim PartCount As Integer

        'On Error Resume Next
        If reader.HasRows = True Then
            Do While reader.Read()
                With RSCheck
                    For i = 0 To 47
                        If reader.Item(i).Value = 1 Then
                            PartCount += 1
                            UnitaryMaterial(PartCount) = Unitmaterial.PartNos(i)
                            'UnitaryMaterialFlag(PartCount) = True
                        End If
                    Next
                End With
                CheckTotalPart = PartCount
            Loop
        End If
        Return True
        reader.Close()
        DBCheck.Close()
    End Function

    Public Function CheckTotalItem(csmodel As String) As Integer

        Dim DBCheck As New SqlConnection(Database)
        DBCheck.Open()

        Dim RSCheck As New SqlCommand("Select * FROM Parameter WHERE ModelName = '" & csmodel & "'", DBCheck)
        Dim reader As SqlDataReader = RSCheck.ExecuteReader()
        Dim ItemCount As Integer

        On Error Resume Next

        If reader.HasRows = True Then
            Do While reader.Read()
                With RSCheck
                    If reader.Item("PrimaryPCBAType") <> "" Then ItemCount += 1
                    If reader.Item("SecondaryPCBAType") <> "" Then ItemCount += 1
                    If reader.Item("ElectroMagnetType") <> "" Then ItemCount += 1
                End With

                CheckTotalItem = ItemCount
            Loop
        End If
        reader.Close()
        DBCheck.Close()
    End Function

    Public Function Check_Serialnos(AAAAAARRRYYWW As String) As String

        Dim DBCheck As New SqlConnection(Database)
        DBCheck.Open() 'INIDATABASEPATH & "TrackSerial.Mdb"

        Dim RSCheck As New SqlCommand("Select * FROM SERIAL WHERE RVYYWW = '" & AAAAAARRRYYWW & "'", DBCheck)
        Dim reader As SqlDataReader = RSCheck.ExecuteReader()
        Dim tempor As String

        On Error GoTo ErrorHandler
        If reader.HasRows = True Then
            Do While reader.Read()
                With RSCheck
                    tempor = reader.Item("LASTNOS")
                End With
                Check_Serialnos = tempor
                Exit Function
            Loop
        End If
ErrorHandler:
        Check_Serialnos = "00000"
        Exit Function
        reader.Close()
        DBCheck.Close()
    End Function

    Public Sub GetLastConfig()
        Dim Filenum As Integer
        Filenum = FreeFile()
        Dim tempcode As String
        Dim pos1, pos2, pos3, pos4, pos5 As Integer

        FileOpen(Filenum, INISTATUSPATH, OpenMode.Input)
        tempcode = LineInput(Filenum)

        FileClose(Filenum)
        pos1 = InStr(1, tempcode, ",")
        pos2 = InStr(pos1 + 1, tempcode, ",")
        pos3 = InStr(pos2 + 1, tempcode, ",")
        pos4 = InStr(pos3 + 1, tempcode, ",")

        LoadWOfrRFID.JobNos = Mid(tempcode, 1, pos1 - 1)
        LoadWOfrRFID.JobModelName = Mid(tempcode, pos1 + 1, (pos2 - pos1) - 1)
        LoadWOfrRFID.JobQTy = CInt(Mid(tempcode, pos2 + 1, (pos3 - pos2) - 1))
        LoadWOfrRFID.JobRFIDTag = Mid(tempcode, pos3 + 1, (pos4 - pos3) - 1)
        LoadWOfrRFID.JobUnitaryCount = CInt(Mid(tempcode, pos4 + 1))

    End Sub


    Public Function NextCounter(ByVal LastCounter As String) As String
        Dim temp As String

        temp = CLng(LastCounter) + 1

        If CLng(temp) >= 99999 Then
            MsgBox("Maximum counter 99999!", vbCritical)
            Exit Function
        End If

        If Len(temp) = 1 Then
            temp = "0000" & temp
        ElseIf Len(temp) = 2 Then
            temp = "000" & temp
        ElseIf Len(temp) = 3 Then
            temp = "00" & temp
        ElseIf Len(temp) = 4 Then
            temp = "0" & temp
        End If
        NextCounter = temp

    End Function

    Public Sub PutLastConfig()
        Dim Filenum As Integer
        Filenum = FreeFile()

        FileOpen(Filenum, Application.StartupPath & "\Setup.INI", OpenMode.Output)
        Print(Filenum, LoadWOfrRFID.JobNos & "," & LoadWOfrRFID.JobModelName & "," & LoadWOfrRFID.JobQTy & "," & LoadWOfrRFID.JobUnitaryCount & "," & LoadWOfrRFID.JobRFIDTag)
        FileClose(Filenum)
    End Sub

    Public Function Save_LastSerialnos(Lastpsn As String) As Boolean
        Dim Lastcount, anrvdc As String
        Dim ssql As String = String.Empty
        Dim DBsave As New SqlConnection(Database)
        DBsave.Open() 'INIDATABASEPATH & "TrackSerial.mdb"

        Dim RSsave As New SqlCommand("Select * From SERIAL Where RVYYWW = '" & anrvdc & "'", DBsave)
        Dim reader As SqlDataReader = RSsave.ExecuteReader()
        ssql = "UPDATE SERIAL SET LASTNOS = @LNOS WHERE RVYYWW = @RV"
        On Error GoTo ErrorHandler

        Lastcount = Right(Lastpsn, 5)
        anrvdc = Left(Lastpsn, 15)

        If reader.HasRows = True Then
            Do While reader.Read()
                With RSsave
                    RSsave.CommandText = ssql
                    RSsave.Parameters.Add("@LNOS", SqlDbType.NVarChar).Value = Lastcount

                End With
            Loop
        End If
        Exit Function

ErrorHandler:
        'Set DBsave = OpenDatabase(INIDATABASEPATH & "TrackSerial.mdb")
        RSsave = New SqlCommand("Select * From SERIAL", DBsave)
        With RSsave
            RSsave.CommandText = "INSERT INTO SERIAL([RVYYWW], [LASTNOS]) VALUES('" & anrvdc & "', '" & Lastcount & "')"
            RSsave.ExecuteNonQuery()
        End With
        reader.Close()
        DBsave.Close()
    End Function

    Public Function FileExists(FileStr) As Boolean

        On Error GoTo FileFalse

        If Dir(FileStr) <> "" Then
            FileExists = True
            Exit Function
        Else
            FileExists = False
            Exit Function
        End If

FileFalse:
        FileExists = False
    End Function

    Public Function UpdateStnStatus() As Boolean
        Dim Filenum1 As Integer
        Filenum1 = FreeFile()
        FileOpen(Filenum1, INISTATUSPATH & "Status1.txt", OpenMode.Output)
        Print(Filenum1, LoadWOfrRFID.JobNos & "," & LoadWOfrRFID.JobModelName & "," & LoadWOfrRFID.JobQTy & "," & LoadWOfrRFID.JobRFIDTag & "," & LoadWOfrRFID.JobUnitaryCount)
        FileClose(Filenum1)
        Return True
    End Function

    Public Function VerifyPCBA1(csmodel As String, scannos As String) As Boolean

        Dim DBCheck As New SqlConnection(Database)
        DBCheck.Open() 'INIDATABASEPATH

        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = Connection.ReadData(query).Tables(0)
        Dim pcbanos As String

        On Error GoTo ErrorHandler


        With dt
            pcbanos = dt.Rows(0).Item("PrimaryPCBAType")
        End With

        If pcbanos = scannos Then
            VerifyPCBA1 = True
        End If

        Exit Function

ErrorHandler:
        VerifyPCBA1 = False

        DBCheck.Close()
    End Function

    Public Function VerifyPCBA2(csmodel As String, scannos As String) As Boolean

        Dim DBCheck As New SqlConnection(Database)
        DBCheck.Open() 'INIDATABASEPATH

        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = Connection.ReadData(query).Tables(0)
        Dim pcbanos As String

        On Error GoTo ErrorHandler

        With dt
            pcbanos = dt.Rows(0).Item("SecondaryPCBAType")
        End With

        If pcbanos = scannos Then
                    VerifyPCBA2 = True
                End If

        Exit Function

ErrorHandler:
        VerifyPCBA2 = False

        DBCheck.Close()
    End Function

    Public Function VerifyPCBA3(csmodel As String, scannos As String) As Boolean

        Dim DBCheck As New SqlConnection(Database)
        DBCheck.Open() 'INIDATABASEPATH
        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & csmodel & "'"
        Dim dt = Connection.ReadData(query).Tables(0)
        Dim pcbanos As String

        On Error GoTo ErrorHandler

        With dt
            pcbanos = dt.Rows(0).Item("ElectroMagnetType")
        End With

        If pcbanos = scannos Then
                    VerifyPCBA3 = True
                End If

        Exit Function

ErrorHandler:
        VerifyPCBA3 = False

        DBCheck.Close()
    End Function

    Public Sub LogLastWO()
        Dim MyMsg, ID$, TestTime
        Dim Atfile$, Fileloc$
        Dim Filenos As Integer

        On Error Resume Next

        Atfile$ = "WO" & Year(Date.Now) & Format(Date.Now, "ww") & ".CSV"
        Fileloc$ = Application.StartupPath & "\Log\" & Atfile$

        MyMsg = Date.Now.Day & "/" & Date.Now.Month & "/" & Date.Now.Year
        Filenos = FreeFile()
        FileOpen(Filenos, Fileloc$, OpenMode.Append)

        Print(Filenos, MyMsg & "," & TimeOfDay & "," & LoadWOfrRFID.JobNos & "," & LoadWOfrRFID.JobModelName & "," & LoadWOfrRFID.JobQTy & "," & LoadWOfrRFID.JobUnitaryCount & "," & TotalunitaryPassCount)
        FileClose(Filenos)
    End Sub

    Public Function Bin2Dec(Data As String) As Long
        Dim Expon As Integer
        Dim Sumtotal As Double

        For i = 1 To 16
            If Mid(Data, i, 1) = "1" Then
                Expon = Math.Abs(i - 16)
                Sumtotal += 2 ^ Expon
            End If
        Next
        Bin2Dec = Sumtotal
    End Function

    Public Function Dec2Bin(Data As Double) As String
        Dim bit16(16) As String
        Dim Mw As String

        For i = 15 To 0 Step -1
            If Data >= 2 ^ i Then
                bit16(i) = "1"
                Data -= 2 ^ 15
            Else
                bit16(i) = "0"
            End If
        Next
        For i = 15 To 0 Step -1
            Mw &= bit16(i)
        Next
        Dec2Bin = Mw
    End Function


    Function DELAY(PauseTime)
        Dim start As Date
        Dim finish As Date

        start = Now
        Do While Now < start
            My.Application.DoEvents()
        Loop
        finish = Now
        DELAY = finish - start
    End Function
End Module
