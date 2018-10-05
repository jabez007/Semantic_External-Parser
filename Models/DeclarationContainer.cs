using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public class DeclarationContainer : Declaration, IDeclarationContainer
  {
    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "headerSpan", Order = 4)]
    public (int, int) HeaderSpan { get; }

    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "footerSpan", Order = 5)]
    public (int, int) FooterSpan { get; }

    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "children", Order = 6)]
    public IList<IDeclarationNode> Children { get; } = new List<IDeclarationNode>();

    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="headerSpan"></param>
    /// <param name="footerSpan"></param>
    public DeclarationContainer(string type, string name, (int, int) start, (int, int) end, (int, int) headerSpan, (int, int) footerSpan)
      : base(type, name, start, end)
    {
      HeaderSpan = headerSpan;
      FooterSpan = footerSpan;
    }
  }
}