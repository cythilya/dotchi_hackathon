using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using util.lib;
using util.uco.model.dotchi;

namespace util.uco.dao
{
    public class dotchi
    {
        //fb 註冊為會員
        internal static bool SaveMember(MemberInfo memberinfo)
        {
            string sql = @"
insert into member
(ID, Name, Image)
values
(@id, @Name, @Image)
";
            Sql u = new Sql();
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@id", memberinfo.ID);
                cmd.Parameters.AddWithValue("@Name", memberinfo.Name);
                cmd.Parameters.AddWithValue("@Image", memberinfo.Image);
                return u.ExecSQL(cmd) == 1;
            }
        }

    }
}
