namespace Poker.CMS.Common.Helpers
{
    using System.IO;
    using System.IO.Compression;

    public static class ZipUtility
    {
        public static void CompressFileToZip(byte[] inputFileBytes, string outputZipFilePath, string entryName)
        {
            using (var fileStream = new FileStream(outputZipFilePath, FileMode.Create))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    var zipEntry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                    using (var entryStream = zipEntry.Open())
                    using (var inputStream = new MemoryStream(inputFileBytes))
                    {
                        inputStream.CopyTo(entryStream);
                    }
                }
            }
        }

        public static byte[] DecompressZipToFile(string zipFilePath)
        {
            // Open the zip file for reading
            using (var zipFileStream = new FileStream(zipFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var archive = new ZipArchive(zipFileStream, ZipArchiveMode.Read))
                {
                    // Extract the first entry in the zip file
                    var entry = archive.Entries.FirstOrDefault();
                    if (entry != null)
                    {
                        using (var entryStream = entry.Open())
                        using (var memoryStream = new MemoryStream())
                        {
                            entryStream.CopyTo(memoryStream);
                            return memoryStream.ToArray();
                        }
                    }
                }
            }

            return null;
        }
    }

}
