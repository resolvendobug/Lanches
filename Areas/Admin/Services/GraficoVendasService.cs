using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Context;
using Lanches.Models;

namespace Lanches.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _context;

        public GraficoVendasService(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);
            var lanches = (from pd in _context.PedidoDetalhes
                            join l in _context.Lanches on pd.LancheId equals l.Id
                            where pd.Pedido.PedidoEnviado >= data
                            group pd by new { pd.Id , l.Nome } 
                            into g 
                            select new{
                                LancheNome = g.Key.Nome,
                                LanchesQuantidade = g.Sum(q => q.Quantidade),
                                LanchesValorTotal = g.Sum(x => x.Quantidade * x.Preco)
                            });
            var lista = new List<LancheGrafico>();
            foreach(var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }
            return lista;             
        }
    }
}