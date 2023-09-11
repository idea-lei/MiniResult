# Mini Result

A mini (can not be smaller anymore) class to represent local action result. You can consider this as local version of ActionResult that does not involve http status.

**Breaking change:** between version 1.0.2 and 1.1.0: .net standard 2.0 does not officially support nullable.

## Usage
This Package is available for .NET standard 2.0 and above.

In Package-Manager:
``` 
Install-Package MiniResult
```

### Non-Generic Result Class
``` C#
using MiniResult;

Result.Ok(string message);

// You must specify a reason of failure
Result.Failed(string message);
```

### Generic Result Class
The generic Result class is to allow you to additionally return a object.
``` C#
using MiniResult;

return Result<T>.Ok(T obj, string message);

// Or just return the object of type T (this will have no message)
return obj;
```

On Failure
``` C#
You must specify a reason of failure

// No target object will be returned (otherwise makes non sense)
return Result<T>.Failed(string message);

// This is usually used in the call-chain when a method failed.
return result.ToNonGenericResult()
```
:coffee: [Buy me a coffee](https://www.buymeacoffee.com/idealei)