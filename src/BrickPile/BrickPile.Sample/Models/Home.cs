using System.ComponentModel.DataAnnotations;
using BrickPile.Domain;

namespace BrickPile.Sample.Models {
    /// <summary>
    /// Represents the home page
    /// </summary>
    [PageModel("Home page")]
    public class Home : BasePageModel {
        [Display(Name = "Settings for main teaser")]
        public MainTeaser MainTeaser { get; set; }
        /// <summary>
        /// Gets or sets the teaser one.
        /// </summary>
        /// <value>
        /// The teaser one.
        /// </value>
        [Display(Name = "Settings for teaser one")]
        public Teaser TeaserOne { get; set; }
        /// <summary>
        /// Gets or sets the teaser two.
        /// </summary>
        /// <value>
        /// The teaser two.
        /// </value>
        [Display(Name = "Settings for teaser two")]
        public Teaser TeaserTwo { get; set; }
        /// <summary>
        /// Gets or sets the teaser three.
        /// </summary>
        /// <value>
        /// The teaser three.
        /// </value>
        [Display(Name = "Settings for teaser three")]
        public Teaser TeaserThree { get; set; }
        /// <summary>
        /// Gets or sets the teaser four.
        /// </summary>
        /// <value>
        /// The teaser four.
        /// </value>
        [Display(Name = "Settings for teaser four")]
        public Teaser TeaserFour { get; set; }
    }
}