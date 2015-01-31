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
        
        #region view
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string q = "")
        {
            GetShopList();
            GetTagList();
            ViewBag.QueryString = q;
            return View();
        }
        #endregion

        #region function
        public List<Dotchi.Models.Dochi.ShopInfo> GetShopList()
        {
            List<Dotchi.Models.Dochi.ShopInfo> shopList = new List< Dotchi.Models.Dochi.ShopInfo>();

            #region fake data - shop list
            //shop 1
            Dotchi.Models.Dochi.ShopInfo shop1 = new Dotchi.Models.Dochi.ShopInfo();
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

            List<Dotchi.Models.Dochi.FriendInfo> FriendList = new List<Dotchi.Models.Dochi.FriendInfo>();
            Dotchi.Models.Dochi.FriendInfo friendItem1 = new Dotchi.Models.Dochi.FriendInfo();
            friendItem1.ID = "123456";
            friendItem1.Name = "Leah Yeh";
            friendItem1.Thumbnail = "http://goo.gl/hpGixd";
            FriendList.Add(friendItem1);

            Dotchi.Models.Dochi.FriendInfo friendItem2 = new Dotchi.Models.Dochi.FriendInfo();
            friendItem2.ID = "123457";
            friendItem2.Name = "Lala Hsu";
            friendItem2.Thumbnail = "http://goo.gl/B1JLkw";
            FriendList.Add(friendItem2);

            Dotchi.Models.Dochi.FriendInfo friendItem3 = new Dotchi.Models.Dochi.FriendInfo();
            friendItem3.ID = "123458";
            friendItem3.Name = "王悅竹";
            friendItem3.Thumbnail = "http://goo.gl/LmRtt5";
            FriendList.Add(friendItem3);

            Dotchi.Models.Dochi.FriendInfo friendItem4 = new Dotchi.Models.Dochi.FriendInfo();
            friendItem4.ID = "123459";
            friendItem4.Name = "Amber Chen";
            friendItem4.Thumbnail = "http://goo.gl/qvyBaS";
            FriendList.Add(friendItem4);

            shop1.FriendDetail = FriendList;

            List<Dotchi.Models.Dochi.Comment> CommentList = new List<Dotchi.Models.Dochi.Comment>();

            Dotchi.Models.Dochi.Comment comment1 = new Dotchi.Models.Dochi.Comment();
            comment1.ID = "12345yhte6u6uj7i7i7";
            comment1.Time = DateTime.Now;
            comment1.Image = "http://goo.gl/5XWi7U";
            comment1.Text = "覺得跟上潮流的壽司午餐，囂張一百分。全部都好好吃喔！轉蛋超好玩的！但我不想要豆皮壽司。";
            
            Dotchi.Models.Dochi.UserInfo userInfo1 = new Dotchi.Models.Dochi.UserInfo();
            userInfo1.UserName = "Leah Yeh";
            userInfo1.UserImage = "http://goo.gl/hpGixd";
            comment1.UserDetail = userInfo1;
            CommentList.Add(comment1);

            Dotchi.Models.Dochi.Comment comment2 = new Dotchi.Models.Dochi.Comment();
            comment2.ID = "12345yhte6u6uj7i7i7";
            comment2.Time = DateTime.Now;
            comment2.Image = "http://goo.gl/5XWi7U";
            comment2.Text = "覺得跟上潮流的壽司午餐，囂張一百分。全部都好好吃喔！轉蛋超好玩的！但我不想要豆皮壽司。";

            Dotchi.Models.Dochi.UserInfo userInfo2 = new Dotchi.Models.Dochi.UserInfo();
            userInfo2.UserName = "Leah Yeh";
            userInfo2.UserImage = "http://goo.gl/hpGixd";
            comment2.UserDetail = userInfo2;
            CommentList.Add(comment2);
            shop1.CommentList = CommentList;
            shopList.Add(shop1);

            //shop 2

            //shop 3

            #endregion
            
            ViewBag.ShopList = shopList;
            return shopList;      
        }

        public List<Dotchi.Models.Dochi.RecommendTag> GetTagList() 
        {
            List<Dotchi.Models.Dochi.RecommendTag> recommendTagList = new List<Dotchi.Models.Dochi.RecommendTag>();

            #region fake data - tag
            Dotchi.Models.Dochi.RecommendTag tag1 = new Dotchi.Models.Dochi.RecommendTag();
            tag1.ID = 1;
            tag1.Name = "日式料理";
            tag1.Number = 3;
            recommendTagList.Add(tag1);

            Dotchi.Models.Dochi.RecommendTag tag2 = new Dotchi.Models.Dochi.RecommendTag();
            tag2.ID = 2;
            tag2.Name = "火鍋";
            tag2.Number = 15;
            recommendTagList.Add(tag2);

            Dotchi.Models.Dochi.RecommendTag tag3 = new Dotchi.Models.Dochi.RecommendTag();
            tag3.ID = 3;
            tag3.Name = "咖啡廳";
            tag3.Number = 43;
            recommendTagList.Add(tag3);

            Dotchi.Models.Dochi.RecommendTag tag4 = new Dotchi.Models.Dochi.RecommendTag();
            tag4.ID = 4;
            tag4.Name = "家庭聚餐";
            tag4.Number = 21;
            recommendTagList.Add(tag4);

            Dotchi.Models.Dochi.RecommendTag tag5 = new Dotchi.Models.Dochi.RecommendTag();
            tag5.ID = 5;
            tag5.Name = "24h營業";
            tag5.Number = 18;
            recommendTagList.Add(tag5);

            Dotchi.Models.Dochi.RecommendTag tag6 = new Dotchi.Models.Dochi.RecommendTag();
            tag6.ID = 6;
            tag6.Name = "宵夜好去處";
            tag6.Number = 45;
            recommendTagList.Add(tag6);

            Dotchi.Models.Dochi.RecommendTag tag7 = new Dotchi.Models.Dochi.RecommendTag();
            tag7.ID = 7;
            tag7.Name = "輕食";
            tag7.Number = 12;
            recommendTagList.Add(tag7);

            Dotchi.Models.Dochi.RecommendTag tag8 = new Dotchi.Models.Dochi.RecommendTag();
            tag8.ID = 8;
            tag8.Name = "異國料理";
            tag8.Number = 32;
            recommendTagList.Add(tag8);

            Dotchi.Models.Dochi.RecommendTag tag9 = new Dotchi.Models.Dochi.RecommendTag();
            tag9.ID = 9;
            tag9.Name = "一個人吃飯";
            tag9.Number = 38;
            recommendTagList.Add(tag9);

            #endregion

            ViewBag.RecommendTag = recommendTagList;
            return recommendTagList;    
        }

        public JsonResult Query() 
        {
            var jsonObject = new { IsSuccess = false, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject); 
        }
        #endregion
    }
}
