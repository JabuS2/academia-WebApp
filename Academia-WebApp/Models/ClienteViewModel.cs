using System.Collections.Generic;

namespace Academia_WebApp.Models
{
    public class ClienteViewModel
    {
        public List<ClienteTreinoViewModel> ListaClientesComTreinos { get; set; }
        public List<ClienteModel> ListaClientes { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}
