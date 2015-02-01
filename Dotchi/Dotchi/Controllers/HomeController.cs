using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dotchi.Models;

namespace Dotchi.Controllers
{
    public class HomeController : Controller
    {
        util.uco.dotchi uco = new util.uco.dotchi();

        #region view
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string q = "")
        {
            string memberID = "";
            HttpCookie myCookie = new HttpCookie("FBUID");
            myCookie = Request.Cookies["FBUID"];

            if (myCookie != null) {
                memberID = myCookie.Value;
            }
            GetShopList();
            GetTagList();
            GetMemberInfo(memberID);
            ViewBag.QueryString = q;
            return View();
        }
        #endregion

        #region function
        public JsonResult SaveMemberInfo(string MemberID, string MemberName, string MemberImage) 
        {
            util.uco.model.dotchi.MemberInfo memberInfo = new util.uco.model.dotchi.MemberInfo();
            memberInfo.ID = MemberID;
            memberInfo.Name = MemberName;
            memberInfo.Image = MemberImage;

            bool result = uco.SaveMember(memberInfo);

            var jsonObject = new { IsSuccess = true, ErrorMessage = "", ReturnData = "" };//current value: true
            return Json(jsonObject); 
        }
        
        public void GetMemberInfo(string MemberID) 
        {
            util.uco.model.dotchi.MemberInfo memberInfo = new util.uco.model.dotchi.MemberInfo();
            memberInfo = uco.QueryMember(MemberID);

            Dotchi.Models.Dotchi.MemberInfo memberDetail = new Dotchi.Models.Dotchi.MemberInfo();
            memberDetail.ID = memberInfo.ID;
            memberDetail.Name = memberInfo.Name;
            memberDetail.Image = memberInfo.Image;

            ViewBag.MemberInfo = memberDetail;
        }

