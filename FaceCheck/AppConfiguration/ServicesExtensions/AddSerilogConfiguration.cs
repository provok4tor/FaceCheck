3 lines (21 sloc)  679 Bytes

using Serilog;

namespace FaceCheck.AppConfiguration.ServicesExtensions
{
    public static partial class ServicesExtensions
    {
        /// <summary>
        /// Add serilog configuration
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSerilogConfiguration(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
            });

            builder.Services.AddHttpContextAccessor();
        }
    }
}