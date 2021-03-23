#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:5000"

cd /app/src
until dotnet-ef database update --project Cars.Api.csproj; do
>&2 echo "SQL Server is starting up...."
sleep 1
done

>&2 echo "SQL Server is up - Running appliction"
exec $run_cmd