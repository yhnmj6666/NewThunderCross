var CookieStore = {};
var ReferStore={};
var PostDataStore = {};

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
                Cookie: CookieStore[rhDetails.requestId] ? CookieStore[rhDetails.requestId].substr(0) : null,
                Refer: ReferStore[rhDetails.requestId] ? ReferStore[rhDetails.requestId].substr(0) : null,
                Method: rhDetails.method,
                PostData: {},

                ShowCenter: showCenter
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
                        break;
                    default:
                        break;
                }
            }
            if (dlInfo.Method == "POST") {
                dlInfo.PostData = PostDataStore[rhDetails.requestId];
            }
            switch (ActionRule.match(new URL(dlInfo.Url).hostname,
                dlInfo.FileExtension,
                dlInfo.ContentType)) {
                case "accept":
                    dlInfo.Action = "External";
                    break;
                case "deny":
                    dlInfo.Action = "Default";
                    break;
                case "ask":
                    dlInfo.Action = null;
                    break;
                default:
                    break;
            }
            //console.log(dlInfo);
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
                //console.log(reply);
                browser.tabs.query({ active: true }).then((tabs) => { //should change to details.tabId
                    if (autoClose && tabs[0].url == "about:blank")
                        browser.tabs.remove(tabs[0].id);
                });
                msgFromNative = reply.Choice;
                if (reply.Save === true) {
                    var action = null;
                    if (reply.Choice === "External")
                        action = "accept";
                    else if (reply.Choice === "Default")
                        action = "deny";

                    if (reply.SaveForSite === true)
                        ActionRule.add(new URL(dlInfo.Url).hostname,
                            dlInfo.FileExtension,
                            dlInfo.ContentType, action);
                    else {
                        ActionRule.add(null,
                            dlInfo.FileExtension,
                            dlInfo.ContentType, action);
                    }
                }
            }));
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
                else if (msgFromNative == "Default" && replaceAsk) {
                    browser.downloads.download({
                        url: dlInfo.Url,
                        filename: dlInfo.Filename,
                        method: rhDetails.method,
                        saveAs: false,
                    })
                    var blockingResponse = {
                        redirectUrl: rhDetails.type == "sub_frame" ? browser.extension.getURL("blank.html") : "http://downloadhandeled/"
                    }
                    return blockingResponse;
                }
                else {
                    return {};
                }
            }, (reason) => {
                //console.log(reason);
            });
        }
        else {
            return;
        }
    },

    sendListener: function (sDetails) {
        for (var header of sDetails.requestHeaders) {
            if (header.name.toLowerCase() == "cookie") {
                CookieStore[sDetails.requestId] = header.value;
            }
            else if (header.name.toLowerCase() == "referer") {
                ReferStore[sDetails.requestId] = header.value;
            }
            if (sDetails.method == "POST") {
                if(header.name.toLowerCase()=="content-type")
                    Object.defineProperty(PostDataStore[sDetails.requestId], "ContentType", {
                        configurable: true,
                        enumerable: true,
                        writable: true,
                        value: header.value
                    });
                else if(header.name.toLowerCase() == "content-length")
                    Object.defineProperty(PostDataStore[sDetails.requestId], "ContentLength", {
                        configurable: true,
                        enumerable: true,
                        writable: true,
                        value: header.value
                    });
            }
        }
    },

    requestListener: function (reqDetails) {
        if (/.*:\/\/pan\.baidu\.com/.test(reqDetails.url)) {
            if (reqDetails.tabId != -1)
                browser.tabs.executeScript(reqDetails.tabId, {
                    file: browser.extension.getURL("bdyHelper.js"),
                    runAt: "document_start"
                });
            return {};
        }
        if (reqDetails.method == "POST" && reqDetails.requestBody) {
            PostDataStore[reqDetails.requestId] = {};
            PostDataStore[reqDetails.requestId].Data = {};
            var _entry = Object.keys(reqDetails.requestBody.formData);
            for (var i = 0; i < _entry.length; i++) {
                Object.defineProperty(PostDataStore[reqDetails.requestId].Data, _entry[i], {
                    configurable: true,
                    enumerable: true,
                    writable: true,
                    value: reqDetails.requestBody.formData[_entry[i]][0]
                });
            }
        }
        return {};
    },

    completeListener: function (details) {
        try {
            delete CookieStore[details.requestId];
        } catch (error) { }
        try {
            delete ReferStore[details.requestId];
        } catch (error) { }
        try {
            if (details.method == "POST")
                delete PostDataStore[details.requestId];
        } catch (error) { }
    },

    downloadedLinkCanceler: function (details) {
        if (details.url == "http://downloadhandeled/")
            return { cancel: true };
        else
            return {};
    },

    fliter: {
        urls: ["<all_urls>"]
    }
}