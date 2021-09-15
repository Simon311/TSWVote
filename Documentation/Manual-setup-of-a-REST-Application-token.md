This guide is here to provide an alternative to steps 3 and 4 of the [TSWVote auto-setup guide](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/wikis/Setting-up-the-plugin-using-auto-setup). It demonstrates how you can set up a REST Application token without using the `/tswautosetup` command or indeed the TSWVote plugin at all. You may refer to it as a general guide on creating Application REST tokens to use with other plugins as well. If you are setting up TSWVote or TSWConsole, you should still follow the [auto-setup guide](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/wikis/Setting-up-the-plugin-using-auto-setup), but replace steps 3 and 4 with the steps from this guide.

0) Make sure you run with TShock's console or superadmin permissions. Running the commands below under a restricted group will likely be impossible.

1) First, you will need to start your server and create a group that will have all the permissions you plan to give to your REST API application token. You can do so with the `/group add` command. Like so: `/group add tserverweb tshock.rest.useapi,tshock.rest.users.info,tshock.rest.command,vote.ping,AdminRest.allow`. The permissions required for the basic operation of our two plugins are included in the above command, where `tserverweb` is the new group's name and the rest are permissions separated by commas. It is at this stage that you may give TServerWeb extra permissions, but you can always add more permissions using `/group addperm` as well. Refer to [TShock's guide on permissions](https://tshock.readme.io/docs/permissions) to learn more.


2) The second step is to create a user and make it a member of the new group. This user's credentials will not be used or exposed to any outside application. You may give this user a randomized username and must give this user a secure randomized password to avoid any abuse or other security concerns. The password's recommended length would be 16 characters. A convenient source of randomness would be [random.org's password tool](https://www.random.org/passwords/). If you're in a Linux terminal environment, you may also try this command `< /dev/urandom tr -dc A-Za-z0-9 | head -c16;echo;` instead. You must keep the username, and you can shred or discard the password after you've used it in the command below. Because the password won't be used for anything, you need not bother to make it mnemonic, easy to remember, or otherwise human-readable.
To create this user, you run `/user add` like this: `/user add tserverwebXXXX PASSWORD GROUP`, where `XXXX` is a randomized postfix/appendix to the username, `PASSWORD` is your random password, and `GROUP` is the group that you've created in step 1 (which was `tserverweb` in our example). Beware that if you intend to use TSWVote's autosetup command later, it may destroy any users with username beginning with `tserverweb` and belonging to group `tserverweb`, as well as delete the group `tserverweb` if no users belonging to it are found. It will also destroy any API tokens that you create in step 3 if their (the token's, not the user's) group is `tserverweb`.


3) Now, you will need to generate a secure token and then manually add it to TShock's config file. You may take one of the passwords that random.org generated for you and use that as a token, but make sure it's different from the user's password in the previous step. Alternatively, if you're a developer, you may find it convenient to use a mnemonic sequence when you're working with the API manually. Open the `config.json` file in the `tshock` folder and locate the `ApplicationRestTokens` section: `"ApplicationRestTokens": {}`. If there's nothing between the brackets, you will need to make some space for your token by pressing Enter after the opening bracket a couple of times. If there are already tokens present, add a comma after the closing bracket of the last token, and then make some space. Then, copy and paste this:
>      "TOKEN": {
>        "Username": "USERNAME",
>        "UserGroupName": "GROUP"
>      },
- Replace `TOKEN` with the token value you decided to use, `USERNAME` with the username you made in step 2, and `GROUP` with the group you made in step 1. In this step, you may also enable REST API and select the port for it. For more info on this, refer to step 2 of [this other guide](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/wikis/Setting-up-the-plugin-using-auto-setup).


4) Now you can save the file and attempt to (re-)start your server. [JSON](https://www.w3schools.in/json/json-syntax/) is a pretty sensitive data structure and if you did anything incorrectly, you may have to come back and fix it before TShock can start properly. Make sure your config looks something like this:

>     "RESTRequestBucketDecreaseIntervalMinutes": 1,
>     "ApplicationRestTokens": {
>       "TOKEN": {
>         "Username": "USERNAME",
>         "UserGroupName": "GROUP"
>       }
>     }


After this step, your REST application token is finally set up and you may continue following the [autosetup guide](https://gitlab.xghozt.com:2345/tsw/TSWVote/-/wikis/Setting-up-the-plugin-using-auto-setup), resuming at step 5, and assuming that any reference to the token acquired from the `tswtoken.txt` file is actually referring to the token you've just created.