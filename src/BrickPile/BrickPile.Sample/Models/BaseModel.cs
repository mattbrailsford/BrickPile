using System.ComponentModel.DataAnnotations;
using BrickPile.Domain.Models;

namespace BrickPile.Sample.Models {
    /// <summary>
    /// Represents the base page
    /// </summary>
    public abstract class BasePageModel : PageModel {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Display(Name = "Page title", Order = 20)]
        public virtual string Title { get; set; }
    }
}