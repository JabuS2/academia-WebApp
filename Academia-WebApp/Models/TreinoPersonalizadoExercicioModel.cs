using System.ComponentModel.DataAnnotations;

namespace Academia_WebApp.Models
{
    public class TreinoPersonalizadoExercicioModel
    {
        [Key]
        public int TreinoPersonalizadoExercicioId { get; set; }

        [Required]
        public int Series { get; set; }

        [Required]
        public int Repeticoes { get; set; }

        [Required]
        public int Carga { get; set; }

        // Relacionamento com Exercício
        public int ExercicioId { get; set; }
        public ExercicioModel ?Exercicio { get; set; }

        // Relacionamento com Treino Personalizado
        public int TreinoPersonalizadoId { get; set; }
        public TreinoPersonalizadoModel ?TreinoPersonalizado { get; set; }
    }
}
