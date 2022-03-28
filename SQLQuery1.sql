select p.FullName , c.PhoneNumber
from Persons As p
inner join Contacts As c ON
p.Id = c.PersonId
where p.FirstName='Mine' 



