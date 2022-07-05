using Grpc.Core;
using System.Threading.Tasks;
using XTC.FMP.MOD.StartKit.LIB.Proto;

namespace XTC.FMP.MOD.StartKit.LIB.Service
{
    public class HealthyService : HealthyBaseService
    {
        public override Task<EchoResponse> Echo(EchoRequest _request, ServerCallContext _context)
        {
            return Task.FromResult(new EchoResponse
            {
                Status = new Proto.Status() { Code = 0, Message = "" },
                Msg = _request.Msg,
            });
        }
    }
}
