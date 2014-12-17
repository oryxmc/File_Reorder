<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.fbBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnPickFolder = New System.Windows.Forms.Button()
        Me.lvFiles = New System.Windows.Forms.ListView()
        Me.btnReorder = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'fbBrowser
        '
        Me.fbBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'btnPickFolder
        '
        Me.btnPickFolder.Location = New System.Drawing.Point(28, 111)
        Me.btnPickFolder.Name = "btnPickFolder"
        Me.btnPickFolder.Size = New System.Drawing.Size(75, 23)
        Me.btnPickFolder.TabIndex = 0
        Me.btnPickFolder.Text = "Folder..."
        Me.btnPickFolder.UseVisualStyleBackColor = True
        '
        'lvFiles
        '
        Me.lvFiles.AllowDrop = True
        Me.lvFiles.Location = New System.Drawing.Point(132, 12)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.ShowItemToolTips = True
        Me.lvFiles.Size = New System.Drawing.Size(283, 475)
        Me.lvFiles.TabIndex = 1
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.List
        '
        'btnReorder
        '
        Me.btnReorder.Location = New System.Drawing.Point(28, 140)
        Me.btnReorder.Name = "btnReorder"
        Me.btnReorder.Size = New System.Drawing.Size(75, 23)
        Me.btnReorder.TabIndex = 2
        Me.btnReorder.Text = "Reorder"
        Me.btnReorder.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 499)
        Me.Controls.Add(Me.btnReorder)
        Me.Controls.Add(Me.lvFiles)
        Me.Controls.Add(Me.btnPickFolder)
        Me.Name = "frmMain"
        Me.Text = "File Reorder"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnPickFolder As System.Windows.Forms.Button
    Friend WithEvents lvFiles As System.Windows.Forms.ListView
    Friend WithEvents btnReorder As System.Windows.Forms.Button

End Class
