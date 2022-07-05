using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyModel : HealthyBaseModel
    {
        public const string NAME = "XTC.FMP.MOD.StartKit.LIB.MVCS.HealthyModel";

        public class HealthyStatus : Model.Status
        {
        }

        public HealthyModel(string _uid) : base(_uid)
        {
        }

        protected HealthyStatus? status
        {
            get
            {
                return status_ as HealthyStatus;
            }
        }

        protected override void preSetup()
        {
            base.preSetup();

            Error err;
            status_ = spawnStatus<HealthyStatus>(this.getUID() + ".Status", out err);
            if (0 != err.getCode())
            {
                getLogger()?.Error(err.getMessage());
            }
            else
            {
                getLogger()?.Trace("setup {0}", this.getUID() + ".Status");
            }
        }


    }
}
