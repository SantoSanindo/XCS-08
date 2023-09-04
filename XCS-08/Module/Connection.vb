Imports System.Data.SqlClient
Module Connection
    Public Function Database() As String
        Dim db As String = "Data Source=192.168.1.188\SQLEXPRESS;
            initial catalog=TESE;
            Persist Security Info=True;
            User ID=tese;
            Password=Sanindo123;
            Connect Timeout=15000;
            Max Pool Size=15000;
            Pooling=True"
        Return db
    End Function

    Public Function ReadData(query As String) As DataSet
        Try
            Dim connect As New SqlConnection(Database)
            Dim scm As New SqlCommand(query, connect)
            Dim adapter As New SqlDataAdapter(scm)
            Dim dts As New DataSet

            adapter.Fill(dts)
            'koneksi.Close()
            Return dts
        Catch ex As Exception
            MsgBox("Database connection Error!")
        End Try
    End Function
End Module