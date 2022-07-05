using System.Threading.Tasks;
using Grpc.Net.Client;
using XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.StartKit.LIB.Proto;

namespace XTC.FMP.MOD.StartKit.LIB.MVCS
{
    public class HealthyBaseService : Service
    {
        protected HealthyModel? model_;
        protected Healthy.HealthyClient? healthyClient_;
        protected GrpcChannel? grpcChannel_;

        public HealthyBaseService(string _uid) : base(_uid)
        {

        }

        public void InjectGrpcChannel(GrpcChannel? _channel)
        {
            grpcChannel_ = _channel;
        }

        protected override void preSetup()
        {
            model_ = findModel(HealthyModel.NAME) as HealthyModel;
        }

        protected override void setup()
        {
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
