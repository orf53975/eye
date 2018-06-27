function fmtMSS(s) { return (s - (s %= 60)) / 60 + (9 < s ? ':' : ':0') + s }

var aegisTimer = new (function() {
	var inventoryElem = $('.inventory');
	var aegisTimerElem;
	var interval = 0;

	this.time = 0;
	this.taken = false;
	this.paused = false;

	var self = this;

	this.aegisTaken = function() {
		this.taken = true;
		this.time = 5 * 60;

		var timer = function() {
			if (self.time <= 0) self.aegisDroped();
			if (!self.paused) self.time--;

			if (aegisTimerElem != null && aegisTimerElem.length !== 0)
				aegisTimerElem.text(fmtMSS(self.time));
		};
		interval = setInterval(timer, 1000);
	};

	this.aegisDroped = function() {
		clearInterval(interval);

		this.time = 0;
		this.taken = false;
		this.aegisOwnerUnselected();
	};

	this.aegisOwnerSelected = function(abilities, slot) {
		inventoryElem.attr('class', "inventory inventory" + abilities);

		aegisTimerElem = $('<div/>', { class: 'aegis-timer', text: fmtMSS(this.time) }).appendTo('#slot' + slot);
	};

	this.aegisOwnerUnselected = function() {
		aegisTimerElem.remove();
	};

	this.pause = function(state) {
		this.paused = state;
	};
});

var bkbSeconds = new (function() {
	var inventoryElem = $('.inventory');
	var bkbSecondsElem, currentSelected = -1;

	var getText = function(seconds) {
		return seconds + " sec";
	};

	this.bkbUsed = function(seconds, member) {
		if (currentSelected != member) return;

		bkbSecondsElem.text(getText(seconds));
	};

	this.bkbOwnerSelected = function(abilities, slot, seconds, member) {
		currentSelected = member;

		inventoryElem.attr('class', "inventory inventory" + abilities);

		bkbSecondsElem = $('<div/>', { class: 'bkb-seconds', text: getText(seconds) }).appendTo('#slot' + slot);
	};

	this.bkbOwnerUnselected = function() {
		currentSelected = -1;

		bkbSecondsElem.remove();
	};
});

var heroesPanelManager = new (function() {
	var self = this;

	this.getHero = function(index) {
		return $('#hero' + index);
	}

	this.addImportantItem = function(item, index) {
		var hero = this.getHero(index);

		$('<div/>', { class: 'modifier ' + item })
			.appendTo(hero.find('.modifiers').first());
	};

	this.removeImportantItem = function(item, index) {
		var hero = this.getHero(index);

		hero.children('.modifiers')
			.children('.' + item)
			.first()
			.remove();
	};

	this.addSmoke = function(index) {
		var hero = this.getHero(index);

		hero.find('.hero-data-rectangle')
			.slideDown(500);
		hero.find('.smoke')
			.show();

		var date = new Date();
		date.setSeconds(date.getSeconds() + 35);

		hero.find('.smoke-timer')
			.show()
			.countdown(date,
				function(event) {
					$(this).text(event.strftime('%S'));
				}).on('finish.countdown',
				function(event) {
					self.removeSmoke(index);
				});
	};

	this.removeSmoke = function(index) {
		var hero = this.getHero(index);

		hero.find('.hero-data-rectangle')
			.slideUp(100);
		hero.find('.smoke')
			.hide();
		hero.find('.smoke-timer')
			.hide()
			.countdown('stop')
			.countdown('remove');
	};

	this.addRune = function(index, rune) {
		var hero = this.getHero(index);

		if (hero.find('.rune.' + rune).length) return;

		$('<div/>', { class: 'rune ' + rune })
			.appendTo(hero.find('.runes'));
	};

	this.removeRune = function(index, rune) {
		var hero = this.getHero(index);

		hero.find('.rune.' + rune)
			.first()
			.remove();
	};

	this.pause = function(state) {
		$('.smoke-timer').each(function() {
			if ($(this).data('countdown-instance') == null) return;

			if (state) $(this).countdown('pause');
			else $(this).countdown('restart');
		});
	};
});

