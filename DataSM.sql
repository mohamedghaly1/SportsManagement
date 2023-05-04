create database DataSM;
use DataSM;
 
/*---------------------------------------------------------------------------------------------------------------------------------*/
/*2.1*/
/*a*/
go;
create proc createAllTables
AS
Create table sys_user(
Username varchar(20),
Password varchar(20),
Id int identity,
Name varchar(20),
Constraint pk_user primary key (username)
)
 
Create table Club(
Id int identity ,
Name varchar(20),
location varchar(20),
Constraint pk_Club primary key (id),
);

Create table stadium (
id int identity,
Name varchar(20),
Status bit,
Capacity int,
Location varchar(20),
constraint pk_stadium primary key(id)
)
 
Create table match(
Id int identity,
Start_time datetime,
End_time datetime,
Stadium_id int,
host_id int,
guest_id int,
Constraint pk_match primary key(id),
Constraint fk_stadium_id foreign key(stadium_id) references Stadium(id) on delete set null,
Constraint fk_club1_id foreign key(host_id) references Club(id),
Constraint fk_club2_id foreign key(guest_id) references Club(id)
);
 
create table Club_Representative(
username varchar(20),
club_id int,
Constraint pk_club_representative primary key(username),
constraint fk_cr_username foreign key(username) references sys_user(username) on delete cascade,
constraint fk_cr_club_id foreign key (club_id) references  Club(id) on delete set null
);
Create table stadium_manager(
Username varchar(20),
stadium_id int,
Constraint pk_stadium_manager primary key (username),
constraint fk_sm_username foreign key(username) references sys_user(username) on delete cascade,
Constraint fk_sm_stadium_id foreign key (stadium_id) references stadium(id) on delete set null
);
create table request(
id int identity,
cr_username varchar(20),
sm_username varchar(20),
match_id int,
accept_status varchar(20),
Constraint pk_request primary key (id),
constraint fk_request_cr_username  foreign key(cr_username) references Club_Representative(username),
Constraint fk_request_sm_username  foreign key (sm_username) references stadium_manager(Username),
Constraint fk_request_match_id  foreign key (match_id) references match(id) on delete set null
);
 
Create table Sports_Association_Manager(
username varchar(20),
Constraint pk_Sports_Association_Manager primary key(username),
Constraint fk_sam_username foreign key (username) references sys_user(username) on delete cascade
);
 
Create table system_admin(
Username varchar(20),
Constraint pk_system_admin primary key(username),
Constraint fk_sa_username foreign key(username) references sys_user(username) on delete cascade
);
 
Create table fan(
Username varchar(20),
national_id varchar(20),
Phone_number int,
Birth_date datetime,
Address varchar(20),
fan_status bit,
Constraint pk_fan primary key(username),
Constraint fk_fan_username foreign key(username) references sys_user(username) on delete cascade
);
 
Create table ticket(
Id int identity,
match_id int,
status bit,
Stadium_name varchar(20),
Fan_username varchar(20),
Constraint pk_ticket primary key(Id, match_id),
Constraint fk_ticket_match_id foreign key (match_id) references match(id) on delete cascade,
Constraint fk_ticket_Fan_username foreign key (fan_username) references fan(username) on delete set null
);
go;
/*b*/
go;
create proc dropAllTables
AS
drop table ticket;
drop table fan;
drop table system_admin;
drop table sports_association_manager;
drop table request;
drop table stadium_manager;
drop table club_representative;
drop table match;
drop table stadium;
drop table club;
drop table sys_user;
go;
/*c*/
go;
create proc dropAllProceduresFunctionsViews
As
drop procedure createAllTables;
drop procedure dropAllTables;
drop procedure clearAllTables;
 
drop view allAssocManagers;
drop view allClubRepresentatives;
drop view allStadiumManagers;
drop view allFans;
drop view allMatches;
drop view allTickets;
drop view allClubs;
drop view allStadiums;
drop view allRequests;
 
