using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresidentsMagazine.Core.Entities
{
    [Table("President")]
    public class PresidentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ElectedDate { get; set; }   
        [Required]
        public string? CountryId { get; set; }
        [Required]
        public CountryEntity? Country { get; set; }
    }
}
