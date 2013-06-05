Dark Souls Connectivity Fix (DSCfix) by M0tah
Version 1.2
Latest release: http://sdrv.ms/128mNwY
Alternative download: http://darksouls.nexusmods.com/mods/334/
Discussion thread: http://steamcommunity.com/app/211420/discussions/0/828935269278734403/


General Information
===================
DSCfix aims to improve the online experience when attempting to engage in jolly cooperation with friends. It is an interception DLL intended to be used with DSfix and functions by adding any online GFWL friends to your P2P connection pool before searching for random peers. This means that direct connections to friends are established right away, whereas in vanilla Dark Souls this only happens after the first successful summon or invasion (if you were even lucky to get that far).

This greatly reduces the time required to summon a friend, with typical wait times of about a few seconds.

What DSCfix does do:
-- Intercepts GFWL matchmaking functions to return a friend's session if available. This is repeated until all online friends are connected to, at which point it resumes normal behavior of looking for random peers.
-- Allows near-instantaneous summoning / invasion of friends, as well as other network info exchanged such as bloodstains, visible blue ghosts / bonfire phantoms, bonfire kindling, etc.

What DSCfix does NOT do:
-- Change any rules of summoning or invading (area boss must not be defeated, players must still be within level range, host must be human, etc.)
-- Fix any NAT related problems. If you have a strict NAT (as reported by GFWL) and have not been able to successfully summon/be summoned, DSCfix will probably not help.
-- Otherwise tamper with any aspect of Dark Souls gameplay. The connections it establishes with friends are the exact same as those established after successfully summoning / invading a player.

Disclaimer:
Due to the nature of DSCfix it must make changes to the internal functionality of Dark Soul's multiplayer networking code. Although there have been no issues during testing of DSCfix, I cannot be held responsible for any potential malfunctioning of the code or GFWL bans. Use DSCfix at your own risk.


Installation & Usage
====================
1) Install DSfix if you haven't done so already: http://blog.metaclassofnil.com/?tag=dsfix
2) Next, place DSCfix.dll and DSCfix.ini in your Dark Souls DATA directory (where DARKSOULS.exe is - for example: "C:\Program Files (x86)\Steam\steamapps\common\Dark Souls Prepare to Die Edition\DATA")
3) Open up DSfix.ini and search for the following line:
      dinput8dllWrapper none
   Replace it with:
      dinput8dllWrapper dscfix.dll

4) ** If you're using DSMfix or another DInput hook (otherwise skip this step) **
   Open up DSCfix.ini and search for the following line:
      ;dInput8Chain = dsmfix.dll
   Remove the ; (comment character) so the line looks like:
      dInput8Chain = dsmfix.dll (or whatever dll you want to load)

5) Boot up Dark Souls, have a friend also using DSCfix place a sign, and behold. ;)
   (Note: Normal rules for summoning apply)

** All players involved must be using DSCfix ** (see notes below on why)


Uninstallation
==============
Simply delete DSCfix.dll, DSCfix.ini, and DSCfix.log.


Frequently Asked Questions
==========================
When starting Dark Souls I see a message box with "Loading of specified dinput wrapper failed with error 126: The specified module could not be found." and the game exits.  What's going on?
   -- Double-check that you have put DSCfix.dll and DSCfix.ini in the DATA directory (there should also be DARKSOULS.exe and DATA.exe in this directory)
   -- You may have made a typo when modifying DSfix.ini; check the line containing dinput8dllWrapper.

When starting Dark Souls I see a message box with "Loading of specified dinput wrapper failed with error 1114: A dynamic link library (DLL) initialization routine failed." and the game exits.  What's happening?
   -- This suggests that you made a bad edit to DSCfix.ini; check DSCfix.log for more information.

DSCfix isn't working!  What's up?
   -- Verify that you have installed DSCfix and it is being loaded.  When this is happening, a DSCfix.log file will be created in DATA.
   -- Verify that you have Invite to Game buttons in the GFWL friends list.
   -- Verify that your target friend has installed DSCfix correctly: http://steamcommunity.com/sharedfiles/filedetails/?id=137890394
   -- Change the logLevel in DSCfix.ini to all, and verify that messages of the format "Connected to friend <gamertag>" are being written.
   -- If you didn't find anything after doing the above, please let us know as per the Known Issues section

I enabled the notice log level, and I see that I am constantly disconnecting and then reconnecting to my friend.  What's causing this?
   -- This suggests that Dark Souls is attempting to establish a direct connection to your friend but failing.
   -- According to Juuri, this issue may be caused by not having ports forwarded or not using UPnP.

Can I use DSCfix without DSfix?
   -- Yes: simply rename DSCfix.dll to DINPUT8.dll.


Notes
=====
-- In order for DSCfix to get friend session information, that session must have the "presence" flag set, which DSCfix also does. This is why all players involved must be using DSCfix.
-- You may notice Invite to Game / Join Session in Progress options available when playing Dark Souls now. This is a side-effect of setting the session "presence" flag on the above point. However, the game ignores these invite/join requests completely (fun fact: presence was always advertised for phantom sessions, which is why someone playing with phantoms always had a Join Session in Progress option).
-- The notice log level will cause connections established with friends to be logged to DSCfix.log. This may be useful for verifying that you are connected to friends.
-- See http://steamcommunity.com/app/211420/discussions/0/882962698499356788/ for an excellent description of how Dark Souls network connectivity works. One clarification: you MUST quit and restart the game completely to clear your P2P IP pool - quitting to the title screen will not clear the pool.
-- Buy Dark Souls if you like hardcore action RPGs!


Known Issues
============
-- Can cause short (~a second) freezes when establishing connections in-game
-- Possible issues with Battle of Stoicism (unconfirmed)
-- Let us know if you find any other issues!
   -- Please include the following in your report:
   -- OS version (Win 8, 7, etc; and 32 or 64 bit)
   -- Whether you are using x360ce, DSfix, and/or DSMfix
   -- Any other information that would help us reproduce the issue


Special Thanks
==============
-- foxUnit01/foxBabble for extensively testing DSCfix with me and pushing me to develop and release it. He also helped write this readme :)
