#!/bin/bash
token="admin"
dir="$(pwd)"

dotnet test test/Infrastructure/EntryPoint/MDT.Web.Test/MDT.Web.Test.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet build-server shutdown
dotnet sonarscanner begin /d:sonar.login="admin" /d:sonar.password="admin" /k:"MDTNetCore" /d:sonar.language="cs"  /d:sonar.cs.opencover.reportsPaths="test/Infrastructure/EntryPoint/MDT.Web.Test/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"
dotnet build
dotnet sonarscanner end /d:sonar.login="admin" /d:sonar.password="admin"

