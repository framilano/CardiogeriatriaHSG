# CardiogeriatriaHSG

### Building
```
#Windows
dotnet publish -c Release -r win-x64 --self-contained true

#Linux
dotnet publish -c Release -r linux-x64 --self-contained true

#MacOs (arm64)
dotnet publish -c Release -r osx-arm64 --self-contained true
```

### DB Migrations
After making changes to the DB models, run the following command to create a new migration:
```
dotnet ef migrations add AnamnesiGeriatrica
```

### To rollback to a previous migration, use the following command:
```
dotnet ef migrations remove
```

### TODO
- [ ] Togliere svariati "riferisce" nel testo del raccordo clinico