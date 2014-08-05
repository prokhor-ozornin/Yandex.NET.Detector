using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para>Mobile Java platform capabilities.</para>
  /// </summary>
  [XmlType("java")]
  public sealed class JavaPlatform : IEquatable<IJavaPlatform>, IJavaPlatform
  {
    /// <summary>
    ///   <para>Whether Java applications have access to device's camera.</para>
    /// </summary>
    [XmlIgnore]
    public bool Camera { get; set; }

    /// <summary>
    ///   <para>Whether Java applications have access to device's camera.</para>
    /// </summary>
    [XmlElement("cam-access")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte CameraAccess
    {
      get { return this.Camera ? (byte) 1 : (byte) 0; }
      set { this.Camera = value > 0; }
    }

    /// <summary>
    ///   <para>Prefix of Java certificate.</para>
    /// </summary>
    [XmlElement("certificate-prefix")]
    public string Certificate { get; set; }

    /// <summary>
    ///   <para>Whether Java applications have access to device's filesystem.</para>
    /// </summary>
    [XmlIgnore]
    public bool FileSystem { get; set; }

    /// <summary>
    ///   <para>Whether Java applications have access to device's filesystem.</para>
    /// </summary>
    [XmlElement("fs-access")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public byte FileSystemAccess
    {
      get { return this.FileSystem ? (byte)1 : (byte)0; }
      set { this.FileSystem = value > 0; }
    }

    /// <summary>
    ///   <para>Size of Java applications icons (width x height).</para>
    /// </summary>
    [XmlElement("iconsize")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string IconSize
    {
      get { return string.Format("{0}x{1}", this.IconWidth, this.IconHeight); }
      set
      {
        var dimensions = value.Split('x');
        this.IconWidth = dimensions[0].ToInt16();
        this.IconHeight = dimensions[1].ToInt16();
      }
    }

    /// <summary>
    ///   <para>Height of Java applications icons.</para>
    /// </summary>
    public short IconHeight { get; set; }

    /// <summary>
    ///   <para>Width of Java applications icons.</para>
    /// </summary>
    public short IconWidth { get; set; }

    /// <summary>
    ///   <para>Determines whether two <see cref="IJavaPlatform"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(IJavaPlatform other)
    {
      return this.Equality(other, java => java.Camera, java => java.Certificate, java => java.FileSystem, java => java.IconHeight, java => java.IconWidth);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as IJavaPlatform);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(java => java.Camera, java => java.Certificate, java => java.FileSystem, java => java.IconHeight, java => java.IconWidth);
    }
  }
}