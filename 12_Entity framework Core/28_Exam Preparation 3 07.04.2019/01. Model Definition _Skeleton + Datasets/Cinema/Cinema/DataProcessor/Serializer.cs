namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        //JSON
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var topMovies = context
                .Movies
                .ToArray() //materializate
                .Where(m => m.Rating >= rating)
                .Where(m => m.Projections.Any(p => p.Tickets.Count > 0))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(p => p.Projections.Sum(t => t.Tickets.Sum(pc => pc.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("f2"),
                    TotalIncomes = m.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                    Customers = m.Projections.SelectMany(p => p.Tickets).Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2"),
                    })
                    .ToArray()
                    .OrderByDescending(x => x.Balance)
                    .ThenBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToArray()
                })
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(topMovies, Formatting.Indented);

            return json;
        }

        //XML
        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                var customers = context
                    .Customers
                    .ToArray() //materializate
                    .Where(c => c.Age >= age)
                    .OrderByDescending(x => x.Tickets.Sum(p => p.Price))
                    .Take(10)
                    .Select(x => new ExportCustomerDto()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        SpentMoney = x.Tickets.Sum(p => p.Price).ToString("F2"),
                        SpentTime = TimeSpan.FromSeconds(
                            x.Tickets.Sum(s => s.Projection.Movie.Duration.TotalSeconds))
                        .ToString(@"hh\:mm\:ss")
                    })

                    .ToArray();

                xmlSerializer.Serialize(stringWriter, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}