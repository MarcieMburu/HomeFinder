using HomeFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Services
{
    public interface IUploadFilesService
    {
        Task<List<string>> UploadHouseImages(HouseDetailsViewModel houseDetailsViewModel);

    }
}
