
using Microsoft.AspNetCore.Components;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.Proto;
using XTC.FMP.MOD.StartKit.LIB.Bridge;
using XTC.FMP.MOD.StartKit.LIB.MVCS;

namespace XTC.FMP.MOD.StartKit.LIB.Razor
{
    public partial class HealthyComponent
    {
        public class HealthyUiBridge : IHealthyUiBridge
        {

            public HealthyUiBridge(HealthyComponent _razor)
            {
                razor_ = _razor;
            }

            public void Alert(string _code, string _message)
            {
                if (null == razor_.messageService_)
                    return;
                Task.Run(async () =>
                {
                    await razor_.messageService_.Success(_message);
                }); 
            }


            public void RefreshEcho(IDTO _dto)
            {
                var dto = _dto as EchoResponseDTO;
                razor_.__debugEcho = dto?.message.ToString();
            }


            private HealthyComponent razor_;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task __debugClick()
        {
            var bridge = (getFacade()?.getViewBridge() as IHealthyViewBridge);
            if (null == bridge)
            {
                logger_?.Error("bridge is null");
                return;
            }

            var reqEcho = new EchoRequest();
            var dtoEcho = new EchoRequestDTO(reqEcho);
            logger_?.Trace("invoke OnEchoSubmit");
            await bridge.OnEchoSubmit(dtoEcho);

        }


        private string? __debugEcho;

    }
}
