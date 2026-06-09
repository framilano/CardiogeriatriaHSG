# CardiogeriatriaHSG

<img width="1934" height="1043" alt="immagine" src="https://github.com/user-attachments/assets/cadacd46-8ae8-4925-bf65-d27dc7f11ab9" />


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
- [ ] Controllare campo altri analgesici su TD, va a in colonna 1 per qualche ragione
- [x] Data iniziale nascita anno attuale -80 di default
- Come gestire le TextBox di di Anamnesi Geriatrica per esempio? Soluzioni possibili:
  - Colonna B non editabile, solo Referto editabile e salvato a database, ma forse manterrebbe informazioni non vere nelle varie sottosezioni? (effort basso)
  - Terza colonna C (o quadrante B2), editabile, copia della colonna B e salvata a database, mostrata nel referto (effort medio)
  - Colonna B editabile, vuota inizialmente ma riempibile con testo di default tramite bottone, salvata a database e mostrata nel referto. Questo elimina la possibilità di generare il testo automaticamente appena interagiamo con colonna A (effort medio)
  - Colonna B editabile formata da più TextBox, una per ogni tipo di frase, editare la colonna A modificherà solo la frase associata, tutte le frasi saranno salvate a database separatamente e mostrate nel referto (effort alto)