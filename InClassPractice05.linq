<Query Kind="Statements">
  <Connection>
    <ID>c10dc1af-16a5-40e7-99b5-1cb522fbef37</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Find out which waiter has the highest bill

var maxBills = (from x in Waiters
					select x.Bills.Count()).Max();
var bestWaiter = from x in Waiters
					where x.Bills.Count() == maxBills
					select new{
								Name = x.FirstName + " " + x.LastName,
								TBills = x.Bills.Count()
							};
bestWaiter.Dump();

//-----------------------------------------------------------------------//
//SubQueries

var bestWaiterSubQueries = from x in Waiters
					where x.Bills.Count() == (from y in Waiters
					select y.Bills.Count()).Max()
					select new{
								Name = x.FirstName + " " + x.LastName,
								TBills = x.Bills.Count()
							};
bestWaiterSubQueries.Dump();

//-----------------------------------------------------------------------//
//Create a data set which contains the summary bill info by waiter

var waiterBills = from x in Waiters
					orderby x.LastName, x.FirstName
					select new {
								Name = x.LastName + ", " + x.FirstName,
								BillInfo = (from y in x.Bills
											where y.BillItems.Count() > 0
											select new {
															BillID = y.BillID, 
															BillDate = y.BillDate,
															TableID = y.TableID,
															Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
														}
											)
											
								};
waiterBills.Dump();
