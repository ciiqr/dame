##Dame: An evernote client for linux##

###TODO###
  * GTK# User Interface (While defining IUserInterface appropriately/generically)
    * Menubar
      * Import/Export, Settings, etc
    * Toolbar
    * 3 panels
    * Tree view on left
    * Lazy loaded list view in middle (Will have to manually implement, probably base interface on iOS's UITableView)
    * Note editor on right with title, dates, searchable notebook/tag dropdowns, etc.
      * Ability to display in different formats (ie. normal formatted, html, enml, etc)
  * Sync manager based on (https://dev.evernote.com/media/pdf/edam-sync.pdf) but preferably taking advantage of new SyncChunkFilter's so that we can download & update each thing progressivly (maybe I can even process chunks asynchronously from the downloading (maybe have an event when a sync chunk is downloaded & add it to the database in a separate thread / in a separate module?...))
  * Database manager
  * Import/Export handlers
    * ExternalDocumentType enum/struct (depending on whether it should be extensible with plugins in the future...)
  * General data conversions for HTML, ENML, XHTML and other exportable/importable types
    * For HTML to ENML will presumably need to convert to XHTML first (Html Agility Pack ?)
    * Any conversions **to** HTML should really be to XHTML?
  * Implement Controller (in the MVC sense) for the application
  * Implement PluginProxy to load the UI & potentially other plugins
