using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHelperSample.TagHelpers
{
    [TargetElement("email", Attributes = "domain")]
    [TargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        public static string emailDomain = "mycompany.com";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var sb = new StringBuilder();

            sb.Append(context.GetChildContentAsync().Result.GetContent());

            if (context.AllAttributes.ContainsKey("domain"))
            {
                sb.Append("@" + context.AllAttributes["domain"].ToString());
            }
            else
            {
                sb.Append("@" + emailDomain);
            }

            output.TagName = "a";
            output.SelfClosing = false;
            output.Attributes.Remove("domain");
            output.Content.SetContent(sb.ToString());
            output.Attributes["href"] = "mailto:" + output.Content;
        }
    }
}
