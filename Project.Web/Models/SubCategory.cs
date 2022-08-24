using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace Project.Web.Models
{
    [Table(name: "SubCategories")]

    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "SubCategory ID")]
        public int Id { get; set; }



        [Required(ErrorMessage = "The Field {0} can't be Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Sector")]
        public string SubCategories { get; set; }


        #region 

        [JsonIgnore]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
        [ForeignKey(nameof(SubCategory.CategoryID))]
        public Category Category { get; set; }

        #endregion
        [JsonIgnore]
        public ICollection<StartupInfo> StartupInfo { get; set; }


    }
}