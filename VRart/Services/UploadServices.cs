using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    }
}