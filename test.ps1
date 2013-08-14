$env:SSH_ASKPASS = "$pwd\bin\debug\askpass.exe"
$env:DISPLAY = "localhost:0.0"

write-host "use ```$null | ssh-add`` to trigger"