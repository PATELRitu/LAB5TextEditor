Option Strict On
Imports System.IO

Public Class frmTextEditor

    Dim fullPath As String = String.Empty
    Private Sub NewClToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuNew.Click

        txtInput.Text = ""
        fullPath = String.Empty
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then

            Try
                Dim openFile As New StreamReader(OpenFileDialog1.FileName)
                txtInput.Text = openFile.ReadToEnd
                openFile.Close()

            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)

            End Try
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click

        SaveFileDialog1.Filter = "txt files (*.txt)|*.txt"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            fullPath = SaveFileDialog1.FileName
            save(fullPath)
        End If

    End Sub


    Private Sub save(fullPath As String)
        Dim fileStreamsave As New FileStream(fullPath, FileMode.Create, FileAccess.Write)

        Dim writeStreamFile As New StreamWriter(fileStreamSave)

        writeStreamFile.Write(txtInput.Text)

        writeStreamFile.Close()
    End Sub


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSave.Click

        SaveFileDialog1.Filter = "txt files (*.txt)|*.txt"

        If File.Exists(fullPath) = False Then

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                fullPath = SaveFileDialog1.FileName
                save(fullPath)
            End If

        Else
            save(fullPath)
        End If

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub CopyCtrlcToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        txtInput.Copy()
    End Sub

    Private Sub CutCtrlxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        txtInput.Cut()
    End Sub

    Private Sub PasteCtrlVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        txtInput.Paste()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        MessageBox.Show("NETD-2202" & vbCrLf & vbCrLf & "LAb # 5" & vbCrLf & vbCrLf & "Ritu Patel", "About")
    End Sub
End Class


