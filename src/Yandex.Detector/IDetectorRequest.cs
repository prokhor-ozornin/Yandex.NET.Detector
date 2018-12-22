using System;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Represents a configurable request to the Yandex.Detector service.</para>
  /// </summary>
  public interface IDetectorRequest
  {
    /// <summary>
    ///   <para>Add new mobile device header for HTTP request, or replaces an existing one.</para>
    /// </summary>
    /// <param name="name">Name of the header.</param>
    /// <param name="value">Value of the header.</param>
    /// <returns>Back reference to the current request instance.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    IDetectorRequest Header(string name, object value);
  }
}