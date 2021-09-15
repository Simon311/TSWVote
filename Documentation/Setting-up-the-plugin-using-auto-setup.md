Steps:

0) You will need the [latest version of TSWVote](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/raw/master/Build/TSWVote.dll). Some parts of this guide may not hold true with older versions.

1) Install the TSWVote plugin. To do this, you will need to place the [plugin DLL file](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/raw/master/Build/TSWVote.dll) into the `ServerPlugins` folder.

2) Enable the REST API. To do this, you will need to manually edit the TShock config file, named `config.json`, located in the `tshock` folder.
Locate these lines:
`"RestApiEnabled": false,
    "RestApiPort": 7878`.
Make sure `"RestApiEnabled"` is set to `true`, with no quotes around `true`. Make sure `"RestApiPort"` is set to a port of your liking (again with no quotes around the value), but not your server's main port.
Beware that as far as we know, TShock will not automatically create a port-forward rule for this port. 
Making sure your networking environment allows you to use this port on the open internet is outside the scope of this guide.
If you're trying to host your server at home, search the internet for a guide on `port-forwarding`. If you're with a hoster that specializes in Terraria servers or game servers, consult their documentation or tech support on whether you can use an extra port for REST API, 
which port it can be, and whether any extra action is needed to make it open to the internet.

3) You can now (re-)start your server. Once you load into a world, type `/tswautosetup` into the server's console, or as superadmin on the server.
If you neither have access to the console nor to a superuser account, then your account's group must have the `vote.autosetup` permission.

4) If the command ran smoothly, you will be told that the token was generated and can be found in the `tshock` folder, which is the same folder that contains tshock's config file that you edited earlier. You will need to restart your server again for the changes to take effect.
The text file containing the token is named `tswtoken.txt`. 
Whether to delete the file after you collected the token is entirely up to you, but beware that running the command again will create a new token and destroy the old one.
If you're somehow obstructed from accessing this file, the only other place you can find this token is in the tshock config file, under the `ApplicationRestTokens` section.

5) If you didn't register your server on TServerWeb yet or didn't register at all, do that before continuing. 
Log into [tserverweb.com](https://tserverweb.com/login.php), proceed to your account, and for the server you're working on, select `Action` -> `Edit Server`. Go to the `tShock Config` tab.
Here, you will first need to enter the REST API port that you've specified in your tshock config file earlier. 
Then, proceed to put the token from the `tswtoken.txt` file into the `Current Server Token` field. Leave the Username and Password fields blank.
Press `Save All Changes`.

6) This step is not required if you only plan to use TSWConsole and not TSWVote. You may remove the TSWVote plugin if in-game voting is not something you want.
To use in-game voting functionality, you also need to run the `/tserverweb` command, specifying your server's ID on TServerWeb.
There are two ways to get the ID of your server. The first way is to make sure your server is currently running, then navigate to the `Manage server` page of the server you're working on. If TServerWeb says that your server is offline, try pressing `Force Server Status Update`.
If that didn't help, you may need to check your network settings, as mentioned in step 2. Then navigate to the `Server Plugins` tab, press `Manage` under `In-game Voting`.
Once the page loads, you will be able to find a tiny writing on the right, saying `Your Server ID: XXXX`. Take this number, and then run `/tserverweb XXXX` (`XXXX` being the number) as console or superadmin. With no console and superuser access, your account's group must have the `vote.changeid` permission. After all that, you can also take some time on this same page to set up what happens upon voting.
The other way of retrieving server ID is to navigate to either `Edit Server` or `Manage Server` and then just click onto your browser's address bar, then locate the digits after `?sid=`. Then you just run the command, as described above.
If all of this seems too complicated, you can instead run `/group addperm tserverweb vote.changeid`. This will hand this step over to TServerWeb to handle, but if somebody steals your token, they will be able to break in-game voting on your server. You will also have to navigate to the `In-game voting` page anyway.

7) _(Optional)_ By default, TServerWeb's access to your server will be limited to the minimum required for the operation of our two plugins and not beyond that.
This mostly includes the ability to see info about users (their group and IP address), and the ability to execute commands that require no additional permissions.
If you wish to use the advanced administrative capabilities of TServerWeb, you will need to manually add the required permissions to the `tserverweb` group, by running the `/group addperm` command. Refer to [TShock's documentation on permissions](https://tshock.readme.io/docs/permissions).

8) _(Optional)_ Try out our [TSWConsole plugin](https://gitlab.xghozt.com:2345/tsw/tswconsole/-/raw/master/Build/TSWConsole.dll). It will enable TServerWeb to present you with a live view of your server's console. After installation, it will require no further
setup beyond what you already did in this guide.