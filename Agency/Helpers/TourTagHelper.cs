using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Web.Mvc;

namespace Agency.Helpers
{
    public class TourTagHelper : TagHelper
    {
        public string TourName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = $@"
            <div class='tour-info'>
                <h3>{TourName}</h3>
                <p>{Description}</p>
                <img src='{ImageUrl}' alt='Tour Image' />
            </div>";

            output.TagName = "tour";
            output.Content.SetHtmlContent(content);
        }
    }
}
