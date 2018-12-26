namespace Yandex.Detector
{
  using System.Collections.Generic;
  using Catharsis.Commons;

  internal sealed class DetectorRequest : IDetectorRequest
  {
    private readonly IDictionary<string, object> headers = new Dictionary<string, object>();

    public IDetectorRequest Header(string name, object value)
    {
      Assertion.NotEmpty(name);
      Assertion.NotNull(value);

      headers[name] = value;
      return this;
    }

    public IDictionary<string, object> Headers
    {
      get { return headers; }
    }
  }
}