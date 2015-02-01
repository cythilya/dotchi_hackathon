/*!
 * jQuery plugin
 * What does it do
 */
(function ($) {
    $.fn.rating = function (opts) {
        // default configuration
        var config = $.extend({}, {
            initScore: 0,
            markScore: true, //分數mark
            readOnly: true,
            callback: function () { }
        }, opts);
        // main function
        function renderRating(obj) {
            var ratingHTML = [
				'<div class="rating-box">',
				'	<div class="star-group">',
				'		<label class="star" for="rating-1">',
				'			<input id="rating-1" name="rating" type="radio" value="1" />1Stars</label>',
				'		<label class="star" for="rating-2">',
				'			<input id="rating-2" name="rating" type="radio" value="2" />2Star</label>',
				'		<label class="star" for="rating-3">',
				'			<input id="rating-3" name="rating" type="radio" value="3" />3Stars</label>',
				'		<label class="star" for="rating-4">',
				'			<input id="rating-4" name="rating" type="radio" value="4" />4Stars</label>',
				'		<label class="star" for="rating-5">',
				'			<input id="rating-5" name="rating" type="radio" value="5" />5Stars</label>',
				'		<div class="rating-mark">' + config.initScore + '</div>',
				'	</div>',
				'</div>'].join('');
            $(ratingHTML).appendTo(obj);
            var dBox = obj.find('.rating-box');
            var dGroup = obj.find('.star-group');
            var dStar = obj.find('.rating-box .star');
            var dRadio = obj.find('.rating-box .star input');
            var checkedValue = '0';

            if (config.markScore == true) {
                dBox.find('.rating-mark').fadeIn();
            }


            var starThurnOn = function (onScore) {
                dStar.each(function (index, item) {
                    if (index < onScore) {
                        $(this).addClass('on');
                    }
                    else {
                        return false;
                    }
                    dBox.find('.rating-mark').text(obj.find('.rating-box .star input:checked').val());
                });
            };

            if (config.readOnly == false) {
                dStar.hover(function () {
                    // Handle star mouse over
                    dStar.removeClass('on');
                    $(this).prevAll().andSelf().addClass('on');
                    var scoreText = $(this).find('input').val();
                    dBox.find('.rating-mark').text(scoreText);
                },
	    		function () {
	    		    $(this).prevAll().andSelf().removeClass('on');
	    		    //觸發change事件 or init
	    		    if (obj.find('.rating-box .star input').is(':checked')) {
	    		        checkedValue = obj.find('.rating-box .star input:checked').val();
	    		        starThurnOn(checkedValue);
	    		    }
	    		    else {
	    		        dBox.find('.rating-mark').text('0');
	    		    }
	    		});

                dRadio.change(function () {
                    checkedValue = obj.find('.rating-box .star input:checked').val();
                    starThurnOn(checkedValue);
                    if (config.callback && typeof config.callback == "function") {
                        $(config.callback);
                    }
                });
            }
            else {
                dRadio.attr('disabled', 'disabled').attr('id', ''); ;
                dStar.css({ cursor: 'default' });
                starThurnOn(config.initScore);
            }
        }
        // initialize every element
        this.each(function () {
            renderRating($(this));
        });
        return this;
    };

    $.fn.ratingForMultiple = function (opts) { 
    
        // default configuration
        var config = $.extend({}, {
            initScore: 0,
            markScore: true, //分數mark
            readOnly: true,
            callback: function () { }
        }, opts);

        var ratingHTML = [
				    '<div class="rating-box">',
				    '	<div class="star-group">',
				    '		<label class="star" data-rating="1">1Stars</label>',
				    '		<label class="star" data-rating="2">2Star</label>',
				    '		<label class="star" data-rating="3">3Stars</label>',
				    '		<label class="star" data-rating="4">4Stars</label>',
				    '		<label class="star" data-rating="5">5Stars</label>',
				    '		<div class="rating-mark">' + config.initScore + '</div>',
				    '	</div>',
				    '</div>'].join('');

        // main function
        var starTurnRun = function (score) {  
            var dSelf = $(this);
            var ratingScore = (parseInt(score, 10) || 0);
            dSelf.removeClass('on');
            if (ratingScore > 0) {
              dSelf.filter(':lt(' + ratingScore + ')').addClass('on');
              dSelf.filter(':gt(' + (ratingScore - 1) + ')').removeClass('on');
            }
            dSelf.eq(0).siblings("div.rating-mark").text(ratingScore);
        };
        var init = function () {
            var dSelf = $(this).html(ratingHTML);
            var dBox = dSelf.find('.rating-box');
            var dStar = dBox.find('.star');

            if (config.markScore == true) {
                dBox.find('.rating-mark').fadeIn();
            }

            starTurnRun.call(dStar, config.initScore);

            if (config.readOnly == false) {

                dStar.bind({
                    mouseenter: function () { 
                        var dStarSelf = $(this);
                        var ratingScore = dStarSelf.data('rating') || 0;
                        starTurnRun.call(dStar, ratingScore);
                    },
                    mouseleave: function () { 
                        starTurnRun.call(dStar, config.initScore);
                    },
                    click: function () { 
                        var dStarSelf = $(this);
                        config.initScore = dStarSelf.data('rating') || 0;
                        starTurnRun.call(dStar, config.initScore);
                        if (config.callback && typeof config.callback == "function") {
                            config.callback();
                        }
                    }
                });

            } else {
                dStar.css({ cursor: 'default' });
            }

        };

        // initialize every element
        return this.each(function () { 
            init.call(this);
        });

    };

})(jQuery);
