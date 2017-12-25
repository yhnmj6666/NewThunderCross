browser.webRequest.onHeadersReceived.addListener(
    downloadCatcher.listener,
    downloadCatcher.fliter,
    ["blocking", "responseHeaders"]
);
browser.runtime.onMessage.addListener((message, sender) => {
    if(autoCloseTab)
        browser.tabs.remove(sender.tab.id).then(() => { }, (reason) => { console.log(reason); });
});
browser.runtime.onInstalled.addListener(()=>{
    if(autoCloseTab)
        browser.tabs.create({url:browser.extension.getURL("Readme.html")});
});