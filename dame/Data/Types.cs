using System;

using EDAM = Evernote.EDAM.Type;

namespace dame.Data
{
    // TODO: Add the additional types so that we never have to return EDAM types, only accept in the Add database methods

    // TODO: Decide if this is the way to go...
    // May not even need
    //        public new Data Data
    //        {
    //            get
    //            {
    //                return (Data)base.Data;
    //            }
    //            set
    //            {
    //                base.Data = value;
    //            }
    //        }
    // TODO: Need a way to create these with copies of their superclass?


    // Dirty 
    public class Notebook : EDAM.Notebook
    {
        public bool Dirty { get; set; }
        public long Luid { get; set; }

        private void testing()
        {

        }
    }
    public class Tag : EDAM.Tag
    {
        public bool Dirty { get; set; }
        public long Luid { get; set; }

        public long ParentLuid { get; set; }
    }
    public class Note : EDAM.Note
    {
        public bool Dirty { get; set; }
        public long Luid { get; set; }

        public long NotebookLuid { get; set; }
    }
    public class Resource : EDAM.Resource
    {
        public bool Dirty { get; set; }
        public long Luid { get; set; }

        public long DataLuid { get; set; }
        public long AlternateDataLuid { get; set; }
        public long RecognitionLuid { get; set; }
    }
    public class SavedSearch : EDAM.SavedSearch
    {
        public bool Dirty { get; set; }
        public long Luid { get; set; }
    }

    public class LinkedNotebook : EDAM.LinkedNotebook
    {
        public long Luid { get; set; }
    }

    public class SharedNotebook : EDAM.SharedNotebook
    {
        public long NotebookLuid { get; set; }
    }
    public class NoteAttributes : EDAM.NoteAttributes
    {
        public long NoteLuid { get; set; }
    }

    public class Data : EDAM.Data
    {
        // TODO: Use the below to access the bytes, need to grab the file from the filesystem though
//        public bytep[] GetBody()
//        {
//            return (this.__isset.body) ? this.Body : 
//        }
    } 

    // Blank
    public class Accounting : EDAM.Accounting {}
    public class BusinessNotebook : EDAM.BusinessNotebook {}
    public class User : EDAM.User {}
}

