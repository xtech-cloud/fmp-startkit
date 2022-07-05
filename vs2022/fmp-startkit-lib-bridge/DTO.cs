namespace XTC.FMP.MOD.StartKit.LIB.Bridge
{
    /// <summary>
    /// 数据传输对象
    /// </summary>
    public interface IDTO
    {
    }

    public class EchoRequestDTO : IDTO
    {
        public string? msg { get; set; }
    }

    public class EchoResponseDTO : IDTO
    {
        public string? msg { get; set; }
    }
}
