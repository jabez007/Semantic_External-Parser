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
      if (args.Length == 2 )
      {
        File.WriteAllText(args[1], "");

        var serializer = new SerializerBuilder()
          .WithTypeConverter(new SpanYamlTypeConverter())
          .WithTypeConverter(new LocationSpanYamlTypeConverter())
          .Build();

        string fileToParse;
        while ((fileToParse = Console.ReadLine()) != "end")
        {
          Encoding encoding = null;
          try
          {
            encoding = Encoding.GetEncoding(Console.ReadLine());
          }
          catch (ArgumentException)
          {
            Console.WriteLine("KO");
          }

          string outputPath = Console.ReadLine();

          try
          {
            using (var writer = File.CreateText(outputPath))
            {
              serializer.Serialize(writer, DeclarationFile.ParseFile<T>(fileToParse, encoding));
            }
          }
          catch (Exception)
          {
            Console.WriteLine("KO");
          }

          Console.WriteLine("OK");
        }
      }
    }
  }
}
