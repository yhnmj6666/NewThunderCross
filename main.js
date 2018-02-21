browser.webRequest.onHeadersReceived.addListener(
    downloadCatcher.receivedListener,
    downloadCatcher.fliter,
    ["blocking", "responseHeaders"]
);
browser.webRequest.onSendHeaders.addListener(
    downloadCatcher.sendListener,
    downloadCatcher.fliter,
    ["requestHeaders"]
);
browser.webRequest.onBeforeRequest.addListener(
    downloadCatcher.requestListener,
    downloadCatcher.fliter,
    ["requestBody"]
);
browser.webRequest.onBeforeRequest.addListener(
    downloadCatcher.downloadedLinkCanceler,
    downloadCatcher.fliter,
    ["blocking"]
);
browser.webRequest.onCompleted.addListener(
    downloadCatcher.completeListener,
    downloadCatcher.fliter,
    []
);
browser.runtime.onMessage.addListener((message, sender) => {
    var msg=JSON.parse(message);
    switch(msg.msg)
    {
        case "delete":
        {
            ActionRule.delete(msg.host, msg.extension, msg.mime, msg.action);
        }
        break;
        case "edit":
        {
            if(msg.action == null)
                ActionRule.modify(msg.host, msg.defaultAction);
        }
        break;
        case "reset":
        {
            resetExtension();
        }
        break;
    }
});
browser.runtime.onInstalled.addListener((details) => {
    if (details.temporary == false && (details.reason=="update" || details.reason=="install"))
        browser.tabs.create({ url: browser.extension.getURL("Readme.html") });
    if (details.reason=="install")
        resetExtension();
});