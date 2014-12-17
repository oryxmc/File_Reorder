Imports System.IO

Public Class frmMain


    Private Sub btnPickFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickFolder.Click

        If fbBrowser.ShowDialog() = Windows.Forms.DialogResult.OK Then 'show dialog and wait for OK/Cancel

            PopulateLV(fbBrowser.SelectedPath)
        End If

    End Sub

    Private Sub PopulateLV(ByVal path As String)
        Dim aszFileList() As String
        Dim dFiles As New Dictionary(Of String, DateTime)

        lvFiles.Clear()
        aszFileList = Directory.GetFiles(path, "*.mp3")

        For Each szFile As String In aszFileList
            dFiles.Add(Strings.Right(szFile, szFile.Length - szFile.LastIndexOf("\") - 1), File.GetLastWriteTime(szFile))
            'lvFiles.Items.Add(Strings.Right(szFile, szFile.Length - szFile.LastIndexOf("\") - 1))
        Next

        Dim sortedDict = (From entry In dFiles Order By entry.Value Descending).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)

        For Each currentKVP As KeyValuePair(Of String, DateTime) In sortedDict
            lvFiles.Items.Add(currentKVP.Key)
        Next

    End Sub

    Private Sub lvFiles_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvFiles.ItemDrag
        Dim myItem As ListViewItem
        Dim myItems(sender.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0

        ' Loop though the SelectedItems collection for the source.
        For Each myItem In sender.SelectedItems
            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i = i + 1
        Next
        ' Create a DataObject containg the array of ListViewItems.
        sender.DoDragDrop(New DataObject("System.Windows.Forms.ListViewItem()", myItems), DragDropEffects.Move)

    End Sub

    Private Sub lvFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragEnter

        If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem()") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub lvFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragDrop

        Try
            Dim i As Integer
            Dim l_Point As Point = lvFiles.PointToClient(New Point(e.X, e.Y))
            Dim l_Item As ListViewItem = lvFiles.GetItemAt(l_Point.X, l_Point.Y)
            Dim l_Items() As ListViewItem = e.Data.GetData("System.Windows.Forms.ListViewItem()")
            Dim l_DropIndex As Integer = l_Item.Index

            For Each l_Item In l_Items
                lvFiles.Items.Remove(lvFiles.SelectedItems.Item(0))
            Next

            For Each l_Item In l_Items
                lvFiles.Items.Insert(l_DropIndex + i, l_Items(i))
                i = i + 1
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReorder.Click

        Dim dtCreation = New DateTime(2012, 1, 1, 1, 1, 1)




        For Each lviFileName As ListViewItem In lvFiles.Items
            File.SetCreationTime(fbBrowser.SelectedPath & "\" & lviFileName.Text, dtCreation)
            File.SetLastWriteTime(fbBrowser.SelectedPath & "\" & lviFileName.Text, dtCreation)
            File.SetLastAccessTime(fbBrowser.SelectedPath & "\" & lviFileName.Text, dtCreation)
            dtCreation = dtCreation.AddSeconds(-1)
        Next


        PopulateLV(fbBrowser.SelectedPath)
        MsgBox("done")

    End Sub
End Class
