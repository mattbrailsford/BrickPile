using System.Web.Mvc;
using BrickPile.Domain.Models;
using BrickPile.Sample.Models;
using BrickPile.Sample.ViewModels;
using BrickPile.Services;
using BrickPile.UI;

namespace BrickPile.Sample.Controllers {
    public class HomeController : Controller {
        private readonly Home _model;
        private readonly IStructureInfo _structureInfo;
        private readonly IPageService _service;

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            var viewModel = new HomeViewModel(_model, _structureInfo)
                                {
                                    MainTeaser = _service.SingleOrDefault<BasePageModel>(model => model.Id == _model.MainTeaser.Reference.Id)
                                };
            return View(viewModel);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="structureInfo">The structure info.</param>
        /// <param name="service">The service.</param>
        public HomeController(IPageModel model, IStructureInfo structureInfo, IPageService service) {
            _model = model as Home;
            _structureInfo = structureInfo;
            _service = service;
        }
    }
}
