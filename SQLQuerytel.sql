SELECT  p.FirstName ,c.PhoneNumber FROM Persons
As P  INNER JOIN  Contacts AS C ON
P.Id = C.PersonId
Where p.Id =1002 and CityId =1