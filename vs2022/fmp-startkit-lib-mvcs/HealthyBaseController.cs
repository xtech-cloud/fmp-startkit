using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseController : Controller
    {
        public HealthyBaseController(string _uid) : base(_uid)
        {

        }

        protected HealthyView? view_
        {
            get
            {
                return findView(HealthyView.NAME) as HealthyView;
            }
        }

    }
}
