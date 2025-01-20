# Test Dokumentation

## Erstelle Eintrag in Sled Tabelle

**Beschreibung:** Erstelle Schlitte durch den UI

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 14.01.2025 11:24 | Alle fählter ausfühlen und auf submit drücken | Create Date: 09.01.2025, Type: Racing | Eintrag befindet sich in der DB | JA |


## Erstelle Eintrag in User Tabelle

**Beschreibung:** Erstelle Benutzer durch UI

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 20.01.2025 11:44 | Alle Felder ausfühlen | Username: nika-nika, First Name: nika Last Name: nika, Email: nika@nika.com, Password: Nika | SqlException: Cannot insert the value NULL into column 'Email', table 'dbo.Users'; column does not allow nulls. INSERT fails | NEIN |
| 2 | 20.01.2025 13:36 | Alle Felder ausfühlen | Username: nika-nika, First Name: nika Last Name: nika, Email: nika@nika.com, Password: Nika | Nichts passiert | NEIN |
| 3 | 20.01.2025 13:42 | Alle Felder ausfühlen | Username: nika-nika, First Name: nika Last Name: nika, Email: nika@nika.com, Password: Nika | - | JA |
| 4 | 20.01.2025 14:01 | Alle Felder ausfuhlen | Username: test10, First Name: Test, Last Name: Ten, Email: test10@gmail.com, test10 | Sagt das felder leer sind, obwohl sie nicht sind | NEIN |
| 5 | 20.01.2025 14:08 | Alle Felder ausfuhlen | Username: test10, First Name: Test, Last Name: Ten, Email: test10@gmail.com, test10 | Nichst passiert | NEIN |
| 6 | 20.01.2025 - | Alle Felder ausfuhlen | Username: test10, First Name: Test, Last Name: Ten, Email: test10@gmail.com, test10 | - | JA |


## Login mit existierenden User

**Beschreibung:** Der vorherig erstellte Benutzer soll sich einlogen duch UI

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 20.01.2025 13:45 | Alle Felder sind richtig ausgefühlt | Username: nika-nika, Password: nika | Sagt das felder leer sind, obwohl sie nicht sind | NEIN |
| 2 | 20.01.2025 14:18 | Alle Felder sind richtig ausgefühlt | Username: nika-nika, Password: nika | - | JA |

## Zeige alle Sleds

**Beschreibung:** Eine Razor Seite wird alle sleds anzeigen

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 20.01.2025 15:24 | Sehe alle sleds | - | - | JA |
