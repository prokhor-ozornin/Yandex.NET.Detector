using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Provides access to functionality of Yandex.Detector mobile service.</para>
  /// </summary>
  public interface IMobileDetector
  {
    /// <summary>
    ///   <para>Performs request to Yandex.Detector web service and determines capabilities of mobile client device, using provided HTTP headers for its identification.</para>
    /// </summary>
    /// <param name="headers">Map of mobile device's HTTP headers with values.</param>
    /// <returns>Instance of <see cref="IMobileDevice"/> object, describing capabilities of identified mobile device.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="headers"/> is a <c>null</c> reference.</exception>
    /// <exception cref="DetectorException">If there was error either during the request to Yandex.Detector web service, or mobile device cannot be identified based on a set of provided HTTP headers.</exception>
    Task<IMobileDevice> Detect(IDictionary<string, object> headers);
  }
}