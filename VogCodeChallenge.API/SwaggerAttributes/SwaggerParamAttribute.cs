using System;

namespace VogCodeChallenge.API.SwaggerAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SwaggerParamAttribute : Attribute
    {
        public SwaggerParamAttribute(string name, string @in)
        {
            this.Name = name;
            this.In = @in;
            this.Required = false;
            this.Description = string.Empty;
            this.Schema = string.Empty;
        }

        public string Name { get; private set; }

        public string In { get; private set; }

        public bool Required { get; set; }

        public string DataType { get; set; }

        public string Description { get; set; }

        public string Schema { get; set; }
    }
}
