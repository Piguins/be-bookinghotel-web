# !/bin/sh
message=$1
dotnet ef migrations add $message -p src/Infrastructure -s src/Api -o Persistence/EntityFramework/Migrations
