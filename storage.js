var fileExtCatch = /\.(zip)$/i;
var fileExtDiscard = /\.(js|woff2?|ttf|swf|cur|aspx|css|html)$/i;
var defaultDM="Thunder";
var minAskSize=1*1024*1024;
browser.storage.sync.get().then((res) => {
    fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip") + ")$", "i");
    fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx|css|html") + ")$", "i");
    defaultDM = res.storage || "Thunder";
    minAskSize=(res.minAskSize || 1)*1024*1024;
});
browser.storage.onChanged.addListener((changes, areaName) => {
    browser.storage.sync.get().then((res) => {
        fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip") + ")$", "i");
        fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx|css|html") + ")$", "i");
        defaultDM = res.storage || "Thunder";
        minAskSize=(res.minAskSize || 1)*1024*1024;        
    });
});
