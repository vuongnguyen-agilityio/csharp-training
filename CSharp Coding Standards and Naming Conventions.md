# C# Coding Standards and Naming Conventions

| Object Name               | Capitalization | Length | Plural | Prefix | Suffix | Abbreviation |
|:--------------------------|:---------------|-------:|:-------|:-------|:-------|:-------------|
| Namespace name            | PascalCase     |    128 | Ye     | **Yes**| No     | No           |
| Class name                | PascalCase     |    128 | **No** | No     | **Yes**| No           |
| Constructor name          | PascalCase     |    128 | **No** | No     | **Yes**| No           |
| Method name               | PascalCase     |    128 | Yes    | No     | No     | No           |
| Method arguments          | **camelCase**  |    128 | Yes    | No     | No     | Yes          |
| Local variables           | **camelCase**  |     50 | Yes    | No     | No     | Yes          |
| Constants name            | PascalCase     |     50 | **No** | No     | No     | No           |
| Field name Public         | PascalCase     |     50 | Yes    | No     | No     | Yes          |
| Field name Private        | **_camelCase** |     50 | Yes    | No     | No     | Yes          |
| Properties name           | PascalCase     |     50 | Yes    | No     | No     | Yes          |
| Delegate name             | PascalCase     |    128 | **No** | No     | **Yes**| Yes          |
| Enum type name            | PascalCase     |    128 | Yes    | No     | No     | No           |

1. Do use PascalCasing for **class names** and **method names**:

```csharp
public class ClientActivity
{
  // Do
  public void ClearStatistics() {}
  // Don't
  public void clearStatistics() {}
}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read.***

2. Do use camelCasing for **method arguments** and **local variables**:

```csharp
public class UserLog
{
  public void Add(LogEvent logEvent)
  {
    // logEvent: method argument
    // itemCount: local variable
    int itemCount = logEvent.Items.Count;
  }
}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read.***

3. Avoid using Abbreviations. Exceptions: abbreviations commonly used as names, such as Id, Xml, Ftp, Uri.

```csharp
// Correct
UserGroup userGroup;
Assignment employeeAssignment;

// Avoid
UserGroup usrGrp;
Assignment empAssignment;

// Exceptions
CustomerId customerId;
XmlDocument xmlDocument;
FtpHelper ftpHelper;
UriPart uriPart;
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and prevents inconsistent abbreviations.***


4. Do use PascalCasing or camelCasing (Depending on the identifier type) for abbreviations 3 characters or more (2 chars are both uppercase when PascalCasing is appropriate or inside the identifier).:

```csharp
HtmlHelper htmlHelper;
FtpTransfer ftpTransfer, fastFtpTransfer;
UIControl uiControl, nextUIControl;
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework. Caps would grab visually too much attention.***

5. Do use predefined type names (C# aliases) like `int`, `float`, `string` for local, parameter and member declarations. Do use .NET Framework names like `Int32`, `Single`, `String` when accessing the type's static members like `Int32.TryParse` or `String.Join`.

```csharp
// csharp
string firstName;
int lastIndex;
bool isSaved;
string commaSeparatedNames = String.Join(", ", names);
int index = Int32.Parse(input);

// .Net Framework but Avoid in csharp
String firstName;
Int32 lastIndex;
Boolean isSaved;
string commaSeparatedNames = string.Join(", ", names);
int index = int.Parse(input);
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and makes code more natural to read.***

6. Do use implicit type **var** for local variable declarations. Exception: primitive types (int, string, double, etc) use predefined names.

```csharp
// Using var for local variable declarations
// Complex generic types
var stream = File.Create(path);
var customers = new Dictionary();

// Exceptions for primitive types
int index = 100;
string timeSheet;
bool isCompleted;
```

⚠️ ***Why: removes clutter, particularly with complex generic types. Type is easily detected with Visual Studio tooltips.***

7. Do use noun or noun phrases to name a class.

```csharp
public class Employee {}
public class BusinessLocation {}
public class DocumentCollection {}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to remember.***

8. Do prefix interfaces with the letter "I". Interface names are noun (phrases) or adjectives.

```csharp
public interface IShape {}
public interface IShapeCollection {}
public interface IGroupable {}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework.***


9. Do declare all member variables at the top of a class, with static variables at the very top.

```csharp
// Correct
public class Account
{
  public static string BankName;
  public static decimal Reserves;

  public string Number { get; set; }
  public DateTime DateOpened { get; set; }
  public DateTime DateClosed { get; set; }
  public decimal Balance { get; set; }

  // Constructor
  public Account() {}
}
```

⚠️ ***Why: generally accepted practice that prevents the need to hunt for variable declarations.***

10. Do use singular names for enums. Exception: bit field enums.

```csharp
// Correct
public enum Color
{
  Red,
  Green,
  Blue,
  Yellow,
  Magenta,
  Cyan
}

// Exception: bit field enums
[Flags]
public enum Dockings
{
  None = 0,
  Top = 1,
  Right = 2,
  Bottom = 4,
  Left = 8
}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and makes the code more natural to read. Plural flags because enum can hold multiple values (using bitwise 'OR').***

11. Do use suffix EventArgs at creation of the new classes comprising the information on event:

```csharp
// Correct
public class BarcodeReadEventArgs : System.EventArgs {}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read.***

12. Do name event handlers (delegates used as types of events) with the "EventHandler" suffix, as shown in the following example:

```csharp
public delegate void ReadBarcodeEventHandler(object sender, ReadBarcodeEventArgs e);
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read.***

13. DO use two parameters named "sender" and e in event handlers. The "sender parameter" represents the object that raised the event. The sender parameter is typically of type object, even if it is possible to employ a more specific type.

```csharp
public void ReadBarcodeEventHandler(object sender, ReadBarcodeEventArgs e) {}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and consistent with prior rule of no type indicators in identifiers.***

14. Do use suffix Exception at creation of the new classes comprising the information on exception:

```csharp
// Correct
public class BarcodeReadException : System.Exception {}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read.***

15. Do use prefix Any, Is, Have or similar keywords for boolean identifier:

```csharp
// Correct
public static bool IsNullOrEmpty(string value) {
  return (value == null || value.Length == 0);
}
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read.***

16. Use Named Arguments in method calls:
When calling a method, arguments are passed with the parameter name followed by a colon and a value.

```csharp
// Method
public void DoSomething(string foo, int bar) {}

// Avoid
DoSomething("someString", 1);

// Correct
DoSomething(foo: "someString", bar: 1);
```

⚠️ ***Why: consistent with the Microsoft's .NET Framework and easy to read. In Named Arguments, we do not need to pass the parameters in order as defined on method definition, so we can pass the arguments in any order on method calling.***

## Official Reference

1. [MSDN General Naming Conventions](http://msdn.microsoft.com/en-us/library/ms229045(v=vs.110).aspx)
2. [DoFactory C# Coding Standards and Naming Conventions](http://www.dofactory.com/reference/csharp-coding-standards)
3. [MSDN Naming Guidelines](http://msdn.microsoft.com/en-us/library/xzf533w0%28v=vs.71%29.aspx)
4. [MSDN Framework Design Guidelines](http://msdn.microsoft.com/en-us/library/ms229042.aspx)
5. [Common C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
6. [Github C# Coding Style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md)