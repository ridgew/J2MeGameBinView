set s = CreateObject("Wscript.Shell")
Set oExec = s.Exec("%comspec% /K ""cscript //nologo /H:CScript""")
If oExec.Status = 0 Then
	Set s = Nothing
End If
