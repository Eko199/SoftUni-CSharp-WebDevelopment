namespace MusicHub
{
    using System;
    using System.Text;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            s.Name,
                            Price = s.Price.ToString("F2"),
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToArray(),
                    Price = a.Price.ToString("F2")
                })
                .AsEnumerable()
                .OrderByDescending(a => double.Parse(a.Price))
                .ToArray();

            var sb = new StringBuilder();

            foreach (var album in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                for (int i = 0; i < album.Songs.Length; i++)
                {
                    var song = album.Songs[i];

                    sb.AppendLine($"---#{i + 1}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
            .ToArray();

            var sb = new StringBuilder();

            for (int i = 0; i < songs.Length; i++)
            {
                var song = songs[i];

                sb.AppendLine($"-Song #{i + 1}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                foreach (string performer in song.Performers)
                {
                    sb.AppendLine($"---Performer: {performer}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
