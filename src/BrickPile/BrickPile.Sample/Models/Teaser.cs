using System.ComponentModel.DataAnnotations;
using BrickPile.UI.Models;

namespace BrickPile.Sample.Models {
    /// <summary>
    /// Represents a small start page teaser
    /// </summary>
    public class Teaser {
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public virtual PageReference Link { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [DataType(DataType.ImageUrl)]
        public virtual string Image { get; set; }
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        public virtual string Heading { get; set; }
    }
}