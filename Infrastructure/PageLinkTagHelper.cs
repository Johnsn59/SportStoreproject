using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportStore.Models.ViewModels;
using System.Collections.Generic;

namespace SportStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IUrlHelperFactory urlHelperFactory;

        public string PageAction { get; set; }

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        public bool PageClassesEnabled { get; set; }

        public PagingInfo PageModel { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
            = new Dictionary<string, object>();

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        //   C o n s t r u c t o r s

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        //   M e t h o d s

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder anchorTag = new TagBuilder("a");
                PageUrlValues["productPage"] = i;
                anchorTag.Attributes["href"] =
                   urlHelper.Action(PageAction, PageUrlValues);

                if (PageClassesEnabled)
                {
                    anchorTag.AddCssClass(PageClass);
                    anchorTag.AddCssClass
                    (i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                anchorTag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(anchorTag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
