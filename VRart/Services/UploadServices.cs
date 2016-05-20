﻿using System;
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
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var fileName = new char[7];
            var random = new Random();

            for (int i = 0; i < fileName.Length; i++)
            {
                fileName[i] = chars[random.Next(chars.Length)];
            }

            var finalFileName = new String(fileName);
            finalFileName += ".tilt"; //TODO - add fileExtension as property

            return finalFileName;
        }

        public static void ExtractThumbNail(byte[] tiltFile, string savePath, string fileName)
        {

            //string extractPath = @"C:\Temp\Uploads\";

            string zipPath = @"C:\Temp\Uploads\test.tilt";
            tiltFile = File.ReadAllBytes(zipPath);

            //Remove the first 16 bytes of the tilt file header to get a standard zip file format
            byte[] fileZipFormat = new byte[tiltFile.Length - 16];
            Buffer.BlockCopy(tiltFile, 16, fileZipFormat, 0, fileZipFormat.Length);
                    //File.WriteAllBytes(extractPath + "blockcopy.zip", fileForZip);
            MemoryStream zipStream = new MemoryStream(fileZipFormat);

            ZipArchive archive = new ZipArchive(zipStream);

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.Equals("thumbnail.png", StringComparison.OrdinalIgnoreCase))
                {
                    entry.ExtractToFile(Path.Combine(savePath, fileName));
                }
            }

        }

    }
}