        public List<Dotchi.Models.Dotchi.ShopInfo> GetShopList()
        {
            List<Dotchi.Models.Dotchi.ShopInfo> shopList = new List<Dotchi.Models.Dotchi.ShopInfo>();
            #region sample data - shop list

            //shop 1
            Dotchi.Models.Dotchi.ShopInfo shop1 = new Dotchi.Models.Dotchi.ShopInfo();
            shop1.ID = 1;
            shop1.Name = "くら寿司 藏壽司 Kura Sushi 松江南京店";
            shop1.Rating = 4;
            shop1.Checkin = 9999;
            shop1.Cover = "http://goo.gl/x2M7oX";
            shop1.Address = "KURA壽司(くら寿司) 松江南京店 台湾1號店";
            shop1.Phone = "(02)2568 - 1519";
            shop1.OpenTime = "11:00 ~ 22:00 ";
            shop1.Price = "1000";
            shop1.Website = "https://www.facebook.com/kurasushi.songjiangnanjing";

            List<Dotchi.Models.Dotchi.FriendInfo> FriendList = new List<Dotchi.Models.Dotchi.FriendInfo>();
            Dotchi.Models.Dotchi.FriendInfo friendItem1 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem1.ID = "123456";
            friendItem1.Name = "Leah Yeh";
            friendItem1.Thumbnail = "http://goo.gl/hpGixd";
            FriendList.Add(friendItem1);

            Dotchi.Models.Dotchi.FriendInfo friendItem2 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem2.ID = "123457";
            friendItem2.Name = "Lala Hsu";
            friendItem2.Thumbnail = "http://goo.gl/B1JLkw";
            FriendList.Add(friendItem2);

            Dotchi.Models.Dotchi.FriendInfo friendItem3 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem3.ID = "123458";
            friendItem3.Name = "王悅竹";
            friendItem3.Thumbnail = "http://goo.gl/LmRtt5";
            FriendList.Add(friendItem3);

            Dotchi.Models.Dotchi.FriendInfo friendItem4 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem4.ID = "123459";
            friendItem4.Name = "Amber Chen";
            friendItem4.Thumbnail = "http://goo.gl/qvyBaS";
            FriendList.Add(friendItem4);

            shop1.FriendDetail = FriendList;

            List<Dotchi.Models.Dotchi.Comment> CommentList = new List<Dotchi.Models.Dotchi.Comment>();

            Dotchi.Models.Dotchi.Comment comment1 = new Dotchi.Models.Dotchi.Comment();
            comment1.ID = "12345yhte6u6uj7i7i7";
            comment1.Time = DateTime.Now;
            comment1.Image = "http://goo.gl/5XWi7U";
            comment1.Text = "覺得跟上潮流的壽司午餐，囂張一百分。全部都好好吃喔！轉蛋超好玩的！但我不想要豆皮壽司。";
            
            Dotchi.Models.Dotchi.UserInfo userInfo1 = new Dotchi.Models.Dotchi.UserInfo();
            userInfo1.UserName = "Leah Yeh";
            userInfo1.UserImage = "http://goo.gl/hpGixd";
            comment1.UserDetail = userInfo1;
            CommentList.Add(comment1);

            Dotchi.Models.Dotchi.Comment comment2 = new Dotchi.Models.Dotchi.Comment();
            comment2.ID = "12345yhte6u6uj7i7i7";
            comment2.Time = DateTime.Now;
            comment2.Image = "http://ppt.cc/SVyx";
            comment2.Text = "好好吃，我們一直點一直點，好吃又好玩";

            Dotchi.Models.Dotchi.UserInfo userInfo2 = new Dotchi.Models.Dotchi.UserInfo();
            userInfo2.UserName = "Jill Tzeng";
            userInfo2.UserImage = "http://ppt.cc/jTLo";
            comment2.UserDetail = userInfo2;
            CommentList.Add(comment2);
            shop1.CommentList = CommentList;
            shopList.Add(shop1);

            //shop 2
            Dotchi.Models.Dotchi.ShopInfo shop2 = new Dotchi.Models.Dotchi.ShopInfo();
            shop2.ID = 1;
            shop2.Name = "禾鶴亭日本料理餐廳";
            shop2.Rating = 4;
            shop2.Checkin = 1349;
            shop2.Cover = "http://pic.pimg.tw/spark0416/1357310739-3160826581_m.jpg?v=1357310741";
            shop2.Address = "台北市松江路108巷3號";
            shop2.Phone = "(02)2568 - 1519";
            shop2.OpenTime = "周一至週六 11:00 ~ 22:00 ";
            shop2.Price = "300~500";
            shop2.Website = "https://www.facebook.com/Nogitsurutei";

            List<Dotchi.Models.Dotchi.FriendInfo> FriendList2 = new List<Dotchi.Models.Dotchi.FriendInfo>();
            Dotchi.Models.Dotchi.FriendInfo friendItem21 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem21.ID = "223456";
            friendItem21.Name = "Joy Wu";
            friendItem21.Thumbnail = "http://ppt.cc/30po";
            FriendList2.Add(friendItem21);

            Dotchi.Models.Dotchi.FriendInfo friendItem22 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem22.ID = "223457";
            friendItem22.Name = "Lin Serena";
            friendItem22.Thumbnail = "http://ppt.cc/NtoW";
            FriendList2.Add(friendItem22);

            Dotchi.Models.Dotchi.FriendInfo friendItem23 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem23.ID = "223458";
            friendItem23.Name = "Chia Ling";
            friendItem23.Thumbnail = "http://ppt.cc/uIeZ";
            FriendList2.Add(friendItem23);
    

            shop2.FriendDetail = FriendList;

            List<Dotchi.Models.Dotchi.Comment> CommentList2 = new List<Dotchi.Models.Dotchi.Comment>();

            Dotchi.Models.Dotchi.Comment comment21 = new Dotchi.Models.Dotchi.Comment();
            comment21.ID = "13345yhte6u6uj7i7i7";
            comment21.Time = DateTime.Now;
            comment21.Image = "http://ppt.cc/hBjW";
            comment21.Text = "最推薦的還是生魚片蓋飯，魚貨夠新鮮，視覺也被滿足，價格上雖不比剛歇業的三大便宜，但也算可以接受吃不飽的話可以再加點親子丼或是壽司類的餐點。";

            Dotchi.Models.Dotchi.UserInfo userInfo21 = new Dotchi.Models.Dotchi.UserInfo();
            userInfo21.UserName = "Ryan Liang";
            userInfo21.UserImage = "http://ppt.cc/SNxh";
            comment21.UserDetail = userInfo1;
            CommentList2.Add(comment21);

            Dotchi.Models.Dotchi.Comment comment22 = new Dotchi.Models.Dotchi.Comment();
            comment22.ID = "22345yhte6u6uj7i7i7";
            comment22.Time = DateTime.Now;
            comment22.Image = "http://ppt.cc/HLq-";
            comment22.Text = "海膽丼看起來很好吃，炸蝦size很大。";

            Dotchi.Models.Dotchi.UserInfo userInfo22 = new Dotchi.Models.Dotchi.UserInfo();
            userInfo22.UserName = "Wang Big-frog ";
            userInfo22.UserImage = "http://ppt.cc/gN0m";
            comment22.UserDetail = userInfo22;
            CommentList2.Add(comment22);
            shop2.CommentList = CommentList2;
            shopList.Add(shop2);

            //shop 3
            Dotchi.Models.Dotchi.ShopInfo shop3 = new Dotchi.Models.Dotchi.ShopInfo();
            shop3.ID = 1;
            shop3.Name = "品盛悅素軒-蔬食素食";
            shop3.Rating = 4;
            shop3.Checkin = 2319;
            shop3.Cover = "http://ppt.cc/mXnm";
            shop3.Address = "台北市中山區南京東路二段206號";
            shop3.Phone = "02-25021718";
            shop3.OpenTime = "日 11:00 ~ 22:00 ";
            shop3.Price = "100~200";
            shop3.Website = "https://www.facebook.com/PinShengDVH";

            List<Dotchi.Models.Dotchi.FriendInfo> FriendList3 = new List<Dotchi.Models.Dotchi.FriendInfo>();
            Dotchi.Models.Dotchi.FriendInfo friendItem31 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem31.ID = "323456";
            friendItem31.Name = "Amber Chao";
            friendItem31.Thumbnail = "http://ppt.cc/K4yb";
            FriendList3.Add(friendItem31);

            Dotchi.Models.Dotchi.FriendInfo friendItem32 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem32.ID = "323457";
            friendItem32.Name = "Yiying Lin";
            friendItem32.Thumbnail = "http://ppt.cc/efjv";
            FriendList3.Add(friendItem32);

            Dotchi.Models.Dotchi.FriendInfo friendItem33 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem33.ID = "323458";
            friendItem33.Name = "Nai-Wen Chi ";
            friendItem33.Thumbnail = "http://ppt.cc/McFs";
            FriendList3.Add(friendItem33);

            Dotchi.Models.Dotchi.FriendInfo friendItem34 = new Dotchi.Models.Dotchi.FriendInfo();
            friendItem34.ID = "323459";
            friendItem34.Name = "Amy Lu ";
            friendItem34.Thumbnail = "http://ppt.cc/RGen";
            FriendList3.Add(friendItem34);

            shop3.FriendDetail = FriendList;

            List<Dotchi.Models.Dotchi.Comment> CommentList3 = new List<Dotchi.Models.Dotchi.Comment>();

            Dotchi.Models.Dotchi.Comment comment31 = new Dotchi.Models.Dotchi.Comment();
            comment31.ID = "1231345yhte6u6uj7i7i7";
            comment31.Time = DateTime.Now;
            comment31.Image = "http://ppt.cc/nbIC";
            comment31.Text = "好吃到我下巴差點掉下來！！！！";

            Dotchi.Models.Dotchi.UserInfo userInfo31 = new Dotchi.Models.Dotchi.UserInfo();
            userInfo31.UserName = "洪小薇";
            userInfo31.UserImage = "http://ppt.cc/rSYV";
            comment31.UserDetail = userInfo31;
            CommentList3.Add(comment31);

            Dotchi.Models.Dotchi.Comment comment32 = new Dotchi.Models.Dotchi.Comment();
            comment32.ID = "12232345yhte6u6uj7i7i7";
            comment32.Time = DateTime.Now;
            comment32.Image = "http://ppt.cc/LRsr";
            comment32.Text = "終於開幕了！一份套餐就可品嚐到多國料理，帶老人家來吃好適合呀~";

            Dotchi.Models.Dotchi.UserInfo userInfo32 = new Dotchi.Models.Dotchi.UserInfo();
            userInfo32.UserName = "Emily Hsu";
            userInfo32.UserImage = "http://ppt.cc/SxHl";
            comment32.UserDetail = userInfo32;
            CommentList3.Add(comment32);
            shop3.CommentList = CommentList3;
            shopList.Add(shop3);

            #endregion
            ViewBag.ShopList = shopList;
            return shopList;      
        }

