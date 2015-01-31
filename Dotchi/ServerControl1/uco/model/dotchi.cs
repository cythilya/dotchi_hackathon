using System.Collections.Generic;

namespace util.uco.model.dotchi
{
    /// <summary>
    /// 會員資料
    /// </summary>
    public class Member
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
