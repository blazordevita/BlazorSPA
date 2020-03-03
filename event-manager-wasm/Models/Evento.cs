using System;
using System.ComponentModel.DataAnnotations;

namespace event_manager_wasm.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Il nome è obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage="La località è obbligatoria")]
        [StringLength(50, ErrorMessage="La lunghezza può essere al massimo di {1} caratteri")]
        public string Localita { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}