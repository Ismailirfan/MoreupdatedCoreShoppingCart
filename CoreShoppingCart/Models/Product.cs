using System.ComponentModel.DataAnnotations;
namespace CoreShoppingCart.Models
{
    public class Product
    {
        [Key]
        public int Pid { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Product Name")]
        public string PName { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name ="Short Description")]
        public string SDescription { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Long Description")]
        public string LDescription { get; set; }
        [Required]
        [Display(Name ="Product Price")]
        public int PPrice { get; set; }
        [Required]
        [StringLength (30)]
        public string ImageUrl { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
