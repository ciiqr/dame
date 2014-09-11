using System;
using System.Runtime.CompilerServices;

namespace dame.Data
{
    public static class FieldParams
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Join(params string[] fields)
        {
            return String.Join(",", fields);
        }

        public static class Sync
        {
            public const string SyncLastUpdateCount = "@" + Fields.Sync.SyncLastUpdateCount;
            public const string SyncLastSyncTime = "@" + Fields.Sync.SyncLastSyncTime;
        }

        public static class Users
        {
            public const string Id = "@" + Fields.Users.Id;
            public const string Username = "@" + Fields.Users.Username;
            public const string Name = "@" + Fields.Users.Name;
            public const string Timezone = "@" + Fields.Users.Timezone;
            public const string Privilege = "@" + Fields.Users.Privilege;
            public const string Created = "@" + Fields.Users.Created;
            public const string Updated = "@" + Fields.Users.Updated;
            public const string Deleted = "@" + Fields.Users.Deleted;
            public const string Active = "@" + Fields.Users.Active;
        }

        public static class BootstrapSettings
        {
            public const string UserId = "@" + Fields.BootstrapSettings.UserId;
            public const string ServiceHost = "@" + Fields.BootstrapSettings.ServiceHost;
            public const string MarketingUrl = "@" + Fields.BootstrapSettings.MarketingUrl;
            public const string SupportUrl = "@" + Fields.BootstrapSettings.SupportUrl;
            public const string AccountEmailDomain = "@" + Fields.BootstrapSettings.AccountEmailDomain;
            public const string EnableFacebookSharing = "@" + Fields.BootstrapSettings.EnableFacebookSharing;
            public const string EnableGiftSubscriptions = "@" + Fields.BootstrapSettings.EnableGiftSubscriptions;
            public const string EnableSupportTickets = "@" + Fields.BootstrapSettings.EnableSupportTickets;
            public const string EnableSharedNotebooks = "@" + Fields.BootstrapSettings.EnableSharedNotebooks;
            public const string EnableSingleNoteSharing = "@" + Fields.BootstrapSettings.EnableSingleNoteSharing;
            public const string EnableSponsoredAccounts = "@" + Fields.BootstrapSettings.EnableSponsoredAccounts;
            public const string EnableTwitterSharing = "@" + Fields.BootstrapSettings.EnableTwitterSharing;
            public const string EnableLinkedInSharing = "@" + Fields.BootstrapSettings.EnableLinkedInSharing;
            public const string EnablePublicNotebooks = "@" + Fields.BootstrapSettings.EnablePublicNotebooks;
        }

        public static class UserAttributes
        {
            public const string UserId = "@" + Fields.UserAttributes.UserId;
            public const string DefaultLocationName = "@" + Fields.UserAttributes.DefaultLocationName;
            public const string DefaultLatitude = "@" + Fields.UserAttributes.DefaultLatitude;
            public const string DefaultLongitude = "@" + Fields.UserAttributes.DefaultLongitude;
            public const string Preactivation = "@" + Fields.UserAttributes.Preactivation;
            public const string IncomingEmailAddress = "@" + Fields.UserAttributes.IncomingEmailAddress;
            public const string Comments = "@" + Fields.UserAttributes.Comments;
            public const string DateAgreedToTermsOfService = "@" + Fields.UserAttributes.DateAgreedToTermsOfService;
            public const string MaxReferrals = "@" + Fields.UserAttributes.MaxReferrals;
            public const string ReferralCount = "@" + Fields.UserAttributes.ReferralCount;
            public const string RefererCode = "@" + Fields.UserAttributes.RefererCode;
            public const string SentEmailDate = "@" + Fields.UserAttributes.SentEmailDate;
            public const string SentEmailCount = "@" + Fields.UserAttributes.SentEmailCount;
            public const string DailyEmailLimit = "@" + Fields.UserAttributes.DailyEmailLimit;
            public const string EmailOptOutDate = "@" + Fields.UserAttributes.EmailOptOutDate;
            public const string PartnerEmailOptInDate = "@" + Fields.UserAttributes.PartnerEmailOptInDate;
            public const string PreferredLanguage = "@" + Fields.UserAttributes.PreferredLanguage;
            public const string PreferredCountry = "@" + Fields.UserAttributes.PreferredCountry;
            public const string ClipFullPage = "@" + Fields.UserAttributes.ClipFullPage;
            public const string TwitterUserName = "@" + Fields.UserAttributes.TwitterUserName;
            public const string TwitterId = "@" + Fields.UserAttributes.TwitterId;
            public const string GroupName = "@" + Fields.UserAttributes.GroupName;
            public const string RecognitionLanguage = "@" + Fields.UserAttributes.RecognitionLanguage;
            public const string ReferralProof = "@" + Fields.UserAttributes.ReferralProof;
            public const string EducationalDiscount = "@" + Fields.UserAttributes.EducationalDiscount;
            public const string BusinessAddress = "@" + Fields.UserAttributes.BusinessAddress;
            public const string HideSponsorBilling = "@" + Fields.UserAttributes.HideSponsorBilling;
            public const string TaxExempt = "@" + Fields.UserAttributes.TaxExempt;
            public const string UseEmailAutoFiling = "@" + Fields.UserAttributes.UseEmailAutoFiling;
            public const string ReminderEmailConfig = "@" + Fields.UserAttributes.ReminderEmailConfig;
        }

