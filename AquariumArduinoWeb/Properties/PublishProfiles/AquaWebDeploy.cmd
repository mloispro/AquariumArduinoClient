echo Web Project: %1
echo Pub Profile: %2

rem C:\Projects\AquariumArduinoClient\AquariumArduinoWeb\AquariumArduinoWeb.csproj
rem C:\Projects\AquariumArduinoClient\AquariumArduinoWeb\Properties\PublishProfiles\Deploy.pubxml

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild" "%1" /p:PublishProfile="%2" /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:Configuration=Release

rem pause