
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    /// <summary>
    /// Healthy数据层
    /// </summary>
    public class HealthyModel : HealthyBaseModel
    {
        /// <summary>
        /// 完整名称
        /// </summary>
        public const string NAME = "XTC.FMP.MOD.StartKit.LIB.MVCS.HealthyModel";

        /// <summary>
        /// Healthy状态
        /// </summary>
        public class HealthyStatus : Model.Status
        {
        }

        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        public HealthyModel(string _uid) : base(_uid)
        {
        }

        protected override void preSetup()
        {
            base.preSetup();

            // 实例化直系状态
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

        protected override void preDismantle()
        {
            base.preDismantle();

            // 销毁直系状态
            Error err;
            killStatus(this.getUID() + ".Status", out err);
            if (0 != err.getCode())
            {
                getLogger()?.Error(err.getMessage());
            }
        }

    }
}