        public static class Accounting
        {
            public const string UserId = "@" + Fields.Accounting.UserId;
            public const string UploadLimit = "@" + Fields.Accounting.UploadLimit;
            public const string UploadLimitEnd = "@" + Fields.Accounting.UploadLimitEnd;
            public const string UploadLimitNextMonth = "@" + Fields.Accounting.UploadLimitNextMonth;
            public const string PremiumServiceStatus = "@" + Fields.Accounting.PremiumServiceStatus;
            public const string PremiumOrderNumber = "@" + Fields.Accounting.PremiumOrderNumber;
            public const string PremiumCommerceService = "@" + Fields.Accounting.PremiumCommerceService;
            public const string PremiumServiceStart = "@" + Fields.Accounting.PremiumServiceStart;
            public const string PremiumServiceSKU = "@" + Fields.Accounting.PremiumServiceSKU;
            public const string LastSuccessfulCharge = "@" + Fields.Accounting.LastSuccessfulCharge;
            public const string LastFailedCharge = "@" + Fields.Accounting.LastFailedCharge;
            public const string LastFailedChargeReason = "@" + Fields.Accounting.LastFailedChargeReason;
            public const string NextPaymentDue = "@" + Fields.Accounting.NextPaymentDue;
            public const string PremiumLockUntil = "@" + Fields.Accounting.PremiumLockUntil;
            public const string Updated = "@" + Fields.Accounting.Updated;
            public const string PremiumSubscriptionNumber = "@" + Fields.Accounting.PremiumSubscriptionNumber;
            public const string LastRequestedCharge = "@" + Fields.Accounting.LastRequestedCharge;
            public const string Currency = "@" + Fields.Accounting.Currency;
            public const string UnitPrice = "@" + Fields.Accounting.UnitPrice;
            public const string UnitDiscount = "@" + Fields.Accounting.UnitDiscount;
            public const string NextChargeDate = "@" + Fields.Accounting.NextChargeDate;
        }

        public static class PremiumInfo
        {
            public const string UserId = "@" + Fields.PremiumInfo.UserId;
            public const string CurrentTime = "@" + Fields.PremiumInfo.CurrentTime;
            public const string Premium = "@" + Fields.PremiumInfo.Premium;
            public const string PremiumRecurring = "@" + Fields.PremiumInfo.PremiumRecurring;
            public const string PremiumExpirationDate = "@" + Fields.PremiumInfo.PremiumExpirationDate;
            public const string PremiumExtendable = "@" + Fields.PremiumInfo.PremiumExtendable;
            public const string PremiumPending = "@" + Fields.PremiumInfo.PremiumPending;
            public const string PremiumCancellationPending = "@" + Fields.PremiumInfo.PremiumCancellationPending;
            public const string CanPurchaseUploadAllowance = "@" + Fields.PremiumInfo.CanPurchaseUploadAllowance;
            public const string SponsoredGroupName = "@" + Fields.PremiumInfo.SponsoredGroupName;
            public const string PremiumUpgradable = "@" + Fields.PremiumInfo.PremiumUpgradable;
        }

        public static class BusinessUserInfo
        {
            public const string UserId = "@" + Fields.BusinessUserInfo.UserId;
            public const string BusinessId = "@" + Fields.BusinessUserInfo.BusinessId;
            public const string BusinessName = "@" + Fields.BusinessUserInfo.BusinessName;
            public const string Role = "@" + Fields.BusinessUserInfo.Role;
            public const string Email = "@" + Fields.BusinessUserInfo.Email;
        }

