using System;
using System.Collections.Generic;
using Catharsis.Commons;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IMobileDetector"/>.</para>
  /// </summary>
  /// <seealso cref="IMobileDetector"/>
  public static class IMobileDetectorExtensions
  {
    /// <summary>
    ///   <para>Performs request to Yandex.Detector web service and determines capabilities of mobile client device.</para>
    /// </summary>
    /// <param name="detector">Instance of client for Yandex.Detector web service.</param>
    /// <param name="request">Delegate that performs configuration of mobile device's HTTP headers to be send with request.</param>
    /// <returns>Instance of <see cref="IMobileDevice"/> object, describing capabilities of identified mobile device.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="detector"/> or <paramref name="request"/> is a <c>null</c> reference.</exception>
    /// <exception cref="DetectorException">If there was error either during the request to Yandex.Detector web service, or mobile device cannot be identified based on a set of provided HTTP headers.</exception>
    /// <seealso cref="IMobileDetector.Detect(IDictionary{string, object})"/>
    /// <seealso cref="Detect(IMobileDetector, IDictionary{string, object}, out IMobileDevice)"/>
    /// <seealso cref="Detect(IMobileDetector, Action{IDetectorRequest}, out IMobileDevice)"/>
    public static IMobileDevice Detect(this IMobileDetector detector, Action<IDetectorRequest> request)
    {
      Assertion.NotNull(detector);
      Assertion.NotNull(request);

      var builder = new DetectorRequest();
      request(builder);

      return detector.Detect(builder.Headers);
    }

    /// <summary>
    ///   <para>Performs request to Yandex.Detector web service and determines capabilities of mobile client device.</para>
    /// </summary>
    /// <param name="detector">Instance of client for Yandex.Detector web service.</param>
    /// <param name="headers">Map of mobile device's HTTP headers with values.</param>
    /// <param name="device">Instance of <see cref="IMobileDevice"/> object, describing capabilities of identified mobile device.</param>
    /// <returns><c>true</c> if request was successfull and <paramref name="device"/> output parameter contains information about determined mobile device, or <c>false</c> if request failed and <paramref name="device"/> output parameter is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="detector"/> or <paramref name="headers"/> is a <c>null</c> reference.</exception>
    /// <seealso cref="IMobileDetector.Detect(IDictionary{string, object})"/>
    /// <seealso cref="Detect(IMobileDetector, Action{IDetectorRequest})"/>
    /// <seealso cref="Detect(IMobileDetector, Action{IDetectorRequest}, out IMobileDevice)"/>
    public static bool Detect(this IMobileDetector detector, IDictionary<string, object> headers, out IMobileDevice device)
    {
      Assertion.NotNull(detector);
      Assertion.NotNull(headers);

      try
      {
        device = detector.Detect(headers);
        return true;
      }
      catch
      {
        device = null;
        return false;
      }
    }

    /// <summary>
    ///   <para>Performs request to Yandex.Detector web service and determines capabilities of mobile client device.</para>
    /// </summary>
    /// <param name="detector">Instance of client for Yandex.Detector web service.</param>
    /// <param name="request">Delegate that performs configuration of mobile device's HTTP headers to be send with request.</param>
    /// <param name="device">Instance of <see cref="IMobileDevice"/> object, describing capabilities of identified mobile device.</param>
    /// <returns><c>true</c> if request was successfull and <paramref name="device"/> output parameter contains information about determined mobile device, or <c>false</c> if request failed and <paramref name="device"/> output parameter is a <c>null</c> reference.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="detector"/> or <paramref name="request"/> is a <c>null</c> reference.</exception>
    /// <seealso cref="IMobileDetector.Detect(IDictionary{string, object})"/>
    /// <seealso cref="Detect(IMobileDetector, Action{IDetectorRequest})"/>
    /// <seealso cref="Detect(IMobileDetector, IDictionary{string, object}, out IMobileDevice)"/>
    public static bool Detect(this IMobileDetector detector, Action<IDetectorRequest> request, out IMobileDevice device)
    {
      Assertion.NotNull(detector);
      Assertion.NotNull(request);

      try
      {
        device = detector.Detect(request);
        return true;
      }
      catch
      {
        device = null;
        return false;
      }
    }
  }
}