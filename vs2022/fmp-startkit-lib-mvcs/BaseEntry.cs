using Grpc.Net.Client;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.Bridge;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class Options
    {
        public GrpcChannel? channel;
    }

    public class BaseEntry
    {
        protected HealthyFacade? facade_;
        protected HealthyModel? model_;
        protected HealthyView? view_;
        protected HealthyController? controller_;
        protected HealthyService? service_;
        protected Options? options_;

        public HealthyFacade? getFacade()
        {
            return facade_;
        }

        public void Inject(Framework _framework, Options _options)
        {
            framework_ = _framework;
            options_ = _options;
        }


        public Error Register()
        {
            if (null == framework_)
                return Error.NewNullErr("framework is null");

           
            // 注册数据层
            model_ = new HealthyModel(HealthyModel.NAME);
            framework_.getStaticPipe().RegisterModel(model_);
            // 注册视图层
            view_ = new HealthyView(HealthyView.NAME);
            framework_.getStaticPipe().RegisterView(view_);
            // 注册控制层
            controller_ = new HealthyController(HealthyController.NAME);
            framework_.getStaticPipe().RegisterController(controller_);
            // 注册服务层
            service_ = new HealthyService(HealthyService.NAME);
            framework_.getStaticPipe().RegisterService(service_);
            service_.InjectGrpcChannel(options_?.channel);
            // 注册UI装饰层
            facade_ = new HealthyFacade(HealthyFacade.NAME);
            var bridge = new HealthyViewBridge();
            bridge.service = service_;
            facade_.setViewBridge(bridge);
            framework_.getStaticPipe().RegisterFacade(facade_);

            return Error.OK;
        }

        public Error Cancel()
        {
            if (null == framework_)
                return Error.NewNullErr("framework is null");

            // 注销服务层
            framework_.getStaticPipe().CancelService(service_);
            // 注销控制层
            framework_.getStaticPipe().CancelController(controller_);
            // 注销视图层
            framework_.getStaticPipe().CancelView(view_);
            // 注销UI装饰层
            framework_.getStaticPipe().CancelFacade(facade_);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(model_);
            

            return Error.OK;
        }

        private Framework? framework_;
    }
}
