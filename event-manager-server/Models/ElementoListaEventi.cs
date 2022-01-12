using System;

namespace event_manager_server.Models
{
    public class ElementoListaEventi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localita { get; set; }
        public DateTime Data { get; set; }
    }
}