Imports System.IO
Public Class FrmMaterial

    Private Sub FrmMaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'LoadParameter()
        'BuatTextbox()
        'BuatLabel()
        Dim filePath As String = INIMATERIALPATH & "Rack\" & "Station1"

        If File.Exists(filePath) Then
            Using sr As New StreamReader(filePath)
                Dim textBoxes As List(Of TextBox) = New List(Of TextBox) From {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10,
                    TextBox11, TextBox12, TextBox13, TextBox14, TextBox15, TextBox16, TextBox17, TextBox18, TextBox19,
                    TextBox20, TextBox21, TextBox22, TextBox23, TextBox24, TextBox25, TextBox26, TextBox27, TextBox28, TextBox29, TextBox30}
                Dim lineIndex As Integer = 0
                Dim line As String

                While Not sr.EndOfStream AndAlso lineIndex < textBoxes.Count
                    line = sr.ReadLine()
                    textBoxes(lineIndex).Text = line
                    lineIndex += 1
                End While

                For i As Integer = lineIndex To textBoxes.Count - 1
                    textBoxes(i).Text = String.Empty
                Next
            End Using
        Else
            MsgBox("File Station1 not found")
        End If


    End Sub

    Private Sub cmdback_Click(sender As Object, e As EventArgs) Handles cmdback.Click
        Me.Close()
    End Sub
End Class