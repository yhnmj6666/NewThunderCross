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
    if ((message == "Downloaded" && autoDownCloseTab) ||
        (message == "Cancel" && autoCancelCloseTab))
        browser.tabs.remove(sender.tab.id).then(() => { }, (reason) => { console.log(reason); });
});
browser.runtime.onInstalled.addListener((details) => {
    if (details.temporary == false)
        browser.tabs.create({ url: browser.extension.getURL("Readme.html") });
});