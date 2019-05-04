# build.ps1
# By: Adam Renaud
# Created on: 2019-02-03

Write-Output "Building All Projects"

# The Solution Dir
$SolutionDir = "C:\Dev\dxflibrary"
$ArtifactsDir = Join-Path -Path $SolutionDir -ChildPath "artifacts"

# Build the projects and place into artifacts
(Get-ChildItem -Path $SolutionDir -Recurse -Filter "*.csproj").FullName | dotnet build -o $ArtifactsDir | dotnet clean
