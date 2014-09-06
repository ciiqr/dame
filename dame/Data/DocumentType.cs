using System;

namespace dame.Data
{
    public struct DocumentType
    {
        public string name;
        public string[] extensions;

        public DocumentType(string name, string[] extensions)
        {
            this.name = name;
            this.extensions = extensions;
        }

        public override string ToString()
        {
            return name;
        }

        #region Standard Types
        // TODO: Convert DocumentType to filter string which works on most platforms
        public static readonly DocumentType PDF = new DocumentType("Pdf", new[] {"pdf"});
        public static readonly DocumentType HTML = new DocumentType("Html", new[] {"html"});
        public static readonly DocumentType XHTML = new DocumentType("XHtml", new[] {"html"});
        public static readonly DocumentType ENML = new DocumentType("Enml", new[] {"enml"});
        public static readonly DocumentType MARKDOWN = new DocumentType("Markdown", new[] {"md"});
        public static readonly DocumentType OPEN_XML = new DocumentType("Open Xml", new[] {"docx", "docm"});
        // TODO: Should this be "" OR "*"
        public static readonly DocumentType PLAIN_TEXT = new DocumentType("Plain Text", new[] {""});
        #endregion

        #region Equality
        public override bool Equals(Object obj) 
        {
            return obj is DocumentType && this == (DocumentType)obj;
        }

        public override int GetHashCode() 
        {
            return name.GetHashCode() ^ extensions.GetHashCode();
        }

        public static bool operator ==(DocumentType lDocument, DocumentType rDocument)
        {
            return lDocument.name == rDocument.name;
        }

        public static bool operator !=(DocumentType lDocument, DocumentType rDocument)
        {
            return !(lDocument == rDocument);
        }
        #endregion
    }
}

