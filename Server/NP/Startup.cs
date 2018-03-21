using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NP.Interface;
using NP.OutputPayment;
using NP.Model;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        static public IConfiguration Configuration { get; private set;  }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("NPPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Converters = new List<JsonConverter> { new DecimalConverter() }
            };

            services.AddMvc();
            //    .AddJsonOptions(opt =>
            //{
            //    opt.SerializerSettings.Converters.Add( new DecimalConverter() );
            //    //opt.SerializerSettings.Culture = new CultureInfo("en-US", true);
            //    //opt.SerializerSettings.FloatParseHandling = FloatParseHandling.Decimal;
            //});
            services.AddApiVersioning();

            services.AddTransient<IOutputPayment, FileOutputPayment>();

            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("NPPolicy");

            Variables.CurrentFolder = env.ContentRootPath;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    class DecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(decimal?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                return token.ToObject<decimal>();
            }
            if (token.Type == JTokenType.String)
            {
                return Decimal.Parse(token.ToString(),
                       System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            }
            if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
            {
                return null;
            }
            throw new JsonSerializationException("Unknown token type: " + token.Type.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Decimal? d = default(Decimal?);
            if (value != null)
            {
                d = value as Decimal?;
                if (d.HasValue) // If value was a decimal?, then this is possible
                {
                    d = new Decimal?(new Decimal(Decimal.ToDouble(d.Value))); // The ToDouble-conversion removes all unnessecary precision
                }
            }
            JToken.FromObject(d).WriteTo(writer);
        }
    }
}
