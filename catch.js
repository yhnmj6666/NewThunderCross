var CookieStore = {};

var downloadCatcher = {
    receivedListener: function (rhDetails) {
        var promises = [];
        var msgFromNative;
        var d = new Downloadable();
        if (d.judge(rhDetails)) {
            //ask native program
            var dlInfo = {
                RequestType: "Download",
                DefaultDM: defaultDM,
                Action: null,
                CustomizedDM: CustomizedDMs,

                Url: rhDetails.url,
                Filename: d.lastFileName,
                FileExtension: /\.[0-9a-z]+$/i.exec(d.lastFileName)[0],
                ContentLength: 0,
                ContentType: "",
                Cookie: CookieStore[rhDetails.requestId].substr(0)
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
                        dlInfo.Cookie += rhDetails.responseHeaders[i].value;
                    default:
                        ;
                }
            }
            switch (ActionRule.match(new URL(dlInfo.Url).hostname,
                dlInfo.FileExtension,
                dlInfo.ContentType)) {
                case true:
                    dlInfo.Action = "External";
                    break;
                case false:
                    dlInfo.Action = "Default";
                    break;
                case null:
                    dlInfo.Action = null;
                    break;
                default:
                    break;
            }
            console.log(dlInfo);
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
                console.log(reply);
                browser.tabs.query({ active: true }).then((tabs) => {
                    if (autoClose && tabs[0].url == "about:blank")
                        browser.tabs.remove(tabs[0].id);
                });
                msgFromNative = reply.Choice;
                if (reply.Save === true) {
                    var action = null;
                    if (reply.Choice === "External")
                        action = true;
                    else if (reply.Choice === "Default")
                        action = false;

                    if (reply.SaveForSite === true)
                        ActionRule.addRule(new URL(dlInfo.Url).hostname,
                            dlInfo.FileExtension,
                            dlInfo.ContentType, action);
                    else {
                        ActionRule.addRule(null,
                            dlInfo.FileExtension,
                            dlInfo.ContentType, action);
                    }
                }
            }));
        }
        if(rhDetails.statusCode!=302)
        {
            delete CookieStore[rhDetails.requestId];
        }
        //if external
        //redirect to two different blank page and decide whether auto close or not.
        //else
        //let it go
        return Promise.all(promises).then(function () {
            if (msgFromNative == "External" || msgFromNative == "Cancel") {
                var blockingResponse = {
                    redirectUrl: rhDetails.type == "sub_frame" ? browser.extension.getURL("blank.html") : "http://downloadhandeled/"
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

    sendListener: function (sDetails) {
        for (var header of sDetails.requestHeaders) {
            if (header.name.toLowerCase() == "cookie") {
                CookieStore[sDetails.requestId] = header.value;                
            }
        }
    },

    requestListener: function (reqDetails) {
        if (reqDetails.url == "http://downloadhandeled/")
            return { cancel: true };
        else
            return {};
    },

    fliter: {
        urls: ["<all_urls>"]
    }
}