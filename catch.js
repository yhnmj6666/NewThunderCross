var downloadCatcher = {
    listener: function (rhDetails) {
        var promises = [];
        var msgFromNative;
        var d = new Downloadable();
        if (d.judge(rhDetails)) {
            //ask native program
            var dlInfo = {
                RequestType: "Download",
                DefaultDM: defaultDM,

                Url: rhDetails.url,
                Filename: d.lastFileName,
                ContentLength: 0,
                ContentType: "",
                Cookie: ""

            };
            if (d.isBaiduLink) {
                dlInfo.Url = d.baiduDownloadLink;
            }
            for (i = 0; i < rhDetails.responseHeaders.length; i++) {
                switch (rhDetails.responseHeaders[i].name.toLowerCase()) {
                    case "content-length":
                        dlInfo.ContentLength = rhDetails.responseHeaders[i].value;
                        break;
                    case "content-type":
                        dlInfo.ContentType = rhDetails.responseHeaders[i].value;
                        break;
                    case "set-cookie":
                        dlInfo.Cookie = rhDetails.responseHeaders[i].value;
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
        //redirect to two different blank page and decide whether auto close or not.
        //else
        //let it go
        return Promise.all(promises).then(function () {
            if (msgFromNative === "External") {
                var blockingResponse = {
                    redirectUrl: browser.extension.getURL("blank_down.html")
                }
                return blockingResponse;
            }
            else if (msgFromNative === "Canceled") {
                var blockingResponse = {
                    redirectUrl: browser.extension.getURL("blank_cancel.html")
                }
                return blockingResponse;
            }
            else {
                return {};
            }
        }, (reason) => {
            console.log(reason);
        });
    },

    fliter: {
        urls: ["<all_urls>"]
    }
}