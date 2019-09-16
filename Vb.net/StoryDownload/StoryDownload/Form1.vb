Imports System.IO, System.Net, System.Text, System.Text.RegularExpressions
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("This Project Coded By > MrVirus" + vbCrLf + "Instagram : BQBB" + vbCrLf + "Telegram : camera")
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Function getid(user As String)
        Dim web As New WebClient
        Dim result As String = web.DownloadString("https://www.instagram.com/" + user)
        Dim idu As String = Regex.Match(result, """profilePage_(.*?)""").Groups(1).Value
        Return idu
    End Function
    Function downloadall(idu As String)
        Dim path As String = System.Environment.CurrentDirectory

        Dim web As New WebClient
        Dim download As New WebClient
        Dim result As String = web.DownloadString("http://mrvirus.cf/StoryDownload.php?id=" + idu)
        Dim ma As MatchCollection = Regex.Matches(result, "{URL:(.*?)}")
        Dim ib As Integer = 0
        For Each url As Match In ma
            Dim ul As String = url.Groups(1).Value
            If ul.Contains("mp4") Then
                Dim ul2 As Uri = New Uri(ul)

                download.DownloadFile(ul2, path + "\" + TextBox1.Text.ToString() + ib.ToString + ".mp4")
                ib += 1
            Else
                Dim ul2 As Uri = New Uri(ul)
                download.DownloadFile(ul2, path + "\" + TextBox1.Text.ToString() + ib.ToString + ".jpg")
                ib += 1
            End If

        Next
        MsgBox("<3")
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ids As String = getid(TextBox1.Text)
        downloadall(ids)

    End Sub
End Class
