using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Contains information about mobile device and its features and capabilities.</para>
  /// </summary>
  [XmlType("yandex-mobile-info")]
  public sealed class MobileDevice : IEquatable<MobileDevice>, IMobileDevice
  {
    /// <summary>
    ///   <para>Description of device's class.</para>
    /// </summary>
    [XmlElement("device-class-desc")]
    public string Description { get; set; }

    /// <summary>
    ///   <para>Class of devices.</para>
    /// </summary>
    [XmlElement("device-class")]
    public string DeviceClass { get; set; }

    /// <summary>
    ///   <para>Device's installed Java platform capabilities.</para>
    /// </summary>
    [XmlIgnore]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IJavaPlatform Java
    {
      get { return this.JavaPlatform; }
    }

    /// <summary>
    ///   <para>Device's installed Java platform capabilities.</para>
    /// </summary>
    [XmlElement("java")]
    public JavaPlatform JavaPlatform { get; set; }

    /// <summary>
    ///   <para>Device's model name.</para>
    /// </summary>
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>Device's screen vertical height (px).</para>
    /// </summary>
    [XmlElement("screeny")]
    public short ScreenHeight { get; set; }

    /// <summary>
    ///   <para>Device's screen horizontal width (px).</para>
    /// </summary>
    [XmlElement("screenx")]
    public short ScreenWidth { get; set; }

    /// <summary>
    ///   <para>Name of device's vendor.</para>
    /// </summary>
    [XmlElement("vendor")]
    public string Vendor { get; set; }

    /// <summary>
    ///   <para>Returns class of devices as instance of <see cref="MobileDevicesClass"/> enumeration.</para>
    /// </summary>
    /// <returns>Class of devices.</returns>
    public MobileDevicesClass GetDeviceClass()
    {
      return Enum.Parse(typeof(MobileDevicesClass), this.DeviceClass, true).To<MobileDevicesClass>();
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="MobileDevice"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(MobileDevice other)
    {
      return this.Equality(other, x => x.Name);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as MobileDevice);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(x => x.Name);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="MobileDevice"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="MobileDevice"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}