using DockerDeployment.Extension;
using DockerDeployment.Model;
using System.IO.Compression;
using System.Text;

namespace DockerDeployment.Service
{
    public class ZipService
    {
        public async Task<List<ZipEntry>> ExtractFiles(Stream fileData)
        {
            await using var ms = new MemoryStream();
            await fileData.CopyToAsync(ms);

            using var archive = new ZipArchive(ms);

            var entries = new List<ZipEntry>();

            foreach (var entry in archive.Entries)
            {
                await using var fileStream = entry.Open();

                var fileBytes = await fileStream.ReadFully();

                var content = Encoding.UTF8.GetString(fileBytes);

                entries.Add(new ZipEntry { Name =entry.FullName ,Content =content });
            }
            return entries;
        }
    }
}
