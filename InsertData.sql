insert into Role values ('1ebd5e9d-d025-47e4-85ee-537b6335310e',N'Guest',1)
insert into Role values ('9bd49d4b-adde-470f-9c70-29cbb73cb46f',N'Customer',1)
insert into Role values ('ae41f26c-fa31-46b2-9857-2fca416c10fb',N'Admin',1)

insert into Size values('1df219d3-596a-475c-aeda-b6a15c5d5a4f','S',1)
insert into Size values('316e515b-9093-4ad3-8b91-932e8fdf8bb3','M',1)
insert into Size values('735ee778-5212-45a9-9463-d548d1da09f8','L',1)
insert into Size values('86315abc-99ef-4b7c-a0eb-828e9e078ca9','XL',1)


insert into Color values('e4f89cd4-2a31-4276-ab47-39b42ffbe6d0',N'Trắng',1)
insert into Color values('f3b5f873-cf5d-4576-95a5-0da7fbf9f9a8',N'Đen',1)
insert into Color values('cb4a2f80-4c4a-42e0-a803-b6c1f374c67b',N'Đỏ',1)
insert into Color values('976a4d4c-34cc-42cf-9e34-7b3b6394380f',N'Xanh',1)
insert into Color values('2e660d11-058b-4bbb-9e2e-a3c07377681a',N'Nâu',1)


insert into Category values('304a299a-c223-4bc0-a537-0a2c4972a5fa',N'Áo phông',1)
insert into Category values('a1451d32-76be-43cf-9882-04758151e57e',N'Áo Hoodie',1)
insert into Category values('c963fdb0-ccb5-4866-a429-c1c092c768be',N'Áo Sweater',1)
insert into Category values('00996822-3d2f-40a0-bd4a-2c31bd42ba87',N'Áo Polo',1)
insert into Category values('65dfda8b-fb11-467d-8044-bb2d42f08dda',N'Combo',1)


insert into Products values('a8426f69-513a-46d0-ab5b-9254d71b02ee',N'Outerity Meowment Tee','',175000,'304a299a-c223-4bc0-a537-0a2c4972a5fa',1 )
insert into Products values('cf07d09c-2ca3-4cac-a29a-060e8fa09c25',N'Outerity BabyMonster Tee','',175000,'304a299a-c223-4bc0-a537-0a2c4972a5fa',1 )
insert into Products values('ccdda834-feee-41a5-b5b5-82ae32f6f941',N'Outerity Meows Garden Tee','',175000,'304a299a-c223-4bc0-a537-0a2c4972a5fa',1 )
insert into Products values('9e1c0289-9bbc-49fb-95cc-8aae5d21ecf7',N'Outerity Meow Basic','',179000,'00996822-3d2f-40a0-bd4a-2c31bd42ba87',1 )

insert into ProductDetails values('3289fe7e-67cd-46e3-86d0-a49dfbf005b6','a8426f69-513a-46d0-ab5b-9254d71b02ee','1df219d3-596a-475c-aeda-b6a15c5d5a4f','e4f89cd4-2a31-4276-ab47-39b42ffbe6d0',100,1)
insert into ProductDetails values('4e37f337-8309-4405-b349-6e6176e94690','a8426f69-513a-46d0-ab5b-9254d71b02ee','1df219d3-596a-475c-aeda-b6a15c5d5a4f','f3b5f873-cf5d-4576-95a5-0da7fbf9f9a8',100,1)
insert into ProductDetails values('6ade14c0-dfc1-4606-bdf0-3aae9c8b263e','a8426f69-513a-46d0-ab5b-9254d71b02ee','1df219d3-596a-475c-aeda-b6a15c5d5a4f','cb4a2f80-4c4a-42e0-a803-b6c1f374c67b',100,1)


