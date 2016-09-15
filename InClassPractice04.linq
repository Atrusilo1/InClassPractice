<Query Kind="Expression">
  <Connection>
    <ID>ea5ad21d-2de2-4815-9edb-37110318af0e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//What is the MediaType with the most tracks
from x in MediaTypes
orderby x.MediaTypeId

select  new {
			MediaType = x.Name,
			NumberOfTracks = x.Tracks.Count
			}