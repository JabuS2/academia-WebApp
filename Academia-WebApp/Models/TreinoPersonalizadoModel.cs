using Academia_WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TreinoPersonalizadoModel
{
    [Key]
    public int TreinoPersonalizadoId { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; }

    [Required]
    [MaxLength(50)]
    public string Observacoes { get; set; }

    // Relacionamento com Cliente
    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public virtual ClienteModel Cliente { get; set; }

    // Relacionamento com Treinos Personalizados Exercícios
    public virtual ICollection<TreinoPersonalizadoExercicioModel> TreinosPersonalizadosExercicios { get; set; }
}
