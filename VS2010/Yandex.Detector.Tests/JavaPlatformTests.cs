using System.Xml.Linq;
using Catharsis.Commons;
using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="JavaPlatform"/>.</para>
  /// </summary>
  public sealed class JavaPlatformTests : UnitTestsBase<JavaPlatform>
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var java = new JavaPlatform();
      var xml = XDocument.Parse(java.Xml());
      Assert.Equal("java", xml.Root.Name);
      Assert.Equal("0", xml.Root.Element("cam-access").Value);
      Assert.Equal("0", xml.Root.Element("fs-access").Value);
      Assert.Null(xml.Root.Element("certificate-prefix"));
      Assert.Equal("0x0", xml.Root.Element("iconsize").Value);
      Assert.Equal(java, java.Xml().Xml<JavaPlatform>());

      java = new JavaPlatform
      {
        Camera = true,
        Certificate = "Thawte",
        FileSystem = true,
        IconHeight = 16,
        IconWidth = 16
      };
      xml = XDocument.Parse(java.Xml());
      Assert.Equal("java", xml.Root.Name);
      Assert.Equal("1", xml.Root.Element("cam-access").Value);
      Assert.Equal("1", xml.Root.Element("fs-access").Value);
      Assert.Equal("Thawte", xml.Root.Element("certificate-prefix").Value);
      Assert.Equal("16x16", xml.Root.Element("iconsize").Value);
      Assert.Equal(java, java.Xml().Xml<JavaPlatform>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="JavaPlatform()"/>
    [Fact]
    public void Constructors()
    {
      var java = new JavaPlatform();
      Assert.False(java.Camera);
      Assert.Null(java.Certificate);
      Assert.False(java.FileSystem);
      Assert.Equal(0, java.IconHeight);
      Assert.Equal(0, java.IconWidth);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="JavaPlatform.Equals(JavaPlatform)"/></description></item>
    ///     <item><description><see cref="JavaPlatform.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Method()
    {
      this.TestEquality("Camera", true, false);
      this.TestEquality("Certificate", "first", "second");
      this.TestEquality("FileSystem", true, false);
      this.TestEquality("IconSize", "16x16", "32x32");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="JavaPlatform.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Camera", true, false);
      this.TestHashCode("Certificate", "first", "second");
      this.TestHashCode("FileSystem", true, false);
      this.TestHashCode("IconSize", "16x16", "32x32");
    }
  }
}