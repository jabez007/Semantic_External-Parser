using PowerDiff.Models.SemanticMerge.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace PowerDiff.Models.SemanticMerge
{
  /// <summary>
  ///
  /// </summary>
  public abstract class DeclarationFile : Declaration, IDeclarationFile
  {
    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "footerSpan", Order = 4)]
    public (int, int) FooterSpan { get; }

    /// <summary>
    ///
    /// </summary>
    [YamlIgnore]
    public ParseErrorsDetected ParseErrorsDetected {
      get
      {
        return (ParseErrorsDetected)Enum.Parse(typeof(ParseErrorsDetected), _ParseErrorDetected, true);
      }
      set
      {
        _ParseErrorDetected = value.ToString().ToLower();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [YamlMember(Alias = "parseErrorsDetected", Order = 5, ScalarStyle = ScalarStyle.Plain)]
    public string _ParseErrorDetected { get; set; } = "false";

    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "parsingErrors", Order = 6)]
    public IList<ParsingError> ParsingErrors { get; } = new List<ParsingError>();

    /// <summary>
    ///
    /// </summary>
    [YamlMember(Alias = "children", Order = 7)]
    public IList<IDeclaration> Children { get; } = new List<IDeclaration>();

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="footerSpan"></param>
    /// <param name="fileConents"></param>
    public DeclarationFile(string name, (int, int) start, (int, int) end, (int, int) footerSpan, string[] fileConents)
      : base("file", name, start, end)
    {
      FooterSpan = footerSpan;
      Parse(new CodeFile(fileConents));
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="name"></param>
    /// <param name="end"></param>
    /// <param name="fileConents"></param>
    public DeclarationFile(string name, (int, int) end, string[] fileConents)
      : this(name, (1, 0), end, (0, -1), fileConents)
    {
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static async Task<T> ParseFile<T>(string filePath)
      where T : DeclarationFile
    {
      return await ParseFile<T>(filePath, Encoding.UTF8);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task<T> ParseFile<T>(string filePath, Encoding encoding)
      where T : DeclarationFile
    {
      string fileName = Path.GetFileName(filePath);
      T file = null;

      if (File.Exists(filePath))
      {
        string[] fileContents = await File.ReadAllLinesAsync(filePath, encoding);
        int fileLength = fileContents.Length;
        file = (T)Activator.CreateInstance(typeof(T), fileName, (fileLength, fileContents[fileLength - 1].Length), fileContents);
      }
      else
      {
        file = (T)Activator.CreateInstance(typeof(T), fileName, (1, 0), new string[0]);
        file.ParseErrorsDetected = ParseErrorsDetected.TRUE;
        file.ParsingErrors.Append(new ParsingError((1, 0), string.Format("'{0}' does not exist", filePath)));
      }

      return file;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="fileContents"></param>
    protected virtual void Parse(CodeFile fileContents)
    {
      throw new NotImplementedException();
    }
  }
}