drop procedure addAssociationManager
drop procedure addNewMatch
drop view clubsWithNoMatches
drop procedure deleteMatch
drop procedure deleteMatchesOnStadium
drop procedure addClub
drop procedure addTicket
drop procedure deleteClub
drop procedure addStadium
drop procedure deleteStadium
drop procedure blockFan
drop procedure unblockFan
drop procedure addRepresentative
drop function dbo.viewAvailableStadiumsOn
drop procedure addHostRequest
drop function dbo.allUnassignedMatches
drop procedure addStadiumManager
drop function dbo.allPendingRequests
drop procedure acceptRequest
drop procedure rejectRequest
drop procedure addFan
drop function dbo.upcomingMatchesOfClub
drop function dbo.availableMatchesToAttend
drop procedure purchaseTicket
drop procedure updateMatchHost
drop view matchesPerTeam
drop view clubsNeverMatched
drop function dbo.clubsNeverPlayed
drop function dbo.matchWithHighestAttendance
drop function dbo.matchesRankedByAttendance
drop function dbo.requestsFromClub
go;
/*d*/
go;
create proc clearAllTables
AS
delete from ticket;
delete from fan;
delete from system_admin;
delete from  sports_association_manager;
delete from  request;
delete from  stadium_manager;
delete from  club_representative;
delete from  match;
delete from  stadium;
delete from  club;
delete from  sys_user;
go;
/*---------------------------------------------------------------------------------------------------------------------------------*/
/*2.2*/
/*a*/
go;
create view allAssocManagers
as
select su.username as username ,su.Password as password, su.name as name
from Sports_Association_Manager sam inner join sys_user su on su.Username = sam.username
go;
/*b*/
go;
create view allClubRepresentatives
as
select su.username as username,su.Password as password ,su.name as name ,c.name as club_name
from Club_Representative cr inner join sys_user su on su.Username = cr.username inner join Club c on c.id = cr.club_id
go;
/*c*/
go;
create view allStadiumManagers
as
select su.username as username,su.Password as password,su.name as name,s.name as stadium_name
from stadium_manager sm inner join sys_user su on su.Username = sm.username inner join stadium s on s.id = sm.stadium_id
go;
/*d*/
go;
create view allFans
as
select  su.Username as username,su.Password as password ,su.name as name,f.national_id as national_id ,f.Birth_date as birth_date ,f.fan_status as fan_status
from fan f inner join sys_user su on su.Username = f.username
go;
/*e*/
go;
create view allMatches
as
select c1.name as host_club ,c2.name as  guest_club ,m.Start_time as start_time
from match as m inner join club c1 on m.host_id=c1.Id inner join club c2 on c2.Id=m.guest_id
go;
/*f*/
go;
create view allTickets
as
select c1.name as  host_club ,c2.name as guest_club,  s.Name as stadium_name, m.Start_time as start_time
from ticket t inner join match m on t.match_id=m.Id inner join club c1 on m.host_id=c1.Id inner join club c2 on m.guest_id=c2.Id inner join stadium s on s.id=m.Stadium_id
go;
/*g*/
go;
create view allClubs
as
select name,location
from club
go;
/*h*/
go;
create view allStadiums
as
select name,location,capacity,status
from stadium
go;
/*i*/
go;
create view allRequests
as
select cr.Username as club_representative_username,sm.Username as stadium_manager_username ,r.accept_status as accept_status
from request r inner join sys_user cr on r.cr_username=cr.Username inner join sys_user sm on r.sm_username=sm.Username
go;
 
 
/*----------------------------------------------------------------------------------------------------------------------------------*/
/*2.3*/
/*i*/
go;
create proc addAssociationManager
@name varchar(20),
@username varchar(20),
@password varchar(20)
as
insert into sys_user (Name,Username,Password) values (@name,@username,@password)
insert into Sports_Association_Manager(username) values (@username)
go;
/*ii*/
go;
create proc addNewMatch
@name_host varchar(20),
@name_guest varchar(20),
@start_time datetime,
@end_time datetime
as
declare @host_id int
declare @guest_id int
select @host_id = c.id
from Club c
where c.name = @name_host
select @guest_id = c.id
from Club c
where c.name = @name_guest
insert into match(host_id,guest_id,Start_time,end_time) values (@host_id ,@guest_id,@start_time,@end_time)
go;
/*iii*/
go;
create view clubsWithNoMatches
as
select c1.name
from club c1
where c1.id not in (select m1.host_id from match m1) and c1.id not in (select m2.guest_id from match m2)
go;
/*iv*/
go;
create proc deleteMatch
@name_host varchar(20),
@name_guest varchar(20)
as
declare @host_id int
declare @guest_id int
select @host_id = c.id
from Club c
where c.name = @name_host
select @guest_id = c.id
from Club c
where c.name = @name_guest
 
delete from match where host_id=@host_id  and guest_id=@guest_id
go;
/*v*/
go;
create proc deleteMatchesOnStadium
@stadium_name varchar(20)
as
declare @stadium_id int
select @stadium_id = s.id
from Stadium s
where s.name = @stadium_name
 
