using System.Web.Http;
using System.Web.Mvc;

namespace DemoWebAPIWithSwagger.Areas.HelpPage
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class HelpPageAreaRegistration : AreaRegistration
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override string AreaName
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            get
            {
                return "HelpPage";
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override void RegisterArea(AreaRegistrationContext context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}