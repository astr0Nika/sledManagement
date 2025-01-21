# Test Dokumentation

## Erstelle Eintrag in Sled Tabelle

**Beschreibung:** Erstelle Schlitte durch den UI

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 14.01.2025 11:24 | Alle fählter ausfühlen und auf submit drücken | Create Date: 09.01.2025, Type: Racing | Eintrag befindet sich in der DB | JA |
| 2 | 21.01.2025 10:30 | Alles Felder ausfühlen | - | Uncaught TypeError in Browser | NEIN |
| 3 | 21.01.2025 10:34 | Alle Felder ausfühlen | Create Date: 22.09.2024, Type: TwoSeater | Eintrag befindet sich in der DB | JA |


## Erstelle Eintrag in User Tabelle

**Beschreibung:** Erstelle Benutzer durch UI

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 20.01.2025 11:44 | Alle Felder ausfühlen | Username: nika-nika, First Name: nika Last Name: nika, Email: nika@nika.com, Password: Nika | SqlException: Cannot insert the value NULL into column 'Email', table 'dbo.Users'; column does not allow nulls. INSERT fails | NEIN |
| 2 | 20.01.2025 13:36 | Alle Felder ausfühlen | Username: nika-nika, First Name: nika Last Name: nika, Email: nika@nika.com, Password: Nika | Nichts passiert | NEIN |
| 3 | 20.01.2025 13:42 | Alle Felder ausfühlen | Username: nika-nika, First Name: nika Last Name: nika, Email: nika@nika.com, Password: Nika | - | JA |
| 4 | 20.01.2025 14:01 | Alle Felder ausfuhlen | Username: test10, First Name: Test, Last Name: Ten, Email: test10@gmail.com, Password: test10 | Sagt das felder leer sind, obwohl sie nicht sind | NEIN |
| 5 | 20.01.2025 14:08 | Alle Felder ausfuhlen | Username: test10, First Name: Test, Last Name: Ten, Email: test10@gmail.com, Password: test10 | Nichst passiert | NEIN |
| 6 | 20.01.2025 14:22 | Alle Felder ausfuhlen | Username: test10, First Name: Test, Last Name: Ten, Email: test10@gmail.com, Password: test10 | - | JA |
| 7 | 21.01.2025 10:37 | Alle Felder ausfühlen | Username: test20, First Name: Test, Last Name: Twenty, Email: test20@gmail.com, Password: test20 | Eintrag befindet sich in der DB | JA |


## Login mit existierenden User

**Beschreibung:** Der vorherig erstellte Benutzer soll sich einlogen duch UI

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 20.01.2025 13:45 | Alle Felder sind richtig ausgefühlt | Username: nika-nika, Password: nika | Sagt das felder leer sind, obwohl sie nicht sind | NEIN |
| 2 | 20.01.2025 14:18 | Alle Felder sind richtig ausgefühlt | Username: nika-nika, Password: nika | - | JA |
| 3 | 21.01.2025 10:40 | Alle Felder sind richtig ausgefühlt | Username: test20, Password: test20 | Meine Fehlermeldung "Username or password does not match" | NEIN |
| 4 | 21.01.2025 10:51 | Alle Felder sind richtig ausgefühlt | Username:test20, Password: test20 | Nach dem Login ein Redirect auf Home Page | JA |

## Zeige alle Sleds

**Beschreibung:** Eine Razor Seite wird alle sleds anzeigen

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 1 | 20.01.2025 15:24 | Sehe alle sleds | - | - | JA |
| 2 | 21.01.2025 10:53 | Sehe alle einträge | - | - | JA |

## Reserviere ein Sled

**Beschreibung:** Reserviere eine Schlitte, wenn es eine gibt bzw. die nicht schon ausgeliehen ist

| Nr. | Datum | Aktion | Eingabe | Kommentar | Test bestanden |
| ----- | ----- | ----- | ----- | ----- | ----- |
| 2 | 20.01.2025 20:36 | Alles ausgefühlt; Leihe die, die noch nicht ausgeliehen worden sind | Type: OneSeater, Start: 22.01.2025 14:30, End: 22.01.2025 15:00 | - | JA |
| 1 | 20.01.2025 20:41 | Alles ausgefühlt; Leihe die, die nicht möglich sind | Type: OneSeater, Start: 22.01.2025 14:15, End 22.01.2025 15:30 | Sled wurde nicht ausgeliehen | JA |
| 3 | 20.01.2025 20:41 | Alles ausgefühlt; Leihe die, die nicht möglich sind | Type: OneSeater, Start: 22.01.2025 14:00, End 22.01.2025 14:45 | Sled wurde nicht ausgeliehen | JA |
| 3 | 20.01.2025 20:41 | Alles ausgefühlt; Leihe die, die nicht möglich sind | Type: OneSeater, Start: 22.01.2025 14:00, End 22.01.2025 14:45 | Sled wurde nicht ausgeliehen | JA |
| 4 | 21.01.2025 10:54 | Alles ausgefühlt; Ausleihen soll möglich sein | Type: TwoSeater, Start 10.01.2025 8:00, End: 10.01.2025 10:30 | Eintrag in Tabelle | JA |
| 5 | 21.01.2025 10:57 | Alles ausgefühlt; Ausleihen soll nicht möglich sein | Type: TwoSeater, Start: 10.01.2025 9:30, End: 10.01.2025 10:00 | Sled nicht ausgeliehen | JA |
