using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ECommerce.WebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            var sb = new StringBuilder();

            if (PageCount > 1)
            {
                sb.Append("<ul class='pagination'>");

                // Prev Button
                if (CurrentPage > 1)
                {
                    sb.AppendFormat("<li class='page-item'><a class='page-link' href='/product/index?page={0}&category={1}'>Prev</a></li>",
                        CurrentPage - 1, CurrentCategory);
                }
                else
                {
                    sb.Append("<li class='page-item disabled'><a class='page-link' href='#'>Prev</a></li>");
                }

                // Page Numbers
                for (int i = 1; i <= PageCount; i++)
                {
                    sb.AppendFormat("<li class='{0}'>", (i == CurrentPage) ? "page-item active" : "page-item");
                    sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>{2}</a>",
                        i, CurrentCategory, i);
                    sb.Append("</li>");
                }

                // Next Button
                if (CurrentPage < PageCount)
                {
                    sb.AppendFormat("<li class='page-item'><a class='page-link' href='/product/index?page={0}&category={1}'>Next</a></li>",
                        CurrentPage + 1, CurrentCategory);
                }
                else
                {
                    sb.Append("<li class='page-item disabled'><a class='page-link' href='#'>Next</a></li>");
                }

                sb.Append("</ul>");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
