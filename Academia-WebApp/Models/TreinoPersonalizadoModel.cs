using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Academia_WebApp.Models
{
    public class TreinoPersonalizadoModel
    {
        [Key]
        public int TreinoPersonalizadoId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        [MaxLength(50)]
        public string Observacoes { get; set; }

        // Relacionamento com Cliente
        [ForeignKey("ClienteId")]
        public ClienteModel Cliente { get; set; }

        // Relacionamento com Treinos Personalizados Exercícios
        public ICollection<TreinoPersonalizadoExercicioModel> TreinosPersonalizadosExercicios { get; set; }
    }


}
