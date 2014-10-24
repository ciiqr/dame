using System;
using System.Collections.Generic;

using System.Data;
using Mono.Data.Sqlite;
using SQLCommand = Mono.Data.Sqlite.SqliteCommand;
using SQLDataReader = Mono.Data.Sqlite.SqliteDataReader;

using EDAM = Evernote.EDAM.Type;

using dame.Utilities;
using dame.Utilities.Extensions;

namespace dame.Data
{
    public partial class Database
    {
        public List<long> GetNotebookLuids()
        {
            List<long> notebookLuids = new List<long>();
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT " + Fields.Notebooks.Luid + " FROM " + Tables.Notebooks;

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notebookLuids.Add(reader.TryGetValue<long>(Fields.Notebooks.Luid));
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return notebookLuids;
        }
        public List<long> GetNoteLuids()
        {
            List<long> noteLuids = new List<long>();
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT " + Fields.Notes.Luid + " FROM " + Tables.Notes;

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            noteLuids.Add(reader.TryGetValue<long>(Fields.Notes.Luid));
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return noteLuids;
        }
        public List<long> GetSavedSearchLuids()
        {
            List<long> savedSearchLuids = new List<long>();
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT " + Fields.SavedSearches.Luid + " FROM " + Tables.SavedSearches;

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            savedSearchLuids.Add(reader.TryGetValue<long>(Fields.SavedSearches.Luid));
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return savedSearchLuids;
        }
        public List<long> GetLinkedNotebookLuids()
        {
            List<long> linkedNotebookLuids = new List<long>();
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT " + Fields.LinkedNotebooks.Luid + " FROM " + Tables.LinkedNotebooks;

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            linkedNotebookLuids.Add(reader.TryGetValue<long>(Fields.LinkedNotebooks.Luid));
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return linkedNotebookLuids;
        }
        public int GetLastSyncTime()
        {
            int lastSyncTime = -1;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT " + Fields.Sync.LastSyncTime + " FROM " + Tables.Sync;

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastSyncTime = (int)reader.TryGetValue<long>(Fields.Sync.LastSyncTime);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return lastSyncTime;
        }
        public int GetLastUpdateCount()
        {
            int lastUpdateCount = -1;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT " + Fields.Sync.LastUpdateCount + " FROM " + Tables.Sync;

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastUpdateCount = (int)reader.TryGetValue<long>(Fields.Sync.LastUpdateCount);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return lastUpdateCount;
        }
        public void DeleteUser(int id)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "DELETE FROM " + Tables.Users + " WHERE " + Fields.Users.Id + "=" + FieldParams.Users.Id;


                comm.Parameters.AddWithValue(FieldParams.Users.Id, id);

                try
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void DeleteNotebook(long luid)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "DELETE FROM " + Tables.Notebooks + " WHERE " + Fields.Notebooks.Luid + "=" + FieldParams.Notebooks.Luid;


                comm.Parameters.AddWithValue(FieldParams.Notebooks.Luid, luid);

                try
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void DeleteTag(long luid)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "DELETE FROM " + Tables.Tags + " WHERE " + Fields.Tags.Luid + "=" + FieldParams.Tags.Luid;


                comm.Parameters.AddWithValue(FieldParams.Tags.Luid, luid);

                try
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void DeleteNote(long luid)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "DELETE FROM " + Tables.Notes + " WHERE " + Fields.Notes.Luid + "=" + FieldParams.Notes.Luid;


                comm.Parameters.AddWithValue(FieldParams.Notes.Luid, luid);

                try
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void DeleteSavedSearch(long luid)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "DELETE FROM " + Tables.SavedSearches + " WHERE " + Fields.SavedSearches.Luid + "=" + FieldParams.SavedSearches.Luid;


                comm.Parameters.AddWithValue(FieldParams.SavedSearches.Luid, luid);

                try
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void DeleteLinkedNotebook(long luid)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "DELETE FROM " + Tables.LinkedNotebooks + " WHERE " + Fields.LinkedNotebooks.Luid + "=" + FieldParams.LinkedNotebooks.Luid;


                comm.Parameters.AddWithValue(FieldParams.LinkedNotebooks.Luid, luid);

