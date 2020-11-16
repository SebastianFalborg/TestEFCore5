using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFCore5.Models
{
    public class GymnastGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public string Name { get; set; }

        public Team Team { get; set; }

        public ICollection<FloorRoutine> FloorRoutines { get; set; }
    }
}
