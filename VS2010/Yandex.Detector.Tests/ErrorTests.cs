using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Error"/>.</para>
  /// </summary>
  public sealed class ErrorTests
  {
    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Error()"/>
    [Fact]
    public void Constructors()
    {
      var error = new Error();
      Assert.Null(error.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Error.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Equal("text", new Error { Text = "text" }.Text);
    }
  }
}