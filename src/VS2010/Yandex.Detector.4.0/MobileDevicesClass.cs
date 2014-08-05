using System.ComponentModel;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Well-known classes of mobile devices.</para>
  /// </summary>
  public enum MobileDevicesClass
  {
    /// <summary>
    ///   <para>Symbian UIQ2.</para>
    /// </summary>
    [Description("Symbian UIQ2")]
    UIQ2,

    /// <summary>
    ///   <para>Symbian UIQ3.</para>
    /// </summary>
    [Description("Symbian UIQ3")]
    UIQ3,

    /// <summary>
    ///   <para>Symbian S60v1.</para>
    /// </summary>
    [Description("Symbian S60v1")]
    S60v1,

    /// <summary>
    ///   <para>Symbian S60v2.</para>
    /// </summary>
    [Description("Symbian S60v2")]
    S60v2,

    /// <summary>
    ///   <para>Symbian S60v3.</para>
    /// </summary>
    [Description("Symbian S60v3")]
    S60v3,

    /// <summary>
    ///   <para>Symbian S60v5.</para>
    /// </summary>
    [Description("Symbian S60v5")]
    S60v5,

    /// <summary>
    ///   <para>Microsoft Windows Mobile 2003 Smartphone edition.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile 2003 Smartphone edition")]
    WM4SP,

    /// <summary>
    ///   <para>Microsoft Windows Mobile 2003 Pocket PC edition.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile 2003 Pocket PC edition")]
    WM4PPC,

    /// <summary>
    ///   <para>Microsoft Windows Mobile 2005 Smartphone edition.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile 2005 Smartphone edition")]
    WM5SP,

    /// <summary>
    ///   <para>Microsoft Windows Mobile 2005 Pocket PC edition.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile 2005 Pocket PC edition")]
    WM5PPC,

    /// <summary>
    ///   <para>Microsoft Windows Mobile 2006 Smartphone edition.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile 2006 Smartphone edition")]
    WM6SP,

    /// <summary>
    ///   <para>Microsoft Windows Mobile 2006 Pocket PC edition.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile 2006 Pocket PC edition")]
    WM6PPC,

    /// <summary>
    ///   <para>Microsoft Windows Mobile Generic.</para>
    /// </summary>
    [Description("Microsoft Windows Mobile Generic")]
    WMGeneric,

    /// <summary>
    ///   <para>Java MIDP2 (small).</para>
    /// </summary>
    [Description("Java MIDP2 (small)")]
    MIDP2ss,

    /// <summary>
    ///   <para>Java MIDP2 (big).</para>
    /// </summary>
    [Description("Java MIDP2 (big)")]
    MIDP2bs,

    /// <summary>
    ///   <para>Java MIDP2 (huge).</para>
    /// </summary>
    [Description("Java MIDP2 (huge)")]
    midp2hs,

    /// <summary>
    ///   <para>Java MIDP2 (small + bluetooth).</para>
    /// </summary>
    [Description("Java MIDP2 (small + bluetooth)")]
    MIDP2ssg,

    /// <summary>
    ///   <para>Java MIDP2 (big + bluetooth).</para>
    /// </summary>
    [Description("Java MIDP2 (big + bluetooth)")]
    MIDP2bsg,

    /// <summary>
    ///   <para>Java MIDP2 (huge + bluetooth).</para>
    /// </summary>
    [Description("Java MIDP2 (huge + bluetooth)")]
    MIDP2hsg,
    
    /// <summary>
    ///   <para>Java MIDP2 (lite).</para>
    /// </summary>
    [Description("Java MIDP2 (lite)")]
    MIDP2lite,

    /// <summary>
    ///   <para>Java MIDP2 (lite + bluetooth).</para>
    /// </summary>
    [Description("Java MIDP2 (lite + bluetooth)")]
    MIDP2LiteG,

    /// <summary>
    ///   <para>Google Android OS.</para>
    /// </summary>
    [Description("Google Android OS")]
    Android,

    /// <summary>
    ///   <para>Blackberry OS.</para>
    /// </summary>
    [Description("Blackberry OS")]
    Rim,

    /// <summary>
    ///   <para>Apple iPhone OS.</para>
    /// </summary>
    [Description("Apple iPhone OS")]
    IPhoneOS
  }
}