using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresidentsMagazine.Core.Entities
{
    [Table("Country")]
    public class CountryEntity
    {
        [Key]
        public string? Id { get; set; }

        public IEnumerable<PresidentEntity>? Presidents { get; set; }

    }
}
