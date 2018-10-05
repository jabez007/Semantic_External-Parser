using System.Collections.Generic;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  /// 
  /// </summary>
  public enum ParseErrorsDetected
  {
    /// <summary>
    /// 
    /// </summary>
    FALSE = 0,

    /// <summary>
    /// 
    /// </summary>
    TRUE = 1,
  }

  /// <summary>
  ///
  /// </summary>
  public interface IDeclarationFile : IDeclaration
  {
    /// <summary>
    /// start character position and end character postition for the footer of this container in the code
    /// </summary>
    (int, int) FooterSpan { get; }

    /// <summary>
    ///
    /// </summary>
    ParseErrorsDetected ParseErrorsDetected { get; set; }

    /// <summary>
    ///
    /// </summary>
    IList<ParsingError> ParsingErrors { get; }

    /// <summary>
    ///
    /// </summary>
    IList<IDeclaration> Children { get; }
  }
}