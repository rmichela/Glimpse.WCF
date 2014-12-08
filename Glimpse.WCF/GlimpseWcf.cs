using Glimpse.WCF.Extensibility;

namespace Glimpse.WCF
{
    public static class GlimpseWcf
    {
        /// <summary>
        /// Call this at application initialize in WCF-only projects.
        /// </summary>
        public static void Initialize()
        {
            GlimpseWcfConfigShim.Register();
        }
    }
}
