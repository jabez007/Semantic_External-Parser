using System;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public class ParsingError
  {
    /// <summary>
    /// line and column of error
    /// </summary>
    public (int, int) Location { get; }

    /// <summary>
    ///
    /// </summary>
    public string ErrorMessage { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="location"></param>
    /// <param name="errorMessage"></param>
    public ParsingError((int, int) location, string errorMessage)
    {
      Location = location;
      ErrorMessage = errorMessage;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="location"></param>
    /// <param name="error"></param>
    public ParsingError((int, int) location, Exception error)
    {
      Location = location;
      ErrorMessage = error.ToString();
    }
  }
}