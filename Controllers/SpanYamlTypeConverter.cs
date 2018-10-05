using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace PowerDiff.Controllers
{
  internal sealed class SpanYamlTypeConverter : IYamlTypeConverter
  {
    public bool Accepts(Type type)
    {
      return type == typeof((int, int));
    }

    public object ReadYaml(IParser parser, Type type)
    {
      throw new NotImplementedException();
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
      (int, int) span = ((int, int))value;
      emitter.Emit(new SequenceStart(null, null, false, SequenceStyle.Flow));
      emitter.Emit(new Scalar(span.Item1.ToString()));
      emitter.Emit(new Scalar(span.Item2.ToString()));
      emitter.Emit(new SequenceEnd());
    }
  }
}
