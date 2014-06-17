using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="MobileDevice"/>.</para>
  /// </summary>
  public sealed class MobileDeviceTests : UnitTestsBase<MobileDevice>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var device = new MobileDevice();
      var xml = XDocument.Parse(device.Xml());
      Assert.Equal("yandex-mobile-info", xml.Root.Name);
      Assert.Equal("0", xml.Root.Element("screenx").Value);
      Assert.Equal("0", xml.Root.Element("screeny").Value);
      Assert.Equal(device, device.Xml().Xml<MobileDevice>());

      device = new MobileDevice
      {
        Description = "Java MIDP2 (small)",
        DeviceClass = "midp2ss",
        JavaPlatform = new JavaPlatform
        {
          Camera = true,
          Certificate = "Thawte",
          FileSystem = true,
          IconSize = "18x18"
        },
        Name = "One Touch C651",
        ScreenHeight = 160,
        ScreenWidth = 128,
        Vendor = "Alcatel"
      };
      xml = XDocument.Parse(device.Xml());
      Assert.Equal("yandex-mobile-info", xml.Root.Name);
      Assert.Equal("One Touch C651", xml.Root.Element("name").Value);
      Assert.Equal("Alcatel", xml.Root.Element("vendor").Value);
      Assert.Equal("midp2ss", xml.Root.Element("device-class").Value);
      Assert.Equal("128", xml.Root.Element("screenx").Value);
      Assert.Equal("160", xml.Root.Element("screeny").Value);
      var java = xml.Root.Element("java");
      Assert.Equal("1", java.Element("cam-access").Value);
      Assert.Equal("1", java.Element("fs-access").Value);
      Assert.Equal("Thawte", java.Element("certificate-prefix").Value);
      Assert.Equal("18x18", java.Element("iconsize").Value);
      Assert.Equal(device, device.Xml().Xml<MobileDevice>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="MobileDevice()"/>
    [Fact]
    public void Constructors()
    {
      var device = new MobileDevice();
      Assert.Null(device.Description);
      Assert.Null(device.DeviceClass);
      Assert.Null(device.Java);
      Assert.Null(device.Name);
      Assert.Equal(0, device.ScreenHeight);
      Assert.Equal(0, device.ScreenWidth);
      Assert.Null(device.Vendor);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="MobileDevice.Equals(MobileDevice)"/></description></item>
    ///     <item><description><see cref="MobileDevice.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Method()
    {
      this.TestEquality("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MobileDevice.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="MobileDevice.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new MobileDevice { Name = "name" }.ToString());
    }
  }
}