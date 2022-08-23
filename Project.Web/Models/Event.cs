using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Project.Web.Models
{
    [Table(name: "Events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Event ID")]
        public int EventId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }


        [Required(ErrorMessage = "The Field {0} can't be Empty!")]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Description of the Event")]
        [StringLength(300)]
        public string EventDescription { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Event Venue")]
        public string EventVenue { get; set; }


        public ICollection<StartupInfo> StartupInfo { get; set; }

    }
}
