using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GreenDot.API.ValueProviders
{
    public class CommaSeparatedQueryStringConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            foreach (var parameter in action.Parameters)
            {
                if (parameter.Attributes.OfType<CommaSeparatedAttribute>().Any() &&
                    !parameter.Action.Filters.OfType<CommaSeparatedQueryStringAttribute>().Any())
                {
                    parameter.Action.Filters.Add(new CommaSeparatedQueryStringAttribute(parameter.ParameterName));
                }
            }
        }
    }
}