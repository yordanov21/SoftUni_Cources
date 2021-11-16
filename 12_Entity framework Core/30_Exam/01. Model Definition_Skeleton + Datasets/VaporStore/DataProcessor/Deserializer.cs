namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedGames
            = "Added {0} ({1}) with {2} tags";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Price < 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                //validadion of OpenDate
                DateTime gameReleaseDate; ;
                bool isGameReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate,
                    "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out gameReleaseDate);

                if (!isGameReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var isDevExist = context.Developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                if (isDevExist == null)
                {
                    isDevExist = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    //	context.Developers.Add(isDevExist);

                }

                var isGenreExist = context.Genres.FirstOrDefault(d => d.Name == gameDto.Genre);
                if (isGenreExist == null)
                {
                    isGenreExist = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    //context.Genres.Add(isGenreExist);
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameReleaseDate,
                    Developer = isDevExist,
                    Genre = isGenreExist
                };

                foreach (var tag in gameDto.Tags)
                {
                    Tag currentTag = context.Tags
                        .FirstOrDefault(t => t.Name == tag);

                    if (currentTag == null)
                    {
                        Tag newTag = new Tag
                        {
                            Name = tag
                        };
                        //context.Tags.Add(newTag);
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = newTag
                        });

                    }
                    //               else
                    //               {
                    //	game.GameTags.Add(new GameTag()
                    //	{
                    //		Game = game,
                    //		Tag = currentTag
                    //	});
                    //}
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchasesDto[]),
                new XmlRootAttribute("Purchases"));

            List<Purchase> purchases = new List<Purchase>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                //
                ImportPurchasesDto[] purchasesDtos = (ImportPurchasesDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var purchasesDto in purchasesDtos)
                {
                    if (!IsValid(purchasesDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //validadion of OpenDate
                    DateTime purchasDate;
                    bool isDateValid = DateTime.TryParseExact(purchasesDto.Date,
                        "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out purchasDate);

                    if (!isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Card card = context.Cards.FirstOrDefault(c => c.Number == purchasesDto.Card);

                    Game game = context.Games.FirstOrDefault(g => g.Name == purchasesDto.Title);

                    //PurchaseType purchaseType = (PurchaseType)purchasesDto.Type;

                   
                    Purchase pr = new Purchase()
                    {
                        Type = (PurchaseType)purchasesDto.Type,
                        ProductKey = purchasesDto.Key,                     
                        Date = purchasDate,
                        Card = card,
                        Game = game
                    };

                    purchases.Add(pr);
                    sb.AppendLine($"Imported {pr.Game.Name} for {pr.Card.User.Username}");

                }

                context.Purchases.AddRange(purchases);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}