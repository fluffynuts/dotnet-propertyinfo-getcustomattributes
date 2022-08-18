// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.Reflection;

var prop = typeof(DerivedType).GetProperty(nameof(DerivedType.Id));
var unspecified = prop.GetCustomAttributes().Select(a => a.GetType().Name).ToArray();
var inheritTrue = prop.GetCustomAttributes(true).Select(a => a.GetType().Name).ToArray();
var inheritFalse = prop.GetCustomAttributes(false).Select(a => a.GetType().Name).ToArray();

Console.WriteLine($"default: {string.Join(",", unspecified)}");
Console.WriteLine($"inherit == true: {string.Join(",", inheritTrue)}");
Console.WriteLine($"inherit == false: {string.Join(",", inheritFalse)}");

public class BaseType
{
    [BaseProperty]
    public virtual int Id { get; set; }
}

public class DerivedType : BaseType
{
    [DerivedProperty]
    public override int Id { get; set; }
}

public class BasePropertyAttribute : Attribute
{
}
public class DerivedPropertyAttribute : Attribute
{
}