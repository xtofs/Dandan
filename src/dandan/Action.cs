namespace dandan;



public abstract record Action(KeywordAction Keyword) { }


public record Sacrifice() : Action(KeywordAction.Sacrifice);
public record Counter() : Action(KeywordAction.Counter);
public record Search(params Zone[] Zones) : Action(KeywordAction.Search);
public record Reveal() : Action(KeywordAction.Reveal);
public record Shuffle() : Action(KeywordAction.Shuffle);
public record Exile() : Action(KeywordAction.Exile);
public record Create() : Action(KeywordAction.Create);
public record Mill() : Action(KeywordAction.Mill);
public record Discard() : Action(KeywordAction.Discard);
public record Scry(int N) : Action(KeywordAction.Scry);
public record Tap() : Action(KeywordAction.TapAndUntap);
public record Untap() : Action(KeywordAction.TapAndUntap);
