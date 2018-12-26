namespace Yandex.Detector
{
  using System;
  using System.Collections.Generic;
  using Catharsis.Commons;
  using System.Threading.Tasks;

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
    public static Task<IMobileDevice> Detect(this IMobileDetector detector, Action<IDetectorRequest> request)
    {
      Assertion.NotNull(detector);
      Assertion.NotNull(request);

      var builder = new DetectorRequest();
      request(builder);

      return detector.Detect(builder.Headers);
    }
  }
}