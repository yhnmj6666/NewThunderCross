function createMenu() {
    browser.menus.create({
        contexts: ["link","audio", "image", "video"],
        id: "contextDownloadLink",
        onclick: contextMenuOnClick,
        title: "Download using " + defaultDM
    });
    // browser.menus.create({
    //     contexts: ["all"],
    //     id:"contextDownloadAll",
    //     onclick: contextMenuDownloadAll,
    //     title: "Download Them All"
    // });
}

function contextMenuOnClick(info, tab) {
    var url = info.srcUrl != "" ? info.srcUrl : info.linkUrl;
    var fn = getFileName(url);
    var ext = /\.[0-9a-z]+$/i.exec(fn);
    var dlInfo = {
        RequestType: "Download",
        DefaultDM: defaultDM,
        Action: "External",
        CustomizedDM: CustomizedDMs,

        Url: url,
        Filename: fn,
        FileExtension: ext == null ? null : ext[0],
        ContentLength: 0,
        ContentType: "",
        Cookie: null,
        Refer: info.pageUrl,
        Method: "GET",
        PostData: {},

        ShowCenter: showCenter
    };
    browser.runtime.sendNativeMessage("ThunderCross",
        dlInfo
    );
}

function contextMenuDownloadAll(info, tab)
{
    console.log(info);
    console.log(tab);
    browser.tabs.executeScript(tab.id,{
        file:"contentDownloadAll.js"
    });
}