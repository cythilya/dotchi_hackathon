using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
//using util.lib;
//using util.uco.model.hty;

namespace ServerControl1.uco.dao
{
    class dotchi
    {
        //fb 註冊為會員
        internal static bool SaveAnswer(string member_id, List<Answer> answers)
        {
            string sql = @"
insert into hty.answer
(member_id, quiz_id, opt_id)
values
(@member_id, @quiz_id{0}, @opt_id{0})
";
            List<SqlCommand> cmds = new List<SqlCommand>();
            foreach (Answer a in answers)
            {
                for (int i = 0; i < a.OptionID.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(string.Format(sql, i.ToString()));

                    cmd.Parameters.AddWithValue("@member_id", member_id);
                    cmd.Parameters.AddWithValue(string.Format("@member_id{0}", i.ToString()), member_id);
                    cmd.Parameters.AddWithValue(string.Format("@quiz_id{0}", i.ToString()), a.QuestionID);
                    cmd.Parameters.AddWithValue(string.Format("@opt_id{0}", i.ToString()), a.OptionID[i]);

                    cmds.Add(cmd);
                }
            }

            Sql u = new Sql();
            return u.ExecSQLs(cmds) == cmds.Count;
        }

    }
}
