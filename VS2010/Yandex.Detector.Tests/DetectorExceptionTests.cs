using System;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DetectorException"/>.</para>
  /// </summary>
  public sealed class DetectorExceptionTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DetectorException(string, Exception)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new DetectorException(null));
      Assert.Throws<ArgumentException>(() => new DetectorException(string.Empty));

      var innerException = new Exception();
      var exception = new DetectorException("message", innerException);
      Assert.True(ReferenceEquals(exception.InnerException, innerException));
      Assert.Equal("message", exception.Message);
    }
  }
}