namespace Yandex.Detector
{
  using System;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDetectorRequest"/>.</para>
  /// </summary>
  /// <seealso cref="IDetectorRequest"/>
  public static class IDetectorRequestExtensions
  {
    /// <summary>
    ///   <para>Adds new header for HTTP request that identifies target mobile device as having an Opera Mini browser installed.</para>
    /// </summary>
    /// <param name="request">Instance of request to Yandex.Detector service.</param>
    /// <param name="version">Version of installed Opera Mini.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="request"/> or <paramref name="version"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="version"/> is <see cref="string.Empty"/> string.</exception>
    /// <seealso cref="IDetectorRequest.Header(string, object)"/>
    public static IDetectorRequest OperaMini(this IDetectorRequest request, string version)
    {
      Assertion.NotNull(request);
      Assertion.NotEmpty(version);

      return request.Header("x-operamini-phone-ua", version);
    }

    /// <summary>
    ///   <para>Adds set of headers for HTTP request that indicates a mobile profile of the target device.</para>
    ///   <para>The following HTTP headers are set : "profile", "wap-profile", "x-wap-profile".</para>
    /// </summary>
    /// <param name="request">Instance of request to Yandex.Detector service.</param>
    /// <param name="profile">Value of HTTP mobile profile headers.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="request"/> or <paramref name="profile"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="profile"/> is <see cref="string.Empty"/> string.</exception>
    /// <seealso cref="IDetectorRequest.Header(string, object)"/>
    public static IDetectorRequest Profile(this IDetectorRequest request, string profile)
    {
      Assertion.NotNull(request);
      Assertion.NotEmpty(profile);

      request.Header("profile", profile);
      request.Header("wap-profile", profile);
      request.Header("x-wap-profile", profile);

      return request;
    }

    /// <summary>
    ///   <para>Adds new "user-agent" header for HTTP request that identifies a target mobile device.</para>
    /// </summary>
    /// <param name="request">Instance of request to Yandex.Detector service.</param>
    /// <param name="userAgent">Value of User-agent header.</param>
    /// <returns>Back reference to the provided <paramref name="request"/> instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="request"/> or <paramref name="userAgent"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="userAgent"/> is <see cref="string.Empty"/> string.</exception>
    /// <seealso cref="IDetectorRequest.Header(string, object)"/>
    public static IDetectorRequest UserAgent(this IDetectorRequest request, string userAgent)
    {
      Assertion.NotNull(request);
      Assertion.NotEmpty(userAgent);

      return request.Header("user-agent", userAgent);
    }
  }
}