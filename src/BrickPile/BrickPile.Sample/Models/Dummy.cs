using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrickPile.Domain;
using BrickPile.Domain.Models;

namespace BrickPile.Sample.Models {
    [PageModel("Dummy")]
    public class Dummy : PageModel {
        
        public string Test { get; set; }
    }
}