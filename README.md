# Portfolio App

Dit is een full-stack portfolio-applicatie gebouwd met Angular voor de frontend en ASP.NET Core met Entity Framework voor de backend. Het maakt gebruik van een MSSQL-database om gegevens op te slaan.

## Overzicht

Deze applicatie is bedoeld om een portfolio van projecten te presenteren. Het bevat functies zoals het bekijken van projecten, toevoegen van nieuwe projecten en het zoeken naar projecten op basis van tags.

## Technologieën

- **Frontend**: Angular
- **Backend**: ASP.NET Core, Entity Framework
- **Database**: MSSQL

## Draai-instructies

1. **Docker Compose**: Draai Docker Compose om de database en de API te starten:
   ```bash
   docker-compose up
   ```

2. Bezoek `localhost:5000/swagger` voor de Swagger API-documentatie. Hier kan de database worden geseed door een POST-verzoek te sturen naar de `SeederController`.

3. Bezoek `localhost:4200` voor de website.

## Auteur

- Naam: Oliver Norton

## Opmerkingen

Dit project is gemaakt als onderdeel van een opdracht voor Cloud Native Development.
