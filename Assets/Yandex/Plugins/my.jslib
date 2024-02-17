mergeInto(LibraryManager.library, {

	WriteToConsole: function (data)
	{
		console.log("LOG: ", UTF8ToString(data));
	},
	
	ClickToPlayerData: function ()
	{
		console.log('ClickToPlayerData');
		auth();
	},

	GetPlayerName: function ()
	{
		let name = "";
		if (player != null) name = player.getName();
		myGameInstance.SendMessage('Yandex', 'ActivatePlayerName', name);
		console.log('GetPlayerName', name);
	},
	
	RateYandexGame: function()
	{
		ysdk.feedback.canReview().then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
						myGameInstance.SendMessage('Yandex', 'RateGameButtonHide');
                    })
            } else {
                console.log(reason);
            }
        });
	},
	
	SaveExternData: function(data)
	{
		console.info('#################### SaveExternData');
		var dateString = UTF8ToString(data);
		console.log(dateString);
		console.log(JSON.parse(dateString));
		if (player != null)
		{
			console.info('Gamer is found');
			player.setData(JSON.parse(dateString));
		}
		else
		{
			console.info('Gamer is NOT found');
			localStorage.setItem('userData', dateString);
		}
	},
	
	LoadExternData: function()
	{
		console.info('#################### LoadExternalData');
		if (player != null) {
			player.getData().then(_data => {
				console.log(_data);
				console.log(JSON.stringify(_data));
				const myJson = JSON.stringify(_data);
				myGameInstance.SendMessage('Yandex', 'SetPlayerInfo', myJson);
			});
		}
		else
		{
			var data = localStorage.getItem('userData');
			if (data != null) myGameInstance.SendMessage('Yandex', 'SetPlayerInfo', data);
		}
	},
	
	GetLang: function() {
		var returnStr = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(returnStr) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(returnStr, buffer, bufferSize);
		return buffer;
	},
	
	ShowAddInternal: function()
	{
		ysdk.adv.showFullscreenAdv();
	},
	
});

