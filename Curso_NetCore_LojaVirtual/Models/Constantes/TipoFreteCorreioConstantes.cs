﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models.Constantes
{
    public class TipoFreteCorreioConstantes
    {
        public const string SEDEX = "4014";
        public const string SEDEX10 = "04790";
        public const string PAC = "04510";

        public static string GetName(string code)
        {
            foreach (var field in typeof(TipoFreteCorreioConstantes).GetFields())
            {
                if ((string)field.GetValue(null) == code)
                    return field.Name.ToString();
            }
            return "";
        }
    }
}
