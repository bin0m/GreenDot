using System;

namespace GreenDot.API.ValueProviders
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class CommaSeparatedAttribute : Attribute
    {
    }
}