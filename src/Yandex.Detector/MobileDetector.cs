namespace Yandex.Detector
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using Catharsis.Commons;

  internal sealed class MobileDetector : IMobileDetector
  {
    private const string EndpointUrl = "http://phd.yandex.net/detect/";

    public async Task<IMobileDevice> Detect(IDictionary<string, object> headers)
    {
      Assertion.NotNull(headers);

      if (!headers.Any())
      {
        throw new DetectorException("No HTTP headers were specified");
      }

      var response = string.Empty;

#if NET_40
      var client = new WebClient();
      foreach (var header in headers)
      {
        client.Headers[header.Key] = header.Value?.ToStringInvariant();
      }

      try
      {
        response = client.DownloadString(EndpointUrl);
      }
      catch (Exception exception)
      {
        throw new DetectorException("Network communication error", exception);
      }
#else
      using (var client = new System.Net.Http.HttpClient())
      {
        foreach (var header in headers)
        {
          client.DefaultRequestHeaders.Add(header.Key, header.Value?.ToStringInvariant());
          try
          {
            response = await client.GetStringAsync(EndpointUrl);
          }
          catch (Exception exception)
          {
            throw new DetectorException("Network communication error", exception);
          }
        }
      }
#endif
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