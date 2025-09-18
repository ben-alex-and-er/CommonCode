@echo off
echo === Packing all projects ===
for %%project in (*.csproj) do (
  echo Packing %%project...
  dotnet pack %%project --configuration Release --no-build -o ./artifacts
)