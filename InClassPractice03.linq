<Query Kind="Expression">
  <Connection>
    <ID>ea5ad21d-2de2-4815-9edb-37110318af0e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//What is the average length of a track for the album in seconds.
//Average() Averages a specific field/expression, thus you will likely need to use a delegate 
//to indicate the collection instance attribute to be used. 
from x in Albums 
orderby x.Title
where x.Tracks.Count() > 0 //Due to some albums not having any tracks within it them
select new {
			Title = x.Title,
			NumberOfAlbumsTracks = x.Tracks.Count(),
			TotalAlbumPrice = x.Tracks.Sum(y => y.UnitPrice),
			AverageTrackLengthA = (x.Tracks.Average (t => t.Milliseconds)) / 1000 ,
			AverageTrackLengthB = x.Tracks.Average (t => (t.Milliseconds) / 1000 )
			}