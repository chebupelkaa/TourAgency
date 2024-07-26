

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agency.Helpers
{
    public static class TourHtmlHelperExtensions
    {
        public static IHtmlContent ReservationButton(this IHtmlHelper htmlHelper, string tourId, string buttonText)
        {
            var button = new TagBuilder("button");
            button.MergeAttribute("type", "button");
            button.MergeAttribute("data-tour-id", tourId);
            button.InnerHtml.Append(buttonText);

            return button;
        }
    }
}
