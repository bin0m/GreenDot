using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GreenDot.API.ValueProviders
{
    public class CommaSeparatedQueryStringAttribute : Attribute, IResourceFilter
    {
        private readonly string _key;
        private readonly CommaSeparatedQueryStringValueProviderFactory _factory;

        public CommaSeparatedQueryStringAttribute() : this(null)
        {
            
        }

        public CommaSeparatedQueryStringAttribute(string key)
        {
            _key = key;
            _factory = new CommaSeparatedQueryStringValueProviderFactory(key);
        }


        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.ValueProviderFactories.Insert(0, _factory);
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Method intentionally left empty.
        }
    }
}