insert into ProductDetails values('b27e0904-7217-4ce9-b7e9-507abddea550','a8426f69-513a-46d0-ab5b-9254d71b02ee','316e515b-9093-4ad3-8b91-932e8fdf8bb3','f3b5f873-cf5d-4576-95a5-0da7fbf9f9a8',100,1)
insert into ProductDetails values('2e56036c-a665-4214-9b76-c9f06dd95d77','a8426f69-513a-46d0-ab5b-9254d71b02ee','316e515b-9093-4ad3-8b91-932e8fdf8bb3','f3b5f873-cf5d-4576-95a5-0da7fbf9f9a8',100,1)
insert into ProductDetails values('f5d84558-1a3d-437f-ae59-5ad1a996c1d5','a8426f69-513a-46d0-ab5b-9254d71b02ee','316e515b-9093-4ad3-8b91-932e8fdf8bb3','cb4a2f80-4c4a-42e0-a803-b6c1f374c67b',100,1)


insert into ProductDetails values('cb1f9643-ffbc-48ed-8ba2-e055a3475ef4','a8426f69-513a-46d0-ab5b-9254d71b02ee','735ee778-5212-45a9-9463-d548d1da09f8','e4f89cd4-2a31-4276-ab47-39b42ffbe6d0',100,1)
insert into ProductDetails values('3daba759-931a-4749-b70c-3f74c3ee21b3','a8426f69-513a-46d0-ab5b-9254d71b02ee','735ee778-5212-45a9-9463-d548d1da09f8','f3b5f873-cf5d-4576-95a5-0da7fbf9f9a8',100,1)
insert into ProductDetails values('b0d7d14f-a9a1-4afd-a7fc-5c6f3d73822b','a8426f69-513a-46d0-ab5b-9254d71b02ee','735ee778-5212-45a9-9463-d548d1da09f8','cb4a2f80-4c4a-42e0-a803-b6c1f374c67b',100,1)



insert into ProductDetails values('058d65ea-986a-41a9-acb8-fff6c33adac1','cf07d09c-2ca3-4cac-a29a-060e8fa09c25','1df219d3-596a-475c-aeda-b6a15c5d5a4f','e4f89cd4-2a31-4276-ab47-39b42ffbe6d0',100,1)
insert into ProductDetails values('0ffca38b-c8de-4a6e-819c-42d690daa25c','cf07d09c-2ca3-4cac-a29a-060e8fa09c25','316e515b-9093-4ad3-8b91-932e8fdf8bb3','f3b5f873-cf5d-4576-95a5-0da7fbf9f9a8',100,1)
insert into ProductDetails values('6471de92-dc6a-46bc-a27b-61bddab1bebe','cf07d09c-2ca3-4cac-a29a-060e8fa09c25','735ee778-5212-45a9-9463-d548d1da09f8','cb4a2f80-4c4a-42e0-a803-b6c1f374c67b',100,1)

insert into Combos values ('1c43986f-8438-4d0e-81cc-7dfe1434dc12',N'Combo 1','',200000,'65dfda8b-fb11-467d-8044-bb2d42f08dda',1)
insert into Combos values ('e92bf4da-ca09-449b-a7aa-67bc70b91991',N'Combo 2','',200000,'65dfda8b-fb11-467d-8044-bb2d42f08dda',1)
insert into Combos values ('db2af35b-c7ff-4cd2-acfd-2c16d2448333',N'Combo 3','',200000,'65dfda8b-fb11-467d-8044-bb2d42f08dda',1)


insert into ComboDetails values('ebf33e51-9247-480b-9662-44d565f4e963','1c43986f-8438-4d0e-81cc-7dfe1434dc12','058d65ea-986a-41a9-acb8-fff6c33adac1',100)
insert into ComboDetails values('77048c2f-5881-4ed1-b0c8-2f58665c179d','1c43986f-8438-4d0e-81cc-7dfe1434dc12','cb1f9643-ffbc-48ed-8ba2-e055a3475ef4',100)
insert into ComboDetails values('1120a546-3ae7-4ef8-9a33-7e5972a4674b','e92bf4da-ca09-449b-a7aa-67bc70b91991','058d65ea-986a-41a9-acb8-fff6c33adac1',100)


insert into Cart values('f9a991b2-c9cf-4ef6-9aec-90235617bce6','',1)
insert into Cart values('46512515-7aba-416f-aae2-f612e4a0f1f4','',1)
insert into Cart values('db8c8657-bf37-48d4-a482-bb9818f0f204','',1)
insert into Cart values('444acb59-28b1-4067-ad85-281dc7c973f1','',1)
insert into Cart values('340287ba-dd62-4ab9-b6c5-5c14c9bc694c','',1)

insert into Customer values('f9a991b2-c9cf-4ef6-9aec-90235617bce6','KH1',N'Nguyễn Văn Thắng','thangnvph25980','123','0367180646','132@gmail.com',N'Nguyên Xá',1,'ae41f26c-fa31-46b2-9857-2fca416c10fb',1)
insert into Customer values('46512515-7aba-416f-aae2-f612e4a0f1f4','KH2',N'Trần Duy Thái','thaitq','123','23423423','132@gmail.com',N'Hong Bít',1,'ae41f26c-fa31-46b2-9857-2fca416c10fb',1)
insert into Customer values('db8c8657-bf37-48d4-a482-bb9818f0f204','KH3',N'Nguyễn Hưng Kiên','kiennh','123','24345234','132@gmail.com',N'Kiều Mai',1,'9bd49d4b-adde-470f-9c70-29cbb73cb46f',1)
insert into Customer values('444acb59-28b1-4067-ad85-281dc7c973f1','KH4',N'Nguyễn Duy Tuấn','tuannd','123','23452345','132@gmail.com',N'Hong Bít',1,'ae41f26c-fa31-46b2-9857-2fca416c10fb',1)
insert into Customer values('340287ba-dd62-4ab9-b6c5-5c14c9bc694c','KH5',N'Trương Quốc Lợi','loitq','123','2345234','132@gmail.com',N'Hong Bít',1,'1ebd5e9d-d025-47e4-85ee-537b6335310e',1)




insert into CartDetails values ('1b114578-20f4-424c-b1a8-61bb7ddc2f03','f9a991b2-c9cf-4ef6-9aec-90235617bce6','058d65ea-986a-41a9-acb8-fff6c33adac1',null,2)
insert into CartDetails values ('ec2c7b60-1feb-4c45-b3fa-0f531a2b1af6','f9a991b2-c9cf-4ef6-9aec-90235617bce6',null,'1c43986f-8438-4d0e-81cc-7dfe1434dc12',2)
insert into CartDetails values ('51c60755-692b-411b-829d-428b7aec3f5c','f9a991b2-c9cf-4ef6-9aec-90235617bce6','b0d7d14f-a9a1-4afd-a7fc-5c6f3d73822b',null,2)


insert into Bill values('37a0577e-0f65-403e-9715-798654fa9a9f','f9a991b2-c9cf-4ef6-9aec-90235617bce6','2023-05-29 11:11',1)
insert into Bill values('47620022-9139-4a6a-a10f-1669013817f2','f9a991b2-c9cf-4ef6-9aec-90235617bce6','2023-05-29 11:11',1)
insert into Bill values('9715e77f-f39a-4579-a74e-1f39a57106aa','f9a991b2-c9cf-4ef6-9aec-90235617bce6','2023-05-29 11:11',1)



insert into BillDetails values('32f985f4-0e4a-48ae-bf91-79c0bab0d306','37a0577e-0f65-403e-9715-798654fa9a9f','b27e0904-7217-4ce9-b7e9-507abddea550',null,2,200000)
insert into BillDetails values('d5c171d0-7887-4b6f-af53-f86c48db7dd9','47620022-9139-4a6a-a10f-1669013817f2','6ade14c0-dfc1-4606-bdf0-3aae9c8b263e',null,2,200000)
insert into BillDetails values('e74dddd8-39f7-476c-a952-6e7529b8a9f9','9715e77f-f39a-4579-a74e-1f39a57106aa',null,'1c43986f-8438-4d0e-81cc-7dfe1434dc12',2,200000)

select * from Customer
select * from ProductDetails
select * from Combos 
select * from ComboDetails 
select * from Cart
select * from CartDetails
select * from Bill
select * from BillDetails