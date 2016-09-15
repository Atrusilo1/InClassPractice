<Query Kind="Expression">
  <Connection>
    <ID>ea5ad21d-2de2-4815-9edb-37110318af0e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//List all customer served by templiyee Jane Peacock 
//Show the customer LastName, FirstName, City, Stat, Phone, Email
//Sample for entity Subset
//Sample of entity navigation from child to parent on where
// reminder that code is C# and this appropriate mathods can be used .Equals()
//-------------------------------------------------------------------
//from x in Customers
//where x.SupportRepId = x.Employees.EmployeeId
//select x.LastName + ", " +  x.FirstName + ", " +  x.City + ", " +  x.State + ", "  +  x.Phone + ", " +   x.Email
//-------------------------------------------------------------------
from x in Customers
//SupportRepIdEmployee Make you go up to the partent ID
where x.SupportRepIdEmployee.FirstName.Equals("Jane") && x.SupportRepIdEmployee.LastName.Equals("PeaCock")
select new {
			Name = x.LastName + ", " +  x.FirstName,
			City = x.City,
			State = x.State,
			Phone = x.Phone,
			Email = x.Email
			}
			