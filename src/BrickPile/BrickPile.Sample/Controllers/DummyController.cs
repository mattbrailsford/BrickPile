using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrickPile.Domain.Models;
using BrickPile.Sample.Models;
using BrickPile.Services;
using BrickPile.UI;
using BrickPile.UI.Web.ViewModels;
using PagedList;

namespace BrickPile.Sample.Controllers
{
    public class DummyController : Controller
    {
        private readonly Dummy _model;
        private readonly IStructureInfo _structureInfo;
        private readonly IPageService _service;

        public ActionResult Index(int? page) {

            var pages = _service.GetChildren(_model);

            var pageIndex = page ?? 0; // if no page was specified in the querystring, default to page 0
            var onePageOfPages = pages.ToPagedList(pageIndex, 1); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfPages = onePageOfPages;

            return View(new DefaultViewModel<Dummy>(_model, _structureInfo));
        }
        public DummyController(IPageModel model, IStructureInfo structureInfo, IPageService service) {
            _model = model as Dummy;
            _structureInfo = structureInfo;
            _service = service;
        }
    }
}
