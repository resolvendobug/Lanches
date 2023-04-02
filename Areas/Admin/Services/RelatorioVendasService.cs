using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Context;
using Lanches.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
       private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                .Include(x => x.PedidoItens)
                .ThenInclude(x => x.Lanche)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}