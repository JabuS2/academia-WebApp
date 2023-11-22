using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Academia_WebApp.Models;


public class ExercicioModel
{
    [Key]
    public int ExercicioId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(200)]
    public string Descricao { get; set; }

    [Required]
    [MaxLength(50)]
    public string MusculoAlvo { get; set; }

    [Required]
    [MaxLength(50)]
    public string Equipamento { get; set; }

    // Relacionamento com Treinos Personalizados Exercícios
    public virtual ICollection<TreinoPersonalizadoExercicioModel> TreinosPersonalizadosExercicios { get; set; }
}
