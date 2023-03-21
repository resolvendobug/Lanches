using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lanches.Models
{
    public class PedidoDetalhe
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int LancheId { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public Lanche Lanche { get; set; }
        public Pedido Pedido { get; set; }
    }
}