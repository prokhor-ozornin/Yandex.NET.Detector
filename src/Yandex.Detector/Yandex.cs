namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Entry point for Yandex.Detector web service's access.</para>
  /// </summary>
  /// <seealso cref="http://api.yandex.ru/detector"/>
  public static class Yandex
  {
    private static readonly IMobileDetector detector = new MobileDetector();

    /// <summary>
    ///   <para>Returns detector's instance to query Yandex.Detector service.</para>
    /// </summary>
    public static IMobileDetector Detector
    {
      get { return detector; }
    }
  }
}