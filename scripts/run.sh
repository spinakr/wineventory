#!/bin/bash

set -e -o pipefail

dotnet restore dotnet-fake.csproj
dotnet fake run build.fsx -t Run