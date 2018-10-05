namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public interface IDeclaration
  {
    /// <summary>
    /// a string like "method" or "function" that is relevant to the programming language
    /// </summary>
    string Type { get; }

    /// <summary>
    /// name of the node
    /// </summary>
    string Name { get; }

    /// <summary>
    ///
    /// </summary>
    LocationSpan LocationSpan { get; }
  }
}