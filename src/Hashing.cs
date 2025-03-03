using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bloxhasher
{
    internal static class Hashing
    {
        public static string GetRblxPath()
        {
            string parentFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox\\Versions");
            string targetFileName = "RobloxPlayerBeta.exe";
            string targetDllName = "RobloxPlayerBeta.dll";

            string rblxPath = "";

            string[] subfolders = Directory.GetDirectories(parentFolder);

            foreach (string folder in subfolders)
            {
                string dllPath = System.IO.Path.Combine(folder, targetDllName);
                string filePath = System.IO.Path.Combine(folder, targetFileName);
                if (File.Exists(filePath) && File.Exists(dllPath))
                {
                    rblxPath = folder;
                    break;
                }
            }
            return rblxPath;
        }
        public static string CreateDirectoryMd5(string srcPath)
        {
            var filePaths = Directory.GetFiles(srcPath, "*", SearchOption.AllDirectories).OrderBy(p => p).ToArray();

            using (var md5 = MD5.Create())
            {
                foreach (var filePath in filePaths)
                {
                    // hash path
                    byte[] pathBytes = Encoding.UTF8.GetBytes(filePath);
                    md5.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                    // hash contents
                    byte[] contentBytes = File.ReadAllBytes(filePath);

                    md5.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }

                //Handles empty filePaths case
                md5.TransformFinalBlock(new byte[0], 0, 0);

                return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
            }
        }
    }
}
