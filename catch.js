var urlDlHandled = "http://downloadhandled/";
var downloadCatcher = {
    listener: function (rhDetails) {
        var promises = [];
        var msgFromNative;
        if (isDownloadable(rhDetails)) {
            //ask native program
            //console.log("call Native");
            var dlInfo = {
                Url: rhDetails.url,
                Filename: lastFileName,
                Filetype: fileType
            };
            //console.log(dlInfo);
            //console.log(dlInfo.Url);
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
                console.log("reply: "+reply);
                msgFromNative = reply;
            }));
        }
        //if external
        //redirect to http://downloadhandled
        //else
        //let it go
        return Promise.all(promises).then(function () {
            if (msgFromNative === "External" ||
                msgFromNative === "Canceled") {
                var blockingResponse = {
                    redirectUrl: urlDlHandled
                }
                console.log("redirected");
                return blockingResponse;
            }
            else {
                //console.log("not redirected");
                return {};
            }
        });
    },

    fliter: {
        urls: ["<all_urls>"]
    }
}