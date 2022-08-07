# CLSS.ExtensionMethods.IComparable.ClampToRange

### Problem

The process to clamp a value to a range is somewhat long:

```
if (value < min) value = min;
else if (value > max) value = max;
```

Even longer when the type of your value does not implement comparison operators:

```
// Type of meetingDate is System.DateTime
if (meetingDate.CompareTo(startDate) < 0) meetingDate = startDate;
else if (meetingDate.CompareTo(endDate) > 0) meetingDate = endDate;
```

The [`System.Math.Clamp`](https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp?view=net-6.0) method can do this operation in one line, but it only supports a limited number of primitive types. Types such as [`System.Version`](https://docs.microsoft.com/en-us/dotnet/api/system.version?view=net-6.0) and [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0) are not supported.

### Solution

`ClampToRange` does this in a more intuitive, shorter and functional style friendly way:

```
using CLSS;

value = value.ClampToRange(min, max);
```

No more short stops in your code reading to decode the meanings of comparison operators. When you read `ClampToRange`, you know what it's doing.

`ClampToRange` has a wider range of supported types than `System.Math.Clamp`. It supports all [`IComparable`](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable?view=net-6.0) and [`IComparable<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-6.0) types.

```
using CLSS;

// System.DateTime implements IComparable<T>
meetingDate = meetingDate.ClampToRange(startDate, endDate);
```

`ClampToRange` can also take in CLSS type [`ValueRange`](https://www.nuget.org/packages/CLSS.Types.ValueRange) on .NET Standard 2.0 or higher.

```
using CLSS;

var displayableRange = new ValueRange(0, 9999);
int value = value.ClampToRange(displayableRange);
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).