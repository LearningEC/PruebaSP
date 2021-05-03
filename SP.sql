CREATE TABLE tlb_Emp  (
	Emp_id Int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NameEmp NVARCHAR(max) not null,
	AddressEmp NVARCHAR(max) null
);

CREATE PROCEDURE SP_EMP_ADD
@NameEmp nvarchar(max),
@AddressEmp nvarchar(max)
as 
begin
	insert into tlb_Emp values(
		@NameEmp,
		@AddressEmp
	)
end

CREATE PROC SP_EMP_UPDATE
@Emp_id int,
@NameEmp nvarchar(max),
@AddressEmp nvarchar(max)
as
begin
	update tlb_emp set
		NameEmp = @NameEmp,
		AddressEmp = @AddressEmp
	where Emp_id = @Emp_id
end

CREATE PROCEDURE SP_DELETE_EMP
@Emp_id int
as
begin
	DELETE FROM tlb_Emp where Emp_id = @Emp_id
end

CREATE PROCEDURE SP_FIND_ID
@Emp_id int
as
begin
	SELECT * FROM tlb_Emp where Emp_id = @Emp_id
end

CREATE PROCEDURE SP_EMPLOYEE_ALL
as
begin
	select * from tlb_Emp
end


select * from tlb_Emp