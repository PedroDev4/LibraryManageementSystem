FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80

COPY *.sln .
COPY "/LibraryManagement.Api/LibraryManagement.Api.csproj" "/LibraryManagement.Api/"
COPY "/LibraryManagement.Application/LibraryManagement.Application.csproj" "/LibraryManagement.Application/"
COPY "/LibraryManagement.Consumers/LibraryManagement.Consumers.csproj" "/LibraryManagement.Consumers/"
COPY "/LibraryManagement.Business/LibraryManagement.Business.csproj" "/LibraryManagement.Business/"
COPY "/LibraryManagement.Infrastructure/LibraryManagement.Infrastructure.csproj" "/LibraryManagement.Infrastructure/"

RUN dotnet restore "/LibraryManagement.Api/LibraryManagement.Api.csproj"


COPY . ./
WORKDIR /app/LibraryManagement.Api
RUN dotnet publish -c Release -o publish 


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/LibraryManagement.Api/publish ./
ENTRYPOINT ["dotnet", "LibraryManagement.Api.dll"]