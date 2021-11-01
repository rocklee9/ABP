using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Demo.Web.Bundling
{
    public class ScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // AdminLTE
            context.Files.Add("/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
            context.Files.Add("/plugins/chart.js/Chart.min.js");
            context.Files.Add("/themes/adminlte/js/adminlte.js");
            context.Files.Add("/themes/adminlte/js/layout.js");

            // App scripts
            context.Files.AddIfNotContains("/js/app/consts.js");
            context.Files.AddIfNotContains("/js/app/messages.js");
            context.Files.AddIfNotContains("/js/app/scripts.js");

            context.Files.AddIfNotContains("/js/Demo/messages.js");
            context.Files.AddIfNotContains("/js/Demo/scripts.js");
            context.Files.AddIfNotContains("/libs/daterangepicker/moment.min.js");
            context.Files.AddIfNotContains("/libs/daterangepicker/daterangepicker.js");

        }
    }
}
