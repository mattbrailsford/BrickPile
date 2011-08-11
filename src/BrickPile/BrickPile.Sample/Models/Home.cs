using System.ComponentModel.DataAnnotations;
using BrickPile.Domain;
using BrickPile.UI.Models;

namespace BrickPile.Sample.Models {
    [PageModel("Startpage")]
    public class Home : BaseModel {
        
        //[Required]
        //[Display(Name = "Teaser 1")]
        //public virtual PageReference TeaserOne { get; set; }
        //[Required]
        //[DataType(DataType.ImageUrl)]
        //public virtual string TeaserOneImage { get; set; }
        //[Required]
        //[DataType(DataType.Text)]
        //public virtual string TeaserOneHeading { get; set; }

        //[Required]
        //[Display(Name = "Teaser 2")]
        //public virtual PageReference TeaserTwo { get; set; }
        //[Required]
        //[DataType(DataType.ImageUrl)]
        //public virtual string TeaserTwoImage { get; set; }
        //[Required]
        //[DataType(DataType.Text)]
        //public virtual string TeaserTwoHeading { get; set; }

        //[Required]
        //[Display(Name = "Teaser 3")]
        //public virtual PageReference TeaserThree { get; set; }
        //[Required]
        //[DataType(DataType.ImageUrl)]
        //public virtual string TeaserThreeImage { get; set; }
        //[Required]
        //[DataType(DataType.Text)]
        //public virtual string TeaserThreeHeading { get; set; }

        //[Required]
        //[Display(Name = "Teaser 4")]
        //public virtual PageReference TeaserFour { get; set; }
        //[Required]
        //[DataType(DataType.ImageUrl)]
        //public virtual string TeaserFourImage { get; set; }
        //[Required]
        //[DataType(DataType.Text)]
        //public virtual string TeaserFourHeading { get; set; }
        
        //[Required]
        //[DataType(DataType.ImageUrl)]
        //public string MainTeaserImage { get; set; }
        //[Required]
        //[DataType(DataType.Text)]
        //public string MainTeaserImageAlt { get; set; }

        //[Required]
        public virtual PageReference MainTeaserLink { get; set; }
    }
}