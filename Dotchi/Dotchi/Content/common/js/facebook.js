var scripts = document.getElementsByTagName('script');
var index = scripts.length - 1;
var currentScript = scripts[index];
//myScript.getAttrbite("data-appid")

if(currentScript.getAttribute("data-appid") == null){
    throw("error,missing appid");
}

var FBUtil = {
    queue: [],
    inited: false,
    FB: {},
    after: function (fn) {
        if (this.inited) fn(FB);
        else
            this.queue.push(fn);
    },
    init: function (obj) {
        var thisobj = this;
        if (obj) {
            thisobj = obj;
        }
        if (!this.inited) {
            //if (FB.getAuthResponse()) {
                thisobj.inited = true;
                thisobj.FB = FB;
                for (var i = 0; i < thisobj.queue.length; ++i) {
                    try {
                        thisobj.queue[i](FB);
                    } catch (ex) {
                        setTimeout(function () {
                            throw ex;
                        }, 0);
                    }
                }
                thisobj.queue = null;
            //}
            //else {
            //    setTimeout(function () { FBUtil.init(thisobj); }, 1);
            //}
        }
    }
};
window.fbAsyncInit = function () {
    FB.init({
        appId: currentScript.getAttribute("data-appid"),                        // App ID from the app dashboard
        status: true,                                 // Check Facebook Login status
        xfbml: true                                  // Look for social plugins on the page
    });
    FB.getLoginStatus(function (response) {
        FBUtil.init();
    });
};
(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/zh_TW/all.js";
    fjs.parentNode.insertBefore(js, fjs);
} (document, 'script', 'facebook-jssdk'));
