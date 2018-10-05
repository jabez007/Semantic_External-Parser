using PowerDiff.Models.SemanticMerge;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using System.Threading.Tasks;
using System;

namespace PowerDiff.Controllers
{
  /// <summary>
  /// 
  /// </summary>
  public static class ExternalParser
  {
    private static bool erred = false;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args"></param>
    /// <returns></returns>
    public async static Task Main<T>(string[] args)
      where T : DeclarationFile
    {
      if (args.Length % 3 == 0)
      {
        var serializer = new SerializerBuilder()
          .WithTypeConverter(new SpanYamlTypeConverter())
          .WithTypeConverter(new LocationSpanYamlTypeConverter())
          .Build();
        for (int i = 0; i < args.Length; i += 3)
        {
          string fileToParse = args[i + 0];
          try
          {
            Encoding encoding = Encoding.GetEncoding(args[i + 1]);
          }
          catch (ArgumentException e)
          {
            erred = true;
            continue;
          }
          string outputPath = args[i + 2];

          try
          {
            using (var writer = File.CreateText(outputPath))
            {
              serializer.Serialize(writer, await DeclarationFile.ParseFile<T>(fileToParse));
            }
          }
          catch (Exception e)
          {
            erred = true;
            continue;
          }
        }
      }
      else
      {
        erred = true;
      }

      if (erred) { Console.WriteLine("KO"); }
      else { Console.WriteLine("OK"); }
    }
  }
}