        public static class Notebooks
        {
            public const string Luid = "@" + Fields.Notebooks.Luid;
            public const string Guid = "@" + Fields.Notebooks.Guid;
            public const string Name = "@" + Fields.Notebooks.Name;
            public const string UpdateSequenceNum = "@" + Fields.Notebooks.UpdateSequenceNum;
            public const string DefaultNotebook = "@" + Fields.Notebooks.DefaultNotebook;
            public const string ServiceCreated = "@" + Fields.Notebooks.ServiceCreated;
            public const string ServiceUpdated = "@" + Fields.Notebooks.ServiceUpdated;
            public const string Published = "@" + Fields.Notebooks.Published;
            public const string Stack = "@" + Fields.Notebooks.Stack;
            public const string Dirty = "@" + Fields.Notebooks.Dirty;
            public const string ContactId = "@" + Fields.Notebooks.ContactId;
        }

        public static class Publishing
        {
            public const string NotebookLuid = "@" + Fields.Publishing.NotebookLuid;
            public const string Uri = "@" + Fields.Publishing.Uri;
            public const string NoteSortOrder = "@" + Fields.Publishing.NoteSortOrder;
            public const string Ascending = "@" + Fields.Publishing.Ascending;
            public const string PublicDescription = "@" + Fields.Publishing.PublicDescription;
        }

        public static class BusinessNotebook
        {
            public const string NotebookLuid = "@" + Fields.BusinessNotebook.NotebookLuid;
            public const string NotebookDescription = "@" + Fields.BusinessNotebook.NotebookDescription;
            public const string Privilege = "@" + Fields.BusinessNotebook.Privilege;
            public const string Recommended = "@" + Fields.BusinessNotebook.Recommended;
        }

        public static class NotebookRescrictions
        {
            public const string NotebookLuid = "@" + Fields.NotebookRescrictions.NotebookLuid;
            public const string NoReadNotes = "@" + Fields.NotebookRescrictions.NoReadNotes;
            public const string NoCreateNotes = "@" + Fields.NotebookRescrictions.NoCreateNotes;
            public const string NoUpdateNotes = "@" + Fields.NotebookRescrictions.NoUpdateNotes;
            public const string NoExpungeNotes = "@" + Fields.NotebookRescrictions.NoExpungeNotes;
            public const string NoShareNotes = "@" + Fields.NotebookRescrictions.NoShareNotes;
            public const string NoEmailNotes = "@" + Fields.NotebookRescrictions.NoEmailNotes;
            public const string NoSendMessageToRecipients = "@" + Fields.NotebookRescrictions.NoSendMessageToRecipients;
            public const string NoUpdateNotebook = "@" + Fields.NotebookRescrictions.NoUpdateNotebook;
            public const string NoExpungeNotebook = "@" + Fields.NotebookRescrictions.NoExpungeNotebook;
            public const string NoSetDefaultNotebook = "@" + Fields.NotebookRescrictions.NoSetDefaultNotebook;
            public const string NoSetNotebookStack = "@" + Fields.NotebookRescrictions.NoSetNotebookStack;
            public const string NoPublishToPublic = "@" + Fields.NotebookRescrictions.NoPublishToPublic;
            public const string NoPublishToBusinessLibrary = "@" + Fields.NotebookRescrictions.NoPublishToBusinessLibrary;
            public const string NoCreateTags = "@" + Fields.NotebookRescrictions.NoCreateTags;
            public const string NoUpdateTags = "@" + Fields.NotebookRescrictions.NoUpdateTags;
            public const string NoExpungeTags = "@" + Fields.NotebookRescrictions.NoExpungeTags;
            public const string NoSetParentTag = "@" + Fields.NotebookRescrictions.NoSetParentTag;
            public const string NoCreateSharedNotebooks = "@" + Fields.NotebookRescrictions.NoCreateSharedNotebooks;
            public const string UpdateWhichSharedNotebookRestrictions = "@" + Fields.NotebookRescrictions.UpdateWhichSharedNotebookRestrictions;
            public const string ExpungeWhichSharedNotebookRestrictions = "@" + Fields.NotebookRescrictions.ExpungeWhichSharedNotebookRestrictions;
        }

        public static class Tags
        {
            public const string Luid = "@" + Fields.Tags.Luid;
            public const string Guid = "@" + Fields.Tags.Guid;
            public const string Name = "@" + Fields.Tags.Name;
            public const string ParentLuid = "@" + Fields.Tags.ParentLuid;
            public const string UpdateSequenceNum = "@" + Fields.Tags.UpdateSequenceNum;
            public const string Dirty = "@" + Fields.Tags.Dirty;
        }

