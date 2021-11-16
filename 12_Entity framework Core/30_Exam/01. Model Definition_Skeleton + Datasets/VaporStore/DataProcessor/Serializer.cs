namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesByGenres = context
				.Genres
				.ToArray()
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games
						.Select(gm => new
						{
							Id = gm.Id,
							Title = gm.Name,
							Developer = gm.Developer.Name,
							Tags = String.Join(",", gm.GameTags),
							Players = gm.Purchases.Count
						})
						.OrderByDescending(x => x.Players)
						.ThenBy(x => x.Id)
						.ToArray(),
					TotalPlayers = g.Games.Sum(x => x.Purchases.Count)
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id)
				.ToArray();

			string json = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			throw new NotImplementedException();
		}
	}
}