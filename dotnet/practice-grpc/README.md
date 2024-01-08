# Practice Dotnet gRPC
Timeline: x days

### Technical
1. .net 8
2. gRPC

### Requirements
- Implement Bi-directional Streaming gRPC service
- Implement Authentication
- Implement Razor Page to send Bi-directional streaming message

### Breakdown Tasks
- Implement a console application is used as the gRPC client
- Implement Authentication for gRPC client
- Implement a gRPC server to validate the access token
- Add Razor Pages to gRPC service
- Setup Bi-directional Streaming gRPC server
  - Add the client into the list of subscribers if client send a message
  - Broadcast message from sender (client) to all other clients
  - Remove client from list if the gRPC client closed
  - Update Razor Page to send a broadcast message to all clients
