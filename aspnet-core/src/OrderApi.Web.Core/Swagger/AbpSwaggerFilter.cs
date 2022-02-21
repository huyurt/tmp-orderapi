using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OrderApi.Web.Swagger
{
    public class AbpSwaggerFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var endpoints = new List<string>
            {
                "Musteri",
                "Sepet",
                "SepetUrun",
            };

            var abpRoutes = swaggerDoc.Paths.Where(x => !endpoints.Any(e => x.Key.Contains(e))).ToList();

            abpRoutes.ForEach(x => swaggerDoc.Paths.Remove(x.Key));
            
            var abpModels = context.SchemaRepository.Schemas.Keys.Where(key => !endpoints.Any(e => key.Contains(e)));
            
            abpModels.ForEach(key =>  context.SchemaRepository.Schemas.Remove(key));
        }
    }
}