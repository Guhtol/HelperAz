dotnet build -c Release
$basePath= $PSScriptRoot + "\src\Presentation\bin\Debug\net8.0"

# To add folder to PATH
$persistedPath = [Environment]::GetEnvironmentVariable('Path', [EnvironmentVariableTarget]::User) -split ';'
if ($persistedPath -notcontains $basePath) {
    $persistedPath = $persistedPath + $basePath | where { $_ }
    [Environment]::SetEnvironmentVariable('Path', $persistedPath -join ';', [EnvironmentVariableTarget]::User)
  }

#To verify if PATH isn't already added
 $envPaths = $env:Path -split ';'
 if ($envPaths -notcontains $basePath) {
     $envPaths = $envPaths + $basePath | where { $_ }
     $env:Path = $envPaths -join ';'
 }
