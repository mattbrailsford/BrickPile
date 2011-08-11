/* Copyright (C) 2011 by Marcus Lindblom

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace BrickPile.UI.Web.Mvc.Html {
    public static class LabelExtensions {
        /// <summary>
        /// Labels the specified HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public static MvcHtmlString Label(this HtmlHelper html, string expression, Func<object, HelperResult> template) {
            return Label(html, expression, null, template);
        }
        /// <summary>
        /// Labels the specified HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="labelText">The label text.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public static MvcHtmlString Label(this HtmlHelper html, string expression, string labelText, Func<object, HelperResult> template) {
            return LabelHelper(html, ModelMetadata.FromStringExpression(expression, html.ViewData), expression, template, labelText);
        }
        /// <summary>
        /// Labels the helper.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="metadata">The metadata.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="template">The template.</param>
        /// <param name="labelText">The label text.</param>
        /// <returns></returns>
        internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, Func<object, HelperResult> template, string labelText = null) {
            string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(resolvedLabelText)) {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tag.InnerHtml = string.Format(
                "{0} {1}",
                resolvedLabelText,
                template(null).ToHtmlString()
            );
            return tag.ToMvcHtmlString(TagRenderMode.Normal);
        }
        /// <summary>
        /// Toes the MVC HTML string.
        /// </summary>
        /// <param name="tagBuilder">The tag builder.</param>
        /// <param name="renderMode">The render mode.</param>
        /// <returns></returns>
        private static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
} 