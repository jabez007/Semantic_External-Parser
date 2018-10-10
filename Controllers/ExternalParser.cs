using PowerDiff.Models.SemanticMerge;
using System;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

namespace PowerDiff.Controllers
{
  /// <summary>
  ///
  /// </summary>
  public static class ExternalParser<T>
    where T : DeclarationFile
  {
    /// <summary>
    ///
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static void Main(string[] args)
    {
      if (args.Length == 2)
      {
        File.WriteAllText(args[1], "");

        var serializer = new SerializerBuilder()
          .WithTypeConverter(new SpanYamlTypeConverter())
          .WithTypeConverter(new LocationSpanYamlTypeConverter())
          .Build();

        string fileToParse;
        while (!string.IsNullOrEmpty(fileToParse = Console.ReadLine())
        {
          try
          {
            Encoding encoding = Encoding.GetEncoding(Console.ReadLine());
            try
            {
              using (var writer = File.CreateText(Console.ReadLine()))
              {
                serializer.Serialize(writer, DeclarationFile.ParseFile<T>(fileToParse, encoding));
              }
            }
            catch (Exception)
            {
              Console.WriteLine("KO");
            }
          }
          catch (ArgumentException)
          {
            Console.WriteLine("KO");
          }          

          Console.WriteLine("OK");
        }
        else
        {
          Console.WriteLine("KO");
        }
      }
    }
  }
}
