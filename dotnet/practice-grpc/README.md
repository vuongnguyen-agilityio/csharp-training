# Practice Dotnet gRPC
Timeline: 4 days

### Technical
1. .net 8
2. gRPC

### Requirements
- Implement Bi-directional Streaming gRPC service
- Implement Authentication
- Implement Razor Page to send Bi-directional streaming message

### Breakdown Tasks (4 days)
- Implement a console application is used as the gRPC client - 0.25 days
- Implement Authentication for gRPC client - 0.25 days
- Implement a gRPC server to validate the access token - 0.5 days
- Add Razor Pages to gRPC service - 0.25 days
- Setup Bi-directional Streaming gRPC server
  - Add the client into the list of subscribers if client send a message - 0.75 days
  - Broadcast message from sender (client) to all other clients - 0.75 days
  - Remove client from list if the gRPC client closed - 0.5 days
  - Update Razor Page to send a broadcast message to all clients - 0.5 days
