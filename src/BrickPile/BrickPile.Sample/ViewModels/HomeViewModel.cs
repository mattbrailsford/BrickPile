using BrickPile.Sample.Models;
using BrickPile.UI;

namespace BrickPile.Sample.ViewModels {
    public class HomeViewModel : BaseViewModel<Home> {
        /// <summary>
        /// Gets the class.
        /// </summary>
        public override string Class {
            get { return "home"; }
        }
        /// <summary>
        /// Gets or sets the main teaser.
        /// </summary>
        /// <value>
        /// The main teaser.
        /// </value>
        public BasePageModel MainTeaser { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="structureInfo">The structure info.</param>
        public HomeViewModel(Home model, IStructureInfo structureInfo) : base(model, structureInfo) {

        }
    }
}