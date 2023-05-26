dotnet test test/Infrastructure/EntryPoint/MDT.Web.Test/MDT.Web.Test.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet build-server shutdown
dotnet sonarscanner begin /k:"depazjose_DomanDrivenDesignNet" /o:"depazjose" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="6c273f46482d3db356ed898f6a92c595fc3fbef9" /d:sonar.cs.opencover.reportsPaths="test\Infrastructure\EntryPoint\MDT.Web.Test\coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs" /d:sonar.exclusions="src/Application/MDT.AppService/wwwroot/css/site.css"
dotnet build
dotnet sonarscanner end /d:sonar.login="6c273f46482d3db356ed898f6a92c595fc3fbef9" 