delete from match
where stadium_id=@stadium_id and start_time>CURRENT_TIMESTAMP
go;
/*vi*/
go;
create proc addClub
@club varchar(20),
@location_club varchar(20)
as
insert into Club (Name,location) values (@club,@location_club)
go;
/*vii*/
go;
create proc addTicket
@name_host_club varchar(20),
@name_guest_club varchar(20),
@start_time datetime
as
declare @host_id int
declare @guest_id int
 
select @host_id = c.Id
from club c
where c.name = @name_host_club
 
select @guest_id = c.Id
from club c
where c.name = @name_guest_club
 
declare @match_id int
select @match_id = m.id
from match m
where m.host_id = @host_id and m.guest_id=@guest_id and m.Start_time = @start_time
 
declare @stadium_name varchar(20)
select  @stadium_name=s.name
from match m inner join stadium s on m.Stadium_id = s.id
where m.id = @match_id
 
insert into ticket values (@match_id,1,@stadium_name,NULL)
go;
/*viii*/
go;
create proc deleteClub
@club_name varchar(20)
as
delete from club where name=@club_name
go;
/*ix*/
go;
create proc addStadium
@stadium_name varchar(20),
@location varchar(20),
@capacity int
as
insert into stadium values (@stadium_name,1,@capacity,@location)
go;
/*x*/
go;
create proc deleteStadium
@stadium_name varchar(20)
as
delete from stadium where name=@stadium_name
select * from stadium;
go;
/*xi*/
go;
create proc blockFan
@national_id varchar(20)
as
update fan set fan_status=0 where national_id=@national_id
go;
/*xii*/
go;
create proc unblockFan
@national_id varchar(20)
as
update fan set fan_status=1 where national_id=@national_id
go;
/*xiii*/
go;
create proc addRepresentative
@name varchar(20),
@club_name varchar(20),
@username varchar(20),
@password varchar(20)
as
declare @club_id INT
select @club_id = c.id
from club c
where c.name =@club_name
 
insert into sys_user (Name,Username,Password) values (@name,@username,@password)
insert into Club_Representative(username,club_id) values (@username,@club_id)
go;
/*xiv*/
go;
create function viewAvailableStadiumsOn
(@date_time datetime)
returns table 
as
return
   select s.name, s.Location,s.Capacity
   from stadium s
   where s.Status=1 and s.id not in(select m.Stadium_id from  match m where s.id=m.Stadium_id and @date_time=m.Start_time)
go;
/*xv*/
go;
create proc addHostRequest
@club_name varchar(20),
@stadium_name varchar(20),
@start_time datetime
as
 
declare @club_id int
select @club_id = c.id
from club c
where c.name = @club_name
 
declare @cr_username varchar(20)
select @cr_username = cr.username
from Club_Representative cr
where cr.club_id = @club_id
 
declare @stadium_id int
select @stadium_id = s.id
from stadium s
where s.name = @stadium_name
 
declare @sm_username varchar(20)
select @sm_username = sm.username
from stadium_manager sm
where sm.stadium_id = @stadium_id
 
declare @match_id int
select @match_id = m.id
from match m
where m.host_id = @club_id and m.Start_time <= @start_time and m.Start_time >= @start_time
 
insert into request values (@cr_username,@sm_username,@match_id,'Unhandled')
go;
/*xvi*/
go;
CREATE FUNCTION allUnassignedMatches(@club_name varchar(20)) 
RETURNS TABLE 
AS
return
   select c2.Name as guest_club_name, m.Start_time as start_time
   from match m inner join club c1 on m.host_id = c1.id inner join club c2 on m.guest_id = c2.id
   where c1.name = @club_name and m.Stadium_id is null
go;
/*xvii*/
go;
create proc addStadiumManager
@name varchar(20),
@stadium_name varchar(20),
@username varchar(20),
@password varchar(20)
as
declare @stadium_id int
select @stadium_id = s.id
from stadium s
where s.name = @stadium_name
 
insert into sys_user (Name,Username,Password) values (@name,@username,@password)
insert into stadium_manager(username,stadium_id) values (@username,@stadium_id)
go;
/*xviii*/
go;
CREATE FUNCTION allPendingRequests(@username varchar(20)) 
RETURNS TABLE 
AS
RETURN 
   SELECT su2.Name as club_representative_name, g.name as guest_club_name, m.Start_time as start_time
   FROM request r inner join stadium_manager sm on r.sm_username=sm.Username
                  inner join Club_Representative cr on r.cr_username=cr.username
                  inner join sys_user su1 on su1.username=sm.Username
                  inner join sys_user su2 on su2.Username=cr.username
                  inner join match m on m.id=r.match_id
                  inner join club g on m.guest_id=g.id
   WHERE  @username = sm.Username and r.accept_status = 'Unhandled'
