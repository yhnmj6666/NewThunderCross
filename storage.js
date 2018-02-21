var unWantedDocumentType = ["beacon", "csp_report", "font", "image", "imageset", "media", "ping", "script", "stylesheet", "web_manifest", "xbl", "xml_dtd", "xmlhttprequest", "xslt"];
var fileExtCatch = /\.(none)$/i;
var fileExtDiscard = /\.(swf)$/i;
var defaultDM = "Thunder";
var minAskSize = 1 * 1024 * 1024;
var autoClose = true;
var showCenter = false;
var replaceAsk = false;
var CustomizedDMs = [1];

function resetExtension()
{
    browser.storage.sync.set({
        wantedExtension: "none",
        unwantedExtensio: "swf|f4v",
        minAskSize: 1,
        defaultDM: "Thunder",
        CustomizedDMs: [{
            ExecutablePath: null,
            Arguments: null,
            Name: null
        }],
        autoClose: true,
        showCenter: false,
        replaceAsk: false
    });

    browser.storage.local.set({
        actionRule: {
            global: {
                rules: [],
                defaultAction: "ask"
            },
            hosts: {}
        }
    });
}

function getAllOptions() {
    browser.storage.sync.get().then((res) => {
        fileExtCatch = new RegExp("\\.(" + (res.wantedExtension || "none") + ")$", "i");
        fileExtDiscard = new RegExp("\\.(" + (res.unwantedExtension || "swf|f4v") + ")$", "i");
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