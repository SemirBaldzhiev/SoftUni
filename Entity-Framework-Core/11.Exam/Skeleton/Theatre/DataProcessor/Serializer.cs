namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.ToArray().Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets
                        .ToArray()
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(tk => new
                        {
                            Price = tk.Price,
                            RowNumber = tk.RowNumber
                        })
                        .OrderByDescending(tk => tk.Price)
                        .ToArray()

                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            string theatreAsJson = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return theatreAsJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .ToArray()
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportActorDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in \'{c.Play.Title}\'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            xmlSerializer.Serialize(sw, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
