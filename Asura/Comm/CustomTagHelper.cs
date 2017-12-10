﻿using System.Threading.Tasks;
using Markdig;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Asura.TagHelpers
{
    [HtmlTargetElement("markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        [HtmlAttributeName("text")]
        public string Text { get; set; }

        [HtmlAttributeName("source")]
        public ModelExpression Source { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Source != null)
            {
                Text = Source.Model.ToString();
            }

            var result = Markdown.ToHtml(Text);
            output.TagName = "div";
            output.Content.SetHtmlContent(result);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
    
    
    [HtmlTargetElement("markplain")]
    public class String2HtmlTagHelper : TagHelper
    {
        [HtmlAttributeName("text")]
        public string Text { get; set; }

        [HtmlAttributeName("source")]
        public ModelExpression Source { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Source != null)
            {
                Text = Source.Model.ToString();
            }
            var result = Markdown.ToPlainText(Text);
            output.TagName = "p";
            output.Content.SetHtmlContent(result);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}