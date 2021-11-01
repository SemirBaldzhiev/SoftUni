using MusicHub.Data;
using MusicHub.Initializer;
using System;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
        }
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            throw new NotImplementedException();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
