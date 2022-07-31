using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autho.Infra.CrossCutting.Globalization
{
    public enum Language
    {
        [Display(Description = "en")]
        EN = 0,

        [Display(Description = "es")]
        ES = 1,

        [Display(Description = "pt-BR")]
        PT_BR = 2
    }
}
