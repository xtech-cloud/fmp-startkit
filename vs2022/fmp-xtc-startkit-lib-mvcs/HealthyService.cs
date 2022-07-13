
namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    /// <summary>
    /// Healthy服务层
    /// </summary>
    public class HealthyService : HealthyBaseService
    {
        /// <summary>
        /// 完整名称
        /// </summary>
        public const string NAME = "XTC.FMP.MOD.StartKit.LIB.MVCS.HealthyService";

        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        public HealthyService(string _uid) : base(_uid)
        {
        }
    }
}
