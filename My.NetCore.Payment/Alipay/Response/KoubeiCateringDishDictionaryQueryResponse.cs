﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringDishDictionaryQueryResponse.
    /// </summary>
    public class KoubeiCateringDishDictionaryQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 返回的字典数据列表
        /// </summary>
        [JsonPropertyName("kb_dish_dictionary_list")]
        public List<KbdishDictionary> KbDishDictionaryList { get; set; }
    }
}
