'const BCPath = "D:\长城软件\手机游戏\Tools\BINCompiler\BinCompiler.exe"
'const SourceDir = "D:\长城软件\手机游戏\@Docs\20081229\pass1\102罗奇村\part1 "
'const OutFileNamePath = "D:\长城软件\手机游戏\@Docs\20081229\pass1\102罗奇村\part1\auto.bin "

sub w(n)
	wscript.sleep n
end Sub

Sub e(x)
	WScript.Echo(x)
End Sub

Function IsMatch(pattern, str)
    Dim Re,blnResult
    blnResult = false
    Set Re = New RegExp
        Re.Pattern = pattern
        Re.IgnoreCase = True
        Re.Global = True
        blnResult = Re.Test(str)
    Set Re = Nothing
    IsMatch = blnResult
End Function

Sub Send(shell, appTitle, str)
	shell.Run "cmd.exe /c echo " & str & " | clip.exe", vbHide
	WScript.Sleep 1000
	shell.AppActivate appTitle
	shell.SendKeys "^v{BS}"
End Sub


Const Win = "BINCompiler v0.70"
set s = CreateObject("Wscript.Shell")
app = s.run(BCPath)
s.AppActivate app
w(1000)
s.SendKeys("{Tab 2}")
If IsMatch("[^\x00-\xFF]+", SourceDir) Then
    Send s, app, SourceDir
Else
    s.SendKeys(SourceDir)
End If
s.SendKeys("{Tab 2}")
If IsMatch("[^\x00-\xFF]+", OutFileNamePath) Then
    Send s, app, OutFileNamePath
Else
    s.SendKeys(OutFileNamePath)
End If
s.SendKeys("{Tab 19}")
s.SendKeys("*.png")
s.SendKeys("%r")
w(500)
s.SendKeys("%f")
w(1000)
s.SendKeys("~")
w(500)
s.SendKeys("%c")
e("BinCompiler创建完成！")
Set s= Nothing
WScript.Quit