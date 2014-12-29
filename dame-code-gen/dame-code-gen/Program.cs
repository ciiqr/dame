#define GENERATE_FILES
using System;
using System.Text;
using GetObjectField = damecodegen.DataAccess.GetObjectField;
using GetObjectSubtype = damecodegen.DataAccess.GetObjectSubtype;
using AddObjectField = damecodegen.DataAccess.AddObjectField;
using AddObjectSubtype = damecodegen.DataAccess.AddObjectSubtype;
using UpdateObjectField = damecodegen.DataAccess.UpdateObjectField;


namespace damecodegen
{
    class MainClass
    {
        public static void GetAllOfField()
        {
            P(DataAccess.GetAllOfField(fieldName:"Luid", methodName:"GetNotebookLuids", returnName:"notebookLuids", returnObjectField:"Luid", returnType:"long", tableName:"Notebooks"));
            P(DataAccess.GetAllOfField(fieldName:"Luid", methodName:"GetNoteLuids", returnName:"noteLuids", returnObjectField:"Luid", returnType:"long", tableName:"Notes"));
            P(DataAccess.GetAllOfField(fieldName:"Luid", methodName:"GetSavedSearchLuids", returnName:"savedSearchLuids", returnObjectField:"Luid", returnType:"long", tableName:"SavedSearches"));
            P(DataAccess.GetAllOfField(fieldName:"Luid", methodName:"GetLinkedNotebookLuids", returnName:"linkedNotebookLuids", returnObjectField:"Luid", returnType:"long", tableName:"LinkedNotebooks"));
        }

        public static void GetSingletonField()
        {
            P(DataAccess.GetSingletonField(returnType:"int", methodName:"GetLastSyncTime", returnName:"lastSyncTime", defaultValue:"-1", fieldName:"LastSyncTime", returnObjectField:"LastSyncTime", tableName:"Sync", castType:"long"));
            P(DataAccess.GetSingletonField(returnType:"int", methodName:"GetLastUpdateCount", returnName:"lastUpdateCount", defaultValue:"-1", fieldName:"LastUpdateCount", returnObjectField:"LastUpdateCount", tableName:"Sync", castType:"long"));
        }

        public static void DeleteObject() // TODO: Delete Subtypes
        {
            P(DataAccess.DeleteObject(fieldName:"Id", methodName:"DeleteUser", parameterName:"id", parameterType:"int", tableName:"Users"));
            P(DataAccess.DeleteObject(fieldName:"Luid", methodName:"DeleteNotebook", parameterName:"luid", parameterType:"long", tableName:"Notebooks"));
            P(DataAccess.DeleteObject(fieldName:"Luid", methodName:"DeleteTag", parameterName:"luid", parameterType:"long", tableName:"Tags"));
            P(DataAccess.DeleteObject(fieldName:"Luid", methodName:"DeleteNote", parameterName:"luid", parameterType:"long", tableName:"Notes"));
            P(DataAccess.DeleteObject(fieldName:"Luid", methodName:"DeleteSavedSearch", parameterName:"luid", parameterType:"long", tableName:"SavedSearches"));
            P(DataAccess.DeleteObject(fieldName:"Luid", methodName:"DeleteLinkedNotebook", parameterName:"luid", parameterType:"long", tableName:"LinkedNotebooks"));
        }

