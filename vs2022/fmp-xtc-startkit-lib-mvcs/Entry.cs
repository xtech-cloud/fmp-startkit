
using XTC.FMP.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    /// <summary>
    /// 模块入口
    /// </summary>
    public class Entry : BaseEntry
    {

        /// <summary>
        /// 静态注册
        /// </summary>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        public Error StaticRegister(Logger? _logger)
        {
            return base.staticRegister(_logger);
        }

        /// <summary>
        /// 动态注册
        /// </summary>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        public Error DynamicRegister(Logger _logger)
        {
            return base.dynamicRegister(_logger);
        }

        /// <summary>
        /// 静态注销
        /// </summary>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        public Error StaticCancel(Logger _logger)
        {
            return base.staticCancel(_logger);
        }

        /// <summary>
        /// 动态注销
        /// </summary>
        /// <param name="_logger">日志</param>
        /// <returns>错误</returns>
        public Error DynamicCancel(Logger _logger)
        {
            return base.dynamicCancel(_logger);
        }
    }
}

