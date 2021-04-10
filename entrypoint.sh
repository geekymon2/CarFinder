#!/bin/bash

set -e
run_cmd="dotnet Cars.Api.dll"

#lets wait 3 seconds for things to startup
sleep 3

# Apply EF migrations
until ./Cars.EF.Migrations; do
>&2 echo "SQL Server migrations are being applied..."
sleep 1
done

>&2 echo "SQL Server is up... Running appliction..."
exec $run_cmd