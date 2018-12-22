namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Mobile Java platform capabilities.</para>
  /// </summary>
  public interface IJavaPlatform
  {
    /// <summary>
    ///   <para>Whether Java applications have access to device's camera.</para>
    /// </summary>
    bool Camera { get; }

    /// <summary>
    ///   <para>Prefix of Java certificate.</para>
    /// </summary>
    string Certificate { get; }

    /// <summary>
    ///   <para>Whether Java applications have access to device's filesystem.</para>
    /// </summary>
    bool FileSystem { get; }

    /// <summary>
    ///   <para>Height of Java applications icons.</para>
    /// </summary>
    short IconHeight { get; }

    /// <summary>
    ///   <para>Width of Java applications icons.</para>
    /// </summary>
    short IconWidth { get; }
  }
}