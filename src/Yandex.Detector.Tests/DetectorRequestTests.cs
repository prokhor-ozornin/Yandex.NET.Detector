using System;
using System.Linq;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DetectorRequest"/>.</para>
  /// </summary>
  public sealed class DetectorRequestTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DetectorRequest()"/>
    [Fact]
    public void Constructors()
    {
      var builder = new DetectorRequest();
      Assert.Empty(builder.Headers);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DetectorRequest.Header(string, object)"/> method.</para>
    /// </summary>
    [Fact]
    public void Header_Method()
    {
      var builder = new DetectorRequest();
      Assert.Throws<ArgumentNullException>(() => builder.Header(null, "value"));
      Assert.Throws<ArgumentNullException>(() => builder.Header("name", null));
      Assert.Throws<ArgumentException>(() => builder.Header(string.Empty, "value"));

      Assert.True(ReferenceEquals(builder, builder.Header("header", "value")));
      Assert.Single(builder.Headers);
      Assert.Equal("header", builder.Headers.FirstOrDefault().Key);
      Assert.Equal("value", builder.Headers.FirstOrDefault().Value);
    }
  }
}