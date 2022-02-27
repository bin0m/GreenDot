﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;

namespace GreenDot.API.ValueProviders
{
    public class SeparatedQueryStringValueProvider : QueryStringValueProvider
    {
        private readonly HashSet<string> _keys;
        private readonly string _separator;

        public SeparatedQueryStringValueProvider(IQueryCollection values, CultureInfo culture)
            : base(null, values, culture)
        {
        }

        public SeparatedQueryStringValueProvider(string key, IQueryCollection values, string separator)
            : this(new List<string> { key }, values, separator)
        {
        }

        public SeparatedQueryStringValueProvider(IEnumerable<string> keys, IQueryCollection values, string separator)
            : base(BindingSource.Query, values, CultureInfo.InvariantCulture)
        {
            _keys = new HashSet<string>(keys);
            _separator = separator;
        }

        public override ValueProviderResult GetValue(string key)
        {
            var result = base.GetValue(key);

            if (_keys != null && !_keys.Contains(key)) return result;

            if (result == ValueProviderResult.None ||
                !result.Values.Any(x => x.IndexOf(_separator, StringComparison.OrdinalIgnoreCase) > 0))
            {
                return result;
            }

            var splitValues = new StringValues(result.Values
                .SelectMany(x => x.Split(new[] { _separator }, StringSplitOptions.None))
                .ToArray());

            return new ValueProviderResult(splitValues, result.Culture);
        }
    }
}