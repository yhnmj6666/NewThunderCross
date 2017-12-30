var unWantedDocumentType = ["beacon", "csp_report", "font", "image", "imageset", "media", "ping", "script", "stylesheet", "web_manifest", "xbl", "xml_dtd", "xmlhttprequest", "xslt"];
var fileExtCatch = /\.(zip|rar|exe)$/i;
var fileExtDiscard = /\.(js|woff2?|ttf|swf|cur|aspx|css|html)$/i;
var defaultDM = "Thunder";
var minAskSize = 1 * 1024 * 1024;
var autoClose = true;
var CustomizedDMs = [];

function getAllOptions() {
    browser.storage.sync.get().then((res) => {
        fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "zip|rar|exe") + ")$", "i");
        fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "js|woff2?|ttf|swf|cur|aspx|css|html") + ")$", "i");
        defaultDM = res.defaultDM || "Thunder";
        if (typeof res.minAskSize === 'undefined' || res.minAskSize === null)
            minAskSize = 1 * 1024 * 1024;
        else
            minAskSize = res.minAskSize * 1024 * 1024;
        autoClose = res.autoClose;
        CustomizedDMs = res.CustomizedDM;
    });
}
browser.storage.onChanged.addListener((changes, areaName) => {
    getAllOptions();
});

getAllOptions();