        public List<Dotchi.Models.Dotchi.RecommendTag> GetTagList() 
        {
            List<Dotchi.Models.Dotchi.RecommendTag> recommendTagList = new List<Dotchi.Models.Dotchi.RecommendTag>();

            #region fake data - tag
            Dotchi.Models.Dotchi.RecommendTag tag1 = new Dotchi.Models.Dotchi.RecommendTag();
            tag1.ID = 1;
            tag1.Name = "日式料理";
            tag1.Number = 3;
            recommendTagList.Add(tag1);

            Dotchi.Models.Dotchi.RecommendTag tag2 = new Dotchi.Models.Dotchi.RecommendTag();
            tag2.ID = 2;
            tag2.Name = "火鍋";
            tag2.Number = 15;
            recommendTagList.Add(tag2);

            Dotchi.Models.Dotchi.RecommendTag tag3 = new Dotchi.Models.Dotchi.RecommendTag();
            tag3.ID = 3;
            tag3.Name = "咖啡廳";
            tag3.Number = 43;
            recommendTagList.Add(tag3);

            Dotchi.Models.Dotchi.RecommendTag tag4 = new Dotchi.Models.Dotchi.RecommendTag();
            tag4.ID = 4;
            tag4.Name = "家庭聚餐";
            tag4.Number = 21;
            recommendTagList.Add(tag4);

            Dotchi.Models.Dotchi.RecommendTag tag5 = new Dotchi.Models.Dotchi.RecommendTag();
            tag5.ID = 5;
            tag5.Name = "24h營業";
            tag5.Number = 18;
            recommendTagList.Add(tag5);

            Dotchi.Models.Dotchi.RecommendTag tag6 = new Dotchi.Models.Dotchi.RecommendTag();
            tag6.ID = 6;
            tag6.Name = "宵夜好去處";
            tag6.Number = 45;
            recommendTagList.Add(tag6);

            Dotchi.Models.Dotchi.RecommendTag tag7 = new Dotchi.Models.Dotchi.RecommendTag();
            tag7.ID = 7;
            tag7.Name = "輕食";
            tag7.Number = 12;
            recommendTagList.Add(tag7);

            Dotchi.Models.Dotchi.RecommendTag tag8 = new Dotchi.Models.Dotchi.RecommendTag();
            tag8.ID = 8;
            tag8.Name = "異國料理";
            tag8.Number = 32;
            recommendTagList.Add(tag8);

            Dotchi.Models.Dotchi.RecommendTag tag9 = new Dotchi.Models.Dotchi.RecommendTag();
            tag9.ID = 9;
            tag9.Name = "一個人吃飯";
            tag9.Number = 38;
            recommendTagList.Add(tag9);

            #endregion

            ViewBag.RecommendTag = recommendTagList;
            return recommendTagList;    
        }

        /*
        public JsonResult Query() 
        {
            var jsonObject = new { IsSuccess = false, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject); 
        }
        */
        #endregion
    }
}