using System;
using System.Runtime.CompilerServices;

namespace dame.Data
{
    public static class Fields
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Join(params string[] fields)
        {
            return String.Join(",", fields);
        }

        public static class Sync
        {
            public const string SyncLastUpdateCount = "SyncLastUpdateCount";
            public const string SyncLastSyncTime = "SyncLastSyncTime";
        }

        public static class Users
        {
            public const string Id = "Id";
            public const string Username = "Username";
            public const string Name = "Name";
            public const string Timezone = "Timezone";
            public const string Privilege = "Privilege";
            public const string Created = "Created";
            public const string Updated = "Updated";
            public const string Deleted = "Deleted";
            public const string Active = "Active";
        }

        public static class BootstrapSettings
        {
            public const string UserId = "UserId";
            public const string ServiceHost = "ServiceHost";
            public const string MarketingUrl = "MarketingUrl";
            public const string SupportUrl = "SupportUrl";
            public const string AccountEmailDomain = "AccountEmailDomain";
            public const string EnableFacebookSharing = "EnableFacebookSharing";
            public const string EnableGiftSubscriptions = "EnableGiftSubscriptions";
            public const string EnableSupportTickets = "EnableSupportTickets";
            public const string EnableSharedNotebooks = "EnableSharedNotebooks";
            public const string EnableSingleNoteSharing = "EnableSingleNoteSharing";
            public const string EnableSponsoredAccounts = "EnableSponsoredAccounts";
            public const string EnableTwitterSharing = "EnableTwitterSharing";
            public const string EnableLinkedInSharing = "EnableLinkedInSharing";
            public const string EnablePublicNotebooks = "EnablePublicNotebooks";
        }

        public static class UserAttributes
        {
            public const string UserId = "UserId";
            public const string DefaultLocationName = "DefaultLocationName";
            public const string DefaultLatitude = "DefaultLatitude";
            public const string DefaultLongitude = "DefaultLongitude";
            public const string Preactivation = "Preactivation";
            public const string IncomingEmailAddress = "IncomingEmailAddress";
            public const string Comments = "Comments";
            public const string DateAgreedToTermsOfService = "DateAgreedToTermsOfService";
            public const string MaxReferrals = "MaxReferrals";
            public const string ReferralCount = "ReferralCount";
            public const string RefererCode = "RefererCode";
            public const string SentEmailDate = "SentEmailDate";
            public const string SentEmailCount = "SentEmailCount";
            public const string DailyEmailLimit = "DailyEmailLimit";
            public const string EmailOptOutDate = "EmailOptOutDate";
            public const string PartnerEmailOptInDate = "PartnerEmailOptInDate";
            public const string PreferredLanguage = "PreferredLanguage";
            public const string PreferredCountry = "PreferredCountry";
            public const string ClipFullPage = "ClipFullPage";
            public const string TwitterUserName = "TwitterUserName";
            public const string TwitterId = "TwitterId";
            public const string GroupName = "GroupName";
            public const string RecognitionLanguage = "RecognitionLanguage";
            public const string ReferralProof = "ReferralProof";
            public const string EducationalDiscount = "EducationalDiscount";
            public const string BusinessAddress = "BusinessAddress";
            public const string HideSponsorBilling = "HideSponsorBilling";
            public const string TaxExempt = "TaxExempt";
            public const string UseEmailAutoFiling = "UseEmailAutoFiling";
            public const string ReminderEmailConfig = "ReminderEmailConfig";
        }

        public static class Accounting
        {
            public const string UserId = "UserId";
            public const string UploadLimit = "UploadLimit";
            public const string UploadLimitEnd = "UploadLimitEnd";
            public const string UploadLimitNextMonth = "UploadLimitNextMonth";
            public const string PremiumServiceStatus = "PremiumServiceStatus";
            public const string PremiumOrderNumber = "PremiumOrderNumber";
            public const string PremiumCommerceService = "PremiumCommerceService";
            public const string PremiumServiceStart = "PremiumServiceStart";
            public const string PremiumServiceSKU = "PremiumServiceSKU";
            public const string LastSuccessfulCharge = "LastSuccessfulCharge";
            public const string LastFailedCharge = "LastFailedCharge";
            public const string LastFailedChargeReason = "LastFailedChargeReason";
            public const string NextPaymentDue = "NextPaymentDue";
            public const string PremiumLockUntil = "PremiumLockUntil";
            public const string Updated = "Updated";
            public const string PremiumSubscriptionNumber = "PremiumSubscriptionNumber";
            public const string LastRequestedCharge = "LastRequestedCharge";
            public const string Currency = "Currency";
            public const string UnitPrice = "UnitPrice";
            public const string UnitDiscount = "UnitDiscount";
            public const string NextChargeDate = "NextChargeDate";
        }

