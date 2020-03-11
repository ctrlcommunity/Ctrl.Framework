#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Presentation/Ctrl.Net/Ctrl.Web.Host.csproj", "src/Presentation/Ctrl.Net/"]
COPY ["src/Domain/System/Ctrl.Domain.Business/Ctrl.Domain.Business.csproj", "src/Domain/System/Ctrl.Domain.Business/"]
COPY ["src/Domain/System/Ctrl.Domain.DataAccess/Ctrl.Domain.DataAccess.csproj", "src/Domain/System/Ctrl.Domain.DataAccess/"]
COPY ["src/Core/Ctrl.Core.DataAccess/Ctrl.Core.DataAccess.csproj", "src/Core/Ctrl.Core.DataAccess/"]
COPY ["src/Core/Ctrl.Core.PetaPoco/Ctrl.Core.PetaPoco.csproj", "src/Core/Ctrl.Core.PetaPoco/"]
COPY ["src/Core/Ctrl.Core.Entities/Ctrl.Core.Entities.csproj", "src/Core/Ctrl.Core.Entities/"]
COPY ["src/Core/Ctrl.Core.Core/Ctrl.Core.Core.csproj", "src/Core/Ctrl.Core.Core/"]
COPY ["src/Core/Ctrl.Core.EntityFrameworkCore/Ctrl.Core.EntityFrameworkCore.csproj", "src/Core/Ctrl.Core.EntityFrameworkCore/"]
COPY ["src/Domain/System/Ctrl.Domain.Models/Ctrl.Domain.Models.csproj", "src/Domain/System/Ctrl.Domain.Models/"]
COPY ["src/Core/Ctrl.Core.Business/Ctrl.Core.Business.csproj", "src/Core/Ctrl.Core.Business/"]
COPY ["src/Core/Ctrl.Core.Web/Ctrl.Core.Web.csproj", "src/Core/Ctrl.Core.Web/"]
RUN dotnet restore "src/Presentation/Ctrl.Net/Ctrl.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Ctrl.Net"
RUN dotnet build "Ctrl.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ctrl.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ctrl.Web.Host.dll"]