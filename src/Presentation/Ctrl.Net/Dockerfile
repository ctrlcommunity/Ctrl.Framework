#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Presentation/Ctrl.Net/CtrlCloud.Framework.Web.csproj", "src/Presentation/Ctrl.Net/"]
COPY ["src/Core/Ctrl.Core.EntityFrameworkCore/CtrlCloud.Framework.EntityFrameworkCore.csproj", "src/Core/Ctrl.Core.EntityFrameworkCore/"]
COPY ["src/Domain/System/Ctrl.Domain.Models/CtrlCloud.Framework.Domain.csproj", "src/Domain/System/Ctrl.Domain.Models/"]
COPY ["src/CtrlCloud.Framework.Application.Contracts/CtrlCloud.Framework.Application.Contracts.csproj", "src/CtrlCloud.Framework.Application.Contracts/"]
COPY ["src/CtrlCloud.Framework.Domain.Shared/CtrlCloud.Framework.Domain.Shared.csproj", "src/CtrlCloud.Framework.Domain.Shared/"]
COPY ["src/CtrlCloud.Framework.Core/CtrlCloud.Framework.Core.csproj", "src/CtrlCloud.Framework.Core/"]
COPY ["src/CtrlCloud.Framework.Web.Core/CtrlCloud.Framework.Web.Core.csproj", "src/CtrlCloud.Framework.Web.Core/"]
COPY ["src/Ctrl.Application/CtrlCloud.Framework.Application.csproj", "src/Ctrl.Application/"]
RUN dotnet restore "src/Presentation/Ctrl.Net/CtrlCloud.Framework.Web.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Ctrl.Net"
RUN dotnet build "CtrlCloud.Framework.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CtrlCloud.Framework.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CtrlCloud.Framework.Web.dll"]