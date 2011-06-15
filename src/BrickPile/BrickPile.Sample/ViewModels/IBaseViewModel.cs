using BrickPile.UI.Web.ViewModels;

namespace BrickPile.Sample.ViewModels {
    public interface IBaseViewModel<out T> : IViewModel<T> {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }
        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        string @Class { get; }
    }
}