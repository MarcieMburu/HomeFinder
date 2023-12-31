using HomeFinder.Migrations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinder.Models
{
    public class HouseDetails
    {
        [Key]
        public int HouseId { get; set; }
        public string HouseName { get; set; }
        public string HouseDescription { get; set;}
        public string HouseType { get; set;}
        public string HouseLocation { get; set;}
        public int HousePrice { get; set;}
        public ICollection<HouseImage> HouseImages { get; set; }



    }
    public class HouseImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public int HouseId { get; set; }
        public HouseDetails HouseDetails { get; set; }
    }

}
