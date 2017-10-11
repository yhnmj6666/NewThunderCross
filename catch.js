var urlDlHandled = "http://downloadhandled/";
var downloadCatcher = {
    listener: function (rhDetails) {
        var promises = [];
        var msgFromnative;
        if (isDownloadable(rhDetails)) {
            //ask native program
            console.log("call Native");
            var dlInfo = {
                Url: rhDetails.url
            };
            console.log(dlInfo);
            console.log(dlInfo.Url);
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
                msgFromnative = reply;
            }));
        }
        //if external
        //redirect to http://downloadhandled
        //else
        //let it go
        return Promise.all(promises).then(function () {
            if (msgFromnative === "External") {
                var blockingResponse = {
                    redirectUrl: urlDlHandled
                }
                console.log("redirected");
                return blockingResponse;
            }
            else {
                console.log("not redirected");
                return {};
            }
        });
    },

    fliter: {
        urls: ["<all_urls>"]
    }
}