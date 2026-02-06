using Microsoft.IdentityModel.Tokens;

namespace DevNet.Middleware
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;
        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var userCulturev = "UserCulture";   
            var language = context.Request.Cookies[userCulturev];
            Console.WriteLine("Selected Language: " + language);
            if (string.IsNullOrEmpty(language))
            {
                 language = "en";
            }
                var culture = new System.Globalization.CultureInfo(language);
                System.Globalization.CultureInfo.CurrentCulture = culture;
                System.Globalization.CultureInfo.CurrentUICulture = culture;
            Console.WriteLine("Current Culture: " + System.Globalization.CultureInfo.CurrentCulture.Name);
            await _next(context);
        }
    }
}
