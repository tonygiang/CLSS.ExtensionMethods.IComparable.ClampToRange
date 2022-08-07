// A part of the C# Language Syntactic Sugar suite.

using System;

namespace CLSS
{
  public static partial class IComparableClampToRange1
  {
    /// <summary>
    /// Returns the specified lower bound if the source value is lower than the
    /// lower bound, the specified upper bound if the source value is higher
    /// than the upper bound, or the source value if it fails both condition.
    /// </summary>
    /// <typeparam name="T">The <see cref="IComparable{T}"/> type of the values
    /// being clamped.</typeparam>
    /// <param name="value">The value being clamped into in a range.</param>
    /// <param name="min">The lower bound to check
    /// <paramref name="value"/> against.</param>
    /// <param name="max">The exclusive upper bound to check
    /// <paramref name="value"/> against.</param>
    /// <returns>The source value clamped to the specifed range.</returns>
    public static T ClampToRange<T>(this T value, T min, T max)
      where T : IComparable<T>
    {
      return value.CompareTo(min) < 0 ? min :
        value.CompareTo(max) > 0 ? max :
        value;
    }

#if NETSTANDARD2_0_OR_GREATER
    /// <inheritdoc cref="IComparableClampToRange1.ClampToRange{T}(T, T, T)"/>
    /// <param name="range">A range struct containing the lower and upper bounds
    /// to check <paramref name="value"/> against.</param>
    public static T ClampToRange<T>(this T value, ValueRange<T> range)
      where T : IComparable<T>
    { return value.ClampToRange(range.Min, range.Max); }
#endif
  }

  public static partial class IComparableClampToRange2
  {
    /// <inheritdoc cref="IComparableClampToRange1.ClampToRange{T}(T, T, T)"/>
    public static T ClampToRange<T>(this T value, T min, T max)
      where T : IComparable
    {
      return value.CompareTo(min) < 0 ? min :
        value.CompareTo(max) > 0 ? max :
        value;
    }
  }
}