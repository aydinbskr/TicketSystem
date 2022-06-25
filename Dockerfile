FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY ./TicketSystem.Business/*.csproj ./TicketSystem.Business/
COPY ./TicketSystem.Core/*.csproj ./TicketSystem.Core/
COPY ./TicketSystem.DataAccess/*.csproj ./TicketSystem.DataAccess/
COPY ./TicketSystem.Entities/*.csproj ./TicketSystem.Entities/
COPY ./TicketSystem.WebMVC/*.csproj ./TicketSystem.WebMVC/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./TicketSystem.WebMVC/*.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT [ "dotnet" , "TicketSystem.WebMVC.dll" ]