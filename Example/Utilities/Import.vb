
Imports System.Data.OleDb

Namespace Utilities

    Module Import

        ''' <summary>
        ''' http://www.microsoft.com/en-us/download/confirmation.aspx?id=13255
        ''' http://www.microsoft.com/download/en/confirmation.aspx?id=23734 (if top does not work)
        ''' 2007 Office System Driver: Data Connectivity Components 
        ''' </summary> 
        ''' <param name="filepath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExcelFile(filepath As String) As DataTable

            'check that the file exists
            Dim dt As New DataTable
            Dim connection As New OleDbConnection(String.Format("Provider=Microsoft.ACE.OLEDB.12.0;data source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";", filepath))
            Dim adapter As New OleDbDataAdapter("select * from [Sheet1$]", connection)

            Try
                'open connection to the excel database
                connection.Open()
                'fill the data table with the excel sheets content
                adapter.Fill(dt)
            Catch ex As Exception

            Finally
                'always dispose connection other wise you cant access the excel file cause it will says it been used by another application
                adapter.Dispose()
                connection.Close()
            End Try

            Return dt
        End Function


    End Module

End Namespace