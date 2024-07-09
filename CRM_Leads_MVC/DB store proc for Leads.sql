select * from Leads;

-- Proc 1
create procedure GetAllLeads
AS
Begin
	Select * from Leads
End
EXEC GetAllLeads


-- Proc 2
alter procedure GetAllLeads
as
Begin
	select Id, LeadDate, Name, EmailAddress, Mobile, LeadSource, LeadStatus, NextFollowUpDate
	from Leads
End
EXEC GetAllLeads