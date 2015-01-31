using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using util.uco.model.dotchi;

namespace util.uco
{
    class class dotchi
    {
        /// <summary>
        /// 問卷答案
        /// </summary>
        public class Answer
        {
            /// <summary>
            /// 問題代號
            /// </summary>
            public string QuestionID { get; set; }
            /// <summary>
            /// 選擇的選項代號
            /// </summary>
            public List<string> OptionID { get; set; }
        }
    }
}