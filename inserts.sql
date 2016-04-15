insert into routes 
values ('111O', 'Харків', 0);
insert into routes 
values ('111O', 'Полтава', 1);
insert into routes 
values ('111O', 'Житомир', 3);
insert into routes 
values ('111O', 'Хмельницький', 4);
insert into routes 
values ('111O', 'Тернопіль', 5);
insert into routes 
values ('111O', 'Львів', 6);

insert into routes 
values ('099К', 'Київ', 0);
insert into routes 
values ('099К', 'Вінниця', 1);
insert into routes 
values ('099К', 'Хмельницький', 2);
insert into routes 
values ('099К', 'Тернопіль', 3);
insert into routes 
values ('099К', 'Львів', 4);
insert into routes 
values ('099К', 'Ужгород', 5);

select *
from routes
where train_num='111O'
order by st_order

select train_num
from routes
where station = 'Київ'
and train_num in (
	select train_num from routes
	where station = 'Ужгород')
	
	
insert into trains
values ('111O', '2016-04-23 04:51:00', '2016-04-23 15:02:00');
insert into trains
values ('111O', '2016-04-24 04:51:00', '2016-04-24 15:02:00');
insert into trains
values ('111O', '2016-04-25 04:51:00', '2016-04-25 15:02:00');
insert into trains
values ('111O', '2016-04-26 04:51:00', '2016-04-26 15:02:00');
insert into trains
values ('111O', '2016-04-27 04:51:00', '2016-04-27 15:02:00');
insert into trains
values ('111O', '2016-04-28 04:51:00', '2016-04-28 15:02:00');
insert into trains
values ('111O', '2016-04-29 04:51:00', '2016-04-29 15:02:00');

insert into trains
values ('141К', '2016-04-23 15:44:00', '2016-04-24 04:40:00');
insert into trains
values ('141К', '2016-04-24 15:44:00', '2016-04-25 04:40:00');
insert into trains
values ('141К', '2016-04-25 15:44:00', '2016-04-26 04:40:00');
insert into trains
values ('141К', '2016-04-26 15:44:00', '2016-04-27 04:40:00');
insert into trains
values ('141К', '2016-04-27 15:44:00', '2016-04-28 04:40:00');
insert into trains
values ('141К', '2016-04-28 15:44:00', '2016-04-29 04:40:00');
insert into trains
values ('141К', '2016-04-29 15:44:00', '2016-04-30 04:40:00');

insert into trains
values ('099К', '2016-04-23 17:39:00', '2016-04-24 08:12:00');
insert into trains
values ('099К', '2016-04-24 17:39:00', '2016-04-25 08:12:00');
insert into trains
values ('099К', '2016-04-25 17:39:00', '2016-04-26 08:12:00');
insert into trains
values ('099К', '2016-04-26 17:39:00', '2016-04-27 08:12:00');
insert into trains
values ('099К', '2016-04-27 17:39:00', '2016-04-28 08:12:00');
insert into trains
values ('099К', '2016-04-28 17:39:00', '2016-04-29 08:12:00');
insert into trains
values ('099К', '2016-04-29 17:39:00', '2016-04-30 08:12:00');

insert into carriages
values (1, 1, 'П');
insert into carriages
values (1, 2, 'К');
insert into carriages
values (1, 3, 'П');
insert into carriages
values (1, 4, 'К');
insert into carriages
values (1, 5, 'Л');

insert into carriages
values ('141К', 1, 'П');
insert into carriages
values ('141К', 2, 'П');
insert into carriages
values ('141К', 3, 'П');
insert into carriages
values ('141К', 4, 'К');
insert into carriages
values ('141К', 5, 'К');
insert into carriages
values ('141К', 6, 'Л');
insert into carriages
values ('141К', 7, 'Л');

insert into carriages
values ('099К', 1, 'П');
insert into carriages
values ('099К', 2, 'П');
insert into carriages
values ('099К', 3, 'П');
insert into carriages
values ('099К', 4, 'П');

insert into users
values('bdaypaddy@gmail.com', 'bday', 'Olia', 'Rodionova', '0950183193', 'user');
insert into users(email, "password", name, phone, "type")
values('test@gmail.com', 'test', 'Test', '0689364512', 'user');


update places
set is_free=0
where carriage_id = (
	select id from carriages
	where train_id = 1
	and num = 5)
and num = 1
