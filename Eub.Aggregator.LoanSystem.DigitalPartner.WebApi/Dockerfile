#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ENV https_proxy='http://proxy.eub.kz:8080'
ENV HTTPS_PROXY='http://proxy.eub.kz:8080'
ENV no_proxy='localhost,127.0.0.1,eub.kz,.eub.kz,*.eub.kz'
ENV NO_PROXY='localhost,127.0.0.1,eub.kz,.eub.kz,*.eub.kz'

ENV DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0

# Install ca-certificates
# Please locate cert_file_name.crt file in the same directory as Dockerfile.
WORKDIR /app
# Create USER
RUN addgroup --system --gid 1000 micro && \
	adduser --system --uid 1000 --ingroup micro --shell /bin/sh micro
WORKDIR /src
COPY . .

RUN dotnet restore "Eub.Aggregator.LoanSystem.DigitalPartner.WebApi/Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.csproj"
RUN dotnet build "Eub.Aggregator.LoanSystem.DigitalPartner.WebApi/Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.csproj" -c Release 

# copy and publish app and libraries
COPY . .
# Build a release artifact.
RUN dotnet publish "Eub.Aggregator.LoanSystem.DigitalPartner.WebApi/Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.csproj" -c Release -o /app

# Support healthcheck
RUN echo 'Acquire::http::Proxy "http://proxy.eub.kz:8080";' > /etc/apt/apt.conf.d/05proxy && \
GRPC_HEALTH_PROBE_VERSION=v0.4.13 && \
wget --no-verbose -e use_proxy=yes -e https_proxy=proxy.eub.kz:8080 -O /app/grpc_health_probe https://github.com/grpc-ecosystem/grpc-health-probe/releases/download/${GRPC_HEALTH_PROBE_VERSION}/grpc_health_probe-linux-amd64 && \
/bin/chmod +x /app/grpc_health_probe

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

COPY --from=build /app .
ENV ASPNETCORE_URLS http://*:7198
EXPOSE 7198
ENTRYPOINT ["dotnet", "Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.dll"]