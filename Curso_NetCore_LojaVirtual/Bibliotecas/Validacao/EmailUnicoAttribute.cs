using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Validacao
{
    public class EmailUnicoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            String email =(value as String).Trim();
            IColaboradoresRepositorio colaboradoresRepositorio = (IColaboradoresRepositorio) validationContext.GetService(typeof(IColaboradoresRepositorio));
            List<Colaboradores> colaboradores =colaboradoresRepositorio.Get_Por_Email(email);
            Colaboradores colaboradores1 = (Colaboradores)validationContext.ObjectInstance;

            if(colaboradores.Count > 1)
            {
                return new ValidationResult("E-mail já cadastrado!");
            }
            if (colaboradores.Count == 1 & colaboradores1.Id != colaboradores[0].Id)
            {
                return new ValidationResult("E-mail já cadastrado!");
            }
            return ValidationResult.Success;
        }
    }
}
