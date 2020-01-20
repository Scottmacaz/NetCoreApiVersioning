# NetCoreApiVersioning
A sample application using swagger and .NET API versioning

# Recommended Changes to API
* Create standard error response across all endpoints

# Notes

* In V3 WidgetName was changed to Name. Note that in a real app automapper would most likely be used to not break the API. The domain would change to "Name" but the API would retain, and map, the updated "Name" back to "WidgetName" so the API wouldn't break and the version of the API would not have to change.


* Options for versioning:
	1. URL
	2. Query String
	3. Header

*Permit adding of new fields without changing version.  Make sure API documentation states this so that clients no to ignore unrecognized fields.
* Version only needs to change when API breaks:  Removing fields, renaming fields, changing data types, etc.
* Supporting a non-versioned route will require a separate controller with a separate route.


Resources:
[.NET Core api versioning nuget package] https://github.com/Microsoft/aspnet-api-versioning/wiki
[Sample versioning app] https://github.com/microsoft/aspnet-api-versioning
[Microsoft best practices for REST] https://github.com/Microsoft/api-guidelines
[Article on best practices] https://dotnetdetail.net/asp-net-core-3-0-web-api-versioning-best-practices/
