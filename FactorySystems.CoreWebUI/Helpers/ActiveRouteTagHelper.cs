using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorySystems.CoreWebUI.Helpers
{
    [HtmlTargetElement(Attributes ="active")]
    public class ActiveRouteTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ActiveRouteTagHelper(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        [HtmlAttributeName("asp-page")]
        public string Page { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (ShouldBeActive())
            {
                MakeActive(output);
            }
        }

        private void MakeActive(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr==null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active")<0)
            {
                output.Attributes.SetAttribute("class", classAttr.Value == null ? " active" : classAttr.Value.ToString()+" active");
            }
        }

        private bool ShouldBeActive()
        {
            if (Page != null)
            {
                if (Page.ToLower() == "/production/index" )
                {
                    return true;
                }
                if (Page.ToLower() == "/production/company/index")
                {
                    return true;
                }
                if (Page.ToLower() == "/production/company/plants/list")
                {
                    return true;
                }

                else if (!string.IsNullOrWhiteSpace(Page) && Page.ToLower() != contextAccessor.HttpContext.Request.Path.Value.ToLower())
                {
                    return false;
                }
            }
            return true;
        }

    }

}
