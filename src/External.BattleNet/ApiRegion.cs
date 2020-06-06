namespace LaDanse.External.BattleNet.Abstractions
{
    public sealed class ApiRegion
    {
        public static ApiRegion Us = new ApiRegion("us");
        public static ApiRegion Eu = new ApiRegion("eu");
        public static ApiRegion Kr = new ApiRegion("kr");
        public static ApiRegion Tw = new ApiRegion("tw");
        public static ApiRegion Cn = new ApiRegion("cn");

        public string RegionId { get; internal set; }

        private ApiRegion(string regionId)
        {
            RegionId = regionId;
        }
    }
}
