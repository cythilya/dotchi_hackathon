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
            #region fake data - recommended tags
            #endregion

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
            
            ViewBag.ShopLis = shopList;
            return shopList;      
        }

        public JsonResult Query() 
        {
            var jsonObject = new { IsSuccess = false, ErrorMessage = "", ReturnData = "" };
            return Json(jsonObject); 
        }
        #endregion
    }
}
