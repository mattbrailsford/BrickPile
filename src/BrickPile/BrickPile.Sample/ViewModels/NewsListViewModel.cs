using BrickPile.Sample.Models;
using BrickPile.UI;

namespace BrickPile.Sample.ViewModels {
    public class NewsListViewModel : BaseViewModel<NewsList> {
        /// <summary>
        /// Gets or sets the news list.
        /// </summary>
        /// <value>
        /// The news list.
        /// </value>
        public PagedList.IPagedList<News> NewsList { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsListViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="structureInfo">The structure info.</param>
        /// <param name="newsList">The news list.</param>
        public NewsListViewModel(NewsList model, IStructureInfo structureInfo, PagedList.IPagedList<News> newsList)
            : base(model, structureInfo) {
            NewsList = newsList;
        }
    }
}