using System;
using System.ComponentModel.DataAnnotations;

namespace event_manager_data
{
    public class DatiEvento
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Localita { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}