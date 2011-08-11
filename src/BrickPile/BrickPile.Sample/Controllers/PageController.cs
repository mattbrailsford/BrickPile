using System.Web.Mvc;
using BrickPile.Domain.Models;
using BrickPile.Sample.Models;
using BrickPile.Sample.ViewModels;
using BrickPile.UI;
using BrickPile.UI.Web.ViewModels;

namespace BrickPile.Sample.Controllers
{
    public class PageController : Controller
    {
        private readonly Page _model;
        private readonly IStructureInfo _structureInfo;

        public ActionResult Index()
        {
            return View(new DefaultViewModel<Page>(_model, _structureInfo));
            //return View(new PageViewModel((Page)_currentPage, _structureInfo) { Class = "page" });
        }
        public PageController(IPageModel model, IStructureInfo structureInfo) {
            _model = model as Page;
            _structureInfo = structureInfo;
        }
    }
}
