using YamlDotNet.Serialization;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public class LocationSpan
  {
    /// <summary>
    /// row and column for the start of this node in the code
    /// </summary>
    [YamlMember(Alias = "start")]
    public (int, int) Start { get; }

    /// <summary>
    /// row and column for the end of this node in the code
    /// </summary>
    [YamlMember(Alias = "end")]
    public (int, int) End { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public LocationSpan((int, int) start, (int, int) end)
    {
      Start = start;
      End = end;
    }
  }
}