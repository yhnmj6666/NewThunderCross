var urlDlHandled = "http://downloadhandled/";
var downloadCatcher = {
    listener: function (rhDetails) {
        var promises = [];
        var msgFromNative;
        if (isDownloadable(rhDetails)) {
            //ask native program
            var dlInfo = {
                Url: rhDetails.url,
                Filename: lastFileName,
                DefaultDM: defaultDM,
                ContentLength: 0,
                ContentType: ""
            };
            for(i=0;i<rhDetails.responseHeaders.length;i++)
            {
                switch(rhDetails.responseHeaders[i].name.toLowerCase())
                {
                    case "content-length":
                        dlInfo.ContentLength=rhDetails.responseHeaders[i].value;
                        break;
                    case "content-type":
                        dlInfo.ContentType=rhDetails.responseHeaders[i].value;
                        break;
                    default:
                        ;
                }
            }
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
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
                return blockingResponse;
            }
            else {
                return {};
            }
        });
    },

    fliter: {
        urls: ["<all_urls>"]
    }
}