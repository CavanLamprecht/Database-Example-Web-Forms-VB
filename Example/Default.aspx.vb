Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LoadUsers()
        End If
    End Sub

#Region "Utilities"

    Private Sub LoadUsers()
        Dim dt As DataTable
        Dim user As New Database.users

        Try
            'get all the users data from the database
            dt = user.GetData

            'set the dropdown list programmatically
            With ddlUsers
                .DataSource = dt
                .DataTextField = "Name"
                .DataValueField = "Recordid"
                'this is the main part without the bind your dropdown will never show the data 
                .DataBind()
            End With

        Catch ex As Exception
            'TODO: log error message
        End Try
    End Sub

    ''' <summary>
    ''' save the users information to the database
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="surname"></param>
    ''' <returns></returns>
    Private Function Save(name As String, surname As String, age As Int32) As Boolean
        Dim isValid As Boolean = False
        Dim user As New Database.users

        Dim id As Int32 = -1

        'TODO: build checking system to make sure all required information is available

        'save the users information and return the recordid
        id = user.Insert(name, surname)

        If id > -1 Then
            'TODO: Add Users Extra to the database

            lblSaveMessage.Text = "successfully insert user information"
            lblSaveMessage.ForeColor = Drawing.Color.Blue

            LoadUsers()
        Else
            lblSaveMessage.Text = "Fail to insert user information"
        End If

        Return isValid
    End Function


#End Region

#Region "Events"

    ''' <summary>
    ''' when the age button is clicked then get the age from the database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtAge_Click(sender As Object, e As EventArgs) Handles BtAge.Click
        Dim extra As New Database.extra
        Dim dt As DataTable

        'get the current selected user in the dropdown age from the database
        dt = extra.GetDataByUsersid(ddlUsers.SelectedValue)

        'check that data waS returned then display the age
        If dt?.Rows.Count > 0 Then
            txtAge.Text = dt.Rows(0)("Age")
        End If
    End Sub

    ''' <summary>
    ''' on click save the new users information
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        Save(txtSaveName.Text, txtSaveSurname.Text, txtSaveAge.Text)
    End Sub

#End Region

End Class