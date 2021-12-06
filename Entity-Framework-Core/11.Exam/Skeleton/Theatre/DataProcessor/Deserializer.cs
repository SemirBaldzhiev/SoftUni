namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), new XmlRootAttribute("Plays"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(stringReader);

            List<Play> plays = new List<Play>();

            foreach (ImportPlayDto playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDuration = TimeSpan.TryParseExact(playDto.Duration, "c",
                    CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);

                if (!isValidDuration)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                int cmp = duration.CompareTo(new TimeSpan(1, 0, 0));

                if (cmp == -1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidGenre = Enum.TryParse(typeof(Genre), playDto.Genre, false, out object validGenre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validGenreEnum = (Genre)validGenre;

                var play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = validGenreEnum,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };


                plays.Add(play);

                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();   
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), new XmlRootAttribute("Casts"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(stringReader);

            List<Cast> casts = new List<Cast>();

            foreach (ImportCastDto castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = context.Plays.Find(castDto.PlayId);

                if (play == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                

                casts.Add(cast);

                string typeRole = cast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, typeRole));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportProjectionDto[] projectionDtos = JsonConvert.DeserializeObject<ImportProjectionDto[]>(jsonString);

            List<Theatre> theatres = new List<Theatre>();
            List<Ticket> tickets = new List<Ticket>();

            foreach (ImportProjectionDto projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = projectionDto.Name,
                    NumberOfHalls = projectionDto.NumberOfHalls,
                    Director = projectionDto.Director,
                };

                foreach (ImportTicketDto ticketDto in projectionDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var play = context.Plays.Find(ticketDto.PlayId);

                    if (play == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                        TheatreId = theatre.Id
                    };

                    tickets.Add(ticket);
                }

                theatre.Tickets = tickets;

                theatres.Add(theatre);

                context.Tickets.AddRange(tickets);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, tickets.Count));
                tickets = new List<Ticket>();
            }


            context.Theatres.AddRange(theatres);
            
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
