Public Class ExcelToDataGrid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As DataTable = Utilities.Import.ExcelFile($"{Server.MapPath("~/App_Data")}\Book2.xlsx")

        With GridView1
            .DataSource = dt
            .DataBind()
        End With
    End Sub

End Class