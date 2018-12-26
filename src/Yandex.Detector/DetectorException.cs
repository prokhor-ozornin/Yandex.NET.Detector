namespace Yandex.Detector
{
  using System;
  using Catharsis.Commons;

  /// <summary>
  ///   <para>Represent error that occurs during execution of request to Yandex.Detector service.</para>
  /// </summary>
  public sealed class DetectorException : Exception
  {
    /// <summary>
    ///   <para>Initializes a new instance exception with a specified error message and a reference to the inner exception that is the cause of this exception.</para>
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="message"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="message"/> is <see cref="string.Empty"/> string.</exception>
    public DetectorException(string message, Exception innerException = null) : base(message, innerException)
    {
      Assertion.NotEmpty(message);
    }
  }
}