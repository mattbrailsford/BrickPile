using BrickPile.Sample.Models;
using BrickPile.UI;

namespace BrickPile.Sample.ViewModels {
    public class NewsViewModel : BaseViewModel<News> {
        public NewsViewModel(News model, IStructureInfo structureInfo) : base(model, structureInfo) {}
    }
}