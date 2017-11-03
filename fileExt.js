var fileExtCatch = /\.(zip)$/i;
var fileExtDiscard = /\.(js|woff2?|ttf|swf|cur|aspx)$/i;
browser.storage.sync.get().then((res) => {
    fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip") + ")$", "i");
    fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx") + ")$", "i");
});
browser.storage.onChanged.addListener((changes, areaName) => {
    browser.storage.sync.get().then((res) => {
        fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip") + ")$", "i");
        fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx") + ")$", "i");
    });
});