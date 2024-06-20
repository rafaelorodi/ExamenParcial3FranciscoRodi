using Repository.Data;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class FacturaRepository
    {
        private readonly AppDbContext _context;

        public FacturaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddFactura(FacturaModel factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
        }

        public IEnumerable<FacturaModel> GetAllFacturas()
        {
            return _context.Facturas.ToList();
        }

        public FacturaModel GetFacturaById(int id)
        {
            return _context.Facturas.FirstOrDefault(f => f.Id == id);
        }

        public void UpdateFactura(FacturaModel factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChanges();
        }

        public void DeleteFactura(int id)
        {
            var factura = _context.Facturas.FirstOrDefault(f => f.Id == id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
            }
        }
    }
}
