using System;
using System.IO;
using System.Text;

namespace dame.Data
{
    public static class Conversion
    {
        // TODO: May be necessary to use Streams for performance & memory usage
        public static string Convert(DocumentType fromType, DocumentType toType, string input)
        {
            // TODO: Implement many convertsions
            if (fromType == toType)
            {
                return input;
            }
            else if (fromType == DocumentType.ENML)
            {
                unimplemented(fromType);
            }
            else if (fromType == DocumentType.HTML)
            {
                if (toType == DocumentType.XHTML)
                {
                    return HTMLToXHTML(input);
                }
                else if (toType == DocumentType.ENML)
                {
                    return XHTMLTOENML(HTMLToXHTML(input));
                }
                else
                {
                    unimplemented(fromType, toType);
                }
            }
            else if (fromType == DocumentType.PDF)
            {
                unimplemented(fromType);
            }
            else
            {
                unimplemented(fromType);
            }
            return null;
        }

        private static Exception unimplemented(DocumentType fromType)
        {
            throw new NotImplementedException(String.Format("Conversion From:{0} has not been implemented", fromType));
        }
        private static Exception unimplemented(DocumentType fromType, DocumentType toType)
        {
            throw new NotImplementedException(String.Format("Conversion From:{0} To: {1} has not been implemented", fromType, toType));
        }

        private static string HTMLToXHTML(string html)
        {
            var sb = new StringBuilder(); 
            var stringWriter = new StringWriter(sb);

            var test = new HtmlAgilityPack.HtmlDocument();
            test.LoadHtml(html);
            test.OptionOutputAsXml = true;
            test.OptionCheckSyntax = true;
            test.OptionFixNestedTags = true;

            // Get node by tag OR id OR whatever
            HtmlAgilityPack.HtmlNode node = test.DocumentNode.FirstChild;
            // Create new node based on it's info
            HtmlAgilityPack.HtmlNode newNode = new HtmlAgilityPack.HtmlNode(HtmlAgilityPack.HtmlNodeType.Element, test, -1);
            // Replace
            node.ParentNode.ReplaceChild(newNode, node);

            test.Save(stringWriter);

            return sb.ToString();
        }

        private static string XHTMLTOENML(string xhtml)
        {
            // TODO:
            unimplemented(DocumentType.XHTML, DocumentType.ENML);
            return null;
        }
    }
}

