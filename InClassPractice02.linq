<Query Kind="Expression">
  <Connection>
    <ID>ea5ad21d-2de2-4815-9edb-37110318af0e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//List All Album Titles and the number of tracks for the album
//List Titles alphabetically.
//use of aggregrates in queries
//First Find the entity of what you are trying to aggregrates (Look for the parent first)
//count() count the number of instances of the collection references
//Sum() totals a specific field so you will likely need to use a delegate 
//to indicate the collection instance attribute to be used. 
from x in Albums 
orderby x.Title
where x.Tracks.Count() > 0 //Due to some albums not having any tracks within it them
select new {
			Title = x.Title,
			NumberOfAlbumsTracks = x.Tracks.Count(),
			TotalAlbumPrice = x.Tracks.Sum(y => y.UnitPrice)
			}
//What is the total track price for the album
