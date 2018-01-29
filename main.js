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
    ["blocking"]
);
browser.runtime.onMessage.addListener((message, sender) => {
    var msg=JSON.parse(message);
    console.log(message);
    switch(msg.msg)
    {
        case "delete":
        {
            ActionRule.delete(msg.host,msg.extension,msg.mime,msg.action);
            console.log(ActionRule.global);
            console.log(ActionRule.hosts);
        }
        break;
    }
});
browser.runtime.onInstalled.addListener((details) => {
    if (details.temporary == false)
        browser.tabs.create({ url: browser.extension.getURL("Readme.html") });
});

console.log(ActionRule.hosts);
ActionRule.add("osu.com",".osz","application/download","accept");
console.log(ActionRule.hosts);