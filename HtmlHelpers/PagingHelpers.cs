using System;
using System.Text;
using System.Web.Mvc;
using MatStore.WebUI.Models;

namespace MatStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        //extension method generates html for page links using a PagingInfo obj. Func generates links for other pages
        public static MvcHtmlString linker(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.currentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}