using System.ComponentModel.DataAnnotations;
using BrickPile.Domain;

namespace BrickPile.Sample.Models {
    [PageModel("Artikel")]
    public class Page : BaseEditorial {

        [DataType(DataType.Html)]
        public string ImageCaption { get; set; }

    }
}