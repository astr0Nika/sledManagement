# Database Plan

Code first with Entity Framework

## Tabelen

**User**

| Column | Type | Constraints |
| ----- | ----- | ----- |
| guid | nvarchar(255) | PK |
| firstName | nvarchar(100) | NOT NULL |
| lasstName | nvarchar(100) | NOT NULL |
| userName | nvarchar(30) | NOT NULL |
| email | nvarchar(150) | NOT NULL |
| passwordHash | nvarchar(255) | NOT NULL |

**Sled**

| Column | Type | Constraints |
| ----- | ----- | ----- |
| sledNr | int | PK |
| type | int | NOT NULL, Range(0, 3) |
| createDate | datetime | NOT NULL |

**Reservation**

| Column | Type | Constraints |
| ----- | ----- | ----- |
| ReservationId | int | PK |
| UserId | nvarchar(255) | FK, NOT NULL |
| sledNr | int | FK, NOT NULL |
| createDate | datetime | NOT NULL |
| beginDate | datetime | NOT NULL |
| endDate | datetime | NOT NULL |
