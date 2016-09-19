<Query Kind="Statements">
  <Connection>
    <ID>ea5ad21d-2de2-4815-9edb-37110318af0e</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//What is the MediaType with the most tracks
//to solve a problem switch your language choice to either statements or programs

//the result of each query will now be save in a variable
//the variable can then be used in future queries

var maxCount = (from x in MediaTypes
	select x.Tracks.Count ()).Max();
//To display the contents of a variable in LINQPad 
//you use the method .Dump()
maxCount.Dump();

//use a value in a proceding created variable
var popularMediaType = from x in MediaTypes
						where x.Tracks.Count() == maxCount
						select new	{
										Type = x.Name,
										TCount = x.Tracks.Count()
									};
popularMediaType.Dump();
//----------------------------------------------------------------------------------//
//Can this set of statments be done as one complete query
//the answer is possibly and in this case yes.
//in this example maxCount could be exchanged for the query that
//actually created the max value in the first place
//this substituted query is a SubQuery
var popularMediaTypeSubQuery = from x in MediaTypes
						where x.Tracks.Count() == (from y in MediaTypes
													select y.Tracks.Count ()).Max()
						select new	{
										Type = x.Name,
										TCount = x.Tracks.Count()
									};
popularMediaTypeSubQuery.Dump();

//----------------------------------------------------------------------------------//
//Using the method syntax to determine the count value for the where expression
//This demonstrats that queries can be contructed using both the query and method syntax
var popularMediaTypeSubMethod = from x in MediaTypes
						where x.Tracks.Count() == MediaTypes.Select(mt => mt.Tracks.Count()).Max() //method type to find the max count
						select new	{
										Type = x.Name,
										TCount = x.Tracks.Count()
									};
popularMediaTypeSubMethod.Dump();




