using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Model;
using Repository.Repository;
using System.Linq;

namespace Services
{
    public class FacturaService
    {
        public class ValidarFacturaFluente : AbstractValidator<FacturaModel>
        {
            private readonly FacturaRepository _facturaRepository;

            public ValidarFacturaFluente(FacturaRepository repositorio)
            {
                _facturaRepository = repositorio;

                RuleFor(factura => factura.Nro_Factura)
                    .NotEmpty().WithMessage("El número de factura es obligatorio.")
                    .Matches(@"^\d{3}-\d{3}-\d{6}$").WithMessage("El número de factura debe tener el formato 'NNN-NNN-NNNNNN'.");

                RuleFor(factura => factura.Total)
                    .NotEmpty().WithMessage("El total de la factura es obligatorio.")
                    .GreaterThan(0).WithMessage("El total de la factura debe ser mayor que cero.");

                RuleFor(factura => factura.Total_iva5)
                    .NotEmpty().WithMessage("El total del IVA 5% es obligatorio.")
                    .GreaterThan(0).WithMessage("El total del IVA 5% debe ser mayor que cero.");

                RuleFor(factura => factura.Total_iva10)
                    .NotEmpty().WithMessage("El total del IVA 10% es obligatorio.")
                    .GreaterThan(0).WithMessage("El total del IVA 10% debe ser mayor que cero.");

                RuleFor(factura => factura.Total_iva)
                    .NotEmpty().WithMessage("El total del IVA es obligatorio.")
                    .GreaterThan(0).WithMessage("El total del IVA debe ser mayor que cero.");

                RuleFor(factura => factura.Total_letras)
                    .NotEmpty().WithMessage("El total en letras es obligatorio.")
                    .MinimumLength(6).WithMessage("El total en letras debe tener al menos 6 caracteres.");
            }

           
        }
    }
}


