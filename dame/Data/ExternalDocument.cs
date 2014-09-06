using System;

namespace dame.Data
{
    public static class ExternalDocument
    {
        public static readonly DocumentType[] IMPORT_TYPES = {
            DocumentType.ENML,
            DocumentType.HTML,
            DocumentType.PDF,
        };

        public static readonly DocumentType[] EXPORT_TYPES = {
            DocumentType.ENML,
            DocumentType.HTML,
            DocumentType.PDF,
        };

        // TODO: Async/Cancel & Progress
        // TODO: Completion Handler parameter

        public static string Import(DocumentType fromType, string[] filePaths)
        {
            // TODO: 
            return null;
        }

        public static string Export(DocumentType toType, string directoryPath, long[] noteLuids)
        {
            // TODO: 
            return null;
        }
    }
}