        public static class PremiumInfo
        {
            public const string UserId = "UserId";
            public const string CurrentTime = "CurrentTime";
            public const string Premium = "Premium";
            public const string PremiumRecurring = "PremiumRecurring";
            public const string PremiumExpirationDate = "PremiumExpirationDate";
            public const string PremiumExtendable = "PremiumExtendable";
            public const string PremiumPending = "PremiumPending";
            public const string PremiumCancellationPending = "PremiumCancellationPending";
            public const string CanPurchaseUploadAllowance = "CanPurchaseUploadAllowance";
            public const string SponsoredGroupName = "SponsoredGroupName";
            public const string PremiumUpgradable = "PremiumUpgradable";
        }

        public static class BusinessUserInfo
        {
            public const string UserId = "UserId";
            public const string BusinessId = "BusinessId";
            public const string BusinessName = "BusinessName";
            public const string Role = "Role";
            public const string Email = "Email";
        }

        public static class Notebooks
        {
            public const string Luid = "Luid";
            public const string Guid = "Guid";
            public const string Name = "Name";
            public const string UpdateSequenceNum = "UpdateSequenceNum";
            public const string DefaultNotebook = "DefaultNotebook";
            public const string ServiceCreated = "ServiceCreated";
            public const string ServiceUpdated = "ServiceUpdated";
            public const string Published = "Published";
            public const string Stack = "Stack";
            public const string Dirty = "Dirty";
            public const string ContactId = "ContactId";
        }

        public static class Publishing
        {
            public const string NotebookLuid = "NotebookLuid";
            public const string Uri = "Uri";
            public const string NoteSortOrder = "NoteSortOrder";
            public const string Ascending = "Ascending";
            public const string PublicDescription = "PublicDescription";
        }

        public static class BusinessNotebook
        {
            public const string NotebookLuid = "NotebookLuid";
            public const string NotebookDescription = "NotebookDescription";
            public const string Privilege = "Privilege";
            public const string Recommended = "Recommended";
        }

        public static class NotebookRescrictions
        {
            public const string NotebookLuid = "NotebookLuid";
            public const string NoReadNotes = "NoReadNotes";
            public const string NoCreateNotes = "NoCreateNotes";
            public const string NoUpdateNotes = "NoUpdateNotes";
            public const string NoExpungeNotes = "NoExpungeNotes";
            public const string NoShareNotes = "NoShareNotes";
            public const string NoEmailNotes = "NoEmailNotes";
            public const string NoSendMessageToRecipients = "NoSendMessageToRecipients";
            public const string NoUpdateNotebook = "NoUpdateNotebook";
            public const string NoExpungeNotebook = "NoExpungeNotebook";
            public const string NoSetDefaultNotebook = "NoSetDefaultNotebook";
            public const string NoSetNotebookStack = "NoSetNotebookStack";
            public const string NoPublishToPublic = "NoPublishToPublic";
            public const string NoPublishToBusinessLibrary = "NoPublishToBusinessLibrary";
            public const string NoCreateTags = "NoCreateTags";
            public const string NoUpdateTags = "NoUpdateTags";
            public const string NoExpungeTags = "NoExpungeTags";
            public const string NoSetParentTag = "NoSetParentTag";
            public const string NoCreateSharedNotebooks = "NoCreateSharedNotebooks";
            public const string UpdateWhichSharedNotebookRestrictions = "UpdateWhichSharedNotebookRestrictions";
            public const string ExpungeWhichSharedNotebookRestrictions = "ExpungeWhichSharedNotebookRestrictions";
        }

        public static class Tags
        {
            public const string Luid = "Luid";
            public const string Guid = "Guid";
            public const string Name = "Name";
            public const string ParentLuid = "ParentLuid";
            public const string UpdateSequenceNum = "UpdateSequenceNum";
            public const string Dirty = "Dirty";
        }

        public static class Notes
        {
            public const string Luid = "Luid";
            public const string Guid = "Guid";
            public const string Title = "Title";
            public const string Content = "Content";
            public const string ContentHash = "ContentHash";
            public const string ContentLength = "ContentLength";
            public const string Created = "Created";
            public const string Updated = "Updated";
            public const string Deleted = "Deleted";
            public const string Active = "Active";
            public const string UpdateSequenceNum = "UpdateSequenceNum";
            public const string Dirty = "Dirty";
            public const string NotebookLuid = "NotebookLuid";
        }

        public static class NoteTags
        {
            public const string NoteLuid = "NoteLuid";
            public const string TagLuid = "TagLuid";
        }

