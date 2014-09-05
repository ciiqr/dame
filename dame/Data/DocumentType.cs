using System;

namespace dame
{
    public struct ExternalDocumentType
    {
        public string name;
        public string mimeType;

        public ExternalDocumentType(string name, string mimeType)
        {
            this.name = name;
            this.mimeType = mimeType;
        }

        public static readonly ExternalDocumentType PDF = new ExternalDocumentType("Pdf", "application/pdf");
    }
}

