﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMerchantDepartmentTreeQueryResponse.
    /// </summary>
    public class KoubeiMerchantDepartmentTreeQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 商户部门组织模型集合，根据返回的结果构造出商户的部门树
        /// </summary>
        [JsonPropertyName("department_dtos")]
        public List<DepartmentDTO> DepartmentDtos { get; set; }
    }
}
