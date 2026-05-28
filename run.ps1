#!/usr/bin/env pwsh
# Spec Kit App - Quick Start Script for Local Development
# This script sets up and runs the application with Docker Compose

param(
    [ValidateSet('start', 'stop', 'restart', 'clean')]
    [string]$Action = 'start'
)

$ErrorActionPreference = 'Stop'
$ComposeFile = Join-Path $PSScriptRoot 'docker-compose.yml'

function Write-Header {
    Write-Host "`n========================================" -ForegroundColor Cyan
    Write-Host "Spec Kit App - Local Development Setup" -ForegroundColor Cyan
    Write-Host "========================================`n" -ForegroundColor Cyan
}

function Get-DockerComposeCommand {
    $dockerComposeCmd = Get-Command docker-compose -ErrorAction SilentlyContinue
    if ($dockerComposeCmd) {
        return $dockerComposeCmd.Path
    }

    $dockerCmd = Get-Command docker -ErrorAction SilentlyContinue
    if ($dockerCmd) {
        return $dockerCmd.Path
    }

    throw "Docker Compose is not available on PATH."
}

function Run-DockerCompose {
    param(
        [string[]]$Args
    )

    $composeCmd = Get-DockerComposeCommand

    if ($composeCmd -like '*docker-compose*') {
        & $composeCmd -f $ComposeFile @Args
    } else {
        & $composeCmd compose -f $ComposeFile @Args
    }
}

function Check-Prerequisites {
    Write-Host "Checking prerequisites..." -ForegroundColor Yellow

    try {
        docker --version | Out-Null
        Write-Host "Docker is installed" -ForegroundColor Green
    } catch {
        Write-Host "Docker not found. Please install Docker Desktop." -ForegroundColor Red
        exit 1
    }

    try {
        Get-DockerComposeCommand | Out-Null
        Write-Host "Docker Compose is available" -ForegroundColor Green
    } catch {
        Write-Host "Docker Compose not found. Please install Docker Desktop or use a Docker version with Compose." -ForegroundColor Red
        exit 1
    }

    try {
        dotnet --version | Out-Null
        Write-Host ".NET SDK is installed" -ForegroundColor Green
    } catch {
        Write-Host ".NET SDK not found. Please install .NET 10.0 or later." -ForegroundColor Red
        exit 1
    }
}

function Start-Services {
    Write-Header
    Check-Prerequisites

    Write-Host "Starting services with Docker Compose..." -ForegroundColor Yellow
    Run-DockerCompose up -d

    Write-Host "`n✓ Services started successfully!" -ForegroundColor Green

    Write-Host "`nWaiting for PostgreSQL to be ready..." -ForegroundColor Yellow
    Start-Sleep -Seconds 3

    Write-Host "`n" -ForegroundColor Green
    Write-Host "Services are now running:" -ForegroundColor Cyan
    Write-Host "  • PostgreSQL: localhost:5432" -ForegroundColor White
    Write-Host "  • PgAdmin: http://localhost:5050" -ForegroundColor White
    Write-Host "    - Email: admin@example.com" -ForegroundColor Gray
    Write-Host "    - Password: admin" -ForegroundColor Gray

    Write-Host "`nBuild backend..." -ForegroundColor Yellow
    Push-Location backend
    dotnet build
    Pop-Location

    Write-Host "`nApply database migrations..." -ForegroundColor Yellow
    Push-Location backend
    dotnet ef database update
    Pop-Location

    Write-Host "`n" -ForegroundColor Green
    Write-Host "Starting backend API..." -ForegroundColor Yellow
    Write-Host "  • API: http://localhost:5000" -ForegroundColor White
    Write-Host "  • Swagger: http://localhost:5000/swagger/ui" -ForegroundColor White
    Write-Host "`nPress Ctrl+C to stop" -ForegroundColor Yellow

    Push-Location backend
    dotnet run
    Pop-Location
}

function Stop-Services {
    Write-Header
    Write-Host "Stopping services..." -ForegroundColor Yellow
    Run-DockerCompose down
    Write-Host "✓ Services stopped" -ForegroundColor Green
}

function Restart-Services {
    Stop-Services
    Start-Sleep -Seconds 2
    Start-Services
}

function Clean-Services {
    Write-Header
    Write-Host "Cleaning up services and data..." -ForegroundColor Yellow
    Run-DockerCompose down -v
    Write-Host "✓ All services and volumes removed" -ForegroundColor Green
}

switch ($Action) {
    'start' { Start-Services }
    'stop' { Stop-Services }
    'restart' { Restart-Services }
    'clean' { Clean-Services }
}
