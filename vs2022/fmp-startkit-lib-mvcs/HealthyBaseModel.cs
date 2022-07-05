using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseModel : Model
    {
        public HealthyBaseModel(string _uid) : base(_uid)
        {

        }

        protected HealthyController? controller_ { get; set; }

        protected override void preSetup()
        {
            controller_ = findController(HealthyController.NAME) as HealthyController;
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(this.getUID() + ".Status", out err);
            if (0 != err.getCode())
            {
                getLogger()?.Error(err.getMessage());
            }
        }

        public void ReceiveEcho(Proto.EchoResponse _response)
        {
            this.Bubble("/XTC/StartKit/Healthy/Echo", _response);
        }
    }
}
