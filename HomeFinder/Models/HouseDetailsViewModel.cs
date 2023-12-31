using System.ComponentModel.DataAnnotations;

namespace HomeFinder.Models
{
    public class HouseDetailsViewModel
    {
        [Key]
        public int HouseId { get; set; }
        public string HouseName { get; set; }
        public string HouseDescription { get; set; }
        public string HouseType { get; set; }
        public string HouseLocation { get; set; }
        public int HousePrice { get; set; }
        [Required(ErrorMessage = "Please select at least one image.")]
      
        public IList<IFormFile> HouseImages { get; set; }
       
    }
}
