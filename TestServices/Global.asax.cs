using System;
using Glimpse.WCF;
using Newtonsoft.Json.Glimpse;

namespace GlimpseServices
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlimpseWcf.Initialize();
            GlimpseJson.Initialize();
        }
    }
}