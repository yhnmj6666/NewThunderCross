browser.webRequest.onBeforeRequest.addListener(
    (details) => {
        if (details.url === urlDlHandled) {
            var blockingResponse = {
                cancel: true
            }
            console.log("canceled");
            return blockingResponse;
        }
        else {
            //console.log("not calceled: " + details.url);
            return {};
        }
    },
    downloadCatcher.fliter,
    ["blocking"]
);
browser.webRequest.onHeadersReceived.addListener(
    downloadCatcher.listener,
    downloadCatcher.fliter,
    ["blocking", "responseHeaders"]
);

//TODO:
//never catch js files!
//settings page
//eagelget support
//improve isDownloadable function.
//instant download after c# returns
//public releases