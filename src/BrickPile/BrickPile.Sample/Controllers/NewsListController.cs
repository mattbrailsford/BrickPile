using System;
using System.Web.Mvc;
using BrickPile.Domain.Models;
using BrickPile.Sample.Models;
using BrickPile.UI;
using BrickPile.UI.Web.ViewModels;
using PagedList;
using Raven.Client;
using Raven.Client.Linq;

namespace BrickPile.Sample.Controllers {
    public class NewsListController : Controller {
        private readonly NewsList _model;
        private readonly IStructureInfo _structureInfo;
        private readonly IDocumentSession _session;

        [HttpGet]
        public ActionResult Index(int? page) {

            var pages = _session.Query<IPageModel>()
                .Where(model => model.Parent.Id == _model.Id); // query all pages below the news list

            var pageIndex = page ?? 0; // if no page was specified in the querystring, default to page 0
            var onePageOfPages = pages.ToPagedList(pageIndex, _model.NewsCount); // will only contain the number of pages specified on the news list

            ViewBag.OnePageOfPages = onePageOfPages;

            return View(new DefaultViewModel<NewsList>(_model, _structureInfo));
        }

        [HttpPost]
        public ActionResult Contact(FormCollection form) {
            throw new NotImplementedException(form["Message"]);
        }
        public NewsListController(IPageModel model, IStructureInfo structureInfo, IDocumentSession session) {

            _model = model as NewsList;
            _structureInfo = structureInfo;
            _session = session;

        }
    }
}
