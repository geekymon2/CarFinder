#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:5000"

until ./Cars.EF.Migrations; do
>&2 echo "SQL Server migrations are being applied..."
sleep 1
done

>&2 echo "SQL Server is up... Running appliction..."
exec $run_cmd