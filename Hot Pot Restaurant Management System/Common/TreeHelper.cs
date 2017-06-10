using Hot_Pot_Restaurant_Management_System.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hot_Pot_Restaurant_Management_System.Common
{
    public static class TreeHelper
    {
        
        public static MvcHtmlString TreeView(this HtmlHelper helper, ITreeView treeView,string controller)
        {
            return DrawTree(treeView, controller);
        }

        
        private static MvcHtmlString DrawTree(ITreeView treeView, string controller)
        {
            if (treeView == null)
                return new MvcHtmlString(string.Empty);

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");

            if (treeView.Children != null)
            {
                foreach (var child in treeView.Children)
                {
                    sb.Append("<li class='liTree'>");
                    sb.Append(string.Format("<a class='aTree' href='/{0}/editpage/{1}'>", controller, child.ID));
                    sb.Append(string.Format("{0}</a>", child.Name));
                    sb.Append("</li>");

                    if (child.Children != null)
                        sb.Append(DrawTree(child, controller));
                }
            }

            sb.Append("</ul>");

            MvcHtmlString result = new MvcHtmlString(sb.ToString());
            return result;
        }
        
        public static T BuildTree<T>(IEnumerable<ITreeView> treeViews)
            where T : ITreeView, new()
        {
            var treeroot = new T();

            var parents = treeViews.Where(c => c.SuperiorID == 0);
            treeroot.Children.AddRange(BuildChildren(parents, treeViews));

            return treeroot;
        }

        
        private static IEnumerable<ITreeView> BuildChildren(IEnumerable<ITreeView> parents,IEnumerable<ITreeView> treeViews)
        {
            foreach (var parent in parents)
            {
                var children = treeViews.Where(c => c.SuperiorID == parent.ID);
                if (children == null)
                    continue;

                parent.Children.AddRange(children);
                BuildChildren(children, treeViews);
            }

            return parents;
        }
    }
}