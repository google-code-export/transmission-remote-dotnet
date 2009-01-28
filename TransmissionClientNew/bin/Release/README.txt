Patches, suggestions and bug reports (with as much info as possible) are always welcome. I will look at
them, but please be patient. Please send them through the google code site (below).

http://code.google.com/p/transmission-remote-dotnet/

If when you start the application you are greeted with an exception (error message) then try upgrading
your .NET framework. 3.5 is recommended.

Enjoy! 

SOURCE CODE
----------------------------

The source is GPLv3 and can be obtained with the command:

svn co http://transmission-remote-dotnet.googlecode.com/svn/trunk/ transmission-remote-dotnet/

CREDITS AND ACKNOWLEDGEMENTS
----------------------------

 * Jayrock (http://jayrock.berlios.de/) is used for encoding and decoding JSON. The revision as of December
   2008 is currently being used with no modifications (which I would have to publish under the LGPL licence).
 * All icons are the creation of David Vignoni in his Nuvola theme. http://www.icon-king.com/
 * Elbandi has made a number of notable contributions including SSL, speed graphs and GeoIP support.

ABOUT
----------------------------

transmission-remote-dotnet is a feature rich client to transmission-daemon. The daemon is the transmission
bittorrent client engine with embedded HTTP server for control. The user interface is inspired by uTorrent,
and it's aim is to make using a remote machine for bittorrent as convenient as a local machine.

Screenshots can be seen here: http://code.google.com/p/transmission-remote-dotnet/wiki/Screenshots

This application is known to work with transmission 1.50beta3 and should automatically take measures to be
compatible with any older version. If there's a change in the RPC API which breaks this application or could
potentially add a useful feature I'll try my best to find time to fix it soon after, so give the latest version
a try and then the one mentioned above if that doesn't work.

You'll need a Microsoft .NET runtime to use this application. 3.5 or newer is recommended. Vista usually
(not always) comes with a recent enough version but XP users may need to upgrade if they haven't done so already.
Trying to run the application with an old .NET runtime or without can result in a really unhelpful error when you start it. 

FEATURES
----------------------------

    * Adding torrents by handling .torrent files, drag-n-drop, and browsing.
    * Starting and stopping torrents.
    * Authentication support
    * Limiting upload/download either globally or for specific torrents.
    * Setting priorities on files and viewing their progress.
    * View peers.
    * Proxy support (works through my university firewall).
    * Minimise to tray option and torrent complete popup.
    * GeoIP support.
    * SSL support.
    * Multiple settings profiles.
    * More! 