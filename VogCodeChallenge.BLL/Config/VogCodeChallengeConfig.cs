namespace VogCodeChallenge.BLL.Config
{
    public class VogCodeChallengeConfig : IVogCodeChallengeConfig
    {
        public VogCodeChallengeConfig()
        {
        }

        public VogCodeChallengeConfig(bool enableDBConnectivity)
        {
            this.EnableDBConnectivity = enableDBConnectivity;
        }

        public bool EnableDBConnectivity { get; set; }
    }
}
