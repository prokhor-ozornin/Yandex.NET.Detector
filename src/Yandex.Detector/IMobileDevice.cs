namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Contains information about mobile device and its features and capabilities.</para>
  /// </summary>
  public interface IMobileDevice
  {
    /// <summary>
    ///   <para>Description of device's class.</para>
    /// </summary>
    string Description { get; }

    /// <summary>
    ///   <para>Class of devices.</para>
    /// </summary>
    string DeviceClass { get; }

    /// <summary>
    ///   <para>Device's installed Java platform capabilities.</para>
    /// </summary>
    IJavaPlatform Java { get; }

    /// <summary>
    ///   <para>Device's model name.</para>
    /// </summary>
    string Name { get; }

    /// <summary>
    ///   <para>Device's screen vertical height (px).</para>
    /// </summary>
    short ScreenHeight { get; }

    /// <summary>
    ///   <para>Device's screen horizontal width (px).</para>
    /// </summary>
    short ScreenWidth { get; }

    /// <summary>
    ///   <para>Name of device's vendor.</para>
    /// </summary>
    string Vendor { get; }
  }
}