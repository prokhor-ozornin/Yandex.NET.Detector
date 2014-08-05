using System;
using System.Collections.Generic;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IMobileDetectorExtensions"/>.</para>
  /// </summary>
  public sealed class IMobileDetectorExtensionsTests
  {
    private const string UnknownUserAgentError = "Unknown user agent and wap profile";

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IMobileDetectorExtensions.Detect(IMobileDetector, Action{IDetectorRequest})"/></description></item>
    ///     <item><description><see cref="IMobileDetectorExtensions.Detect(IMobileDetector, IDictionary{string, object}, out IMobileDevice)"/></description></item>
    ///     <item><description><see cref="IMobileDetectorExtensions.Detect(IMobileDetector, Action{IDetectorRequest}, out IMobileDevice)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Detect_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => new MobileDetector().Detect((Action<IDetectorRequest>) null));

      IMobileDevice device;
      Assert.Throws<ArgumentNullException>(() => new MobileDetector().Detect((IDictionary<string, object>) null, out device));
      Assert.Throws<ArgumentNullException>(() => new MobileDetector().Detect((Action<IDetectorRequest>) null, out device));

      try
      {
        new MobileDetector().Detect(request => { });
        throw new InvalidOperationException();
      }
      catch (DetectorException exception)
      {
        Assert.Equal("No HTTP headers were specified", exception.Message);
        Assert.Null(exception.InnerException);
      }

      Assert.False(new MobileDetector().Detect(request => { }, out device));
      Assert.Null(device);

      try
      {
        new MobileDetector().Detect(request => request.Profile("invalid"));
        throw new InvalidOperationException();
      }
      catch (DetectorException exception)
      {
        Assert.Equal("Failed to understand service's response", exception.Message);
        Assert.True(exception.InnerException is InvalidOperationException);
      }

      Assert.False(new MobileDetector().Detect(request => request.Profile("invalid"), out device));
      Assert.Null(device);
      
      try
      {
        new MobileDetector().Detect(request => request.UserAgent("invalid"));
        throw new InvalidOperationException();
      }
      catch (DetectorException exception)
      {
        Assert.Equal("Unknown user agent and wap profile", exception.Message);
        Assert.Null(exception.InnerException);
      }

      Assert.False(new MobileDetector().Detect(request => request.UserAgent("invalid"), out device));
      Assert.Null(device);

      device = new MobileDetector().Detect(request => request.Profile("http://www-ccpp-mpd.alcatel.com/files/ALCATEL-CTH3_MMS10_1.0.rdf"));
      Assert.Equal("Java MIDP2 (small)", device.Description);
      Assert.Equal("midp2ss", device.DeviceClass);
      Assert.True(device.Java.Camera);
      Assert.Equal(string.Empty, device.Java.Certificate);
      Assert.True(device.Java.FileSystem);
      Assert.Equal(18, device.Java.IconHeight);
      Assert.Equal(18, device.Java.IconWidth);
      Assert.Equal("CTH3", device.Name);
      Assert.Equal(160, device.ScreenHeight);
      Assert.Equal(128, device.ScreenWidth);
      Assert.Equal("Alcatel", device.Vendor);

      Assert.True(new MobileDetector().Detect(request => request.Profile("http://www-ccpp-mpd.alcatel.com/files/ALCATEL-CTH3_MMS10_1.0.rdf"), out device));
      Assert.Equal("Java MIDP2 (small)", device.Description);
      Assert.Equal("midp2ss", device.DeviceClass);
      Assert.True(device.Java.Camera);
      Assert.Equal(string.Empty, device.Java.Certificate);
      Assert.True(device.Java.FileSystem);
      Assert.Equal(18, device.Java.IconHeight);
      Assert.Equal(18, device.Java.IconWidth);
      Assert.Equal("CTH3", device.Name);
      Assert.Equal(160, device.ScreenHeight);
      Assert.Equal(128, device.ScreenWidth);
      Assert.Equal("Alcatel", device.Vendor);

      device = new MobileDetector().Detect(request => request.UserAgent("Alcatel-CTH3/1.0 UP.Browser/6.2.ALCATEL MMP/1.0"));
      Assert.Equal("Java MIDP2 (small)", device.Description);
      Assert.Equal("midp2ss", device.DeviceClass);
      Assert.True(device.Java.Camera);
      Assert.Equal(string.Empty, device.Java.Certificate);
      Assert.True(device.Java.FileSystem);
      Assert.Equal(18, device.Java.IconHeight);
      Assert.Equal(18, device.Java.IconWidth);
      Assert.Equal("One Touch C651", device.Name);
      Assert.Equal(160, device.ScreenHeight);
      Assert.Equal(128, device.ScreenWidth);
      Assert.Equal("Alcatel", device.Vendor);

      Assert.True(new MobileDetector().Detect(request => request.UserAgent("Alcatel-CTH3/1.0 UP.Browser/6.2.ALCATEL MMP/1.0"), out device));
      Assert.Equal("Java MIDP2 (small)", device.Description);
      Assert.Equal("midp2ss", device.DeviceClass);
      Assert.True(device.Java.Camera);
      Assert.Equal(string.Empty, device.Java.Certificate);
      Assert.True(device.Java.FileSystem);
      Assert.Equal(18, device.Java.IconHeight);
      Assert.Equal(18, device.Java.IconWidth);
      Assert.Equal("One Touch C651", device.Name);
      Assert.Equal(160, device.ScreenHeight);
      Assert.Equal(128, device.ScreenWidth);
      Assert.Equal("Alcatel", device.Vendor);
    }
  }
}