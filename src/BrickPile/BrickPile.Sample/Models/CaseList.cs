using System.ComponentModel.DataAnnotations;
using BrickPile.Domain;

namespace BrickPile.Sample.Models {
    [PageModel("Case list")]
    public class CaseList : BaseModel {
        public virtual string Heading { get; set; }
        [DataType(DataType.Html)]
        public virtual string MainBody { get; set; }
        [UIHint("Number")]
        public int? CaseCount { get; set; }
    }
}