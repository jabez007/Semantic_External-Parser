using PowerDiff.Models.SemanticMerge;
using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace PowerDiff.Controllers
{
  internal sealed class LocationSpanYamlTypeConverter : IYamlTypeConverter
  {
    public bool Accepts(Type type)
    {
      return type == typeof(LocationSpan);
    }

    public object ReadYaml(IParser parser, Type type)
    {
      throw new NotImplementedException();
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
      SpanYamlTypeConverter spanConverter = new SpanYamlTypeConverter();
      LocationSpan locationSpan = (LocationSpan)value;
      emitter.Emit(new MappingStart(null, null, false, MappingStyle.Flow));
      emitter.Emit(new Scalar(null, "start"));
      spanConverter.WriteYaml(emitter, locationSpan.Start, typeof((int, int)));
      emitter.Emit(new Scalar(null, "end"));
      spanConverter.WriteYaml(emitter, locationSpan.End, typeof((int, int)));
      emitter.Emit(new MappingEnd());
    }
  }
}