go;
/*xix*/
go;
create proc acceptRequest
@sm_username varchar(20),
@hosting_club_name varchar(20),
@competing_club_name varchar(20),
@start_time datetime
as
declare @cr_username varchar(20)
select @cr_username = cr.username
from club_representative cr inner join club c on cr.club_id = c.id
where c.name = @hosting_club_name
 
declare @hosting_club_id int
select @hosting_club_id = c.id
from club c
where c.name = @hosting_club_name
 
declare @competing_club_id int
select @competing_club_id = c.id
from club c
where c.name = @competing_club_name
 
declare @stadium_id int
select @stadium_id = sm.stadium_id
from stadium_manager sm
where sm.username = @sm_username
 
declare @match_id int
select @match_id = m.id
from match m
where m.start_time = @start_time and m.host_id = @hosting_club_id and m.guest_id = @competing_club_id
 
update match set stadium_id = @stadium_id where id = @match_id
update request set accept_status = 'Accepted' where cr_username = @cr_username and sm_username = @sm_username and match_id =@match_id
go;
/*xx*/
go;
create proc rejectRequest
@sm_username varchar(20),
@hosting_club_name varchar(20),
@competing_club_name varchar(20),
@start_time datetime
as
declare @cr_username varchar(20)
select @cr_username = cr.username
from club_representative cr inner join club c on cr.club_id = c.id
where c.name = @hosting_club_name
 
declare @hosting_club_id int
select @hosting_club_id = c.id
from club c
where c.name = @hosting_club_name
 
declare @competing_club_id int
select @competing_club_id = c.id
from club c
where c.name = @competing_club_name
 
declare @stadium_id int
select @stadium_id = sm.stadium_id
from stadium_manager sm
where sm.username = @sm_username
 
declare @match_id int
select @match_id = m.id
from match m
where m.start_time = @start_time and m.host_id = @hosting_club_id and m.guest_id = @competing_club_id
 
update request set accept_status = 'Rejected' where cr_username = @cr_username and sm_username = @sm_username and match_id =@match_id
delete from match where id = @match_id
 
go;
/*xxi*/
go;
create proc addFan
@name varchar(20),
@username varchar(20),
@password varchar(20),
@national_id varchar(20),
@birth_date datetime,
@address varchar(20),
@phone_number int
as
insert into sys_user values (@username,@password,@name)
insert into fan values (@username,@national_id,@phone_number,@birth_date,@address,1)
go;
/*xxii*/
go;
create function upcomingMatchesOfClub (@clubname varchar(20))
returns table
as
return
((select h.name as club_name, g.name as competing_club_name, m.Start_time, s.name as stadium_name
from match m inner join club h on m.host_id=h.id inner join club g on m.guest_id=g.id inner join stadium s on m.Stadium_id = s.id
where h.name = @clubname and m.Start_time > CURRENT_TIMESTAMP
)
UNION ALL
(
select g.name as club_name, h.name as competing_club_name, m.Start_time, s.name as stadium_name
from match m inner join club h on m.host_id=h.id inner join club g on m.guest_id=g.id inner join stadium s on m.Stadium_id = s.id
where g.name = @clubname and m.Start_time > CURRENT_TIMESTAMP
)
)
go;
/*xxiii*/
go;
create function availableMatchesToAttend (@date datetime)
returns table
as
return
select h.name as host_club_name, g.name as guest_club_name, m.Start_time, s.name as stadium_name , s.Location as location
from match m inner join club h on m.host_id=h.id inner join club g on m.guest_id=g.id inner join stadium s on m.Stadium_id = s.id
where m.Start_time >= @date and exists (
                                       select *
                                       from ticket t
                                       where t.match_id=m.Id and t.status = 1
                                     )
go;
/*xxiv*/
go;
create proc purchaseTicket
@national_id varchar(20),
@hosting_club_name varchar(20),
@competing_club_name varchar(20),
@start_time datetime
as
declare @fan_username varchar(20)
select @fan_username = f.username
from fan f
where f.national_id = @national_id
 
declare @hosting_club_id int
select @hosting_club_id = c.id
from club c
where c.name = @hosting_club_name
 
