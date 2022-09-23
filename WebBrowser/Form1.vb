Public Class Form1
    Private Tabs As ArrayList

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        WebBrowser1.Navigate(inpSearch.Text)
        Dim page As TabReference
        page = New TabReference()
        page.currentTab = TabControl1.SelectedTab
        page.url = inpSearch.Text
        Tabs.Add(page)
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub NewTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTabToolStripMenuItem.Click
        TabControl1.TabPages.Add("New Page")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Add("New Page")
        Tabs = New ArrayList()
    End Sub

    Private Sub WebBrowser1_Update(sender As Object, e As EventArgs) Handles WebBrowser1.DocumentTitleChanged
        If TabControl1.SelectedTab IsNot Nothing Then
            TabControl1.SelectedTab.Text = WebBrowser1.DocumentTitle
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
End Class
