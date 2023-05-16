using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreShoppingCart.Models
{
    [Table("TblCat")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string CName { get; set; }
        public string Slug { get; set; }
        public bool CStatus { get; set; }
    }
}
