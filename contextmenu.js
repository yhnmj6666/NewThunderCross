function createMenu() {
    // browser.menus.create({
    //     contexts: ["audio", "image", "video"],
    //     id: "contextDownload",
    //     onclick: contextMenuOnClick,
    //     title: "Download using " + defaultDM
    // });
    browser.menus.create({
        contexts: ["link"],
        id: "contextDownloadLink",
        onclick: contextMenuOnClick,
        title: "Download using " + defaultDM
    });
}

function contextMenuOnClick(info, tab) {
    var url = info.menuItemId === "contextDownload" ? info.srcUrl : info.linkUrl;
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