browser.webRequest.onHeadersReceived.addListener(
    downloadCatcher.listener,
    downloadCatcher.fliter,
    ["blocking", "responseHeaders"]
);
browser.runtime.onMessage.addListener((message, sender) => {
    if((message=="Downloaded" && autoDownCloseTab) || 
        (message=="Cancel" && autoCancelCloseTab))
        browser.tabs.remove(sender.tab.id).then(() => { }, (reason) => { console.log(reason); });
});
browser.runtime.onInstalled.addListener(()=>{
    browser.tabs.create({url:browser.extension.getURL("Readme.html")});
});