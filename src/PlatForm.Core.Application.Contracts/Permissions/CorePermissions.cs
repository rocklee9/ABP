namespace PlatForm.Core.Permissions
{
    public static class CorePermissions
    {
        public const string GroupName = "Core";
        public const string GroupNameCommon = "Common";

        public class BoPhan
        {
            public const string Default = GroupNameCommon + ".BoPhan";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class NhanVien
        {
            public const string Default = GroupNameCommon + ".NhanVien";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}