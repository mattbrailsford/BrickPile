using BrickPile.Sample.Models;
using BrickPile.Services;
using BrickPile.UI;

namespace BrickPile.Sample.ViewModels {
    public class HomeViewModel : BaseViewModel<Home> {
        private readonly Home _model;
        private readonly IPageService _pageService;

        public HomeViewModel(Home model, IPageService pageService, IStructureInfo structureInfo) : base(model, structureInfo) {
            _model = model;
            _pageService = pageService;
        }

        //public BaseModel MainTeaser {
        //    get {
        //        return _pageService.SingleOrDefault<BaseModel>(x => x.Id == _model.MainTeaserLink.Id);
        //    }
        //}
        //public BaseEditorial TeaserOne {
        //    get {
        //        return _pageService.SingleOrDefault<BaseEditorial>(x => x.Id == _model.TeaserOne.Id);
        //    }
        //}
        //public BaseEditorial TeaserTwo {
        //    get {
        //        return _pageService.SingleOrDefault<BaseEditorial>(x => x.Id == _model.TeaserTwo.Id);
        //    }
        //}
        //public BaseEditorial TeaserThree {
        //    get {
        //        return _pageService.SingleOrDefault<BaseEditorial>(x => x.Id == _model.TeaserThree.Id);
        //    }
        //}
        //public BaseEditorial TeaserFour {
        //    get {
        //        return _pageService.SingleOrDefault<BaseEditorial>(x => x.Id == _model.TeaserFour.Id);
        //    }
        //}
    }
}