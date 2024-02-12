mergeInto(LibraryManager.library, {

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
		if (player != null) {
			var dateString = UTF8ToString(data);
			console.log(dateString);
			console.log(JSON.parse(dateString));
			player.setData(JSON.parse(dateString));
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
	},
	
});

