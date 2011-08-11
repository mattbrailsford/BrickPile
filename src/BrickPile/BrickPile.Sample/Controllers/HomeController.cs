using System.Web.Mvc;
using BrickPile.Domain.Models;
using BrickPile.Sample.Models;
using BrickPile.Services;
using BrickPile.UI;
using BrickPile.UI.Web.ViewModels;
using PagedList;

namespace BrickPile.Sample.Controllers {
    /// <summary>
    /// 
    /// </summary>
public class HomeController : Controller {
    private readonly IStructureInfo _structureInfo;
        private readonly IPageService _service;
        private readonly Home _model;
        public ActionResult Index(int? page) {

            var pages =  _service.GetChildren(_model);

            var pageIndex = page ?? 0; // if no page was specified in the querystring, default to page 0
            var onePageOfPages = pages.ToPagedList(pageIndex, 1); // will only contain 25 pages max because of the pageSize

            ViewBag.OnePageOfPages = onePageOfPages;
        
            return View(new DefaultViewModel<Home>(_model, _structureInfo));
        }
        public HomeController(IPageModel model, IStructureInfo structureInfo, IPageService service) {
            _structureInfo = structureInfo;
            _service = service;
            _model = model as Home;
        }
    }
}

