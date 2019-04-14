# Build image
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder

WORKDIR /
# Copy files
COPY . ./

WORKDIR /src/MessageEndpoint
RUN dotnet publish --configuration Release -o out 

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /bin
COPY --from=builder /src/MessageEndpoint/out .
ENTRYPOINT ["dotnet", "MessageEndpoint.dll"]