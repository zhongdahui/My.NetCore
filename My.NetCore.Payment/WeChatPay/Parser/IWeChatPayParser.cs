namespace My.NetCore.Payment.WeChatPay.Parser
{
    public interface IWeChatPayParser<T> where T : WeChatPayObject
    {
        T Parse(string body);

        T Parse(string body, string data);
    }
}
