using System.ComponentModel.DataAnnotations;
using BrickPile.UI.Models;

namespace BrickPile.Sample.Models {
    public class MainTeaser {
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        /// <summary>
        /// Gets or sets the image alt.
        /// </summary>
        /// <value>
        /// The image alt.
        /// </value>
        public string ImageAlt { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public virtual PageReference Reference { get; set; }
    }
}