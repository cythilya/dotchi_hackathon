using System.Collections.Generic;

namespace util.uco.model.dotchi
{
    /// <summary>
    /// 會員資料
    /// </summary>
    public class MemberInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Image
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 朋友清單
        /// </summary>
        public List<FriendInfo> FriendDetail { get; set; }
    }

    public class FriendInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Thumbnail
        /// </summary>
        public string Thumbnail { get; set; }
    }
}
