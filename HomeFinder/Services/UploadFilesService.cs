using HomeFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Services
{
    public class UploadFilesService : IUploadFilesService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadFilesService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

      

        public async Task<List<string>> UploadHouseImages(HouseDetailsViewModel houseDetailsViewModel)
        {
            List<string> uploadedFileNames = new List<string>();

            if (houseDetailsViewModel.HouseImages != null && houseDetailsViewModel.HouseImages.Count > 0)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                foreach (var file in houseDetailsViewModel.HouseImages)
                {
                    if (file.Length > 0)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        uploadedFileNames.Add(uniqueFileName);
                    }
                }
            }

            return uploadedFileNames;
        }
    }
}