        public static class NoteResources
        {
            public const string NoteLuid = "NoteLuid";
            public const string ResourceLuid = "ResourceLuid";
        }

        public static class NoteAttributes
        {
            public const string NoteLuid = "NoteLuid";
            public const string SubjectDate = "SubjectDate";
            public const string Latitude = "Latitude";
            public const string Longitude = "Longitude";
            public const string Altitude = "Altitude";
            public const string Author = "Author";
            public const string Source = "Source";
            public const string SourceURL = "SourceURL";
            public const string SourceApplication = "SourceApplication";
            public const string ShareDate = "ShareDate";
            public const string ReminderOrder = "ReminderOrder";
            public const string ReminderDoneTime = "ReminderDoneTime";
            public const string ReminderTime = "ReminderTime";
            public const string PlaceName = "PlaceName";
            public const string ContentClass = "ContentClass";
            public const string LastEditedBy = "LastEditedBy";
            public const string CreatorId = "CreatorId";
            public const string LastEditorId = "LastEditorId";
        }

        public static class NoteAttributesClassifications
        {
            public const string NoteLuid = "NoteLuid";
            public const string ClassificationType = "ClassificationType";
            public const string Classification = "Classification";
        }

        public static class Resources
        {
            public const string Luid = "Luid";
            public const string Guid = "Guid";
            public const string DataLuid = "DataLuid";
            public const string Mime = "Mime";
            public const string Width = "Width";
            public const string Height = "Height";
            public const string RecognitionLuid = "RecognitionLuid";
            public const string UpdateSequenceNum = "UpdateSequenceNum";
            public const string AlternateDataLuid = "AlternateDataLuid";
            public const string Dirty = "Dirty";
        }

        public static class Data
        {
            public const string Luid = "Luid";
            public const string BodyHash = "BodyHash";
            public const string Size = "Size";
        }

        public static class ResourceAttributes
        {
            public const string ResourceLuid = "ResourceLuid";
            public const string SourceURL = "SourceURL";
            public const string Timestamp = "Timestamp";
            public const string Latitude = "Latitude";
            public const string Longitude = "Longitude";
            public const string Altitude = "Altitude";
            public const string CameraMake = "CameraMake";
            public const string CameraModel = "CameraModel";
            public const string ClientWillIndex = "ClientWillIndex";
            public const string FileName = "FileName";
            public const string Attachment = "Attachment";
        }

        public static class SavedSearches
        {
            public const string Luid = "Luid";
            public const string Guid = "Guid";
            public const string Name = "Name";
            public const string Query = "Query";
            public const string Format = "Format";
            public const string UpdateSequenceNum = "UpdateSequenceNum";
            public const string Dirty = "Dirty";
        }

        public static class SavedSearchScope
        {
            public const string SavedSearchLuid = "SavedSearchLuid";
            public const string IncludeAccount = "IncludeAccount";
            public const string IncludePersonalLinkedNotebooks = "IncludePersonalLinkedNotebooks";
            public const string IncludeBusinessLinkedNotebooks = "IncludeBusinessLinkedNotebooks";
        }

        public static class LinkedNotebooks
        {
            public const string Luid = "Luid";
            public const string ShareName = "ShareName";
            public const string Username = "Username";
            public const string ShardId = "ShardId";
            public const string ShareKey = "ShareKey";
            public const string Uri = "Uri";
            public const string Guid = "Guid";
            public const string UpdateSequenceNum = "UpdateSequenceNum";
            public const string NoteStoreUrl = "NoteStoreUrl";
            public const string WebApiUrlPrefix = "WebApiUrlPrefix";
            public const string Stack = "Stack";
            public const string BusinessId = "BusinessId";
        }

        public static class SharedNotebooks
        {
            public const string NotebookLuid = "NotebookLuid";
            public const string Id = "Id";
            public const string UserId = "UserId";
            public const string Email = "Email";
            public const string NotebookModifiable = "NotebookModifiable";
            public const string RequireLogin = "RequireLogin";
            public const string ServiceCreated = "ServiceCreated";
            public const string ServiceUpdated = "ServiceUpdated";
            public const string ShareKey = "ShareKey";
            public const string Username = "Username";
            public const string Privilege = "Privilege";
            public const string AllowPreview = "AllowPreview";
        }

        public static class SharedNotebookRecipientSettings
        {
            public const string SharedNotebookLuid = "SharedNotebookLuid";
            public const string ReminderNotifyEmail = "ReminderNotifyEmail";
            public const string ReminderNotifyInApp = "ReminderNotifyInApp";
        }
    }
}