        public static void GetObject() // TODO: Get additional items
        {
            P(DataAccess.GetObject(returnType:"Note", methodName:"GetNote", parameterType:"long", parameterName:"luid", returnName:"note", defaultValue:"null", tableName:"Notes", fieldName:"Luid",
                fields: new[] {
                new GetObjectField("Luid", "long", "Luid"),
                new GetObjectField("Guid", "string", "Guid"),
                new GetObjectField("Title", "string", "Title"),
                new GetObjectField("Content", "string", "Content"),
                new GetObjectField("ContentHash", "byte[]", "ContentHash"),
                new GetObjectField("ContentLength", "int", "ContentLength"),
                new GetObjectField("Created", "long", "Created"),
                new GetObjectField("Updated", "long", "Updated"),
                new GetObjectField("Deleted", "long", "Deleted"),
                new GetObjectField("Active", "bool", "Active"),
                new GetObjectField("UpdateSequenceNum", "int", "UpdateSequenceNum"),
                new GetObjectField("Dirty", "bool", "Dirty"),
                new GetObjectField("NotebookLuid", "long", "NotebookLuid")
            },
                subtypes: new[] {
                new GetObjectSubtype("Attributes", "GetNoteAttributes"),
                new GetObjectSubtype("Resources", "GetNoteResources"),
                new GetObjectSubtype("TagNames", "GetNoteTagNames")
            }));
            P(DataAccess.GetObject(returnType:"NoteAttributes", methodName:"GetNoteAttributes", parameterType:"long", parameterName:"noteLuid", returnName:"attributes", defaultValue:"null", tableName:"NoteAttributes", fieldName:"NoteLuid",
                fields: new[] {
                new GetObjectField("SubjectDate", "long", "SubjectDate"),
                new GetObjectField("Latitude", "double", "Latitude"),
                new GetObjectField("Longitude", "double", "Longitude"),
                new GetObjectField("Altitude", "double", "Altitude"),
                new GetObjectField("Author", "string", "Author"),
                new GetObjectField("Source", "string", "Source"),
                new GetObjectField("SourceURL", "string", "SourceURL"),
                new GetObjectField("SourceApplication", "string", "SourceApplication"),
                new GetObjectField("ShareDate", "long", "ShareDate"),
                new GetObjectField("ReminderOrder", "long", "ReminderOrder"),
                new GetObjectField("ReminderDoneTime", "long", "ReminderDoneTime"),
                new GetObjectField("ReminderTime", "long", "ReminderTime"),
                new GetObjectField("PlaceName", "string", "PlaceName"),
                new GetObjectField("ContentClass", "string", "ContentClass"),
                new GetObjectField("LastEditedBy", "string", "LastEditedBy"),
                new GetObjectField("CreatorId", "int", "CreatorId"),
                new GetObjectField("LastEditorId", "int", "LastEditorId")
            },
                subtypes: new[] {
                new GetObjectSubtype("Classifications", "GetNoteAttributesClassifications")
            }));

            P(DataAccess.GetObject(returnType:"SavedSearch", methodName:"GetSavedSearch", parameterType:"long", parameterName:"luid", returnName:"savedSearch", defaultValue:"null", tableName:"SavedSearches", fieldName:"Luid",
                fields: new[] {
                new GetObjectField("Luid", "long", "Luid"),
                new GetObjectField("Guid", "string", "Guid"),
                new GetObjectField("Name", "string", "Name"),
                new GetObjectField("Query", "string", "Query"),
                new GetObjectField("Format", "EDAM.QueryFormat", "Format"),
                new GetObjectField("UpdateSequenceNum", "int", "UpdateSequenceNum"),
                new GetObjectField("Dirty", "bool", "Dirty")
            },
                subtypes: new[] {
                new GetObjectSubtype("Scope", "GetSavedSearchScope")
            }));
            P(DataAccess.GetObject(returnType:"LinkedNotebook", methodName:"GetLinkedNotebook", parameterType:"long", parameterName:"luid", returnName:"linkedNotebooks", defaultValue:"null", tableName:"LinkedNotebooks", fieldName:"Luid",
                fields: new[] {
                new GetObjectField("Luid", "long", "Luid"),
                new GetObjectField("ShareName", "string", "ShareName"),
                new GetObjectField("Username", "string", "Username"),
                new GetObjectField("ShardId", "string", "ShardId"),
                new GetObjectField("ShareKey", "string", "ShareKey"),
                new GetObjectField("Uri", "string", "Uri"),
                new GetObjectField("Guid", "string", "Guid"),
                new GetObjectField("UpdateSequenceNum", "int", "UpdateSequenceNum"),
                new GetObjectField("NoteStoreUrl", "string", "NoteStoreUrl"),
                new GetObjectField("WebApiUrlPrefix", "string", "WebApiUrlPrefix"),
                new GetObjectField("Stack", "string", "Stack"),
                new GetObjectField("BusinessId", "int", "BusinessId")
            }, subtypes: new GetObjectSubtype[] {}));

            P(DataAccess.GetObject(returnType:"User", methodName:"GetUser", parameterType:"long", parameterName:"id", returnName:"user", defaultValue:"null", tableName:"Users", fieldName:"Id",
                fields: new[] {
                new GetObjectField("Id", "int", "Id"),
                new GetObjectField("Username", "string", "Username"),
                new GetObjectField("Name", "string", "Name"),
                new GetObjectField("Timezone", "string", "Timezone"),
                new GetObjectField("Privilege", "EDAM.PrivilegeLevel", "Privilege"),
                new GetObjectField("Created", "long", "Created"),
                new GetObjectField("Updated", "long", "Updated"),
                new GetObjectField("Deleted", "long", "Deleted"),
                new GetObjectField("Active", "bool", "Active")
            },
                subtypes: new[] {
                new GetObjectSubtype("Attributes", "GetUserAttributes"),
                new GetObjectSubtype("Accounting", "GetAccounting"),
                new GetObjectSubtype("PremiumInfo", "GetPremiumInfo"),
                new GetObjectSubtype("BusinessUserInfo", "GetBusinessUserInfo")
            }));
            P(DataAccess.GetObject(returnType:"Accounting", methodName:"GetAccounting", parameterType:"long", parameterName:"userId", returnName:"accounting", defaultValue:"null", tableName:"Accounting", fieldName:"UserId",
                fields: new[] {
                new GetObjectField("UploadLimit", "long", "UploadLimit"),
                new GetObjectField("UploadLimitEnd", "long", "UploadLimitEnd"),
                new GetObjectField("UploadLimitNextMonth", "long", "UploadLimitNextMonth"),
                new GetObjectField("PremiumServiceStatus", "EDAM.PremiumOrderStatus", "PremiumServiceStatus"),
                new GetObjectField("PremiumOrderNumber", "string", "PremiumOrderNumber"),
                new GetObjectField("PremiumCommerceService", "string", "PremiumCommerceService"),
                new GetObjectField("PremiumServiceStart", "long", "PremiumServiceStart"),
                new GetObjectField("PremiumServiceSKU", "string", "PremiumServiceSKU"),
                new GetObjectField("LastSuccessfulCharge", "long", "LastSuccessfulCharge"),
                new GetObjectField("LastFailedCharge", "long", "LastFailedCharge"),
                new GetObjectField("LastFailedChargeReason", "string", "LastFailedChargeReason"),
                new GetObjectField("NextPaymentDue", "long", "NextPaymentDue"),
                new GetObjectField("PremiumLockUntil", "long", "PremiumLockUntil"),
                new GetObjectField("Updated", "long", "Updated"),
                new GetObjectField("PremiumSubscriptionNumber", "string", "PremiumSubscriptionNumber"),
                new GetObjectField("LastRequestedCharge", "long", "LastRequestedCharge"),
                new GetObjectField("Currency", "string", "Currency"),
                new GetObjectField("UnitPrice", "int", "UnitPrice"),
                new GetObjectField("UnitDiscount", "int", "UnitDiscount"),
                new GetObjectField("NextChargeDate", "long", "NextChargeDate")
            }, subtypes: new GetObjectSubtype[] {}));
            P(DataAccess.GetObject(returnType:"EDAM.PremiumInfo", methodName:"GetPremiumInfo", parameterType:"long", parameterName:"userId", returnName:"premiumInfo", defaultValue:"null", tableName:"PremiumInfo", fieldName:"UserId",
                fields: new[] {
                new GetObjectField("CurrentTime", "long", "CurrentTime"),
                new GetObjectField("Premium", "bool", "Premium"),
                new GetObjectField("PremiumRecurring", "bool", "PremiumRecurring"),
                new GetObjectField("PremiumExpirationDate", "long", "PremiumExpirationDate"),
                new GetObjectField("PremiumExtendable", "bool", "PremiumExtendable"),
                new GetObjectField("PremiumPending", "bool", "PremiumPending"),
                new GetObjectField("PremiumCancellationPending", "bool", "PremiumCancellationPending"),
                new GetObjectField("CanPurchaseUploadAllowance", "bool", "CanPurchaseUploadAllowance"),
                new GetObjectField("SponsoredGroupName", "string", "SponsoredGroupName"),
                new GetObjectField("PremiumUpgradable", "bool", "PremiumUpgradable")
            }, subtypes: new GetObjectSubtype[] {}));
            P(DataAccess.GetObject(returnType:"EDAM.BusinessUserInfo", methodName:"GetBusinessUserInfo", parameterType:"long", parameterName:"userId", returnName:"businessUserInfo", defaultValue:"null", tableName:"BusinessUserInfo", fieldName:"UserId",
                fields: new[] {
                new GetObjectField("BusinessId", "int", "BusinessId"),
                new GetObjectField("BusinessName", "string", "BusinessName"),
                new GetObjectField("Role", "EDAM.BusinessUserRole", "Role"),
                new GetObjectField("Email", "string", "Email"),

            }, subtypes: new GetObjectSubtype[] {}));

            P(DataAccess.GetObject(returnType:"Notebook", methodName:"GetNotebook", parameterType:"long", parameterName:"luid", returnName:"notebook", defaultValue:"null", tableName:"Notebooks", fieldName:"Luid",
                fields: new[] {
                new GetObjectField("Luid", "long", "Luid"),
                new GetObjectField("Guid", "string", "Guid"),
                new GetObjectField("Name", "string", "Name"),
                new GetObjectField("UpdateSequenceNum", "int", "UpdateSequenceNum"),
                new GetObjectField("DefaultNotebook", "bool", "DefaultNotebook"),
                new GetObjectField("ServiceCreated", "long", "ServiceCreated"),
                new GetObjectField("ServiceUpdated", "long", "ServiceUpdated"),
                new GetObjectField("Published", "bool", "Published"),
                new GetObjectField("Stack", "string", "Stack"),
                new GetObjectField("Dirty", "bool", "Dirty")
            },
                subtypes: new[] {
                new GetObjectSubtype("BusinessNotebook", "GetBusinessNotebook"),
                new GetObjectSubtype("Contact", "GetUser"), // TODO: Needs to ba handled differently because we want to pass in the ContactId instead of the notebookId, TODO: Also need to handle when we set/add/update
                new GetObjectSubtype("Publishing", "GetPublishing"),
                new GetObjectSubtype("Restrictions", "GetNotebookRestrictions"),
                new GetObjectSubtype("SharedNotebooks", "GetSharedNotebooks")
            }));
            P(DataAccess.GetObject(returnType:"EDAM.Publishing", methodName:"GetPublishing", parameterType:"long", parameterName:"notebookLuid", returnName:"publishing", defaultValue:"null", tableName:"Publishing", fieldName:"NotebookLuid",
                fields: new[] {
                new GetObjectField("Uri", "string", "Uri"),
                new GetObjectField("Order", "EDAM.NoteSortOrder", "NoteSortOrder"),
                new GetObjectField("Ascending", "bool", "Ascending"),
                new GetObjectField("PublicDescription", "string", "PublicDescription")
            }, subtypes: new GetObjectSubtype[] {}));
            P(DataAccess.GetObject(returnType:"BusinessNotebook", methodName:"GetBusinessNotebook", parameterType:"long", parameterName:"notebookLuid", returnName:"businessNotebook", defaultValue:"null", tableName:"BusinessNotebook", fieldName:"NotebookLuid",
                fields: new[] {
                new GetObjectField("NotebookDescription", "string", "NotebookDescription"),
                new GetObjectField("Privilege", "EDAM.SharedNotebookPrivilegeLevel", "Privilege"),
                new GetObjectField("Recommended", "bool", "Recommended")
            }, subtypes: new GetObjectSubtype[] {}));
            P(DataAccess.GetObject(returnType:"EDAM.NotebookRestrictions", methodName:"GetNotebookRestrictions", parameterType:"long", parameterName:"notebookLuid", returnName:"restrictions", defaultValue:"null", tableName:"NotebookRestrictions", fieldName:"NotebookLuid",
                fields: new[] {
                new GetObjectField("NoReadNotes", "bool", "NoReadNotes"),
                new GetObjectField("NoCreateNotes", "bool", "NoCreateNotes"),
                new GetObjectField("NoUpdateNotes", "bool", "NoUpdateNotes"),
                new GetObjectField("NoExpungeNotes", "bool", "NoExpungeNotes"),
                new GetObjectField("NoShareNotes", "bool", "NoShareNotes"),
                new GetObjectField("NoEmailNotes", "bool", "NoEmailNotes"),
                new GetObjectField("NoSendMessageToRecipients", "bool", "NoSendMessageToRecipients"),
                new GetObjectField("NoUpdateNotebook", "bool", "NoUpdateNotebook"),
                new GetObjectField("NoExpungeNotebook", "bool", "NoExpungeNotebook"),
                new GetObjectField("NoSetDefaultNotebook", "bool", "NoSetDefaultNotebook"),
                new GetObjectField("NoSetNotebookStack", "bool", "NoSetNotebookStack"),
                new GetObjectField("NoPublishToPublic", "bool", "NoPublishToPublic"),
                new GetObjectField("NoPublishToBusinessLibrary", "bool", "NoPublishToBusinessLibrary"),
                new GetObjectField("NoCreateTags", "bool", "NoCreateTags"),
                new GetObjectField("NoUpdateTags", "bool", "NoUpdateTags"),
                new GetObjectField("NoExpungeTags", "bool", "NoExpungeTags"),
                new GetObjectField("NoSetParentTag", "bool", "NoSetParentTag"),
                new GetObjectField("NoCreateSharedNotebooks", "bool", "NoCreateSharedNotebooks"),
                new GetObjectField("UpdateWhichSharedNotebookRestrictions", "EDAM.SharedNotebookInstanceRestrictions", "UpdateWhichSharedNotebookRestrictions"),
                new GetObjectField("ExpungeWhichSharedNotebookRestrictions", "EDAM.SharedNotebookInstanceRestrictions", "ExpungeWhichSharedNotebookRestrictions")
            }, subtypes: new GetObjectSubtype[] {}));
            P(DataAccess.GetObject(returnType:"Tag", methodName:"GetTag", parameterType:"long", parameterName:"luid", returnName:"tag", defaultValue:"null", tableName:"Tags", fieldName:"Luid",
                fields: new[] {
                new GetObjectField("Luid", "long", "Luid"),
                new GetObjectField("Guid", "string", "Guid"),
                new GetObjectField("Name", "string", "Name"),
                new GetObjectField("ParentLuid", "long", "ParentLuid"),
                new GetObjectField("UpdateSequenceNum", "int", "UpdateSequenceNum"),
                new GetObjectField("Dirty", "bool", "Dirty")
            }, subtypes: new GetObjectSubtype[] {}));
        }

