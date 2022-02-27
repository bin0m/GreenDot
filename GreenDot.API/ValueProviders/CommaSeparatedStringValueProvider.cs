using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;

namespace GreenDot.API.ValueProviders
{
    public class CommaSeparatedQueryStringValueProvider : QueryStringValueProvider
    {
        private const string Separator = ",";
        private readonly string _key;
        private readonly IQueryCollection _values;

        public CommaSeparatedQueryStringValueProvider(string key, IQueryCollection values) 
            : base(BindingSource.Query, values, CultureInfo.InvariantCulture)
        {
            _key = key;
            _values = values;
        }

        public override ValueProviderResult GetValue(string key)
        {
            var result = base.GetValue(key);
            if (_key != null && _key != key)
            {
                return result;
            }

            if (result == ValueProviderResult.None ||
                !result.Values.Any(val => val.IndexOf(Separator, StringComparison.OrdinalIgnoreCase) > 0))
            {
                return result;
            }

            var splitValues = new StringValues(
                result.Values.SelectMany(val => val.Split(new[] {Separator}, StringSplitOptions.None)).ToArray()
            );

            return new ValueProviderResult(splitValues);
        }
    }
}