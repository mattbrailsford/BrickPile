using System.ComponentModel.DataAnnotations;

namespace BrickPile.Sample.Models {
    public class BaseEditorial : BaseModel {
        public virtual string Heading { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual string MainIntro { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [DataType(DataType.Html)]
        public virtual string MainBody { get; set; }
    }
}