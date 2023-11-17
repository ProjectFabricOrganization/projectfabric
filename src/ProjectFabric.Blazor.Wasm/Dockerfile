FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
COPY ["../ProjectFabric.Razor/ProjectFabric.Razor.csproj", "ProjectFabric.Razor/"]
RUN dotnet restore ProjectFabric.Blazor.Wasm.csproj
COPY . .
RUN dotnet build ProjectFabric.Blazor.Wasm.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ProjectFabric.Blazor.Wasm.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf