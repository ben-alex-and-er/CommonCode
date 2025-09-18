@echo off
echo === Pushing packages to NuGet ===
for %%package in (artifacts\*.nupkg) do (
  echo Pushing %%package...
  dotnet nuget push %%package --api-key %1 --source https://api.nuget.org/v3/index.json --skip-duplicate
)
