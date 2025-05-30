# SportsManagement

An SQL database-based sports management system's website interface.
To assist me, I have constructed an EERD and its relational schema.

[EERD_SM.pdf](https://github.com/mohamedghaly1/SportsManagement/files/11394213/EERD_SM.pdf)

[Schema_SM.pdf](https://github.com/mohamedghaly1/SportsManagement/files/11394214/Schema_SM.pdf)


# ⚽ Sports Match & Fan Management System
## 📌 Project Overview
This project is a relational database system designed to manage football clubs, stadiums, matches, fans, and organizational users such as association managers, club representatives, stadium managers, and system administrators. The system offers functionality for ticket booking, match scheduling, and data access control based on user roles.

It was developed as a term project for a university Database Systems course, emphasizing Enhanced ER modeling, relational schema design, SQL views, stored procedures, triggers, and role-based access logic.

## ✅ Key Features
### Role-based system:

Association Managers: Manage clubs and matches.

Club Representatives: View tickets and fans of their matches.

Stadium Managers: View tickets for matches at their stadiums.

System Admins: Manage user accounts.

Fans: Register, buy tickets, and view match history.

### Ticketing System:

Fans can book only one ticket per match.

Matches can be scheduled, ongoing, or completed.

System prevents booking after match starts.

### Match Management:

Each match has exactly one home and one away club.

Stadiums host matches, with seating and ticketing capacity constraints.

Match results are derived from score data.

### Data Integrity and Security:

Use of stored procedures and functions to encapsulate logic.

Views ensure access control per user role.

Proper naming conventions followed for all database objects.

## 🗂️ System Modules and Entities
###🧩 Core Entities
Club (ClubID, Name, Location, ManagerID)

Stadium (StadiumID, Name, Capacity, Location)

Match (MatchID, HomeClubID, AwayClubID, StadiumID, StartTime, EndTime, Status, HomeScore, AwayScore)

User (ISA hierarchy into Fan, ClubRep, StadiumManager, AssociationManager, SystemAdmin)

Ticket (SeatNumber, MatchID, FanID)

### 🗺️ EER Model Highlights
ISA relationship from User to specialized roles.

Ticket is a weak entity, identified by (SeatNumber, MatchID), dependent on both Match and Fan.

Derived attributes like MatchResult.

Participation constraints and cardinality accurately modeled.

## 🧮 Database Schema and Design
[EERD_SM.pdf](https://github.com/mohamedghaly1/SportsManagement/files/11394213/EERD_SM.pdf)

[Schema_SM.pdf](https://github.com/mohamedghaly1/SportsManagement/files/11394214/Schema_SM.pdf)

### The relational schema was derived from the EER model using:

Normalization to 3NF.

Clear primary and foreign key constraints.

Support for referential integrity.

### Schema includes:

CLUB, STADIUM, MATCH, TICKET, USER, and subtype tables (FAN, CLUBREP, etc.).

Proper usage of indexes, views, and composite/partial keys.

## 🧠 SQL Logic Implementation
Stored Procedures: For ticket booking, match creation, user registration, and result calculation.

Functions: Derive match result from scores.

Views: Role-based access for ClubReps, StadiumManagers, and AssociationManagers.

Constraints and Triggers:

Prevent multiple tickets per fan per match.

Restrict bookings after match start time.

## 🛠️ Tech Stack
DBMS: MySQL / PostgreSQL (specify your DBMS)

Tools: MySQL Workbench / pgAdmin (or others you used)

Languages: SQL (DDL, DML, Procedures, Functions)

📷 Screenshots
(Optional — add ER diagram, schema snapshots, sample query results, etc.)

##🚀 Setup & Testing
Clone the repository:
git clone https://github.com/mohamedghaly1/SportsManagement.git
Load schema and procedures from /sql directory.
