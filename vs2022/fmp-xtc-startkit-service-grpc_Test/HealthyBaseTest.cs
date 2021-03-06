
//*************************************************************************************
//   !!! Generated by the fmp-cli.  DO NOT EDIT!
//*************************************************************************************

using XTC.FMP.MOD.StartKit.LIB.Proto;
using XTC.FMP.MOD.StartKit.App.Service;

public class HealthyBaseTest
{

    [Fact]
    public virtual async Task EchoTest()
    {
        var service = new HealthyService();
        var request = new EchoRequest();
        var response = await service.Echo(request, TestServerCallContext.Create());
        Assert.Equal(0, response.Status.Code);
    }

}
