using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseController : Controller
    {
        public HealthyBaseController(string _uid):base(_uid)
        {

        }

        protected HealthyView? view_ { get; set; }

        protected override void preSetup()
        {
            view_ = findView(HealthyView.NAME) as HealthyView;
        }

        protected override void setup()
        {
        }
    }
}
