using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GreenDot.API.ValueProviders
{
    public class CommaSeparatedQueryStringValueProviderFactory : IValueProviderFactory
    {
        private readonly string _key;

        public CommaSeparatedQueryStringValueProviderFactory() : this(null)
        {
        }

        public CommaSeparatedQueryStringValueProviderFactory(string key)
        {
            _key = key;
        }

        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
            context.ValueProviders.Insert(0, new CommaSeparatedQueryStringValueProvider(_key, context.ActionContext.HttpContext.Request.Query));
            return Task.CompletedTask;
        }
    }
}