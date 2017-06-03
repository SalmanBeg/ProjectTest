using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html; 

namespace HRMS.Web.Models
{
    public static class Extension
    {
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty, TEnum>(
                   this HtmlHelper<TModel> htmlHelper,
                   Expression<Func<TModel, TProperty>> expression,
                   TEnum selectedValue, object htmlAttributes)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum))
                                        .Cast<TEnum>();
            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem()
                                                {
                                                    Text = value.ToString(),
                                                    Value = value.ToString(),
                                                    Selected = (value.Equals(selectedValue))
                                                };
            return SelectExtensions.DropDownListFor(htmlHelper, expression, items, htmlAttributes);
        }

        
    }
}