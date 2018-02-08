
Namespace Database

    Public Module connection

        ''' <summary>
        ''' Retrieve the conenction string from the web.config file.
        ''' This database must contain the framework database tabels.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetConnectionString() As String
            Try
                Dim strConnectionString As String = ""
                strConnectionString = My.MySettings.Default.dbExample
                Return strConnectionString
            Catch ex As Exception
                'TODO: add to error Log
                Return ""
            End Try
        End Function



    End Module

End Namespace