var bountyGoldManager = new (function() {
	var self = this;

	this.opened = false;
	this.panel = $('.bountygold');

	this.show = function(data) {
		if(this.opened) return;

		var minutes = data.Minutes;

		if (data.Team1Logo)
			$('.bountygold__logo').eq(0).attr('src', data.Team1Logo);
		else
			$('.bountygold__logo').eq(0).text(data.Team1Name);

		if (data.Team1Logo)
			$('.bountygold__logo').eq(1).attr('src', data.Team2Logo);
		else
			$('.bountygold__logo').eq(1).text(data.Team2Name);

		$('.bountygold__points').eq(0).text(data.RadiantGold);
		$('.bountygold__points').eq(1).text(data.DireGold);


		for (var i in minutes) {
			var minute = minutes[i];

			var wrap = $('.bountygold__wrap').eq(i);

			var time = data.Seconds / 60;

			var radiantBounties = wrap.find('.bountygold__multiply').eq(0);
			var direBounties = wrap.find('.bountygold__multiply').eq(1);

			var radiantGold = wrap.find('.bountygold__runes').eq(0);
			var direGold = wrap.find('.bountygold__runes').eq(1);

			var wrapMinute = wrap.find('.bountygold__period');

			wrap.find('.bountygold__bounty')
				.attr('class', 'bountygold__bounty');

			radiantBounties.text('x' + minute.Radiant.Bounties);
			direBounties.text('x' + minute.Dire.Bounties);

			radiantGold.text(minute.Radiant.Gold);
			direGold.text(minute.Dire.Gold);

			wrapMinute.attr('class', 'bountygold__period');
			wrapMinute.html(minute.Minute + '<div class="bountygold__line"></div>');

			if (minute.Minute <= time && time <= minute.Minute + 5) {
				var timePercent = (data.Seconds - minute.Minute * 60) / (5 * 60) * 100;

				wrapMinute.attr('class', 'bountygold__period active');

				var line = wrap.find('.bountygold__line').last();
				line.html('<div class="bountygold__time"></div>');
				line.css({
						'background': 'linear-gradient(to bottom, #d04e08 0%, #d04e08 ' +
							timePercent +
							'%, rgba(255, 255, 255, 0.23) ' +
							timePercent +
							'%, rgba(255, 255, 255, 0.23) 100%)'
					}).find('.bountygold__time')
					.css({ 'top': timePercent + '%' });
			}
		}

		this.panel.animate({ 'margin-right': '+=300' }, 'slow')
			.queue(function() {
				self.opened = true;
				$(this).dequeue();
			});
	};

	this.hide = function() {
		if (!this.opened) return;

		this.panel.animate({ 'margin-right': '-=300' }, 'slow')
			.queue(function() {
				var wrap = $('.bountygold__wrap');

				var bounties = wrap.find('.bountygold__multiply');
				var gold = wrap.find('.bountygold__runes');
				var wrapMinute = wrap.find('.bountygold__period');

				wrap.find('.bountygold__bounty')
					.attr('class', 'bountygold__bounty bountygold__bounty--hide');

				$('.bountygold__points').text('0');

				bounties.text('');
				gold.text('');

				wrapMinute.attr('class', 'bountygold__period disable');
				wrapMinute.each(function(i) {
					 $(this).html((i * 5) + '<div class="bountygold__line"></div>');
				});

				self.opened = false;
				$(this).dequeue();
			});

		self.opened = false;
	};
});

var dataShowerManager = new (function() {
	var textShowed, dataShowed;

	var showData = function(data) {
		dataShowed = true;

		$('.data-title').text(data.Name).slideDown(1000);//.queue(function() { $(this).text(data.Name).dequeue(); });

		for (var i in data.Datas) {
			var text = data.Datas[i];
				
			$('.data').eq(i)
				.find('.icon')
				.attr('class', 'icon ' + data.Icon);

			$('.data').eq(i)
				.find('.value')
				.css('color', data.Color)
				.html('<div class="icon ' + data.Icon + '"></div>' + text);
		}
	};

	var showText = function(data) {
		textShowed = true;

		$('.text-title').text(data.Name).slideDown(1000);//.queue(function() { $(this).text(data.Name).dequeue(); });

		for (var i in data.Datas) {
			var text = data.Datas[i];

			$('.text').eq(i)
				.find('.value')
				.css('color', data.Color)
				.text(text);
		}
	};

	this.show = function(event) {
		$('.hero-data-rectangle').slideDown(1000);

		if (event.TextValue) showText(event.TextValue);
		if (event.DataValue) showData(event.DataValue);
	};

	this.hide = function() {
		if (textShowed) $('.text-title').slideUp(600).queue(function() { $(this).text('').dequeue(); });
		if (dataShowed) $('.data-title').slideUp(600).queue(function() { $(this).text('').dequeue(); });

		$('.smoke-timer').each(function(i) {
			if (!$(this).is(':visible')) {
				$('.hero-data-rectangle')
					.eq(i)
					.slideUp(600)
					.queue(function() {
						$('.icon').attr('class', 'icon');
						$('.value').text('');

						$(this).dequeue();
					});
			} else {
				$('.icon').attr('class', 'icon');
				$('.value').text('');
			}
		});

		textShowed = dataShowed = false;
	};
});

var webSocket;
var connectToServer = function() {
	webSocket = new WebSocket("ws://127.0.0.1:81");
	webSocket.onclose = function() { setTimeout(connectToServer, 1 * 1000); }
	//webSocket.onopen = function () { console.log('WebSocket connection open!');}
	webSocket.onmessage = function(e) {
		var event = JSON.parse(e.data);

		console.log(event.Type, event);

		switch (event.Type) {
		case 0:
			//aegisTimer.aegisTaken();
			break;
		case 1:
			aegisTimer.aegisOwnerSelected(event.Abilities, event.Slot);
			break;
		case 2:
			aegisTimer.aegisOwnerUnselected();
			break;

		case 3:
			heroesPanelManager.addImportantItem(event.Item, event.Member);

			if (event.Item === 'aegis')
				aegisTimer.aegisTaken();
			break;
		case 4:
			heroesPanelManager.removeImportantItem(event.Item, event.Member);

			if (event.Item === 'aegis')
				aegisTimer.aegisDroped();
			break;

		case 5:
			bkbSeconds.bkbUsed(event.Seconds, event.Member);
			break;
		case 6:
			bkbSeconds.bkbOwnerSelected(event.Abilities, event.Slot, event.Seconds, event.Member)
			break;
		case 7:
			bkbSeconds.bkbOwnerUnselected();
			break;

		case 8:
			heroesPanelManager.addSmoke(event.Hero);
			break;
		case 9:
			heroesPanelManager.removeSmoke(event.Hero);
			break;

		case 10:
			heroesPanelManager.addRune(event.Hero, event.Rune);
			break;
		case 11:
			heroesPanelManager.removeRune(event.Hero, event.Rune);
			break;

		case 12:
			heroesPanelManager.pause(event.State);
			aegisTimer.pause(event.State);
			break;

		case 13:
			bountyGoldManager.show(event.Data);
			break;
		case 14:
			bountyGoldManager.hide();
			break;

		case 15:
			dataShowerManager.show(event);
			break;
		case 16:
			dataShowerManager.hide();
			break;
		default:
		}
	};
};

connectToServer();

function play(arg) {

}

function stop() {

}

function next() {

}

function update(arg) {

}