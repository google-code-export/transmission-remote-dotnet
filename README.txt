HELLO
----------------------------

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

The transmission bittorrent client comes with a transmission-daemon application. It uses the transmission
bittorrent client engine and an embedded HTTP server for clients to control it. Big thanks to them for all
their great work.

It includes a great web interface called clutch, but I wanted an application for my windows machines that
was as close to a local client as possible (handling .torrent files etc). I use this to control an old
monitorless Linux machine at home, and it works pretty well I think.

This application is known to work with transmission 1.42 and should automatically take measures to be
compatible with any older version. If there's a change in the RPC API which breaks this application I'll
try my best to find time to fix it soon after, so give the latest version a try and then the one mentioned
above if that doesn't work.

You'll need a Microsoft .NET runtime to use this application. 3.5 or newer is recommended. Vista comes
with a working version but XP users may need to upgrade. Trying to run the application with an old .NET
runtime or without can result in an unhelpful error.

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
    * Settings profiles for multiple servers/locations.
    * More! 