using System.Web;
using System.Configuration;

namespace util.lib
{
    public static class Config
    {
        public static string ConectionString
        {
            get {
                return "Data Source=b540e36a-f831-4378-8adb-a431008ad795.sqlserver.sequelizer.com;Initial Catalog=dbb540e36af83143788adba431008ad795;Persist Security Info=True;User ID=bkskubhskwdcpbmv;Password=3bZdjkUBLKGosSQfAVm34pBCEv7BDnhoWNmpNZgZLpUkDeAPmcLWXH5MGwEWmr6x;Asynchronous Processing=true";
            }
        }
    }
}