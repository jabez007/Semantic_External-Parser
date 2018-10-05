using System.Collections.Generic;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public interface IDeclarationContainer : IDeclaration
  {
    /// <summary>
    /// start character position and end character postition for the header of this container in the code
    /// </summary>
    (int, int) HeaderSpan { get; }

    /// <summary>
    /// start character position and end character postition for the footer of this container in the code
    /// </summary>
    (int, int) FooterSpan { get; }

    /// <summary>
    ///
    /// </summary>
    IList<IDeclarationNode> Children { get; }
  }
}