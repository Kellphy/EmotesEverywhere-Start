using System.IO.Compression;

namespace Start_EmotesEverywhere
{
    class Program
    {
        static void Main()
        {
            try
            {
                string name = "EmotesEverywhere";
                string zipPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, $"{name}.zip");
                string exePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, $"{name}.exe");
                string extractPath = System.Environment.CurrentDirectory;
                string verPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "version");
                string webfolder = $"http://kellphy.com/downloads/{name}";

                System.Console.WriteLine("Downloading Zip ...");
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    webClient.DownloadFile($"{webfolder}/{name}.zip", zipPath);
                }

                System.Console.WriteLine("Extracting Zip ...");
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string destinationPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(extractPath, entry.FullName));
                        entry.ExtractToFile(destinationPath, true);
                    }
                }

                System.Console.WriteLine("Removing Zip ...");
                System.IO.File.Delete(zipPath);

                System.Console.WriteLine("Starting Emotes Everywhere ...");
                System.Diagnostics.Process.Start(exePath);

                System.Threading.Thread.Sleep(2000);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                System.Console.WriteLine("Press any key to close this window.");
                System.Console.ReadKey();
            }
        }
    }
}