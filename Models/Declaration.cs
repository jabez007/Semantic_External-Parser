using YamlDotNet.Serialization;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public abstract class Declaration : IDeclaration
  {
    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "type", Order = 1)]
    public string Type { get; }

    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "name", Order = 2)]
    public string Name { get; }

    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "locationSpan", Order = 3)]
    public LocationSpan LocationSpan { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public Declaration(string type, string name, (int, int) start, (int, int) end)
    {
      Type = type;
      Name = name;
      LocationSpan = new LocationSpan(start, end);
    }
  }
}