var fileExtCatch = /\.(zip|rar|exe)$/i;
var fileExtDiscard = /\.(js|woff2?|ttf|swf|cur|aspx|css|html)$/i;
var defaultDM = "Thunder";
var minAskSize = 1 * 1024 * 1024;
var autoCloseTab = false;
browser.storage.sync.get().then((res) => {
    fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip|rar|exe") + ")$", "i");
    fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx|css|html") + ")$", "i");
    defaultDM = res.defaultDM || "Thunder";
    if (typeof res.minAskSize === 'undefined' || res.minAskSize === null)
        minAskSize = 1 * 1024 * 1024;
    else
        minAskSize = res.minAskSize * 1024 * 1024;
    autoCloseTab = false;
});
browser.storage.onChanged.addListener((changes, areaName) => {
    browser.storage.sync.get().then((res) => {
        fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip|rar|exe") + ")$", "i");
        fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx|css|html") + ")$", "i");
        defaultDM = res.defaultDM || "Thunder";
        if (typeof res.minAskSize === 'undefined' || res.minAskSize === null)
            minAskSize = 1 * 1024 * 1024;
        else
            minAskSize = res.minAskSize * 1024 * 1024;
        autoCloseTab = false;
    });
});