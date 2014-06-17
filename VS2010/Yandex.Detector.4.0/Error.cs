using System;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Yandex.Detector
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  [XmlType("yandex-mobile-info-error")]
  public sealed class Error : IEquatable<Error>
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    [XmlText]
    public string Text { get; set; }

    public bool Equals(Error other)
    {
      return this.Equality(other, error => error.Text);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Error);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(error => error.Text);
    }

    public override string ToString()
    {
      return this.Text;
    }
  }
}