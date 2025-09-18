@echo off
echo === Pushing packages to NuGet ===

for %%p in (artifacts\*.nupkg) do (
  echo Pushing %%p...
  dotnet nuget push "%%p" --api-key "%NUGET_TOKEN%" --source "https://api.nuget.org/v3/index.json" --skip-duplicate
)
