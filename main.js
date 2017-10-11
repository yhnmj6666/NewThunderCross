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
            console.log("not calceled: " + details.url);
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

// /*
// On startup, connect to the "ping_pong" app.
// */

// var port = browser.runtime.connectNative("ThunderCross");

// /*
// Listen for messages from the app.
// */
// port.onMessage.addListener((response) => {
//   console.log("Received " + response);
// });

// /*
// On a click on the browser action, send the app a message.
// */
// browser.browserAction.onClicked.addListener(() => {
//   console.log("Sending:  ping");
//   port.postMessage("ping");
// });
