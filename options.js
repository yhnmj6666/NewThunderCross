function saveOptions(e) {
    browser.storage.sync.set({
        wantedExtension: document.querySelector("#we").value,
        unwantedExtensio: document.querySelector("#ue").value,
        minAskSize: document.querySelector("#minsize").value,
        defaultDM: document.querySelector("#dm").value
    });
    e.preventDefault();
}

function restoreOptions() {
    var gettingItem = browser.storage.sync.get();
    gettingItem.then((res) => {
        document.querySelector("#we").value = res.wantedExtension || 'zip';
        document.querySelector("#ue").value = res.unwantedExtensio || 'js|woff2?|ttf|swf|cur|aspx';
        document.querySelector("#minsize").value=res.minAskSize || 1;
        document.querySelector("#dm").value=res.defaultDM || "Thunder";
    });
}

document.addEventListener('DOMContentLoaded', restoreOptions);
document.querySelector("form").addEventListener("submit", saveOptions);