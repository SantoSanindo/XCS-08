Imports EasyModbus
Public Class FrmModbus
    Dim ModbusClient As ModbusClient
    Private Sub FrmModbus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboreg.SelectedIndex = 3
        bConnect.PerformClick()
        FrmMain.Show()
    End Sub

    Public Function Bacamodbus(addrs As Integer) As Integer
        If lbl_status.Text = "Connected" Then
            Textaddress.Text = addrs
            read_modbus()
            Return CInt(Textvalue.Text)
        Else
            MsgBox("modbus Not connected")
            Return 0
        End If
    End Function

    Public Function Tulismodbus(addrs As Integer, value As Integer) As Boolean
        If lbl_status.Text = "Connected" Then
            Textaddress.Text = addrs
            Textnewval.Text = value
            write_modbus()
            Return True
        Else
            MsgBox("modbus Not connected")
            Return False
        End If
    End Function
    Private Sub bConnect_Click(sender As Object, e As EventArgs) Handles bConnect.Click
        Try
            ModbusClient = New ModbusClient(Textip.Text, Val(Textport.Text))
            ModbusClient.Connect()

            bConnect.Enabled = False
            bDisconnect.Enabled = True
            lbl_status.Text = "Connected"
            lbl_status.ForeColor = Color.Green
        Catch ex As Exception
            MsgBox("Modbus Error Connect! " & ex.Message)
        End Try
    End Sub

    Private Sub bDisconnect_Click(sender As Object, e As EventArgs) Handles bDisconnect.Click
        Try
            ModbusClient.Disconnect()

            bConnect.Enabled = True
            bDisconnect.Enabled = True
        Catch ex As Exception
            MsgBox("Modbus Error Disconnect! " & ex.Message)
        End Try
        lbl_status.Text = "Not Connected"
        lbl_status.ForeColor = Color.Red
    End Sub

    Private Sub read_modbus()
        Dim startaddress As Integer = Val(Textaddress.Text)

        Select Case comboreg.SelectedIndex
            Case 0
                Dim ReadValues() As Boolean = ModbusClient.ReadCoils(startaddress, 1)
                Textvalue.Text = ReadValues(0)
            Case 1
                If startaddress > 10000 Then startaddress = startaddress - 10001
                Dim ReadValues() As Boolean = ModbusClient.ReadDiscreteInputs(startaddress, 1)
                Textvalue.Text = ReadValues(0)
            Case 2
                If startaddress > 30000 Then startaddress = startaddress - 30001
                Dim ReadValues() As Integer = ModbusClient.ReadInputRegisters(startaddress, 1)
                Textvalue.Text = ReadValues(0)
            Case 3
                If startaddress > 40000 Then startaddress = startaddress - 40001
                Dim ReadValues() As Integer = ModbusClient.ReadHoldingRegisters(startaddress, 1)
                Textvalue.Text = ReadValues(0)
        End Select
    End Sub
    Private Sub bRead_Click(sender As Object, e As EventArgs) Handles bRead.Click
        Try
            read_modbus()

        Catch ex As Exception
            MsgBox("Modbus Error Read! " & ex.Message)
        End Try
    End Sub

    Private Sub write_modbus()
        Dim StartAddress As Integer = Val(Textaddress.Text)

        Select Case comboreg.SelectedIndex
            Case 0
                Dim WriteVals(0) As Boolean
                WriteVals(0) = Val(Textnewval.Text)
                ModbusClient.WriteMultipleCoils(StartAddress, WriteVals)
            Case 1
                    '
            Case 2
                    '
            Case 3
                If StartAddress > 40000 Then StartAddress = StartAddress - 40001
                Dim WriteVals(0) As Integer
                WriteVals(0) = Val(Textnewval.Text)
                ModbusClient.WriteMultipleRegisters(StartAddress, WriteVals)
        End Select
    End Sub

    Private Sub bWrite_Click(sender As Object, e As EventArgs) Handles bWrite.Click
        Try
            write_modbus()

        Catch ex As Exception
            MsgBox("Modbus Error Write! " & ex.Message)
        End Try
    End Sub

    Private Sub comboreg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboreg.SelectedIndexChanged
        Dim iSel As Integer = comboreg.SelectedIndex
        If iSel > -1 Then
            If iSel = 0 Then
                Textaddress.Text = "00001"
                bWrite.Enabled = True
            End If
            If iSel = 1 Then
                Textaddress.Text = "10001"
                bWrite.Enabled = False
            End If

            If iSel = 2 Then
                Textaddress.Text = "30001"
                bWrite.Enabled = False
            End If
            If iSel = 3 Then
                Textaddress.Text = "40001"
                bWrite.Enabled = True
            End If

        End If
    End Sub

    Private Sub bBack_Click(sender As Object, e As EventArgs) Handles bBack.Click
        Hide()
    End Sub
End Class