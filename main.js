browser.webRequest.onHeadersReceived.addListener(
  downloadCatcher.listener,
  downloadCatcher.fliter,
  downloadCatcher.extraInfoSpec
);


// /*
// On startup, connect to the "ping_pong" app.
// */

// var port = browser.runtime.connectNative("ThunderCross");

// /*
// Listen for messages from the app.
// */
// port.onMessage.addListener((response) => {
//   console.log("Sending Raw: " + response);
// });

// /*
// On a click on the browser action, send the app a message.
// */
// browser.browserAction.onClicked.addListener(() => {
//   console.log("Sending:  ping");
//   port.postMessage("ping");
// });
