$projectDir = $(Join-Path . test -Resolve)
#$testPath = $(Join-Path . '..\..\ockham.net\tools\test.ps1' -Resolve)
$testPath = $(Join-Path . '..\ref\ockham.net\tools\test.ps1' -Resolve)

. $testPath -ProjectDirectory $projectDir -Configuration Release -API -Build -Unit