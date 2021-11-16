namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportMovieDto[] movieDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            List<Movie> movies = new List<Movie>();

            foreach (var movieDto in movieDtos)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                TimeSpan movieDuratin = TimeSpan.Parse(movieDto.Duration);
                //may can do validation of duration

                Movie movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = movieDto.Genre,
                    Duration = movieDuratin,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                foreach (var m in movies)
                {
                    if (m.Title == movie.Title)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                }

                movies.Add(movie);
                sb.AppendLine(String.Format(SuccessfulImportMovie, movie.Title, movie.Genre, String.Format("{0:0.00}", movieDto.Rating)));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportHallSeatDto[] importHallSeatDtos = JsonConvert.DeserializeObject<ImportHallSeatDto[]>(jsonString);

            List<Hall> halls = new List<Hall>();

            foreach (var importHallSeatDto in importHallSeatDtos)
            {
                if (!IsValid(importHallSeatDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importHallSeatDto.Seats < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall
                {
                    Name = importHallSeatDto.Name,
                    Is4Dx = importHallSeatDto.Is4Dx,
                    Is3D = importHallSeatDto.Is3D,
                };

                for (int i = 0; i < importHallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);
                string projectionType;
                if (hall.Is4Dx)
                {
                    projectionType = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    projectionType = "3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(String.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                new XmlRootAttribute("Projections"));

            List<Projection> projections = new List<Projection>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportProjectionDto[] projectionDtos = (ImportProjectionDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var projectionDto in projectionDtos)
                {
                    if (!IsValid(projectionDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //check for valid movie and hall Id's;
                    var movie = context.Movies.Find(projectionDto.MovieId);
                    var hall = context.Halls.Find(projectionDto.HallId);
                    if (movie == null || hall == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //validadion of DateTime
                    DateTime projectionDateTime;
                    bool isProjectionDateTimeValid = DateTime.TryParseExact(projectionDto.DateTime,
                        "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectionDateTime);

                    if (!isProjectionDateTimeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Projection projection = new Projection
                    {
                        MovieId = projectionDto.MovieId,
                        HallId = projectionDto.HallId,
                        DateTime = projectionDateTime
                    };


                    projections.Add(projection);
                    sb.AppendLine(String.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                }

                context.Projections.AddRange(projections);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            List<Customer> customers = new List<Customer>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportCustomerDto[] customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (customerDto.Balance < 0.01M)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer customer = new Customer
                    {
                        FirstName = customerDto.FirstName,
                        LastName = customerDto.LastName,
                        Age = customerDto.Age,
                        Balance = customerDto.Balance
                    };

                    foreach (var ticketDto in customerDto.Tickets)
                    {
                        if (!IsValid(ticketDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (ticketDto.Price < 0.01M)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Ticket ticket = new Ticket
                        {
                            ProjectionId = ticketDto.ProjectionId,
                            Price = ticketDto.Price
                        };

                        customer.Tickets.Add(ticket);
                       
                    }
                    customers.Add(customer);
                    sb.AppendLine(String.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
                }

                context.Customers.AddRange(customers);
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