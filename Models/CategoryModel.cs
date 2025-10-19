using Humanizer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapNhom02_Lan_02.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        [DefaultValue(1)]
        public byte States { get; set; } // 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden

        [StringLength(150)]
        public string? Slug { get; set; }

        // Navigation property (tùy chọn)
        [ForeignKey("ParentId")]                                //Một Category có thể thuộc về một Category cha (ParentCategory).                  
        public virtual Categories? ParentCategory { get; set; } //Và ParentId chính là ID của Category cha đó.
    }
}
