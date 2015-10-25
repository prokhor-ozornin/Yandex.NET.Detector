using System;
using System.Collections.Generic;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="MobileDetector"/>.</para>
  /// </summary>
  public sealed class MobileDetectorTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="MobileDetector.Detect(IDictionary{string, object})"/> method.</para>
    /// </summary>
    [Fact]
    public async void Detect_Method()
    {
      await Assert.ThrowsAsync<ArgumentNullException>(() => new MobileDetector().Detect((IDictionary<string, object>) null));

      try
      {
        await new MobileDetector().Detect(new Dictionary<string, object>());
        throw new InvalidOperationException();
      }
      catch (DetectorException exception)
      {
        Assert.Equal("No HTTP headers were specified", exception.Message);
        Assert.Null(exception.InnerException);
      }

      try
      {
        await new MobileDetector().Detect(new Dictionary<string, object> { { "wap-profile", "invalid" } });
        throw new InvalidOperationException();
      }
      catch (DetectorException exception)
      {
        Assert.Equal("Failed to understand service's response", exception.Message);
        Assert.True(exception.InnerException is InvalidOperationException);
      }

      try
      {
        await new MobileDetector().Detect(new Dictionary<string, object> { { "user-agent", "invalid" } });
        throw new InvalidOperationException();
      }
      catch (DetectorException exception)
      {
        Assert.Equal("Unknown user agent and wap profile", exception.Message);
        Assert.Null(exception.InnerException);
      }

      var device = await new MobileDetector().Detect(new Dictionary<string, object> { { "wap-profile", "http://www-ccpp-mpd.alcatel.com/files/ALCATEL-CTH3_MMS10_1.0.rdf" } });
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

      device = await new MobileDetector().Detect(new Dictionary<string, object> { { "user-agent", "Alcatel-CTH3/1.0 UP.Browser/6.2.ALCATEL MMP/1.0" } });
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