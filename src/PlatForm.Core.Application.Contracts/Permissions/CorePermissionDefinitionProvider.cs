using PlatForm.Core.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;


namespace PlatForm.Core.Permissions
{
    public class CorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CorePermissions.GroupName);
            var myGroupCommon = context.AddGroup(CorePermissions.GroupNameCommon, L("Permission:Common"));

            var boPhanPermission = myGroupCommon.AddPermission(CorePermissions.BoPhan.Default, L("Permission:BoPhan"));
            boPhanPermission.AddChild(CorePermissions.BoPhan.Create, L("Permission:Create"));
            boPhanPermission.AddChild(CorePermissions.BoPhan.Update, L("Permission:Update"));
            boPhanPermission.AddChild(CorePermissions.BoPhan.Delete, L("Permission:Delete"));

            var nhanVienPermission = myGroupCommon.AddPermission(CorePermissions.NhanVien.Default, L("Permission:NhanVien"));
            nhanVienPermission.AddChild(CorePermissions.NhanVien.Create, L("Permission:Create"));
            nhanVienPermission.AddChild(CorePermissions.NhanVien.Update, L("Permission:Update"));
            nhanVienPermission.AddChild(CorePermissions.NhanVien.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CoreResource>(name);
        }
    }
}
