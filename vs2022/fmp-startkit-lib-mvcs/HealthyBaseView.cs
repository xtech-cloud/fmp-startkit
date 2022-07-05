﻿using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.Bridge;
using XTC.FMP.MOD.StartKit.LIB.Proto;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseView : View
    {
        protected Facade? facade_;
        protected HealthyModel? model_;
        protected HealthyService? service_;

        public HealthyBaseView(string _uid) : base(_uid)
        {

        }

        protected override void preSetup()
        {
            facade_ = findFacade(HealthyFacade.NAME) as HealthyFacade;
            model_ = findModel(HealthyModel.NAME) as HealthyModel;
            service_ = findService(HealthyService.NAME) as HealthyService;
        }

        protected override void setup()
        {
            addObserver(model_?.getUID()??"" , "/XTC/StartKit/Healthy/Echo", this.handleHealthyEcho);
        }

        protected override void postSetup()
        {
            /*
            bridge_ = facade_.getUiBridge() as IHealthyUiBridge;
            object rootPanel = bridge_.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.startkit.Healthy"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
            */
        }

        private void handleHealthyEcho(Model.Status? _status, object _data)
        {
            var bridge= facade_?.getUiBridge() as IHealthyUiBridge;
            if (null == bridge)
                return;

            EchoResponse? response = _data as EchoResponse;
            if(null == response)
            {
                bridge?.Alert("data_is_null", "Data is null");
                return;
            }

            if (0!= response.Status.Code)
            {
                bridge?.Alert(string.Format("code_is_{0}", response.Status.Code), response.Status.Message);
                return;
            }
            EchoResponseDTO dto = new EchoResponseDTO();
            dto.msg = response.Msg;
            bridge.RefreshEcho(dto);
        }

    }
}