using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteSGRENTALS.Helpers;

namespace TesteSGRENTALS.Entities
{
    public class Produto
    {
        [Display(Name = "ID")]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Use menos caracteres.")]
        [RegularExpression(@"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        [PrimeiraMaiuscula]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(300, ErrorMessage = "Use menos caracteres.")]
        [RegularExpression(@"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$", ErrorMessage = "Números e caracteres especiais não são permitidos na descrição.")]
        [PrimeiraMaiuscula]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Preço")]
        [Range(0, double.MaxValue, ErrorMessage = "Preço inválido.")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Campo Preço inválido; Somente números sem o ponto no início e no máximo com duas casas decimais depois da [,].")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }
}
