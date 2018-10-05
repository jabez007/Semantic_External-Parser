using YamlDotNet.Serialization;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public class DeclarationNode : Declaration, IDeclarationNode
  {
    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "span", Order = 4)]
    public (int, int) Span { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="span"></param>
    public DeclarationNode(string type, string name, (int, int) start, (int, int) end, (int, int) span)
      : base(type, name, start, end)
    {
      Span = span;
    }
  }
}