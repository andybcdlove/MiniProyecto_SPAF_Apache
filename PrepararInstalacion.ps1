$ErrorActionPreference = 'Stop'
$marca = Get-Date -Format 'yyyyMMdd-HHmmss-fff'
$salida = Join-Path $PSScriptRoot "artifacts/Windows-x64-$marca"
$proyecto = Join-Path $PSScriptRoot 'MiniProyecto_SPAF_Apache/MiniProyecto_SPAF_Apache.csproj'
dotnet publish $proyecto -c Release -r win-x64 --self-contained true -o $salida
if ($LASTEXITCODE -ne 0) { throw 'Falló la publicación. No se generó el ZIP.' }
Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'docs/INSTALACION.txt') -Destination $salida
Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'docs/Verificacion-otra-computadora.md') -Destination $salida
Compress-Archive -Path (Join-Path $salida '*') -DestinationPath "$salida.zip"
Write-Output "Paquete generado: $salida.zip"
