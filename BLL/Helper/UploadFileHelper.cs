using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BLL.Helper
{
    class UploadFileHelper
    {
        public static string SaveFile(IFormFile FileUrl, string FolderPath)
        {

            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName);

            // Merge The Directory With File Name
            string FinalPath = Path.Combine(FilePath, FileName);

            // Save Your File As Stream "Data Overtime"
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }

            return FileName;
        }

        public static void RemoveFile(string FolderName, string RemovedFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + RemovedFileName);
            }

        }
    }
}
