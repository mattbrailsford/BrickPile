using System.ComponentModel.DataAnnotations;
using BrickPile.Domain;
using BrickPile.Domain.Models;

namespace BrickPile.Sample.Models {
    [PageModel("News list")]
    public class NewsList : PageModel {
        [UIHint("Number")]
        [Display(Name = "Number of news on each page")]
        public int NewsCount { get; set; }
    }
}