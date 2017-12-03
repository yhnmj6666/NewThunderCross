browser.webRequest.onHeadersReceived.addListener(
    downloadCatcher.listener,
    downloadCatcher.fliter,
    ["blocking", "responseHeaders"]
);
browser.runtime.onMessage.addListener((message, sender) => {
    browser.tabs.remove(sender.tab.id).then(() => { }, (reason) => { console.log(reason); });
});