                try
                {
                    int affectedRowCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public Note GetNote(long luid)
        {
            Note note = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Notes + " WHERE " + Fields.Notes.Luid + "=" + FieldParams.Notes.Luid;
                    command.Parameters.AddWithValue(FieldParams.Notes.Luid, luid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new Note();
                            temp.Luid = reader.TryGetValue<long>(Fields.Notes.Luid);
                            temp.Guid = reader.TryGetValue<string>(Fields.Notes.Guid);
                            temp.Title = reader.TryGetValue<string>(Fields.Notes.Title);
                            temp.Content = reader.TryGetValue<string>(Fields.Notes.Content);
                            temp.ContentHash = reader.TryGetValue<byte[]>(Fields.Notes.ContentHash);
                            temp.ContentLength = reader.TryGetValue<int>(Fields.Notes.ContentLength);
                            temp.Created = reader.TryGetValue<long>(Fields.Notes.Created);
                            temp.Updated = reader.TryGetValue<long>(Fields.Notes.Updated);
                            temp.Deleted = reader.TryGetValue<long>(Fields.Notes.Deleted);
                            temp.Active = reader.TryGetValue<bool>(Fields.Notes.Active);
                            temp.UpdateSequenceNum = reader.TryGetValue<int>(Fields.Notes.UpdateSequenceNum);
                            temp.Dirty = reader.TryGetValue<bool>(Fields.Notes.Dirty);
                            temp.NotebookLuid = reader.TryGetValue<long>(Fields.Notes.NotebookLuid);
                            temp.Attributes = GetNoteAttributes(luid);
                            temp.Resources = GetNoteResources(luid);
                            temp.TagNames = GetNoteTags(luid);
                            note = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return note;
        }
        public NoteAttributes GetNoteAttributes(long noteLuid)
        {
            NoteAttributes attributes = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.NoteAttributes + " WHERE " + Fields.NoteAttributes.NoteLuid + "=" + FieldParams.NoteAttributes.NoteLuid;
                    command.Parameters.AddWithValue(FieldParams.NoteAttributes.NoteLuid, noteLuid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new NoteAttributes();
                            temp.SubjectDate = reader.TryGetValue<long>(Fields.NoteAttributes.SubjectDate);
                            temp.Latitude = reader.TryGetValue<double>(Fields.NoteAttributes.Latitude);
                            temp.Longitude = reader.TryGetValue<double>(Fields.NoteAttributes.Longitude);
                            temp.Altitude = reader.TryGetValue<double>(Fields.NoteAttributes.Altitude);
                            temp.Author = reader.TryGetValue<string>(Fields.NoteAttributes.Author);
                            temp.Source = reader.TryGetValue<string>(Fields.NoteAttributes.Source);
                            temp.SourceURL = reader.TryGetValue<string>(Fields.NoteAttributes.SourceURL);
                            temp.SourceApplication = reader.TryGetValue<string>(Fields.NoteAttributes.SourceApplication);
                            temp.ShareDate = reader.TryGetValue<long>(Fields.NoteAttributes.ShareDate);
                            temp.ReminderOrder = reader.TryGetValue<long>(Fields.NoteAttributes.ReminderOrder);
                            temp.ReminderDoneTime = reader.TryGetValue<long>(Fields.NoteAttributes.ReminderDoneTime);
                            temp.ReminderTime = reader.TryGetValue<long>(Fields.NoteAttributes.ReminderTime);
                            temp.PlaceName = reader.TryGetValue<string>(Fields.NoteAttributes.PlaceName);
                            temp.ContentClass = reader.TryGetValue<string>(Fields.NoteAttributes.ContentClass);
                            temp.LastEditedBy = reader.TryGetValue<string>(Fields.NoteAttributes.LastEditedBy);
                            temp.CreatorId = reader.TryGetValue<int>(Fields.NoteAttributes.CreatorId);
                            temp.LastEditorId = reader.TryGetValue<int>(Fields.NoteAttributes.LastEditorId);
                            temp.Classifications = GetNoteAttributesClassifications(noteLuid);
                            attributes = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return attributes;
        }
        public SavedSearch GetSavedSearch(long luid)
        {
            SavedSearch savedSearch = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.SavedSearches + " WHERE " + Fields.SavedSearches.Luid + "=" + FieldParams.SavedSearches.Luid;
                    command.Parameters.AddWithValue(FieldParams.SavedSearches.Luid, luid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new SavedSearch();
                            temp.Luid = reader.TryGetValue<long>(Fields.SavedSearches.Luid);
                            temp.Guid = reader.TryGetValue<string>(Fields.SavedSearches.Guid);
                            temp.Name = reader.TryGetValue<string>(Fields.SavedSearches.Name);
                            temp.Query = reader.TryGetValue<string>(Fields.SavedSearches.Query);
                            temp.Format = reader.TryGetValue<EDAM.QueryFormat>(Fields.SavedSearches.Format);
                            temp.UpdateSequenceNum = reader.TryGetValue<int>(Fields.SavedSearches.UpdateSequenceNum);
                            temp.Dirty = reader.TryGetValue<bool>(Fields.SavedSearches.Dirty);
                            temp.Scope = GetSavedSearchScope(luid);
                            savedSearch = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return savedSearch;
        }
        public LinkedNotebook GetLinkedNotebook(long luid)
        {
            LinkedNotebook linkedNotebooks = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.LinkedNotebooks + " WHERE " + Fields.LinkedNotebooks.Luid + "=" + FieldParams.LinkedNotebooks.Luid;
                    command.Parameters.AddWithValue(FieldParams.LinkedNotebooks.Luid, luid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new LinkedNotebook();
                            temp.Luid = reader.TryGetValue<long>(Fields.LinkedNotebooks.Luid);
                            temp.ShareName = reader.TryGetValue<string>(Fields.LinkedNotebooks.ShareName);
                            temp.Username = reader.TryGetValue<string>(Fields.LinkedNotebooks.Username);
                            temp.ShardId = reader.TryGetValue<string>(Fields.LinkedNotebooks.ShardId);
                            temp.ShareKey = reader.TryGetValue<string>(Fields.LinkedNotebooks.ShareKey);
                            temp.Uri = reader.TryGetValue<string>(Fields.LinkedNotebooks.Uri);
                            temp.Guid = reader.TryGetValue<string>(Fields.LinkedNotebooks.Guid);
                            temp.UpdateSequenceNum = reader.TryGetValue<int>(Fields.LinkedNotebooks.UpdateSequenceNum);
                            temp.NoteStoreUrl = reader.TryGetValue<string>(Fields.LinkedNotebooks.NoteStoreUrl);
                            temp.WebApiUrlPrefix = reader.TryGetValue<string>(Fields.LinkedNotebooks.WebApiUrlPrefix);
                            temp.Stack = reader.TryGetValue<string>(Fields.LinkedNotebooks.Stack);
                            temp.BusinessId = reader.TryGetValue<int>(Fields.LinkedNotebooks.BusinessId);
                            linkedNotebooks = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return linkedNotebooks;
        }
        public User GetUser(long id)
        {
            User user = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Users + " WHERE " + Fields.Users.Id + "=" + FieldParams.Users.Id;
                    command.Parameters.AddWithValue(FieldParams.Users.Id, id);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new User();
                            temp.Id = reader.TryGetValue<int>(Fields.Users.Id);
                            temp.Username = reader.TryGetValue<string>(Fields.Users.Username);
                            temp.Name = reader.TryGetValue<string>(Fields.Users.Name);
                            temp.Timezone = reader.TryGetValue<string>(Fields.Users.Timezone);
                            temp.Privilege = reader.TryGetValue<EDAM.PrivilegeLevel>(Fields.Users.Privilege);
                            temp.Created = reader.TryGetValue<long>(Fields.Users.Created);
                            temp.Updated = reader.TryGetValue<long>(Fields.Users.Updated);
                            temp.Deleted = reader.TryGetValue<long>(Fields.Users.Deleted);
                            temp.Active = reader.TryGetValue<bool>(Fields.Users.Active);
                            temp.Attributes = GetUserAttributes(id);
                            temp.Accounting = GetAccounting(id);
                            temp.PremiumInfo = GetPremiumInfo(id);
                            temp.BusinessUserInfo = GetBusinessUserInfo(id);
                            user = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return user;
        }
        public Accounting GetAccounting(long userId)
        {
            Accounting accounting = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Accounting + " WHERE " + Fields.Accounting.UserId + "=" + FieldParams.Accounting.UserId;
                    command.Parameters.AddWithValue(FieldParams.Accounting.UserId, userId);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new Accounting();
                            temp.UploadLimit = reader.TryGetValue<long>(Fields.Accounting.UploadLimit);
                            temp.UploadLimitEnd = reader.TryGetValue<long>(Fields.Accounting.UploadLimitEnd);
                            temp.UploadLimitNextMonth = reader.TryGetValue<long>(Fields.Accounting.UploadLimitNextMonth);
                            temp.PremiumServiceStatus = reader.TryGetValue<EDAM.PremiumOrderStatus>(Fields.Accounting.PremiumServiceStatus);
                            temp.PremiumOrderNumber = reader.TryGetValue<string>(Fields.Accounting.PremiumOrderNumber);
                            temp.PremiumCommerceService = reader.TryGetValue<string>(Fields.Accounting.PremiumCommerceService);
                            temp.PremiumServiceStart = reader.TryGetValue<long>(Fields.Accounting.PremiumServiceStart);
                            temp.PremiumServiceSKU = reader.TryGetValue<string>(Fields.Accounting.PremiumServiceSKU);
                            temp.LastSuccessfulCharge = reader.TryGetValue<long>(Fields.Accounting.LastSuccessfulCharge);
                            temp.LastFailedCharge = reader.TryGetValue<long>(Fields.Accounting.LastFailedCharge);
                            temp.LastFailedChargeReason = reader.TryGetValue<string>(Fields.Accounting.LastFailedChargeReason);
                            temp.NextPaymentDue = reader.TryGetValue<long>(Fields.Accounting.NextPaymentDue);
                            temp.PremiumLockUntil = reader.TryGetValue<long>(Fields.Accounting.PremiumLockUntil);
                            temp.Updated = reader.TryGetValue<long>(Fields.Accounting.Updated);
                            temp.PremiumSubscriptionNumber = reader.TryGetValue<string>(Fields.Accounting.PremiumSubscriptionNumber);
                            temp.LastRequestedCharge = reader.TryGetValue<long>(Fields.Accounting.LastRequestedCharge);
                            temp.Currency = reader.TryGetValue<string>(Fields.Accounting.Currency);
                            temp.UnitPrice = reader.TryGetValue<int>(Fields.Accounting.UnitPrice);
                            temp.UnitDiscount = reader.TryGetValue<int>(Fields.Accounting.UnitDiscount);
                            temp.NextChargeDate = reader.TryGetValue<long>(Fields.Accounting.NextChargeDate);
                            accounting = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return accounting;
        }
        public EDAM.PremiumInfo GetPremiumInfo(long userId)
        {
            EDAM.PremiumInfo premiumInfo = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.PremiumInfo + " WHERE " + Fields.PremiumInfo.UserId + "=" + FieldParams.PremiumInfo.UserId;
                    command.Parameters.AddWithValue(FieldParams.PremiumInfo.UserId, userId);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new EDAM.PremiumInfo();
                            temp.CurrentTime = reader.TryGetValue<long>(Fields.PremiumInfo.CurrentTime);
                            temp.Premium = reader.TryGetValue<bool>(Fields.PremiumInfo.Premium);
                            temp.PremiumRecurring = reader.TryGetValue<bool>(Fields.PremiumInfo.PremiumRecurring);
                            temp.PremiumExpirationDate = reader.TryGetValue<long>(Fields.PremiumInfo.PremiumExpirationDate);
                            temp.PremiumExtendable = reader.TryGetValue<bool>(Fields.PremiumInfo.PremiumExtendable);
                            temp.PremiumPending = reader.TryGetValue<bool>(Fields.PremiumInfo.PremiumPending);
                            temp.PremiumCancellationPending = reader.TryGetValue<bool>(Fields.PremiumInfo.PremiumCancellationPending);
                            temp.CanPurchaseUploadAllowance = reader.TryGetValue<bool>(Fields.PremiumInfo.CanPurchaseUploadAllowance);
                            temp.SponsoredGroupName = reader.TryGetValue<string>(Fields.PremiumInfo.SponsoredGroupName);
                            temp.PremiumUpgradable = reader.TryGetValue<bool>(Fields.PremiumInfo.PremiumUpgradable);
                            premiumInfo = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return premiumInfo;
        }
        public EDAM.BusinessUserInfo GetBusinessUserInfo(long userId)
        {
            EDAM.BusinessUserInfo businessUserInfo = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.BusinessUserInfo + " WHERE " + Fields.BusinessUserInfo.UserId + "=" + FieldParams.BusinessUserInfo.UserId;
                    command.Parameters.AddWithValue(FieldParams.BusinessUserInfo.UserId, userId);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new EDAM.BusinessUserInfo();
                            temp.BusinessId = reader.TryGetValue<int>(Fields.BusinessUserInfo.BusinessId);
                            temp.BusinessName = reader.TryGetValue<string>(Fields.BusinessUserInfo.BusinessName);
                            temp.Role = reader.TryGetValue<EDAM.BusinessUserRole>(Fields.BusinessUserInfo.Role);
                            temp.Email = reader.TryGetValue<string>(Fields.BusinessUserInfo.Email);
                            businessUserInfo = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return businessUserInfo;
        }
        public Notebook GetNotebook(long luid)
        {
            Notebook notebook = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Notebooks + " WHERE " + Fields.Notebooks.Luid + "=" + FieldParams.Notebooks.Luid;
                    command.Parameters.AddWithValue(FieldParams.Notebooks.Luid, luid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new Notebook();
                            temp.Luid = reader.TryGetValue<long>(Fields.Notebooks.Luid);
                            temp.Guid = reader.TryGetValue<string>(Fields.Notebooks.Guid);
                            temp.Name = reader.TryGetValue<string>(Fields.Notebooks.Name);
                            temp.UpdateSequenceNum = reader.TryGetValue<int>(Fields.Notebooks.UpdateSequenceNum);
                            temp.DefaultNotebook = reader.TryGetValue<bool>(Fields.Notebooks.DefaultNotebook);
                            temp.ServiceCreated = reader.TryGetValue<long>(Fields.Notebooks.ServiceCreated);
                            temp.ServiceUpdated = reader.TryGetValue<long>(Fields.Notebooks.ServiceUpdated);
                            temp.Published = reader.TryGetValue<bool>(Fields.Notebooks.Published);
                            temp.Stack = reader.TryGetValue<string>(Fields.Notebooks.Stack);
                            temp.Dirty = reader.TryGetValue<bool>(Fields.Notebooks.Dirty);
                            temp.BusinessNotebook = GetBusinessNotebook(luid);
                            temp.Contact = GetUser(luid);
                            temp.Publishing = GetPublishing(luid);
                            temp.Restrictions = GetNotebookRestrictions(luid);
                            temp.SharedNotebooks = GetSharedNotebooks(luid);
                            notebook = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return notebook;
        }
        public EDAM.Publishing GetPublishing(long notebookLuid)
        {
            EDAM.Publishing publishing = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Publishing + " WHERE " + Fields.Publishing.NotebookLuid + "=" + FieldParams.Publishing.NotebookLuid;
                    command.Parameters.AddWithValue(FieldParams.Publishing.NotebookLuid, notebookLuid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new EDAM.Publishing();
                            temp.Uri = reader.TryGetValue<string>(Fields.Publishing.Uri);
                            temp.Order = reader.TryGetValue<EDAM.NoteSortOrder>(Fields.Publishing.NoteSortOrder);
                            temp.Ascending = reader.TryGetValue<bool>(Fields.Publishing.Ascending);
                            temp.PublicDescription = reader.TryGetValue<string>(Fields.Publishing.PublicDescription);
                            publishing = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return publishing;
        }
        public BusinessNotebook GetBusinessNotebook(long notebookLuid)
        {
            BusinessNotebook businessNotebook = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.BusinessNotebook + " WHERE " + Fields.BusinessNotebook.NotebookLuid + "=" + FieldParams.BusinessNotebook.NotebookLuid;
                    command.Parameters.AddWithValue(FieldParams.BusinessNotebook.NotebookLuid, notebookLuid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new BusinessNotebook();
                            temp.NotebookDescription = reader.TryGetValue<string>(Fields.BusinessNotebook.NotebookDescription);
                            temp.Privilege = reader.TryGetValue<EDAM.SharedNotebookPrivilegeLevel>(Fields.BusinessNotebook.Privilege);
                            temp.Recommended = reader.TryGetValue<bool>(Fields.BusinessNotebook.Recommended);
                            businessNotebook = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return businessNotebook;
        }
        public EDAM.NotebookRestrictions GetNotebookRestrictions(long notebookLuid)
        {
            EDAM.NotebookRestrictions restrictions = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.NotebookRestrictions + " WHERE " + Fields.NotebookRestrictions.NotebookLuid + "=" + FieldParams.NotebookRestrictions.NotebookLuid;
                    command.Parameters.AddWithValue(FieldParams.NotebookRestrictions.NotebookLuid, notebookLuid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new EDAM.NotebookRestrictions();
                            temp.NoReadNotes = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoReadNotes);
                            temp.NoCreateNotes = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoCreateNotes);
                            temp.NoUpdateNotes = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoUpdateNotes);
                            temp.NoExpungeNotes = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoExpungeNotes);
                            temp.NoShareNotes = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoShareNotes);
                            temp.NoEmailNotes = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoEmailNotes);
                            temp.NoSendMessageToRecipients = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoSendMessageToRecipients);
                            temp.NoUpdateNotebook = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoUpdateNotebook);
                            temp.NoExpungeNotebook = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoExpungeNotebook);
                            temp.NoSetDefaultNotebook = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoSetDefaultNotebook);
                            temp.NoSetNotebookStack = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoSetNotebookStack);
                            temp.NoPublishToPublic = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoPublishToPublic);
                            temp.NoPublishToBusinessLibrary = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoPublishToBusinessLibrary);
                            temp.NoCreateTags = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoCreateTags);
                            temp.NoUpdateTags = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoUpdateTags);
                            temp.NoExpungeTags = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoExpungeTags);
                            temp.NoSetParentTag = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoSetParentTag);
                            temp.NoCreateSharedNotebooks = reader.TryGetValue<bool>(Fields.NotebookRestrictions.NoCreateSharedNotebooks);
                            temp.UpdateWhichSharedNotebookRestrictions = reader.TryGetValue<EDAM.SharedNotebookInstanceRestrictions>(Fields.NotebookRestrictions.UpdateWhichSharedNotebookRestrictions);
                            temp.ExpungeWhichSharedNotebookRestrictions = reader.TryGetValue<EDAM.SharedNotebookInstanceRestrictions>(Fields.NotebookRestrictions.ExpungeWhichSharedNotebookRestrictions);
                            restrictions = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return restrictions;
        }
        public Tag GetTag(long luid)
        {
            Tag tag = null;
            PerformOperation((conn, command) =>
            {
                try
                {
                    command.CommandText = "SELECT * FROM " + Tables.Tags + " WHERE " + Fields.Tags.Luid + "=" + FieldParams.Tags.Luid;
                    command.Parameters.AddWithValue(FieldParams.Tags.Luid, luid);

                    using (SQLDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var temp = new Tag();
                            temp.Luid = reader.TryGetValue<long>(Fields.Tags.Luid);
                            temp.Guid = reader.TryGetValue<string>(Fields.Tags.Guid);
                            temp.Name = reader.TryGetValue<string>(Fields.Tags.Name);
                            temp.ParentLuid = reader.TryGetValue<long>(Fields.Tags.ParentLuid);
                            temp.UpdateSequenceNum = reader.TryGetValue<int>(Fields.Tags.UpdateSequenceNum);
                            temp.Dirty = reader.TryGetValue<bool>(Fields.Tags.Dirty);
                            tag = temp;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine('\n');
                    Console.WriteLine(ex);
                }
            });
            return tag;
        }
        public void AddNote(EDAM.Note note)
        {
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "INSERT INTO " + Tables.Notes + "(" + Fields.Join(
                    Fields.Notes.Guid
                ) + ") VALUES(" + FieldParams.Join(
                    FieldParams.Notes.Guid
                ) + ")";

                comm.Parameters.AddWithValue(FieldParams.Notes.Guid, note.Guid);
                int affectedRowCount = command.ExecuteNonQuery();
            });
        }
        public bool UpdateNote(Note note)
        {
            bool success = false;
            PerformOperation((conn, command) =>
            {
                var comm = (SQLCommand)command;

                command.CommandText = "UPDATE " + Tables.Notes + " SET " + Fields.Join(
                    Fields.Notes.Guid+"="+FieldParams.Notes.Guid
                ) + ") WHERE " + Fields.Notes.Luid + "=" + FieldParams.Notes.Luid;

                comm.Parameters.AddWithValue(FieldParams.Notes.Guid, note.Guid);
                comm.Parameters.AddWithValue(FieldParams.Notes.Luid, note.Luid);

                command.ExecuteNonQuery();
                success = true;
            });
            return success;
        }

    }
}

