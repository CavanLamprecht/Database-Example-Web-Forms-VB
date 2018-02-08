Imports System.Data.SqlClient

Namespace Database
    Public Class extra



#Region "Utilities"

#End Region

#Region "Information"

#Region "Data"

        ''' <summary>
        ''' get all the users from that database
        ''' </summary>
        ''' <returns></returns>
        Public Function GetDataByUsersid(usersid As Int32) As DataTable

            Dim dtData As New DataTable
            Dim Query As String = " SELECT [Recordid], [Usersid], [Age], [isDeleted] " +
                                  " FROM [Extra] " +
                                  " WHERE [Usersid] = @Usersid "

            'this is the database connection object
            Dim Connection As New SqlConnection
            'get the connection from the config file
            Connection.ConnectionString = Database.GetConnectionString

            'add the parameters that are needed by the query
            Dim Parameters(0) As SqlParameter
            Parameters(0) = New SqlParameter("Usersid", SqlDbType.Int) With {.Value = usersid}

            Try
                'check that the connection is closed if not then open the connection string
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                'get the database adapter that will be getting data from the database
                Dim objDbda As New SqlDataAdapter(Query, Connection)
                'always clear the parameters to avoid wrong variables been set
                objDbda.SelectCommand.Parameters.Clear()
                'add the set parameters for the query to the database adapter
                objDbda.SelectCommand.Parameters.AddRange(Parameters)

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


#End Region

#End Region

    End Class

End Namespace

