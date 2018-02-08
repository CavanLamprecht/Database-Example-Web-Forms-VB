Imports System.Data.SqlClient

Namespace Database

    Public Class users



#Region "Utilities"

#End Region

#Region "Information"

#Region "Data"

    ''' <summary>
    ''' get all the users from that database
    ''' </summary>
    ''' <returns></returns>
    Public Function GetData() As DataTable

            Dim dtData As New DataTable
            Dim Query As String = " SELECT [Recordid], [Name], [Surname], [isDeleted] " +
                                  " FROM [Users] "

            'this is the database connection object
            Dim Connection As New SqlConnection
        'get the connection from the config file
        Connection.ConnectionString = Database.GetConnectionString

        Try

            'check that the connection is closed if not then open the connection string
            If Connection.State = ConnectionState.Closed Then Connection.Open()

            'get the database adapter that will be getting data from the database
            Dim objDbda As New SqlDataAdapter(Query, Connection)
            'always clear the parameters to avoid wrong variables been set
            objDbda.SelectCommand.Parameters.Clear()

            objDbda.Fill(dtData)
            objDbda.Dispose()

        Catch ex As Exception
            'TODO: log error message
        Finally
            'check if connection is open then close the connection
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try

        Return dtData
    End Function


#End Region

#Region "Save"

        ''' <summary>
        ''' insert a new users information into the database
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="surname"></param>
        ''' <param name="isdeleted"></param>
        ''' <returns>
        ''' returns the inserted users new recordid
        ''' IF -1 is returned there was an error 
        ''' </returns>
        Public Function Insert(name As String, surname As String, Optional isdeleted As Boolean = False) As Int32
            Dim i As Int32 = 0
            Dim Recordid As Int32 = -1
            'this is the database connection object
            Dim Connection As New SqlConnection

            Try
                'get the connection from the config file
                Connection.ConnectionString = Database.GetConnectionString

                Dim comm As New SqlCommand
                Dim parm(3) As SqlParameter
                'open database connection 
                Connection.Open()

                'connect database connection and add the parameters
                With comm
                    .Connection = Connection
                    .CommandText = " INSERT INTO [Users]([Name], [Surname], [isDeleted]) " +
                                   " VALUES ( @Name, @Surname, @isDeleted) " +
                                   " SELECT @RecordID = SCOPE_IDENTITY();"


                    parm(0) = New SqlParameter("RecordID", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                    parm(1) = New SqlParameter("Name", SqlDbType.VarChar) With {.Value = name}
                    parm(2) = New SqlParameter("Surname", SqlDbType.VarChar) With {.Value = surname}
                    parm(3) = New SqlParameter("isDeleted", SqlDbType.Int) With {.Value = If(isdeleted, 1, 0)}

                    .Parameters.Clear()
                    .Parameters.AddRange(parm)
                    'i will return the number of rows affected in this case it should be 1
                    i = .ExecuteNonQuery

                    'check if i returned a row then add value to record id 
                    If i > 0 Then Recordid = parm(0).Value
                End With

            Catch ex As Exception
                Recordid = -1
                'TODO: add error to log system
            Finally
                'check if connection is open then close the connection
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try

            Return Recordid
        End Function


#End Region

#End Region

    End Class

End Namespace