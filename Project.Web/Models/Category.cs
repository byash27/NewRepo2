using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project.Web.Models
{
    [Table(name: "Categories")]

    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category ID")]
        public int CatgoryId { get; set; }


        [Required(ErrorMessage = "The Field {0} can't be Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Name of the Category")]
        public string Categories { get; set; }


        [Required(ErrorMessage = "The Field {0} can't be Empty!")]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Description of the Category")]
        [StringLength(300)]
        public string CategoryDescription { get; set; }

        public ICollection<SubCategory> SubCategory { get; set; }

    }
}
