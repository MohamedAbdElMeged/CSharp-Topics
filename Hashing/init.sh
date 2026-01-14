#!/bin/bash
echo "UPDATING DATABASE"
dotnet restore "Hashing.csproj"
dotnet-ef database update
dotnet watch run --no-launch-profile