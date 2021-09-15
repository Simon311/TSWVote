When you start your server with the plugin installed, it will immediately create a config file under the name of `TSWVote.json` in the `tshock` folder. 
The contents of this file will look something like this:
```
{
  "ServerID": 0,
  "NumberOfWebClients": 30,
  "Timeout": 10000,
  "RequirePermission": false,
  "PermissionName": "vote.vote"
}
```

Let's break down the available options.

- `ServerID` is the ID of your server at TServerWeb. You can set it up in-game or in the console, using the `/tserverweb` command. You can read more about this in the [auto-setup guide](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/wikis/Setting-up-the-plugin-using-auto-setup).
- `NumberOfWebClients` is the maximum number of connections that your server will make to TServerWeb at any given time. Under normal circumstances, this will not need to exceed the number of player slots on your server, and lower values might work fine too. The default is `30`. The value does _not_ need quotation marks `""` around it.
- `Timeout` is the number of milliseconds (one second is 1000 milliseconds) that the plugin will wait for to get a response from TServerWeb. If this is too low, you will get errors even when a vote gets placed successfully. If you're getting any errors mentioning something timing out, try increasing this value. The default is `10000` (which is 10 seconds). The value does _not_ need quotation marks `""` around it.
- `RequirePermission` is whether voting on your server will require the player's group to have a certain permission. The default is `false`. The other option is `true`. The value does _not_ need quotation marks `""` around it.
- `PermissionName` is the permission that players will need to vote. This only takes effect if `RequirePermission` is set to `true`. The default is `vote.vote`. The value _does_ need quotation marks `""` around it.

If you're creating the config file ahead of time even before you've installed the plugin, be aware of the following things:
- On non-Windows operating systems, filenames are often case-sensitive. Make sure the filename is exactly `TSWVote.json`, with the first 4 letters being upper-case.
- The names of every config option do need quotation marks `""` around them, as they're considered a string-type value in [JSON](https://www.w3schools.in/json/json-syntax/). It would be best on your part to just copy the example presented above and fill your values in.