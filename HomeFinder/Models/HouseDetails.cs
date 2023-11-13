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
        public string ImageName { get; set;}
        public byte[] ImageContent { get; set;}

        //[DisplayName("Upload File")]
        //public string HouseImage { get; set; }
   


    }

}
