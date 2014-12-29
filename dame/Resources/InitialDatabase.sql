-- Create the tables for Dame client database --
------------------------------------------------
-- Created By: William Villeneuve
-- Created: June 18, 2014
-- Modified: June 19, 2014
---------------------------------------------

-- Essentially These are the Types --
-------------------------------------
-- INT
-- TEXT
-- BLOB
-- DATE
-- DATETIME
-- BOOLEAN
-- REAL
-------------------------------------

-- NOTES --
-----------
-- Testing This File: sqlite3 test.db < DefaultDatabase.sql
-- x Resources, when a Resource is dirty, that means it's new, if it changes in any way, we create a new resource (really just delete it's guid, send the deleted update & addNewNote with all the resources set)
	-- x NOTE: Doing it this way because evernote only supports updating the meta-data anyways, I can always change this in the future so that the meta-data can be updated without creating a whole new resource
	-- !! Not Necessary, simply chekc the resources updateSequenceNum, dirty can still mean a change in the meta-data,!!

-- TODO --
----------
-- Add Constraints (UNIQUE, NULL, NOT NULL, etc.)
-- ? Dirty? Users, SharedNotebooks
-- Add NOT NULL to all necessary fields
-- Consider moving SavedSearchScope fields to SavedSearch
-- Consider moving SharedNotebookRecipientSettings fields to SharedNotebook
-- Data.body - Store in a resources subfolder ie. ~/.cache/dame/{username}/data/{Data.uid}

-- DOCUMENTATION --
-------------------
-- userID PK in the below tables and contactId in the Notebooks table are references the id in the Users table

-- DAME --
CREATE TABLE Sync (
	lastUpdateCount	INT,
	lastSyncTime	INT
);

INSERT INTO Sync (lastUpdateCount,lastSyncTime) VALUES(0, 0);

-- USER --

CREATE TABLE Users (
	id			INTEGER		PRIMARY KEY		NOT NULL,
	username	TEXT		NOT NULL,
	name		TEXT,
	timezone	TEXT,
	privilege	INT,
	created		INT,
	updated		INT,
	deleted		INT,
	active		BOOLEAN
);

CREATE TABLE BootstrapSettings (
	userId					INTEGER		PRIMARY KEY		NOT NULL,
	serviceHost				TEXT,
	marketingUrl			TEXT,
	supportUrl				TEXT,
	accountEmailDomain		TEXT,
	enableFacebookSharing	BOOLEAN,
	enableGiftSubscriptions	BOOLEAN,
	enableSupportTickets	BOOLEAN,
	enableSharedNotebooks	BOOLEAN,
	enableSingleNoteSharing	BOOLEAN,
	enableSponsoredAccounts	BOOLEAN,
	enableTwitterSharing	BOOLEAN,
	enableLinkedInSharing	BOOLEAN,
	enablePublicNotebooks	BOOLEAN,
	FOREIGN KEY(userId)		REFERENCES Users(id)
);

CREATE TABLE UserAttributes (
	userId						INTEGER		PRIMARY KEY		NOT NULL,
	defaultLocationName			TEXT,
	defaultLatitude				REAL,
	defaultLongitude			REAL,
	preactivation				BOOLEAN,
	incomingEmailAddress		TEXT,
	-- recentMailedAddresses		TODO: DO I WANT THIS? List Needs Joining Table (links userID to text) (UserAttributesRecentMailedAddresses)
	comments					TEXT,
	dateAgreedToTermsOfService	INT,
	maxReferrals				INT,
	referralCount				INT,
	refererCode					TEXT,
	sentEmailDate				INT,
	sentEmailCount				INT,
	dailyEmailLimit				INT,
	emailOptOutDate				INT,
	partnerEmailOptInDate		INT,
	preferredLanguage			TEXT,
	preferredCountry			TEXT,
	clipFullPage				BOOLEAN,
	twitterUserName				TEXT,
	twitterId					TEXT,
	groupName					TEXT,
	recognitionLanguage			TEXT,
	referralProof				TEXT,
	educationalDiscount			BOOLEAN,
	businessAddress				TEXT,
	hideSponsorBilling			BOOLEAN,
	taxExempt					BOOLEAN,
	useEmailAutoFiling			BOOLEAN,
	reminderEmailConfig			INT,
	FOREIGN KEY(userId)		REFERENCES Users(id)
);

CREATE TABLE Accounting (
	userId						INTEGER		PRIMARY KEY		NOT NULL,
	uploadLimit					INT,
	uploadLimitEnd				INT,
	uploadLimitNextMonth		INT,
	premiumServiceStatus		INT,
	premiumOrderNumber			TEXT,
	premiumCommerceService		TEXT,
	premiumServiceStart			INT,
	premiumServiceSKU			TEXT,
	lastSuccessfulCharge		INT,
	lastFailedCharge			INT,
	lastFailedChargeReason		TEXT,
	nextPaymentDue				INT,
	premiumLockUntil			INT,
	updated						INT,
	premiumSubscriptionNumber	TEXT,
	lastRequestedCharge			INT,
	currency					TEXT,
	unitPrice					INT,
	unitDiscount				INT,
	nextChargeDate				INT,
	FOREIGN KEY(userId)		REFERENCES Users(id)
);

