namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public interface IDeclarationNode : IDeclaration
  {
    /// <summary>
    /// start character position and end character postition of this node in the code
    /// </summary>
    (int, int) Span { get; }
  }
}