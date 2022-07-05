using System.Threading.Tasks;
using Grpc.Net.Client;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.Proto;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseService : Service
    {
        protected Healthy.HealthyClient? healthyClient_;
        protected GrpcChannel? grpcChannel_;

        protected HealthyModel? model_
        {
            get
            {
                return findModel(HealthyModel.NAME) as HealthyModel;
            }
        }

        public HealthyBaseService(string _uid) : base(_uid)
        {

        }

        public void InjectGrpcChannel(GrpcChannel? _channel)
        {
            grpcChannel_ = _channel;
        }


        protected Healthy.HealthyClient? getGrpcClient()
        {
            if (null == grpcChannel_)
                return null;

            if(null == healthyClient_)
            {
                healthyClient_ = new Healthy.HealthyClient(grpcChannel_);
            }
            return healthyClient_;
        }


        public async Task CallEcho(EchoRequest _request)
        {
            var client = getGrpcClient();
            if (null == client)
                return;
            var response = await client.EchoAsync(_request);
            model_?.ReceiveEcho(response);
        }

    }
}
