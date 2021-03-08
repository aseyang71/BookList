using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookList.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp; 
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        // Create a Dictionary property to store each combination of urls used by the user as string objects
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")] 
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false; 

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        // Create the PageClassSelected string property to show which category is selected (by Category1) in the HomeController.cs file
        public string PageClassSelected { get; set; }

        //Overriding 
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div"); 

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                //Set PageUrlValues to i, which is the number of page
                PageUrlValues["pageNum"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, 
                    PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
