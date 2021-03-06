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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BrickPile.Domain.Models;
using BrickPile.UI.Common;

namespace BrickPile.UI.Web.Mvc.Html {
    /// <summary>
    /// Extension methods for the <see cref="HtmlHelper"/> object.
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class SubMenuHelper {
        /// <summary>
        /// Gets the current model.
        /// </summary>
        private static IPageModel CurrentModel {
            get { return ((MvcHandler) HttpContext.Current.Handler).RequestContext.RouteData.GetCurrentModel<IPageModel>(); }
        }
        /// <summary>
        /// Creates a hierarchical unordered navigation list
        /// </summary>
        /// <param name="html">HtmlHelper</param>
        /// <param name="hierarchy">The hierarchy.</param>
        /// <param name="itemContent">A lambda expression defining the content in each tree node</param>
        /// <returns></returns>
        public static MvcHtmlString SubMenu(this HtmlHelper html, IEnumerable<IPageModel> hierarchy, Func<IPageModel, MvcHtmlString> itemContent) {
            return SubMenu(html, hierarchy, itemContent, itemContent);
        }
        /// <summary>
        /// Responsible for creating a navigation tree based on a hierarchical structure
        /// </summary>
        /// <param name="html">HtmlHelper</param>
        /// <param name="hierarchy">The hierarchy.</param>
        /// <param name="itemContent">A lambda expression defining the content in each tree node</param>
        /// <param name="selectedItemContent">A lambda expression defining the content in each selected tree node</param>
        /// <returns></returns>
        public static MvcHtmlString SubMenu(this HtmlHelper html, IEnumerable<IPageModel> hierarchy, Func<IPageModel, MvcHtmlString> itemContent, Func<IPageModel, MvcHtmlString> selectedItemContent) {
            return SubMenu(html, hierarchy, itemContent, selectedItemContent, itemContent);
        }
        /// <summary>
        /// Responsible for creating a navigation tree based on a hierarchical structure
        /// </summary>
        /// <param name="html">HtmlHelper</param>
        /// <param name="hierarchy">The hierarchy.</param>
        /// <param name="itemContent">A lambda expression defining the content in each tree node</param>
        /// <param name="selectedItemContent">A lambda expression defining the content in each selected tree node</param>
        /// <param name="expandedItemContent">Content of the expanded item.</param>
        /// <returns></returns>
        public static MvcHtmlString SubMenu(this HtmlHelper html, IEnumerable<IPageModel> hierarchy, Func<IPageModel, MvcHtmlString> itemContent, Func<IPageModel, MvcHtmlString> selectedItemContent, Func<IPageModel, MvcHtmlString> expandedItemContent) {
            return SubMenu(html, hierarchy, itemContent, selectedItemContent, expandedItemContent, null);
        }
        /// <summary>
        /// Responsible for creating a navigation tree based on a hierarchical structure
        /// </summary>
        /// <param name="html">HtmlHelper</param>
        /// <param name="hierarchy">The hierarchy.</param>
        /// <param name="itemContent">A lambda expression defining the content in each tree node</param>
        /// <param name="selectedItemContent">A lambda expression defining the content in each selected tree node</param>
        /// <param name="expandedItemContent">Content of the expanded item.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString SubMenu(this HtmlHelper html, IEnumerable<IPageModel> hierarchy, Func<IPageModel, MvcHtmlString> itemContent, Func<IPageModel, MvcHtmlString> selectedItemContent, Func<IPageModel, MvcHtmlString> expandedItemContent, object htmlAttributes) {
            if (hierarchy == null) {
                return MvcHtmlString.Empty;
            }

            var hierarchyNodes = hierarchy.AsHierarchy();

            var item = hierarchyNodes.SingleOrDefault(x => x.Expanded);

            if (item == null || !item.ChildNodes.Any())
                return MvcHtmlString.Empty;

            var ul = new TagBuilder("ul");
            // merge html attributes
            ul.MergeAttributes(new RouteValueDictionary(htmlAttributes));


            foreach (var node in item.ChildNodes) {
                RenderLi(ul, node.Entity, node.Entity.Equals(CurrentModel) ? selectedItemContent : (node.Expanded ? expandedItemContent : itemContent));
                AppendChildrenRecursive(ul, node, x => x.ChildNodes, itemContent, selectedItemContent, expandedItemContent);
            }

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.Normal));            
        }

        /// <summary>
        /// Creates an unordered hierarchical list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagBuilder">The tag builder.</param>
        /// <param name="rootNode">The root node.</param>
        /// <param name="childrenProperty">The children property.</param>
        /// <param name="itemContent">Content of the item.</param>
        /// <param name="selectedItemContent">Content of the selected item.</param>
        /// <param name="expandedItemContent">Content of the expanded item.</param>
        private static void AppendChildrenRecursive<T>(TagBuilder tagBuilder, IHierarchyNode<IPageModel> rootNode, Func<IHierarchyNode<IPageModel>, IEnumerable<IHierarchyNode<IPageModel>>> childrenProperty, Func<T, MvcHtmlString> itemContent, Func<T, MvcHtmlString> selectedItemContent, Func<T, MvcHtmlString> expandedItemContent) {
            var children = childrenProperty(rootNode);

            if (!children.Any()) {
                tagBuilder.InnerHtml += new TagBuilder("li").ToString(TagRenderMode.EndTag);
                return;
            }

            var ul = new TagBuilder("ul");

            foreach (var item in children) {
                RenderLi(ul, (T)item.Entity, item.Entity.Id.Equals(CurrentModel) ? selectedItemContent : (item.Expanded ? expandedItemContent : itemContent));
                AppendChildrenRecursive(ul, item, childrenProperty, itemContent, selectedItemContent, expandedItemContent);
            }

            tagBuilder.InnerHtml += ul.ToString(TagRenderMode.Normal);
            tagBuilder.InnerHtml += new TagBuilder("li").ToString(TagRenderMode.EndTag);
        }

        /// <summary>
        /// Responsible for renderingen the li element with it's content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tagBuilder">The tag builder.</param>
        /// <param name="item">The item.</param>
        /// <param name="itemContent">A lambda expression defining the content in each tree node</param>
        private static void RenderLi<T>(TagBuilder tagBuilder, T item, Func<T, MvcHtmlString> itemContent) {
            tagBuilder.InnerHtml += new TagBuilder("li").ToString(TagRenderMode.StartTag) + itemContent(item);
        }  
    }
}