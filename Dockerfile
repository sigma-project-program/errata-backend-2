# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source

# # copy csproj and restore as distinct layers
# COPY errata-backend-2/errata-backend-2.sln .
# RUN mkdir errata-backend-2
# COPY errata-backend-2/ ./errata-backend-2/
# RUN dotnet restore -r linux-x64 errata-backend-2.sln
# WORKDIR /source/errata-backend-2
# CMD /bin/bash
# # RUN dotnet add package Microsoft.EntityFrameworkCore.Analyzers --version 6.0.5
# # RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

# # final stage/image
# # FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal-amd64
# #  WORKDIR /app
# # COPY --from=build /app ./
# # ENTRYPOINT ["./errata-backend-2"]


# copy csproj and restore as distinct layers
COPY errata-backend-2.sln ./errata-backend-2.sln
COPY errata-backend-2/*.csproj ./errata-backend-2/
# RUN dotnet restore -r linux-x64
RUN dotnet restore -r linux-x64

# copy everything else and build app
COPY errata-backend-2/. ./errata-backend-2/
WORKDIR /source/errata-backend-2
RUN dotnet add package Microsoft.EntityFrameworkCore.Analyzers --version 6.0.5
RUN dotnet add package Microsoft.EntityFrameworkCore
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations add InitialCreate2
RUN dotnet ef database update
RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal-amd64
WORKDIR /app
# RUN dotnet ef migrations add InitialCreate3
# RUn dotnet ef database update
COPY --from=build /app ./
ENTRYPOINT ["./errata-backend-2"]