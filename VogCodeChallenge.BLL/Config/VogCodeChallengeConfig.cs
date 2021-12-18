namespace VogCodeChallenge.BLL.Config
{
    public class VogCodeChallengeConfig : IVogCodeChallengeConfig
    {
        public VogCodeChallengeConfig()
        {
        }

        public VogCodeChallengeConfig(bool DBConnectivity)
        {
            this.DBConnectivity = DBConnectivity;
        }

        public bool DBConnectivity { get; set; }
    }
}
