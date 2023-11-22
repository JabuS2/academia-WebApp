using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Academia_WebApp.Models;

public class ClienteModel
{
    [Key]
    public int ClienteId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [MaxLength(20)]
    public string Plano { get; set; }

    [Required]
    public DateTime DataCadastro { get; set; }

    // Relacionamento com Treinos Personalizados
    public virtual ICollection<TreinoPersonalizadoModel> TreinosPersonalizados { get; set; }
}
