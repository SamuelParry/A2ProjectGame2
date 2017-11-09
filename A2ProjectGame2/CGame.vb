Public Class CGame

    Private XPosition As Integer
    Private YPosition As Integer
    Private Width As Integer
    Private Height As Integer
    Private Jumping As Boolean = False
    Private Falling As Boolean = False
    Const YACCELERATION As Double = -2
    Private YVelocity As Double = 0
    Private JumpTime As Double
    Const TIME_INCREMENT As Double = 0.1
    Private XDirection As String
    Const XVELOCITY As Double = 2
    Private Collision As Boolean = False
    Private R As New Random
    Public RandomX As Double
    Public RandomY As Double
    Const NO_OF_PLATFORMS As Integer = 4
    Public Platform(NO_OF_PLATFORMS - 1) As CPlatform
    Public YDirection As String
    Public PredictedYPos As Double
    Const PLATFORM_WIDTH As Integer = 80

    Private Structure PlatformCoordinates
        Public PlatformXPositionStart As Integer
        Public PlatformXPositionEnd As Integer
        Public Elevation As Integer
    End Structure

    Private PlatformList(NO_OF_PLATFORMS - 1) As PlatformCoordinates

    Public Sub CreatePlatforms()

        RandomX = R.Next(21, 150)
        RandomY = R.Next(11, 80)
        Platform(0) = New CPlatform(RandomX, RandomY, PLATFORM_WIDTH, 1)
        PlatformList(0).PlatformXPositionStart = RandomX
        PlatformList(0).PlatformXPositionEnd = PlatformList(0).PlatformXPositionStart + PLATFORM_WIDTH
        PlatformList(0).Elevation = RandomY

        For N = 0 To NO_OF_PLATFORMS - 2
            RandomX = R.Next(11, GameForm.Width - 500)
            RandomY = R.Next(11, 100)

            While RandomX < PlatformList(N).PlatformXPositionEnd
                RandomX += 50
            End While

            RandomX += 20

            Platform(N + 1) = New CPlatform(RandomX, RandomY, PLATFORM_WIDTH, 1)
            PlatformList(N + 1).PlatformXPositionStart = RandomX
            PlatformList(N + 1).PlatformXPositionEnd = PlatformList(N + 1).PlatformXPositionStart + PLATFORM_WIDTH
            PlatformList(N + 1).Elevation = RandomY
        Next

    End Sub

    Public Sub New(X As Integer, Y As Integer, W As Integer, H As Integer)

        XPosition = X
        YPosition = Y
        Width = W
        Height = H

    End Sub

    Public Sub DrawCharacter(g As Graphics)

        Dim Pen As New Pen(Color.Red, 1)

        g.DrawRectangle(Pen, XPosition, GameForm.Height() - 51 - YPosition, Width, Height)

    End Sub

    Public Sub DrawPlatform(g As Graphics)

        For N = 0 To NO_OF_PLATFORMS - 1
            Platform(N).Draw(g)
        Next

    End Sub

    Public Sub KeyPress(Key As String)

        Select Case Key
            Case "l"
                XDirection = "left"
            Case "r"
                XDirection = "right"
            Case "u"
                'If YPosition = 0 Or Collision = True Then
                If YVelocity = 0 Or YPosition = 0 Then
                    Jumping = True
                    JumpTime = 0
                End If
            Case "d"
                XDirection = "stationary"
        End Select

    End Sub

    Public Sub Tick()

        Collision = CheckCollision()

        If Jumping = True Or Falling = True Then
            JumpTime += TIME_INCREMENT
        End If

        YPosition = UpdateYPosition()
        XPosition = UpdateXPosition()

    End Sub

    Public Function CheckCollision()

        For N = 0 To NO_OF_PLATFORMS - 1

            If (XPosition + Width) > PlatformList(N).PlatformXPositionStart And (XPosition < PlatformList(N).PlatformXPositionEnd) And PlatformList(N).Elevation >= YPosition Then

                If PredictedYPos < PlatformList(N).Elevation And YVelocity < 0 Then
                    YPosition = PlatformList(N).Elevation + 11
                    YVelocity = 0
                    Jumping = False

                    Collision = True
                End If

            ElseIf ((XPosition + Width) < PlatformList(N).PlatformXPositionStart Or (XPosition > PlatformList(N).PlatformXPositionEnd)) And Collision = True Then

                'YPosition += 10

                Collision = False

                Falling = True

            End If

        Next

        Return Collision

    End Function

    Public Function UpdateYPosition()

        PredictedYPos = YPosition + ((4 + (YACCELERATION * (JumpTime + TIME_INCREMENT))) * (JumpTime + TIME_INCREMENT)) - (0.5 * YACCELERATION * (JumpTime + TIME_INCREMENT) ^ 2)

        If Jumping = True Then

            YVelocity = 4 + (YACCELERATION * JumpTime)

            If YPosition + (YVelocity * JumpTime) - (0.5 * YACCELERATION * JumpTime ^ 2) < 0 Then
                YPosition = 0
                Jumping = False
                JumpTime = 0
                YVelocity = 0
            Else
                YPosition += (YVelocity * JumpTime) - (0.5 * YACCELERATION * JumpTime ^ 2)
            End If

        End If

        If Falling = True And YPosition > 0 And Jumping = False Then

            JumpTime = 0

            YVelocity = (YACCELERATION * JumpTime)

            If YPosition + (YVelocity * JumpTime) - (0.5 * YACCELERATION * JumpTime ^ 2) < 0 Then
                YPosition = 0
                Falling = False
                JumpTime = 0
                YVelocity = 0
            Else
                YPosition += (YVelocity * JumpTime) - (0.5 * YACCELERATION * JumpTime ^ 2)
            End If

        End If

        Return YPosition

    End Function

    Public Function UpdateXPosition()

        If XDirection = "left" And XPosition > 0 Then
            XPosition -= XVELOCITY
        ElseIf XDirection = "right" And XPosition < (GameForm.Width() - 28) Then
            XPosition += XVELOCITY
        End If

        Return XPosition

    End Function

End Class
