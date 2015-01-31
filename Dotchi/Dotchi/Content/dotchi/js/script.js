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
		
    },	
    pageSearchResult: function(dModule){
		var dModule = $(dModule);


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
    doWhileExist('pageSearchResult',SP.module.pageSearchResult);
})();