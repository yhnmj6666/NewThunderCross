var urlDlHandled = "http://downloadhandled/";
var downloadCatcher = {
    listener: function (rhDetails) {
        var promises = [];
        var msgFromNative;
        if (isDownloadable(rhDetails)) {
            //ask native program
            var dlInfo = {
                RequestType:"Download",                
                DefaultDM: defaultDM,

                Url: rhDetails.url,
                Filename: lastFileName,                
                ContentLength: 0,
                ContentType: "",
                Cookie: ""

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
                    case "set-cookie":
                        dlInfo.Cookie=rhDetails.responseHeaders[i].value;
                    default:
                        ;
                }
            }
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
                msgFromNative = reply.Choice;
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