        public static class Notes
        {
            public const string Luid = "@" + Fields.Notes.Luid;
            public const string Guid = "@" + Fields.Notes.Guid;
            public const string Title = "@" + Fields.Notes.Title;
            public const string Content = "@" + Fields.Notes.Content;
            public const string ContentHash = "@" + Fields.Notes.ContentHash;
            public const string ContentLength = "@" + Fields.Notes.ContentLength;
            public const string Created = "@" + Fields.Notes.Created;
            public const string Updated = "@" + Fields.Notes.Updated;
            public const string Deleted = "@" + Fields.Notes.Deleted;
            public const string Active = "@" + Fields.Notes.Active;
            public const string UpdateSequenceNum = "@" + Fields.Notes.UpdateSequenceNum;
            public const string Dirty = "@" + Fields.Notes.Dirty;
            public const string NotebookLuid = "@" + Fields.Notes.NotebookLuid;
        }

        public static class NoteTags
        {
            public const string NoteLuid = "@" + Fields.NoteTags.NoteLuid;
            public const string TagLuid = "@" + Fields.NoteTags.TagLuid;
        }

        public static class NoteResources
        {
            public const string NoteLuid = "@" + Fields.NoteResources.NoteLuid;
            public const string ResourceLuid = "@" + Fields.NoteResources.ResourceLuid;
        }

        public static class NoteAttributes
        {
            public const string NoteLuid = "@" + Fields.NoteAttributes.NoteLuid;
            public const string SubjectDate = "@" + Fields.NoteAttributes.SubjectDate;
            public const string Latitude = "@" + Fields.NoteAttributes.Latitude;
            public const string Longitude = "@" + Fields.NoteAttributes.Longitude;
            public const string Altitude = "@" + Fields.NoteAttributes.Altitude;
            public const string Author = "@" + Fields.NoteAttributes.Author;
            public const string Source = "@" + Fields.NoteAttributes.Source;
            public const string SourceURL = "@" + Fields.NoteAttributes.SourceURL;
            public const string SourceApplication = "@" + Fields.NoteAttributes.SourceApplication;
            public const string ShareDate = "@" + Fields.NoteAttributes.ShareDate;
            public const string ReminderOrder = "@" + Fields.NoteAttributes.ReminderOrder;
            public const string ReminderDoneTime = "@" + Fields.NoteAttributes.ReminderDoneTime;
            public const string ReminderTime = "@" + Fields.NoteAttributes.ReminderTime;
            public const string PlaceName = "@" + Fields.NoteAttributes.PlaceName;
            public const string ContentClass = "@" + Fields.NoteAttributes.ContentClass;
            public const string LastEditedBy = "@" + Fields.NoteAttributes.LastEditedBy;
            public const string CreatorId = "@" + Fields.NoteAttributes.CreatorId;
            public const string LastEditorId = "@" + Fields.NoteAttributes.LastEditorId;
        }

        public static class NoteAttributesClassifications
        {
            public const string NoteLuid = "@" + Fields.NoteAttributesClassifications.NoteLuid;
            public const string ClassificationType = "@" + Fields.NoteAttributesClassifications.ClassificationType;
            public const string Classification = "@" + Fields.NoteAttributesClassifications.Classification;
        }

        public static class Resources
        {
            public const string Luid = "@" + Fields.Resources.Luid;
            public const string Guid = "@" + Fields.Resources.Guid;
            public const string DataLuid = "@" + Fields.Resources.DataLuid;
            public const string Mime = "@" + Fields.Resources.Mime;
            public const string Width = "@" + Fields.Resources.Width;
            public const string Height = "@" + Fields.Resources.Height;
            public const string RecognitionLuid = "@" + Fields.Resources.RecognitionLuid;
            public const string UpdateSequenceNum = "@" + Fields.Resources.UpdateSequenceNum;
            public const string AlternateDataLuid = "@" + Fields.Resources.AlternateDataLuid;
            public const string Dirty = "@" + Fields.Resources.Dirty;
        }

        public static class Data
        {
            public const string Luid = "@" + Fields.Data.Luid;
            public const string BodyHash = "@" + Fields.Data.BodyHash;
            public const string Size = "@" + Fields.Data.Size;
        }

