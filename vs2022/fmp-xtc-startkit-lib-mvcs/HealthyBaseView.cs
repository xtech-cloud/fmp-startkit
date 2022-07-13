
//*************************************************************************************
//   !!! Generated by the fmp-cli.  DO NOT EDIT!
//*************************************************************************************

using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.Bridge;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    /// <summary>
    /// Healthy视图层基类
    /// </summary>
    public class HealthyBaseView : View
    {
        /// <summary>
        /// 带uid参数的构造函数
        /// </summary>
        /// <param name="_uid">实例化后的唯一识别码</param>
        public HealthyBaseView(string _uid) : base(_uid)
        {

        }


        /// <summary>
        /// 刷新Echo的数据
        /// </summary>
        /// <param name="_err">错误</param>
        /// <param name="_dto">EchoResponse的数据传输对象</param>
        public void RefreshProtoEcho(Error _err, EchoResponseDTO _dto)
        {
            var bridge = getFacade()?.getUiBridge() as IHealthyUiBridge; 
            if (!Error.IsOK(_err))
            {
                bridge?.Alert(string.Format("errcode_Echo_{0}", _err.getCode()), _err.getMessage());
                return;
            }
            bridge?.RefreshEcho(_dto);
        }


        /// <summary>
        /// 获取直系数据层
        /// </summary>
        /// <returns>数据层</returns>
        protected HealthyModel? getModel()
        {
            if(null == model_)
                model_ = findModel(HealthyModel.NAME) as HealthyModel;
            return model_;
        }

        /// <summary>
        /// 获取直系服务层
        /// </summary>
        /// <returns>服务层</returns>
        protected HealthyService? getService()
        {
            if(null == service_)
                service_ = findService(HealthyService.NAME) as HealthyService;
            return service_;
        }

        /// <summary>
        /// 获取直系UI装饰层
        /// </summary>
        /// <returns>UI装饰层</returns>
        protected HealthyFacade? getFacade()
        {
            if(null == facade_)
                facade_ = findFacade(HealthyFacade.NAME) as HealthyFacade;
            return facade_;
        }

        /// <summary>
        /// 直系数据层
        /// </summary>
        private HealthyModel? model_;

        /// <summary>
        /// 直系服务层
        /// </summary>
        private HealthyService? service_;

        /// <summary>
        /// 直系UI装饰层
        /// </summary>
        private HealthyFacade? facade_;
    }
}

