namespace Academia_WebApp.Models
{
    public class ClienteTreinoViewModel
    {
        public ClienteModel Cliente { get; set; }
        public List<TreinoPersonalizadoModel> Treinos { get; set; }

        public List<TreinoPersonalizadoExercicioModel> TreinosExcercicio { get; set; }
    }

}