using Xunit;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Yandex"/>.</para>
  /// </summary>
  public sealed class YandexTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="Yandex.Detector"/> property.</para>
    /// </summary>
    [Fact]
    public void Detector_Property()
    {
      Assert.NotNull(Yandex.Detector);
      Assert.True(ReferenceEquals(Yandex.Detector, Yandex.Detector));
    }
  }
}