<Query Kind="Expression">
  <Connection>
    <ID>c10dc1af-16a5-40e7-99b5-1cb522fbef37</ID>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Multie colum group
//grouping data placed in a local temp data set for further processing
//.Key Allows you to have acess the values(s) if your group key(s)
//If you have multiplie groups columns they must be in an anomyous datatype
//to crae a DTO type collection you can use .ToList() on the temp data set
// you can have a custom annomymus data collection by using a nested query

from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	select new	{
					MenuCategoryID = tempdataset.Key.MenuCategoryID,
					CurrentPrice = tempdataset.Key.CurrentPrice,
					FoodItems = from x in tempdataset
								select new {
											ItemId = x.ItemID,
											FoodDescription = x.Description,
											TimeServed = x.BillItems.Count()
								}
				}