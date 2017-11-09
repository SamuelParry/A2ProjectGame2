Public Class CPlatform

    Private XPosition As Integer
    Private YPosition As Integer
    Private Width As Integer
    Private Height As Integer

    Public Sub New(X As Integer, Y As Integer, W As Integer, H As Integer)

        XPosition = X
        YPosition = Y
        Width = W
        Height = H

    End Sub

    Public Sub Draw(g As Graphics)

        Dim Pen As New Pen(Color.Blue, 1)

        g.DrawRectangle(Pen, XPosition, GameForm.Height() - 51 - YPosition, Width, Height)

    End Sub

End Class
