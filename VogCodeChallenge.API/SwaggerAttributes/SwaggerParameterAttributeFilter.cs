using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace VogCodeChallenge.API.SwaggerAttributes
{
    public class SwaggerParameterAttributeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<SwaggerParamAttribute>();

            foreach (var attribute in attributes)
            {
                if (Enum.TryParse<ParameterLocation>(attribute.In, out ParameterLocation parameterLocation))
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = attribute.Name,
                        In = parameterLocation,
                        Description = attribute.Description,
                        Required = attribute.Required,
                        Schema = new OpenApiSchema()
                        {
                            Type = attribute.DataType
                        }
                    });
                }
                else
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = attribute.Name,
                        Description = attribute.Description,
                        Required = attribute.Required,
                        Schema = new OpenApiSchema()
                        {
                            Type = attribute.DataType
                        }
                    });
                }
            }
        }
    }
}
