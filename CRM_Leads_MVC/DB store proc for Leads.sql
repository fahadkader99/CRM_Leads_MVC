Use CRMLeads;
select * from Leads;

-- Proc 1 (GetAll)
create procedure GetAllLeads
AS
Begin
	Select * from Leads
End
--EXEC GetAllLeads


-- Proc 2 (Alter)
alter procedure GetAllLeads
as
Begin
	select Id, LeadDate, Name, EmailAddress, Mobile, LeadSource, LeadStatus, NextFollowUpDate
	from Leads
End
--EXEC GetAllLeads


-- Proc 3 (Insert)
alter procedure AddLead
@LeadDate datetime,
@Name varchar(100),
@EmailAddress varchar(100),
@Mobile varchar(12),
@LeadSource varchar(50),
@LeadStatus varchar(20),
@NextFollowUpDate datetime
AS
Begin

	INSERT INTO Leads (LeadDate, Name, EmailAddress, Mobile, LeadSource, LeadStatus, NextFollowUpDate)
	VALUES
	(@LeadDate, @Name, @EmailAddress, @Mobile, @LeadSource, @LeadStatus, @NextFollowUpDate)
END

-- to check execute 1 entry here:
--EXEC AddLead '2024-07-03', 'Robert', 'robert@gmail.com' ,'33445566', 'Web', 'Open', '2024-08-04'
--EXEC GetAllLeads


-- Proc 3 (GetById)
create procedure GetLeadDetailsById
@Id int
as
Begin
	select Id, LeadDate, Name, EmailAddress, Mobile, LeadSource, LeadStatus, NextFollowUpDate
	from Leads
	Where Id = @Id
End

--EXEC GetAllLeads
--EXEC GetLeadDetailsById 9


-- Proc 4 (Edit by Id)
create procedure EditLeadById
@Id int,
@LeadDate datetime,
@Name varchar(100),
@EmailAddress varchar(100),
@Mobile varchar(12),
@LeadSource varchar(50),
@LeadStatus varchar(20),
@NextFollowUpDate datetime
AS
Begin

	UPDATE Leads SET 
	LeadDate=@LeadDate,
	Name=@Name, 
	EmailAddress=@EmailAddress,
	Mobile=@Mobile,
	LeadSource=@LeadSource, 
	LeadStatus=@LeadStatus, 
	NextFollowUpDate=@NextFollowUpDate
	
	WHERE ID=@Id
END


-- Proc 5 (Delete)
create procedure DeleteLeadDetails
@Id int
as
Begin
	Delete from Leads
	Where Id = @Id
End


select * from Leads;