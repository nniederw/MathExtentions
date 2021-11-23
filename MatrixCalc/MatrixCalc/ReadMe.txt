Crosscompile for diffrent os

run in terminal in source directory.
dotnet publish -c release -r win-x64 --self-contained
dotnet publish -c release -r linux-x64 --self-contained
dotnet publish -c release -r osx-x64 --self-contained

Reference:
https://docs.microsoft.com/en-us/dotnet/core/rid-catalog