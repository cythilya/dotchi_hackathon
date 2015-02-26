using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dotchi.Models
{
    public class Dotchi
    {
        public class ShopInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Rating { get; set; }
            public int Checkin { get; set; }
            public string Cover { get; set; }
            public List<FriendInfo> FriendDetail { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string OpenTime { get; set; }
            public string Price { get; set; }
            public string Website { get; set; }
            public List<Comment> CommentList {get; set;}
        }
        
        public class FriendInfo
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Thumbnail { get; set; }
        }

        public class Comment 
        {
            public string ID { get; set; }
            public DateTime Time { get; set; }
            public string Image { get; set; }
            public string Text { get; set; }
            public UserInfo UserDetail { get; set; }
        }

        public class UserInfo
        {
            public string UserName {get; set;}
            public string UserImage { get; set; }
        }

        public class RecommendTag 
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Number { get; set; }
        }

        public class MemberInfo 
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public List<FriendInfo> FriendDetail{ get; set; }
        }

        public class SaveMemberInfo 
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
        }
    }
}