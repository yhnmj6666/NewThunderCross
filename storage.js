var unWantedDocumentType = ["beacon", "csp_report", "font", "image", "imageset", "media", "ping", "script", "stylesheet", "web_manifest", "xbl", "xml_dtd", "xmlhttprequest", "xslt"];
var fileExtCatch = /\.(none)$/i;
var fileExtDiscard = /\.(swf)$/i;
var defaultDM = "Thunder";
var minAskSize = 1 * 1024 * 1024;
var autoClose = true;
var showCenter = false;
var replaceAsk = false;
var CustomizedDMs = [1];

function getAllOptions() {
    console.log("loaded");
    browser.storage.sync.get().then((res) => {
        fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "none") + ")$", "i");
        fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "swf") + ")$", "i");
        defaultDM = res.defaultDM || "Thunder";
        if (typeof res.minAskSize === 'undefined' || res.minAskSize === null)
            minAskSize = 1 * 1024 * 1024;
        else
            minAskSize = res.minAskSize * 1024 * 1024;
        autoClose = res.autoClose;
        showCenter = res.showCenter;
        replaceAsk = res.replaceAsk;
        CustomizedDMs = res.CustomizedDMs;
    });
}
browser.storage.onChanged.addListener((changes, areaName) => {
    if (areaName == "sync")
        getAllOptions();
});

getAllOptions();