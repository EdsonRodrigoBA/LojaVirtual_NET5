using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models.Constantes
{
    public class TiposColaboradores_Constantes
    {
        public const String COMUM = "C";
        public const String GERENTE = "G";


        public static string GetName(string code)
        {
            foreach (var field in typeof(TiposColaboradores_Constantes).GetFields())
            {
                if ((string)field.GetValue(null) == code)
                    return field.Name.ToString();
            }
            return "";
        }
    }
}
