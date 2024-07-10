Use CRMLeads;
select * from Leads;

-- Proc 1 (GetAll)
create procedure GetAllLeads
AS
Begin
	Select * from Leads
End
EXEC GetAllLeads


-- Proc 2 (Alter)
alter procedure GetAllLeads
as
Begin
	select Id, LeadDate, Name, EmailAddress, Mobile, LeadSource, LeadStatus, NextFollowUpDate
	from Leads
End
EXEC GetAllLeads


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
EXEC GetAllLeads
