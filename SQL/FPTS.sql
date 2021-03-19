Create table products (
	id int primary key identity,
	name nvarchar(255) not null,
	price float not null ,
	quantity int not null
)
alter table products add  id_brands int ;
alter table products add id_categories int ;

create table categories(
	id int identity primary key ,
	name nvarchar(200) not null
)
create table brands(
	id int identity primary key,
	name nvarchar(200) not null
)
--create table productDetail(
--	id int identity primary key,
--	name nvarchar (250) not null,
--	price float 
--)

--select all
select * from products ;
select name,price from products;
select * from categories;
select * from brands;

--insert
insert into products(name,price,quantity)values(N'IPhone6',1000000,1);
insert into products(name,price,quantity)values(N'IPhone11',1000000,1);
insert into categories(name)values(N'Phone');
insert into categories(name)values(N'Phone');
insert into brands(name)values(N'IPhone');
insert into brands(name)values(N'IPhone');

--update where id
update products set name = N'IPhone12',price = 123 , quantity = 199 where id = 1 ;
update categories set name = N'Laptop' where id = 1 ;
update brands set name = N'Samsung' where id = 1 ;
update products set price = 222 where name = N'Iphone12'
--delete 
delete from products where id = 1;
delete from categories where id = 2;
delete from brands where id = 2;

--inner join
select products. , brands.name from products inner join brands on products.id = brands.id; 
select products.id , categories.name from products inner join categories on products.id = categories.id; 
--join three table
select products.id , categories.name,brands.name from ((products
inner join categories on products.id = categories.id)
inner join brands on products.id = brands.id)
--left join
select products.name , categories.id from products left join categories on products.id = categories.id order by products.id; 
select brands.name , products.name from brands left join products on brands.name = products.name order by brands.name; 
--full join 
select products.price from products full outer join brands on products.name = brands.name order by products.name;