CREATE TABLE PremiumInfo (
	userId						INTEGER		PRIMARY KEY		NOT NULL,
	currentTime					INT,
	premium						BOOLEAN,
	premiumRecurring			BOOLEAN,
	premiumExpirationDate		INT,
	premiumExtendable			BOOLEAN,
	premiumPending				BOOLEAN,
	premiumCancellationPending	BOOLEAN,
	canPurchaseUploadAllowance	BOOLEAN,
	sponsoredGroupName			TEXT,
	premiumUpgradable			BOOLEAN,
	FOREIGN KEY(userId)		REFERENCES Users(id)
);

CREATE TABLE BusinessUserInfo (
	userId			INTEGER		PRIMARY KEY		NOT NULL,
	businessId		INT,
	businessName	TEXT,
	role			INT,
	email			TEXT,
	FOREIGN KEY(userId)		REFERENCES Users(id)
);

-- Data --

CREATE TABLE Notebooks (
	luid				INTEGER		PRIMARY KEY		NOT NULL,
	guid				TEXT		UNIQUE,
	name				TEXT,
	updateSequenceNum	INT,
	defaultNotebook		BOOLEAN,
	serviceCreated		INT,
	serviceUpdated		INT,
	published			BOOLEAN,
	stack				TEXT,
	dirty				BOOLEAN,
	contactId			INTEGER,
	FOREIGN KEY(contactId)	REFERENCES Users(id)
);

CREATE TABLE Publishing (
	notebookLuid		INTEGER		PRIMARY KEY		NOT NULL,
	uri					TEXT,
	noteSortOrder		INT,
	ascending			BOOLEAN,
	publicDescription	TEXT,
	FOREIGN KEY(notebookLuid)		REFERENCES Notebooks(luid)
);

CREATE TABLE BusinessNotebook (
	notebookLuid		INTEGER		PRIMARY KEY		NOT NULL,
	notebookDescription	TEXT,
	privilege			INT,
	recommended			BOOLEAN,
	FOREIGN KEY(notebookLuid)		REFERENCES Notebooks(luid)
);

CREATE TABLE NotebookRestrictions (
	notebookLuid							INTEGER		PRIMARY KEY		NOT NULL,
	noReadNotes								BOOLEAN,
	noCreateNotes							BOOLEAN,
	noUpdateNotes							BOOLEAN,
	noExpungeNotes							BOOLEAN,
	noShareNotes							BOOLEAN,
	noEmailNotes							BOOLEAN,
	noSendMessageToRecipients				BOOLEAN,
	noUpdateNotebook						BOOLEAN,
	noExpungeNotebook						BOOLEAN,
	noSetDefaultNotebook					BOOLEAN,
	noSetNotebookStack						BOOLEAN,
	noPublishToPublic						BOOLEAN,
	noPublishToBusinessLibrary				BOOLEAN,
	noCreateTags							BOOLEAN,
	noUpdateTags							BOOLEAN,
	noExpungeTags							BOOLEAN,
	noSetParentTag							BOOLEAN,
	noCreateSharedNotebooks					BOOLEAN,
	updateWhichSharedNotebookRestrictions	INT,
	expungeWhichSharedNotebookRestrictions	INT,
	FOREIGN KEY(notebookLuid)		REFERENCES Notebooks(luid)
);

CREATE TABLE Tags (
	luid				INTEGER		PRIMARY KEY		NOT NULL,
	guid				TEXT		UNIQUE,
	name				TEXT,
	parentLuid			INTEGER,
	updateSequenceNum	INT,
	dirty				BOOLEAN,
	FOREIGN KEY(parentLuid)			REFERENCES Tags(luid)
);

CREATE TABLE Notes (
	luid				INTEGER		PRIMARY KEY		NOT NULL,
	guid				TEXT		UNIQUE,
	title				TEXT,
	content				TEXT,
	contentHash			TEXT,
	contentLength		INT,
	created				INT,
	updated				INT,
	deleted				INT,
	active				BOOLEAN,
	updateSequenceNum	INT,
	dirty				BOOLEAN,
	notebookLuid		INTEGER		NOT NULL,
	FOREIGN KEY(notebookLuid)		REFERENCES Notebooks(luid)
);

CREATE TABLE NoteTags (
	noteLuid	INTEGER	NOT NULL,
	tagLuid		INTEGER	NOT NULL,
	PRIMARY KEY (noteLuid, tagLuid),
	FOREIGN KEY(noteLuid)	REFERENCES Notes(luid),
	FOREIGN KEY(tagLuid)	REFERENCES Tags(luid)
);

