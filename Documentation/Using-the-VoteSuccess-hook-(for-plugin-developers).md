`VoteSuccess` is the hook that allows your plugins to listen for successful in-game votes.

Add `TSWVote.dll` to your project's references. 

Add to the top of your .cs file: `using TSWVote;`

Assuming that `TSWVote()` will be your event handler function, add to your `Initialize` or `OnInitialize`:
```
try
{
	VoteHooks.VoteSuccessRegister(TSWVote);
}
catch
{

}
```
Add to your Dispose:
```
try
{
	VoteHooks.VoteSuccessDeregister(TSWVote);
}
catch
{

}
```

Your function will need to accept a single argument of type `VoteSuccessArgs`:
```
private void TSWVote(VoteSuccessArgs e)
{

}
```

`VoteSuccessArgs` has two child fields: `Player` is the `TSPlayer` object for the player that voted successfully, and `Container` is of type `object` and can be used in cases when your two or more separate event handlers need to communicate.