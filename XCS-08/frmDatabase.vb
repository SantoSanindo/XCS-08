Imports System.Data.SqlClient

Public Class FrmDatabase

    Private Sub FrmDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadRefCombo()
        'For i = 0 To 47
        '    Combo1(i).AddItem "0"
        '    Combo1(i).AddItem "1"
        'Next

        Dim query = "SELECT ModelName FROM TESE.dbo.Parameter"
        Dim dt = Connection.ReadData(query).Tables(0)

        For i As Integer = 0 To dt.Rows.Count - 1
            ComboBox1.Items.Add(dt.Rows(i).Item(0))
        Next

    End Sub

    Private Sub cmdback_Click(sender As Object, e As EventArgs) Handles cmdback.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text = "" Then Exit Sub
        Dim query = "SELECT * FROM TESE.dbo.Parameter WHERE ModelName = '" & ComboBox1.Text & "'"
        Dim dt = Connection.ReadData(query).Tables(0)
        Text1.Text = dt.Rows(0).Item("ARTICLENOS")
        Text2.Text = dt.Rows(0).Item("PrimaryPCBAType")
        Text3.Text = dt.Rows(0).Item("SecondaryPCBAType")
        Text4.Text = dt.Rows(0).Item("ElectroMagnetType")

        TextBox1.Text = dt.Rows(0).Item("MaterialType")
        TextBox2.Text = dt.Rows(0).Item("FunctionType")

        TextBox3.Text = dt.Rows(0).Item("Contact1Type")
        TextBox4.Text = dt.Rows(0).Item("Contact2Type")
        TextBox5.Text = dt.Rows(0).Item("Contact3Type")
        TextBox6.Text = dt.Rows(0).Item("Contact4Type")
        TextBox7.Text = dt.Rows(0).Item("Contact5Type")
        TextBox8.Text = dt.Rows(0).Item("Contact6Type")

        TextBox13.Text = dt.Rows(0).Item("Contact1_W_Key")
        TextBox14.Text = dt.Rows(0).Item("Contact2_W_Key")
        TextBox15.Text = dt.Rows(0).Item("Contact3_W_Key")
        TextBox16.Text = dt.Rows(0).Item("Contact4_W_Key")
        TextBox17.Text = dt.Rows(0).Item("Contact5_W_Key")
        TextBox18.Text = dt.Rows(0).Item("Contact6_W_Key")

        TextBox23.Text = dt.Rows(0).Item("Contact1_W_Key_Ten")
        TextBox24.Text = dt.Rows(0).Item("Contact2_W_Key_Ten")
        TextBox25.Text = dt.Rows(0).Item("Contact3_W_Key_Ten")
        TextBox26.Text = dt.Rows(0).Item("Contact4_W_Key_Ten")
        TextBox27.Text = dt.Rows(0).Item("Contact5_W_Key_Ten")
        TextBox28.Text = dt.Rows(0).Item("Contact6_W_Key_Ten")

    End Sub

    Private Function RefCheck(strName As String) As Boolean

        Dim DBTemp As New SqlConnection(Database)
        DBTemp.Open() 'INIDATABASEPATH & "TrayConfig.mdb"

        Dim RSTemp As New SqlCommand("Select * From LOCATION Where MODELNAME = '" & strName & "'", DBTemp)
        Dim reader As SqlDataReader = RSTemp.ExecuteReader()
        Dim temp As Object

        On Error GoTo ErrorHandler
        If reader.HasRows = True Then
            Do While reader.Read()
                With RSTemp
                    temp = reader.Item("MODELNAME")
                End With
                RSTemp = Nothing
            Loop
        Else
        End If

        RSTemp = New SqlCommand("Select * From BARCODE Where MODELNAME = '" & strName & "'", DBTemp)

        If reader.HasRows = True Then
            With RSTemp
                temp = reader.Item("MODELNAME")
            End With
        Else
        End If
        RefCheck = True
        Exit Function

ErrorHandler:
        RefCheck = False

        reader.Close()
        DBTemp.Close()
    End Function

    Private Sub LoadRefCombo()

        Dim DBload As New SqlConnection(Database)
        DBload.Open() 'INIDATABASEPATH

        Dim RSload As New SqlCommand("SELECT * From Parameter", DBload)
        Dim reader As SqlDataReader = RSload.ExecuteReader()

        If reader.HasRows = True Then
            While Not reader.Read()
                ComboBox1.Items.Add(reader.Item("ModelName"))
            End While
        End If

        reader.Close()
        DBload.Close()
    End Sub

    Private Sub ClearRefCombo()
        For i = 1 To ComboBox1.Items.Count
            ComboBox1.Items.Remove(0)
        Next i
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class