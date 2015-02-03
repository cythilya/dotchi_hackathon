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
				top.location.href = '/Food/Search?q=' + queryString;
			}
			else{
				top.location.href = '/Food/Search';
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
								alert('系統有誤，請重新再試一次。');
							}
							else {
								var ID = res.id;
								var Name = res.first_name + res.last_name;
								var UserImage = 'http://graph.facebook.com/'+ ID + '/picture?width=40&height=40';

								//save cookie
								document.cookie = 'FBUID=' + ID + '; path=/';

								$.ajax({
									url: '/Food/SaveMemberInfo',
									type: 'post',
									data: {
										"MemberID": ID,
										"MemberName": Name,
										"MemberImage": UserImage
									},
									dataType: 'json',
									error: function (xhr) {
										alert('請稍後再試一次。');
									},
									success: function (response) {
										if (response.IsSuccess) {
											top.location.href = '/Food/Search';
										}
										else {
											alert('請稍後再試一次。');
										}
									}
								});								
							}
						});
					}
					else {
						FB.login(function (response) {
							top.location.href = '/Food/Search';
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
		var dFriendLoginBtn = dModule.find('.friendBtn');
		var dGoTop = dModule.find('.goTop');
		var moreBtn = dModule.find('.more');
		
		var $rating = dModule.find('.rating-bar');
		$rating.ratingForMultiple({
            initScore: 5,
            markScore: true, //分數mark
            readOnly: false,
            callback: function () { }
		});		
	
		var login = function(){
			FB.getLoginStatus(function (response) {
				if (response.status === 'connected') {
					
					FB.api('/me', function (res) {
						if (!res || res.error) {
							alert('系統有誤，請重新再試一次。');
						}
						else {
							var ID = res.id;
							var Name = res.first_name + res.last_name;
							var UserImage = 'http://graph.facebook.com/'+ ID + '/picture?width=40&height=40';

							//save cookie
							document.cookie = 'FBUID=' + ID + '; path=/';

							$.ajax({
								url: '/Food/SaveMemberInfo',
								type: 'post',
								data: {
									"MemberID": ID,
									"MemberName": Name,
									"MemberImage": UserImage
								},
								dataType: 'json',
								error: function (xhr) {
									console.log(xhr);
									alert('請稍後再試一次。');
								},
								success: function (response) {
									if (response.IsSuccess) {
										top.location.href = '/Food/Search';
									}
									else {
										alert('請稍後再試一次。');
									}
								}
							});								
						}
					});					
				}
				else {
					FB.login(function (response) {
						top.location.href = '/Food/Search';
					});
				}
			});		
		};

		dSearchBtn.click(function(e){
			e.preventDefault();
			
			var queryString = $.trim(dQueryInput.val());
			if(queryString){
				top.location.href = '/Food/Search?q=' + queryString;
			}
			else{
				top.location.href = '/Food/Search';
			}
		});
		
		dFBLoginBtn.click(function(e){
			e.preventDefault();
			login();
		});	

		dFriendLoginBtn.click(function(e){
			e.preventDefault();
			login();
		});

        dGoTop.click(function(e) {
            e.preventDefault();
            var $body = (window.opera) ? (document.compatMode == "CSS1Compat" ? $('html') : $('body')) : $('html,body');
            $body.animate({scrollTop: 0}, 1000);
        });

        moreBtn.click(function (e) {
            e.preventDefault();
            var detail = $(this).parent().find('.detail');
            detail.toggleClass("show");
            if (detail.hasClass('show')) {
                $(this).text("▲");
            } else {
                $(this).text("▼");
            }
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