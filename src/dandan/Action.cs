namespace dandan;

using System.Text;


public interface IAction { }


public abstract record KeywordAction(KeywordActionKind Keyword) : IAction
{
    protected virtual bool PrintMembers(StringBuilder stringBuilder)
    {
        return false;
    }
}



public record Sacrifice() : KeywordAction(KeywordActionKind.Sacrifice) { public override string ToString() => $"{Keyword}"; }

public record Counter() : KeywordAction(KeywordActionKind.Counter) { public override string ToString() => $"{Keyword}"; }

public record Search(params Zone[] Zones) : KeywordAction(KeywordActionKind.Search)
{
    public override string ToString() => $"{Keyword}({string.Join(", ", from zone in Zones select zone.Name)})";
}

public record Reveal() : KeywordAction(KeywordActionKind.Reveal) { public override string ToString() => $"{Keyword}"; }
public record Shuffle() : KeywordAction(KeywordActionKind.Shuffle) { public override string ToString() => $"{Keyword}"; }
public record Exile() : KeywordAction(KeywordActionKind.Exile) { public override string ToString() => $"{Keyword}"; }
public record Create() : KeywordAction(KeywordActionKind.Create) { public override string ToString() => $"{Keyword}"; }
public record Mill() : KeywordAction(KeywordActionKind.Mill) { public override string ToString() => $"{Keyword}"; }
public record Discard() : KeywordAction(KeywordActionKind.Discard) { public override string ToString() => $"{Keyword}"; }
public record Scry(int N) : KeywordAction(KeywordActionKind.Scry) { public override string ToString() => $"{Keyword}({N})"; }
public record Untap() : KeywordAction(KeywordActionKind.Untap) { public override string ToString() => $"{Keyword}"; }
public record Tap() : KeywordAction(KeywordActionKind.Tap) { public override string ToString() => $"{Keyword}"; }

public record Recover(ManaCost Cost) : KeywordAction(KeywordActionKind.Recover) { public override string ToString() => $"{Keyword}({Cost})"; }

public record Flashback(ManaCost Cost) : KeywordAction(KeywordActionKind.Flashback) { public override string ToString() => $"{Keyword}({Cost})"; }


public record ReturnTarget(Target Target, ManaCost Cost, Zone From, Zone To) : IAction
{
    public override string ToString() => $"ReturnTarget({TargetsToString(Target)}, {From}, {To}{(Cost.IsNone ? "" : $", {Cost}")})";

    private static string TargetsToString(Target target) => string.Join("|", Enum.GetValues<Target>().Where(t => target.HasFlag(t)));
}

