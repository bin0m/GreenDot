using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GreenDot.API.ValueProviders
{
    public class CommaSeparatedQueryStringConvention : IActionModelConvention
    {
        private const string Separator = ",";

        public void Apply(ActionModel action)
        {
            SeparatedQueryStringAttribute attribute = null;
            foreach (var parameter in action.Parameters)
            {
                if (parameter.Attributes.OfType<CommaSeparatedAttribute>().Any())
                {
                    if (attribute == null)
                    {
                        attribute = new SeparatedQueryStringAttribute(Separator);
                        parameter.Action.Filters.Add(attribute);
                    }

                    attribute.AddKey(parameter.ParameterName);
                }
            }
        }
    }
}