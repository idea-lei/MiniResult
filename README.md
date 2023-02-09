# Mini Result

A mini (can not be smaller anymore) class to represent local action result. You can consider this as local version of ActionResult that does not involve http status.

## Usage
This Package is available for .NET 6 and above.

### Non-Generic Result Class
``` C#
using SimpleResult;

Result.Ok(string? message);

// You must specify a reason of failure
Result.Failed(string message);
```

### Generic Result Class
The generic Result class is to allow you to additionally return a object.
``` C#
using SimpleResult;

Result<T>.Ok(T obj, string? message);

// You must specify a reason of failure
// No target object will be returned (otherwise makes non sense)
Result<T>.Failed(string message);

// This is usually used in the call-chain when a method failed.
result.ToNonGenericResult()
```
:coffee: [Buy me a coffee](https://www.buymeacoffee.com/idealei) :smiling_face_with_three_hearts: