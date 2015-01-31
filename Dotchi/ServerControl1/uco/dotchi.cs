using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using util.uco.model.dotchi;

namespace util.uco
{
    public class dotchi
    {
        /// <summary>
        /// 儲存會員資料
        /// </summary>
        public bool SaveMember(MemberInfo memberinfo)
        {
            return dao.dotchi.SaveMember(memberinfo);
        }
        /// <summary>
        /// 取得會員資訊
        /// </summary>
        public MemberInfo QueryMember(string ID)
        {
            return dao.dotchi.QueryMember(ID);
        }
    }
}