CREATE TABLE NoteResources (
	noteLuid		INTEGER	NOT NULL,
	resourceLuid	INTEGER	NOT NULL,
	PRIMARY KEY (noteLuid, resourceLuid),
	FOREIGN KEY(noteLuid)	REFERENCES Notes(luid),
	FOREIGN KEY(resourceLuid)	REFERENCES Resources(luid)
);

CREATE TABLE NoteAttributes (
	noteLuid			INTEGER		PRIMARY KEY		NOT NULL,
	subjectDate			INT,
	latitude			REAL,
	longitude			REAL,
	altitude			REAL,
	author				TEXT,
	source				TEXT,
	sourceURL			TEXT,
	sourceApplication	TEXT,
	shareDate			INT,
	reminderOrder		INT,
	reminderDoneTime	INT,
	reminderTime		INT,
	placeName			TEXT,
	contentClass		TEXT,
	lastEditedBy		TEXT,
	creatorId			INT,
	lastEditorId		INT,
	FOREIGN KEY(noteLuid)	REFERENCES Notes(luid)
);

CREATE TABLE NoteAttributesClassifications (
	noteLuid			INTEGER	NOT NULL,
	classificationType	TEXT	NOT NULL,	-- ie. "recipe"
	classification		TEXT	NOT NULL,	-- ie. "001" for a "user recipe"
	PRIMARY KEY (noteLuid, classificationType),
	FOREIGN KEY(noteLuid)	REFERENCES NoteAttributes(noteLuid)
);

CREATE TABLE Resources (
	luid				INTEGER		PRIMARY KEY		NOT NULL,
	guid				TEXT		UNIQUE,
	dataLuid			INTEGER,
	mime				TEXT,
	width				INT,
	height				INT,
	recognitionLuid		INTEGER,
	updateSequenceNum	INT,
	alternateDataLuid	INTEGER,
	dirty				BOOLEAN,
	FOREIGN KEY(dataLuid)	REFERENCES Data(luid),
	FOREIGN KEY(recognitionLuid)	REFERENCES Data(luid),
	FOREIGN KEY(alternateDataLuid)	REFERENCES Data(luid)
);

CREATE TABLE Data (
	luid		INTEGER		PRIMARY KEY		NOT NULL,
	bodyHash	TEXT,
	size		INT
);

CREATE TABLE ResourceAttributes (
	resourceLuid	INTEGER		PRIMARY KEY		NOT NULL,
	sourceURL		TEXT,
	timestamp		INT,
	latitude		REAL,
	longitude		REAL,
	altitude		REAL,
	cameraMake		TEXT,
	cameraModel		TEXT,
	clientWillIndex	BOOLEAN,
	fileName		TEXT,
	attachment		BOOLEAN,
	FOREIGN KEY(resourceLuid)	REFERENCES Resources(luid)
);

CREATE TABLE SavedSearches (
	luid				INTEGER		PRIMARY KEY		NOT NULL,
	guid				TEXT		UNIQUE,
	name				TEXT,
	query				TEXT,
	format				INT,
	updateSequenceNum	INT,
	dirty				BOOLEAN
);

CREATE TABLE SavedSearchScope (
	savedSearchLuid					INTEGER		PRIMARY KEY		NOT NULL,
	includeAccount					BOOLEAN,
	includePersonalLinkedNotebooks	BOOLEAN,
	includeBusinessLinkedNotebooks	BOOLEAN,
	FOREIGN KEY(savedSearchLuid)	REFERENCES SavedSearches(luid)
);

CREATE TABLE LinkedNotebooks (
	luid				INTEGER		PRIMARY KEY		NOT NULL,
	shareName			TEXT,
	username			TEXT,
	shardId				TEXT,
	shareKey			TEXT,
	uri					TEXT,
	guid				TEXT		UNIQUE,
	updateSequenceNum	INT,
	noteStoreUrl		TEXT,
	webApiUrlPrefix		TEXT,
	stack				TEXT,
	businessId			INT
);

CREATE TABLE SharedNotebooks (
	notebookLuid		INTEGER,
	id					INT		PRIMARY KEY		NOT NULL,
	userId				INT, -- TODO: Is there supposed to be a reference to the Users table? I don't think there is but I just want to make sure
	email				TEXT,
	notebookModifiable	BOOLEAN,
	requireLogin		BOOLEAN,
	serviceCreated		INT,
	serviceUpdated		INT,
	shareKey			TEXT,
	username			TEXT,
	privilege			INT,
	allowPreview		BOOLEAN,
	FOREIGN KEY(notebookLuid)	REFERENCES Notebooks(luid)
);

CREATE TABLE SharedNotebookRecipientSettings (
	sharedNotebookLuid	INTEGER		PRIMARY KEY		NOT NULL,
	reminderNotifyEmail	BOOLEAN,
	reminderNotifyInApp	BOOLEAN,
	FOREIGN KEY(sharedNotebookLuid)	REFERENCES SharedNotebooks(notebookLuid)
);