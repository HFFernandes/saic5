<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBase
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.stsEstatus = New System.Windows.Forms.StatusStrip
        Me.tstLblNombre = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstLblFecha = New System.Windows.Forms.ToolStripStatusLabel
        Me.tstLblSeparador = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.stsEstatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.stsEstatus)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(507, 274)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(507, 321)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.ttsPanelPrincipal
        '
        '
        'stsEstatus
        '
        Me.stsEstatus.BackColor = System.Drawing.Color.Transparent
        Me.stsEstatus.Dock = System.Windows.Forms.DockStyle.None
        Me.stsEstatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstLblFecha, Me.tstLblSeparador, Me.tstLblNombre})
        Me.stsEstatus.Location = New System.Drawing.Point(0, 0)
        Me.stsEstatus.Name = "stsEstatus"
        Me.stsEstatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.stsEstatus.Size = New System.Drawing.Size(507, 22)
        Me.stsEstatus.TabIndex = 0
        '
        'tstLblNombre
        '
        Me.tstLblNombre.Font = New System.Drawing.Font("Tahoma", 7.534884!, System.Drawing.FontStyle.Bold)
        Me.tstLblNombre.ForeColor = System.Drawing.Color.Navy
        Me.tstLblNombre.Name = "tstLblNombre"
        Me.tstLblNombre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tstLblNombre.Size = New System.Drawing.Size(44, 17)
        Me.tstLblNombre.Text = "Nombre"
        '
        'tstLblFecha
        '
        Me.tstLblFecha.Font = New System.Drawing.Font("Tahoma", 7.534884!, System.Drawing.FontStyle.Bold)
        Me.tstLblFecha.ForeColor = System.Drawing.Color.Navy
        Me.tstLblFecha.Name = "tstLblFecha"
        Me.tstLblFecha.Size = New System.Drawing.Size(34, 17)
        Me.tstLblFecha.Text = "Fecha"
        '
        'tstLblSeparador
        '
        Me.tstLblSeparador.Name = "tstLblSeparador"
        Me.tstLblSeparador.Size = New System.Drawing.Size(212, 17)
        Me.tstLblSeparador.Text = "                                                                     "
        '
        'frmBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(507, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.stsEstatus.ResumeLayout(False)
        Me.stsEstatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents stsEstatus As System.Windows.Forms.StatusStrip
    Friend WithEvents tstLblNombre As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstLblFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tstLblSeparador As System.Windows.Forms.ToolStripStatusLabel
End Class
