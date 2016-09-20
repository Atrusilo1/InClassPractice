<Query Kind="Program">
  <Connection>
    <ID>c10dc1af-16a5-40e7-99b5-1cb522fbef37</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	//A list of bill count for all waiters
	//This query will create a flat dataset
	//The columns are native data types (ex: int, string,...)
	//One is not concerned with a repeated data in a column
	//Instead of using an anonymous data type (new{...})
	//we wish to use a defined class definition
	var bestWaiter = from x in Waiters
					select new WaiterBillCounts	{
													Name = x.FirstName + " " + x.LastName,
													TCount = x.Bills.Count()
												};
	bestWaiter.Dump();
	
	var paramMonth = 4;
	var paramYear = 2014;
	var waiterBills = from x in Waiters
					where x.LastName.Contains("k")
					orderby x.LastName, x.FirstName
					select new WaiterBills {
											Name = x.LastName + ", " + x.FirstName,
											TotalBillCount = x.Bills.Count(),
											BillInfo = (from y in x.Bills
														where y.BillItems.Count() > 0
															&& y.BillDate.Month == DateTime.Today.Month - paramMonth
															&& y.BillDate.Year == paramYear
														select new BillItemSummary {
																						BillID = y.BillID, 
																						BillDate = y.BillDate,
																						TableID = y.TableID,
																						Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
																					}
														).ToList()	//This changes it from an IEnumerable() to a List() ...Change it dataType
														
											};
waiterBills.Dump();
}

//An example of a POCO class (flat)
public class WaiterBillCounts
{
	//Whatever recieving field on your query in your select 
	//appears as a property in this class
	public string Name{get; set;}
	public int TCount {get; set;}
}
 public class BillItemSummary
 {
 	public int BillID{get; set;}
	public DateTime BillDate{get; set;}
	public int? TableID{get; set;}
	public decimal Total{get; set;}
 }

//An example of a DTO class (structred)
public class WaiterBills
{
	public string Name{get; set;}
	public int TotalBillCount{get; set;}
	//public List<BillItemSummary> BillInfo{get; set;} //Prblem with data types
	public IEnumerable<BillItemSummary> BillInfo{get; set;} //The Item needs the right datatype
}

