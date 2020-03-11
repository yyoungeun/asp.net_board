﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace DotNetNote.Models
{
    public enum ContentEncodingType
    {
        ///<summary>
        /// 입력한 소스 그대로 표시(태그 실행하지 않음)
        /// </summary>
        Text,
        ///<summary>
        /// HTML로 실행
        /// </summary>
        Html,
        ///<summary>
        /// HTML로 실행 + 엔터키(\r\n)적용됨
        /// </summary>
        Mixed
    }
}