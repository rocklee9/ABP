using System.Threading.Tasks;
using PlatForm.Core.Localization;
using PlatForm.Core.Permissions;
using Volo.Abp.UI.Navigation;

namespace PlatForm.Core.Web.Menus
{
    public class CoreMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<CoreResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(CoreMenus.Home, l["Menu:Home"], "/"));
            context.Menu.AddItem(new ApplicationMenuItem("TongQuan", "Tổng quan", url: "/#", icon: "fa fa-signal", order: 1, cssClass: "tongQuan"));

            var boPhan = await context.IsGrantedAsync(CorePermissions.BoPhan.Default);
            if (boPhan)
            {
                context.Menu.AddItem(new ApplicationMenuItem("BoPhan", "Bộ phận", icon: "fa fa-circle", order: 2, url: "/Commons/BoPhan"));
            }

            var nhanVien = await context.IsGrantedAsync(CorePermissions.NhanVien.Default);
            if (nhanVien)
            {
                context.Menu.AddItem(new ApplicationMenuItem("NhanVien", "Nhân viên", icon: "fa fa-users", order: 3, url: "/Commons/NhanVien"));
            } 
        }
    }
}
