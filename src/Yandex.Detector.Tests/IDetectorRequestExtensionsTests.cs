using System;
using System.Linq;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDetectorRequestExtensions"/>.</para>
  /// </summary>
  public sealed class IDetectorRequestExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDetectorRequestExtensions.OperaMini(IDetectorRequest, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void OperaMini_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDetectorRequestExtensions.OperaMini(null, "version"));
      Assert.Throws<ArgumentNullException>(() => new DetectorRequest().OperaMini(null));
      Assert.Throws<ArgumentException>(() => new DetectorRequest().OperaMini(string.Empty));

      var request = new DetectorRequest();
      Assert.True(ReferenceEquals(request, request.OperaMini("version")));
      Assert.Equal(1, request.Headers.Count());
      Assert.Equal("x-operamini-phone-ua", request.Headers.FirstOrDefault().Key);
      Assert.Equal("version", request.Headers.FirstOrDefault().Value);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDetectorRequestExtensions.Profile(IDetectorRequest, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Profile_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDetectorRequestExtensions.Profile(null, "profile"));
      Assert.Throws<ArgumentNullException>(() => new DetectorRequest().Profile(null));
      Assert.Throws<ArgumentException>(() => new DetectorRequest().Profile(string.Empty));

      var builder = new DetectorRequest();
      Assert.True(ReferenceEquals(builder, builder.Profile("profile")));
      Assert.Equal(3, builder.Headers.Count());
      Assert.Equal("profile", builder.Headers.ElementAt(0).Key);
      Assert.Equal("profile", builder.Headers.ElementAt(0).Value);
      Assert.Equal("wap-profile", builder.Headers.ElementAt(1).Key);
      Assert.Equal("profile", builder.Headers.ElementAt(1).Value);
      Assert.Equal("x-wap-profile", builder.Headers.ElementAt(2).Key);
      Assert.Equal("profile", builder.Headers.ElementAt(2).Value);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IDetectorRequestExtensions.UserAgent(IDetectorRequest, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void UserAgent_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDetectorRequestExtensions.UserAgent(null, "userAgent"));
      Assert.Throws<ArgumentNullException>(() => new DetectorRequest().UserAgent(null));
      Assert.Throws<ArgumentException>(() => new DetectorRequest().UserAgent(string.Empty));

      var builder = new DetectorRequest();
      Assert.True(ReferenceEquals(builder, builder.UserAgent("userAgent")));
      Assert.Equal(1, builder.Headers.Count());
      Assert.Equal("user-agent", builder.Headers.FirstOrDefault().Key);
      Assert.Equal("userAgent", builder.Headers.FirstOrDefault().Value);
    }
  }
}