        public static class ResourceAttributes
        {
            public const string ResourceLuid = "@" + Fields.ResourceAttributes.ResourceLuid;
            public const string SourceURL = "@" + Fields.ResourceAttributes.SourceURL;
            public const string Timestamp = "@" + Fields.ResourceAttributes.Timestamp;
            public const string Latitude = "@" + Fields.ResourceAttributes.Latitude;
            public const string Longitude = "@" + Fields.ResourceAttributes.Longitude;
            public const string Altitude = "@" + Fields.ResourceAttributes.Altitude;
            public const string CameraMake = "@" + Fields.ResourceAttributes.CameraMake;
            public const string CameraModel = "@" + Fields.ResourceAttributes.CameraModel;
            public const string ClientWillIndex = "@" + Fields.ResourceAttributes.ClientWillIndex;
            public const string FileName = "@" + Fields.ResourceAttributes.FileName;
            public const string Attachment = "@" + Fields.ResourceAttributes.Attachment;
        }

        public static class SavedSearches
        {
            public const string Luid = "@" + Fields.SavedSearches.Luid;
            public const string Guid = "@" + Fields.SavedSearches.Guid;
            public const string Name = "@" + Fields.SavedSearches.Name;
            public const string Query = "@" + Fields.SavedSearches.Query;
            public const string Format = "@" + Fields.SavedSearches.Format;
            public const string UpdateSequenceNum = "@" + Fields.SavedSearches.UpdateSequenceNum;
            public const string Dirty = "@" + Fields.SavedSearches.Dirty;
        }

        public static class SavedSearchScope
        {
            public const string SavedSearchLuid = "@" + Fields.SavedSearchScope.SavedSearchLuid;
            public const string IncludeAccount = "@" + Fields.SavedSearchScope.IncludeAccount;
            public const string IncludePersonalLinkedNotebooks = "@" + Fields.SavedSearchScope.IncludePersonalLinkedNotebooks;
            public const string IncludeBusinessLinkedNotebooks = "@" + Fields.SavedSearchScope.IncludeBusinessLinkedNotebooks;
        }

        public static class LinkedNotebooks
        {
            public const string Luid = "@" + Fields.LinkedNotebooks.Luid;
            public const string ShareName = "@" + Fields.LinkedNotebooks.ShareName;
            public const string Username = "@" + Fields.LinkedNotebooks.Username;
            public const string ShardId = "@" + Fields.LinkedNotebooks.ShardId;
            public const string ShareKey = "@" + Fields.LinkedNotebooks.ShareKey;
            public const string Uri = "@" + Fields.LinkedNotebooks.Uri;
            public const string Guid = "@" + Fields.LinkedNotebooks.Guid;
            public const string UpdateSequenceNum = "@" + Fields.LinkedNotebooks.UpdateSequenceNum;
            public const string NoteStoreUrl = "@" + Fields.LinkedNotebooks.NoteStoreUrl;
            public const string WebApiUrlPrefix = "@" + Fields.LinkedNotebooks.WebApiUrlPrefix;
            public const string Stack = "@" + Fields.LinkedNotebooks.Stack;
            public const string BusinessId = "@" + Fields.LinkedNotebooks.BusinessId;
        }

        public static class SharedNotebooks
        {
            public const string NotebookLuid = "@" + Fields.SharedNotebooks.NotebookLuid;
            public const string Id = "@" + Fields.SharedNotebooks.Id;
            public const string UserId = "@" + Fields.SharedNotebooks.UserId;
            public const string Email = "@" + Fields.SharedNotebooks.Email;
            public const string NotebookModifiable = "@" + Fields.SharedNotebooks.NotebookModifiable;
            public const string RequireLogin = "@" + Fields.SharedNotebooks.RequireLogin;
            public const string ServiceCreated = "@" + Fields.SharedNotebooks.ServiceCreated;
            public const string ServiceUpdated = "@" + Fields.SharedNotebooks.ServiceUpdated;
            public const string ShareKey = "@" + Fields.SharedNotebooks.ShareKey;
            public const string Username = "@" + Fields.SharedNotebooks.Username;
            public const string Privilege = "@" + Fields.SharedNotebooks.Privilege;
            public const string AllowPreview = "@" + Fields.SharedNotebooks.AllowPreview;
        }

        public static class SharedNotebookRecipientSettings
        {
            public const string SharedNotebookLuid = "@" + Fields.SharedNotebookRecipientSettings.SharedNotebookLuid;
            public const string ReminderNotifyEmail = "@" + Fields.SharedNotebookRecipientSettings.ReminderNotifyEmail;
            public const string ReminderNotifyInApp = "@" + Fields.SharedNotebookRecipientSettings.ReminderNotifyInApp;
        }
    }
}

