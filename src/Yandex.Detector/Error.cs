namespace Yandex.Detector
{
  using System;
  using System.Xml.Serialization;
  using Catharsis.Commons;

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

    /// <summary>
    ///   <para>Determines whether two <see cref="Error"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(Error other)
    {
      return this.Equality(other, error => error.Text);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return Equals(other as Error);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(error => error.Text);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Error"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Error"/>.</returns>
    public override string ToString()
    {
      return Text;
    }
  }
}