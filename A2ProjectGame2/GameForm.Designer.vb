<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GameScreen = New System.Windows.Forms.PictureBox()
        Me.GameTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GameScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GameScreen
        '
        Me.GameScreen.Location = New System.Drawing.Point(0, -1)
        Me.GameScreen.Name = "GameScreen"
        Me.GameScreen.Size = New System.Drawing.Size(1055, 505)
        Me.GameScreen.TabIndex = 0
        Me.GameScreen.TabStop = False
        '
        'GameTimer
        '
        Me.GameTimer.Enabled = True
        Me.GameTimer.Interval = 1
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 505)
        Me.Controls.Add(Me.GameScreen)
        Me.Name = "GameForm"
        CType(Me.GameScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GameScreen As PictureBox
    Friend WithEvents GameTimer As Timer
End Class
