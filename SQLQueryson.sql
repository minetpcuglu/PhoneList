SELECT DISTINCT TOP 1  p.FirstName ,c.PhoneNumber FROM Contacts
As c  INNER JOIN  Persons AS p ON
c.PersonId = p.Id
