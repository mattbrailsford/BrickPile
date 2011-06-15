using System.ComponentModel.DataAnnotations;
using BrickPile.Domain;

namespace BrickPile.Sample.Models {
    /// <summary>
    /// A common article page
    /// </summary>
    [PageModel("Articel")]
    public class Page : BaseEditorial {
        /// <summary>
        /// Gets or sets the image caption.
        /// </summary>
        /// <value>
        /// The image caption.
        /// </value>
        [DataType(DataType.Html)]
        public string ImageCaption { get; set; }
    }
}