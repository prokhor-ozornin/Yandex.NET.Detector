using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Catharsis.Commons;

namespace Yandex.Detector
{
  internal sealed class MobileDetector : IMobileDetector
  {
    private const string EndpointUrl = "http://phd.yandex.net/detect/";

    public IMobileDevice Detect(IDictionary<string, object> headers)
    {
      Assertion.NotNull(headers);

      if (!headers.Any())
      {
        throw new DetectorException("No HTTP headers were specified");
      }

      var response = string.Empty;
      using (var web = new WebClient())
      {
        foreach (var header in headers)
        {
          web.Headers[header.Key] = header.Value.ToStringInvariant();
        }

        try
        {
          response = web.DownloadString(EndpointUrl);
        }
        catch (Exception exception)
        {
          throw new DetectorException("Network communication error", exception);
        }
      }

      try
      {
        var error = response.AsXml<Error>();
        throw new DetectorException(error.Text);
      }
      catch (InvalidOperationException)
      {
      }

      try
      {
        return response.AsXml<MobileDevice>();
      }
      catch (Exception exception)
      {
        throw new DetectorException("Failed to understand service's response", exception);
      }
    }
  }
}