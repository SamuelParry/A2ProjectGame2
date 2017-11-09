Public Class GameForm

    Public Game As CGame


    Public Sub Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Game = New CGame(0, 0, 10, 10)

        Game.CreatePlatforms()

    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick

        Game.Tick()

        GameScreen.Refresh()

    End Sub

    Private Sub Screen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Left Then
            Game.KeyPress("l")
        ElseIf e.KeyCode = Keys.Right Then
            Game.KeyPress("r")
        ElseIf e.KeyCode = Keys.Up Then
            Game.KeyPress("u")
        ElseIf e.KeyCode = Keys.Down Then
            Game.KeyPress("d")
        End If

        GameScreen.Refresh()

    End Sub

    Private Sub GameScreen_Paint(sender As Object, e As PaintEventArgs) Handles GameScreen.Paint

        Dim g As Graphics

        g = e.Graphics

        Game.DrawCharacter(g)

        Game.DrawPlatform(g)

    End Sub

End Class