declare @competing_club_id int
select @competing_club_id = c.id
from club c
where c.name = @competing_club_name
 
declare @match_id int
select @match_id = m.id
from match m
where m.start_time = @start_time and m.host_id = @hosting_club_id and m.guest_id = @competing_club_id
 
 
declare @ticket_id int
select @ticket_id = t.id
from ticket t
where t.match_id = @match_id and t.status=1 and t.id > all ( select t1.id
                                                           from ticket t1
                                                           where t1.id <> t.id and t1.match_id=@match_id and t1.status=1)
 
update ticket set status=0 where id=@ticket_id
update ticket set fan_username=@fan_username where id=@ticket_id
go;
/*xxv*/
go;
create proc updateMatchHost
@hosting_club_name varchar(20),
@competing_club_name varchar(20),
@date datetime
as
declare @hosting_club_id int
select @hosting_club_id = c.id
from club c
where c.name = @hosting_club_name
 
declare @competing_club_id int
select @competing_club_id = c.id
from club c
where c.name = @competing_club_name
 
declare @match_id int
select @match_id = m.id
from match m
where @competing_club_id = m.guest_id and @hosting_club_id = m.host_id and m.Start_time = @date
 
update match set host_id = @competing_club_id where id = @match_id
update match set guest_id = @hosting_club_id where id = @match_id
go;
/*xxvi*/
go;
create view matchesPerTeam
as
select c.name as club_name, count(m.id) as count
from club c left outer join match m on ((c.id = m.host_id or c.id=m.guest_id ) and m.Start_time < CURRENT_TIMESTAMP)
group by c.name
go;
/*xxvii*/
go;
create view clubsNeverMatched
as
select c1.name as club_one_name, c2.name as club_two_name
from club c1, club c2
where c1.id <> c2.id and c1.id>c2.id and not exists (
                                                   select *
                                                   from match m
                                                   where (m.host_id = c1.id and m.guest_id=c2.id) or (m.host_id = c2.id and m.guest_id=c1.id) and m.Start_time < CURRENT_TIMESTAMP
                                                   )
go;
/*xxviii*/
go;
CREATE FUNCTION clubsNeverPlayed(@club_name varchar(20)) 
RETURNS TABLE 
AS
RETURN
   select c.name as club_name
   from club c
   where c.name<>@club_name and  not exists (
                                             select *
                                             from match m inner join club h on m.host_id=h.id inner join club g on m.guest_id=g.id
                                             where m.Start_time<CURRENT_TIMESTAMP and ((@club_name=h.name and c.id = m.guest_id ) or (@club_name=g.name and c.id = m.host_id ))
                                            )       
go;
/*xxxix*/
go;
CREATE FUNCTION matchWithHighestAttendance() 
RETURNS TABLE 
AS
RETURN
   select top 1 h.name as hosting_club_name,g.name as guest_club_name
   from (match m inner join club h on h.id=m.host_id inner join club g on g.id=m.guest_id) left outer join ticket t on (t.match_id=m.id and t.status = 0)
   group by m.id,h.name,g.name
   order by count(t.id) desc
go;
/*xxx*/
go;
CREATE FUNCTION matchesRankedByAttendance() 
RETURNS TABLE 
AS
RETURN
   select h.name as hosting_club_name,g.name as guest_club_name
   from (match m inner join club h on h.id=m.host_id inner join club g on g.id=m.guest_id) left outer join ticket t on (t.match_id=m.id and t.status = 0)
   group by m.id,h.name,g.name
   order by count(t.id) desc offset 0 rows
go;
/*xxxi*/
go;
CREATE FUNCTION requestsFromClub(@stadium_name varchar(20),@club_name varchar(20)) 
RETURNS TABLE 
AS
RETURN
   select  h.name as hosting_club_name, g.name as guest_club_name
   from request r inner join stadium_manager sm on r.sm_username=sm.Username inner join stadium s on sm.stadium_id=s.id
                  inner join Club_Representative cr on r.cr_username=cr.Username inner join club c on cr.club_id=c.id
                  inner join match m on r.match_id =m.id inner join club g on g.id=m.guest_id inner join club h on h.id = m.host_id
   where @stadium_name=s.Name and @club_name = c.name
go;

select * from sys_user
/*--------------------------------------------------------------------------------------------------*/

/*This is the system admin account

insert into sys_user (Name,Username,Password) values ('sa','saun','12345')
insert into system_admin(username) values ('saun')*/