# MvcCoreTutorial

Upgraded to .net 8.0

# How to run it
1. clone the project
   `git clone https://github.com/rd003/MvcCoreTutorial.git`
2. open `appsettings.json` file and update connection string's

    "ConnectionStrings": { "conn": "data source=your_server;initial  catalog=MvcCoreTutorial;integrated security=true;TrustServerCertificate=True" }

4. Delete `Migrations` folder
5. Open Tools > Package Manager > Package manager console
6. Run these 2 commands
    ```
     (i) add-migration init
     (ii) update-database
     ````
7. Now you can run this project
