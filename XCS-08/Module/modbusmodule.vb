Imports EasyModbus
Module modbusmodule
    Public Nb_retry
    Public Communication_progress

    Sub reset_bit(var As Long, n As Long)
        Dim mask As Long
        ' example reset_bit W350(0), 9
        ' i.e. reset bit9 of word %MW350
        ' 2 the power of n
        mask = 2 ^ n
        mask = mask Xor -1
        var = var And mask

    End Sub

    Sub set_bit(var As Long, n As Long)
        Dim mask As Long
        mask = 2 ^ n
        var = var Or mask
    End Sub

    Sub Wait(ByVal Condition As Long)
        ' Wait Data to be sent

        'Conditions :
        '1 : Connected
        '2 : SendComplete
        If Condition = Connected Then
            While lpConnected = False
                My.Application.DoEvents()
            End While
        ElseIf Condition = Sendcomplete Then
            While DataSended <> True And Abord = False
                My.Application.DoEvents()
            End While
        Else
            If Condition = Connected Then Exit Sub
            If Condition = Sendcomplete Then Exit Sub
        End If

        DataReceived = False
        DataSended = False
        Abord = False
        '     If FrmMain!Winsock1.state <> 7 Then
        '    Wait(Connected)
        '   FrmMain.Errors.Items.Add(" Waiting to be connected ")
        '   End If

    End Sub
End Module
