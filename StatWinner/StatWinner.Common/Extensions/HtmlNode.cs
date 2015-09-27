using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace StatWinner.CommonExtensions
{
    public static class HtmlNodeExtensions
    {
        public static bool HasClass(this HtmlNode node, string className)
        {
            return node.Attributes["class"] != null &&
                   node.Attributes["class"].Value.AsString()
                       .ToLower()
                       .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                       .Contains(className.ToLower());
        }

        public static bool HasItemWithClass(this HtmlNodeCollection cln, string className)
        {
            return cln.Any(c => c.HasClass(className));
        }

        public static List<HtmlNode> FindNodesWithCssClass(this HtmlNodeCollection cln, string className)
        {
            return cln.Where(c => c.HasClass(className)).ToList();
        }

        public static HtmlNode FindFirstNodeWithCssClass(this HtmlNodeCollection cln, string className)
        {
            return cln.FindNodesWithCssClass(className).FirstOrDefault();
        }

        public static HtmlTextNode FindFirstTextNode(this HtmlNodeCollection cln)
        {
            return cln.FirstOrDefault(n => n.NodeType == HtmlNodeType.Text) as HtmlTextNode;
        }

        public static List<HtmlNode> GetElementsByClassName(this HtmlNode node, string className)
        {
            return node.DescendantNodes().Where(dn => dn.HasClass(className)).ToList();
        }

        public static HtmlNode GetFirstElementByClassName(this HtmlNode node, string className)
        {
            return GetElementsByClassName(node, className).FirstOrDefault();
        }

        public static HtmlNode GetElementById(this HtmlNode node, string id)
        {
            return
                node.DescendantNodes()
                    .FirstOrDefault(
                        dn => dn.Attributes["id"] != null && dn.Attributes["id"].Value.ToLower() == id.ToLower());
        }
    }
}
