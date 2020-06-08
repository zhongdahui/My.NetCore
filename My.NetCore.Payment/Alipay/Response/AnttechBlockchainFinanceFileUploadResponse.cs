using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AnttechBlockchainFinanceFileUploadResponse.
    /// </summary>
    public class AnttechBlockchainFinanceFileUploadResponse : AlipayResponse
    {
        /// <summary>
        /// 上传成功后返回文件信息
        /// </summary>
        [JsonPropertyName("file_info")]
        public FinanceFileInfo FileInfo { get; set; }
    }
}
