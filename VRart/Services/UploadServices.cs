using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.IO.Compression;

namespace VRart.Services
{
    public class UploadServices
    {

        public static string GetRandomFileName()
        {
            //TODO - check for collision
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var fileName = new char[7];
            var random = new Random();

            for (int i = 0; i < fileName.Length; i++)
            {
                fileName[i] = chars[random.Next(chars.Length)];
            }

            var finalFileName = new String(fileName);
            //finalFileName += ".tilt"; //TODO - add fileExtension as property

            return finalFileName;
        }

        //public static string GetRandomAlbumUrl()
        //{
        //    //TODO - check for collision
        //    var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        //    var fileName = new char[7];
        //    var random = new Random();

        //    for (int i = 0; i < fileName.Length; i++)
        //    {
        //        fileName[i] = chars[random.Next(chars.Length)];
        //    }

        //    var finalFileName = new String(fileName);
        //    return finalFileName;
        //}

        public static void ExtractThumbNail(byte[] tiltFile, string savePath, string fileName)
        {
            //For Testing
            //string zipPath = @"C:\Temp\Uploads\test.tilt";
            //tiltFile = File.ReadAllBytes(zipPath);

            //Remove the first 16 bytes of the tilt file header to get a standard zip file format
            byte[] fileZipFormat = new byte[tiltFile.Length - 16];
            Buffer.BlockCopy(tiltFile, 16, fileZipFormat, 0, fileZipFormat.Length);
                    
            //Create zip file in memory 
            MemoryStream zipStream = new MemoryStream(fileZipFormat);
            ZipArchive archive = new ZipArchive(zipStream);

            //Loop through each entry in zip file looking for thumbnail
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                //Extract the file with name matching thumbnail.png from the zip
                if (entry.FullName.Equals("thumbnail.png", StringComparison.OrdinalIgnoreCase))
                {
                    //TODO - exception for file already exists
                    entry.ExtractToFile(Path.Combine(savePath, fileName));
                }
            }

        }

    }
}