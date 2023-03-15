using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lanches.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        [Required(ErrorMessage = "Informe a descrição curta do lanche")]
        [Display(Name = "Descrição Curta do Lanche")]
        public string DescricaoCurta { get; set; }
        [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição detalhada do lanche")]
        [Display(Name = "Descrição Detalhada do Lanche")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço do Lanche")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho Imagem")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho Imagem Thumbnail")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Lanche Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}