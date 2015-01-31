var SP = {};
SP.module = {
    version: '0.1',
    namespace: function(ns_string){
        var parts = ns_string.split('.'),
            parent = SP,
            i;
        if (parts[0] === 'SP'){
            parts = parts.slice(1);
        }
        for (i = 0; i < parts.length; i += 1){
            if (typeof parent[parts[i]] === 'undefined') {
                parent[parts[i]] = {};
            }
            parent = parent[parts[i]];
        }
        return parent;
    },
    inherit: function(Child, Parent){
        Child.prototype = new Parent();
    },
    index: function(dModule){
		var dModule = $(dModule);
		var dSearchBtn = dModule.find('.search.button');
		var dFBLoginBtn = dModule.find('.fb.button');
		var dQueryInput = dModule.find('.query');

		//remove cookie
		$.removeCookie('FBUID');		
		$.removeCookie('Name');		
		$.removeCookie('UserImage');		
		
		//search something
		dSearchBtn.click(function(e){
			e.preventDefault();
			
			var queryString = $.trim(dQueryInput.val());
			
			if(queryString){
				top.location.href = '/Home/Search?q=' + queryString;
			}
			else{
				top.location.href = '/Home/Search';
			}
		});
		
		//facebook login
		dFBLoginBtn.click(function(e){
			e.preventDefault();

            var dThisLoginBtn = $(this);
			FBUtil.after(function (FB) {
				FB.getLoginStatus(function (response) {
					if (response.status === 'connected') {
						FB.api('/me', function (res) {
							if (!res || res.error) {
								//取不到資料，報錯
								alert('系統有誤，請重新再試一次。');
							}
							else {
								var ID = res.id;
								var Name = res.first_name + res.last_name;
								var UserImage = 'http://graph.facebook.com/'+ ID + '/picture?width=40&height=40';

								$.ajax({
									url: '/Home/SaveMemberInfo',
									type: 'post',
									data: {
										"MemberID": ID,
										"MemberName": Name,
										"MemberImage": UserImage,
									},
									dataType: 'json',
									error: function (xhr) {
										alert('請稍後再試一次。');
									},
									success: function (response) {
										if (response.IsSuccess) {
											top.location.href = '/Home/Search';
										}
										else {
											alert('請稍後再試一次。');
										}
									},
									complete: function () {
										//delete cookie
										//document.cookie = name+"=;expires="+(new Date(0)).toGMTString();
									}
								});								
								//save cookie
								//document.cookie = 'FBUID=' + ID + '; path=/';
								//document.cookie = 'Name=' + Name + '; path=/';
								//document.cookie = 'UserImage=' + UserImage + '; path=/';
								
								//console.log(document.cookie);
								//if (res.name) {
								//	Name = res.name;
								//}
							}
						});
						//top.location.href = '/Home/Search';
					}
					else {
						FB.login(function (response) {
							//top.location.href = '/Home/Search';
						});
					}
				});		
			});			
		});	
    },	
    page: function(dModule){
		var dModule = $(dModule);
		var dQueryInput = dModule.find('.queryInput');
		var dSearchBtn = dModule.find('.search.button');
		var dFBLoginBtn = dModule.find('.fb.button');

		dSearchBtn.click(function(e){
			e.preventDefault();
			
			var queryString = $.trim(dQueryInput.val());
			if(queryString){
				top.location.href = '/Home/Search?q=' + queryString;
			}
			else{
				top.location.href = '/Home/Search';
			}
		});
		
		dFBLoginBtn.click(function(e){
			e.preventDefault();
			
            var dThisLoginBtn = $(this);
			FB.getLoginStatus(function (response) {
				if (response.status === 'connected') {
					top.location.href = '/Home/Search';
				}
				else {
					FB.login(function (response) {
						top.location.href = '/Home/Search';
					});
				}
			});
		});			
	}
};
(function(){
    var doWhileExist = function(ModuleID,objFunction){
        var dTarget = document.getElementById(ModuleID);
        if(dTarget){
            objFunction(dTarget);
        }                
    };
    doWhileExist('index',SP.module.index);
    doWhileExist('page',SP.module.page);
})();