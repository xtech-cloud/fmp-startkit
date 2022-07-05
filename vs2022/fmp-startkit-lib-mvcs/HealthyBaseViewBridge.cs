using System.Threading.Tasks;
using XTC.FMP.MOD.StartKit.LIB.Bridge;
using XTC.FMP.MOD.StartKit.LIB.Proto;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseViewBridge : IHealthyViewBridge
    {
        public HealthyService? service { get; set; }
        public async Task OnEchoSubmit(IDTO _dto)
        {
            EchoResponseDTO? dto = _dto as EchoResponseDTO;
            var request = new EchoRequest();
            request.Msg = dto?.msg??"";
            await service.CallEcho(request);
        }
    }
}
