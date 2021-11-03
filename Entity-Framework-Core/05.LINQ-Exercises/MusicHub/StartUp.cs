using MusicHub.Data;
using MusicHub.Initializer;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext context =
               new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            string result = ExportAlbumsInfo(context, 9);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .ToList()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs
                        .Select(s => new
                        {
                            s.Name,
                            s.Price,
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToArray(),
                    a.Price
                })
                .ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int songsCount = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{songsCount}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");

                    songsCount++;
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
