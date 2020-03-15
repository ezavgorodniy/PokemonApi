SETLOCAL
SET ApiUrl=%1
dotnet test --filter "Category=Functional"