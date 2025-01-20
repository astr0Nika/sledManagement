# Sled Manager

## Current Status

Works: 
- creating user
- creating sled
- reserving a sled
- login page, but logged user is not saved

In Progress:
- when task failed, show message
- sucessfull login
- check for authorised users 

Documentation:
- tables for database 
- tests for any entry in the database
- user documentation which has not yet been started

## Run Program

- clone git reposetory
- change database connection in file `SledDbContext.cs` - path: `./apec4_sledManagement/apec4_sledManagement.Library/`
- now build/run

## Exercise in german

Eine Almhütte möchte neben der Verpflegung von Gästen, auch einen Rodelverleih anbieten. Über einen Onlineservice soll den Gästen, die Reservierung von Schlitten aus den drei Kategorien Rennschlitten, Einsitzer und Zweisitzer möglich sein. 

### Beschreibung:
- Jeder Gast muss sich mit Benutzernamen und Passwort (mindestens 5 Zeichen mit Buchstaben und Zahlen) anmelden – ist ein Gast noch nicht im System vorhanden, kann er sich über die Plattform mit einer E-Mail-Adresse registrieren. 
- Erstellung der Registrierungsmaske für die Gäste. 
    - Vorname 
    - Nachname 
    - Username 
    - E-Mail-Adresse 
    - Passwort 
- Erstellung einer Erfassungsmaske für die Reservierung eines Schlittens 
    - Datum 
    - Zeitstempel Beginn 
    - Zeitstempel Ende 
    - Kunde 
    - Schlitten-Nummer 
- Erstellung einer Erfassungsmaske der Schlitten (Kann nur vom Admin angelegt werden) - Schlittenkategorie soll mittels Auswahlliste gewählt werden. 
    - Schlitten-Nummer 
    - Tag der Anschaffung 
    - Schlittenkategorie 
- Erstellen einer Auswertungsseite. Der angemeldete Admin soll alle Zeiten (Gesamtzeit pro Schlitten-Kategorie) sehen. Achten Sie auf die Zeiten Ende darf nicht vor Beginn der Ausleihzeit liegen! Alle Pflichtfelder müssen gefüllt sein. 

### Abgabe: 
- Datenbankdiagramm 
- Dokumentation der Eingabemaske „Reservierung“ mit Bildschirmaufbau, Feldtypen, Validierungen. 
- Kommentierter Programmcode 