        public static void AddObject() // TODO: The rest of the Addable objects
        {
            // TODO: The rest of the fields
            P(DataAccess.AddObject(methodName:"AddNote", parameterName:"note", parameterType:"EDAM.Note", tableName:"Notes",
                fields: new[] {
                // TODO: Is this correct?
                new AddObjectField("Guid", "Guid")
            }, subtypes: new AddObjectSubtype[] {
                // TODO: Add the subtypes
            }));
        }

        public static void UpdateObject() // TODO: The rest of the Update-able objects
        {
            // TODO: The rest of the fields
            P(DataAccess.UpdateObject(fieldName:"Luid", methodName:"UpdateNote", parameterName:"note", parameterType:"Note", parameterUniqueIdFieldName:"Luid", tableName: "Notes",
                fields: new[] {
                new UpdateObjectField("Guid", "Guid")
            }));
        }

        public static void GenerateDataAccess()
        {
            // TODO: Generate the entire partial class
            GetAllOfField();
            GetSingletonField();
            DeleteObject();
            GetObject();
            AddObject();
            UpdateObject();

            #if GENERATE_FILES
            CreateDataAccessFile();
            #endif
        }

        public static void Main(string[] args)
        {
            GenerateDataAccess();
        }

        #if GENERATE_FILES
        public static StringBuilder dataAccessContent = new StringBuilder();
        public static void P(string text)
        {
            dataAccessContent.AppendLine(text);
        }
        public static void CreateDataAccessFile()
        {
            System.IO.File.WriteAllText("./test.txt", dataAccessContent.ToString());
        }
        #else
        public static void P(string text)
        {
            Console.WriteLine(text);
        }
        #endif
    }
}
