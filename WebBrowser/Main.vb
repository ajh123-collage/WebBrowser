Public Class Main
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
        Settings.font = Font
        Settings.color = Color.Black
        Timer1.Start()
    End Sub

    Private Sub WebBrowser1_Update(sender As Object, e As EventArgs) Handles WebBrowser1.DocumentTitleChanged
        If TabControl1.SelectedTab IsNot Nothing Then
            TabControl1.SelectedTab.Text = WebBrowser1.DocumentTitle
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        For i = 0 To UBound(Tabs.ToArray())
            Dim page As TabReference
            page = Tabs.ToArray()(i)
            If TabControl1.SelectedTab.TabIndex = page.currentTab.TabIndex Then
                If WebBrowser1.Url IsNot page.url Then
                    WebBrowser1.Navigate(page.url)
                    inpSearch.Text = page.url
                End If
            End If
        Next
    End Sub

    Private Sub inpSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles inpSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            WebBrowser1.Navigate(inpSearch.Text)
            Dim page As TabReference
            page = New TabReference()
            page.currentTab = TabControl1.SelectedTab
            page.url = inpSearch.Text
            Tabs.Add(page)
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim newWin As Main
        newWin = New Main()
        newWin.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Font = Settings.font
        TabControl1.Font = Settings.font
        MenuStrip1.Font = Settings.font

        ForeColor = Settings.color
        MenuStrip1.ForeColor = Settings.color
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseTabToolStripMenuItem.Click
        For i = 0 To UBound(Tabs.ToArray())
            Dim page As TabReference
            page = Tabs.ToArray()(i)
            If TabControl1.SelectedTab.TabIndex = page.currentTab.TabIndex Then
                Tabs.Remove(page)
                TabControl1.TabPages.Remove(TabControl1.SelectedTab)
            End If
        Next
    End Sub
End Class
