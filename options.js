function saveOptions(e) {
    browser.storage.sync.set({
        wantedExtension: document.querySelector("#we").value,
        unwantedExtensio: document.querySelector("#ue").value,
        minAskSize: document.querySelector("#minsize").value,
        defaultDM: document.querySelector("#dm").value,
        CustomizedDMs: [{
            ExecutablePath: document.getElementById("exeFile").value,
            Arguments: document.getElementById("exeArgs").value,
            Name: null
        }],
        autoClose: document.getElementById("autoClose").checked,
        showCenter: document.getElementById("showCenter").checked,
        replaceAsk: document.getElementById("replaceAsk").checked
    });
    e.preventDefault();
}

function restoreOptions() {
    browser.storage.sync.get().then((res) => {
        document.querySelector("#we").value = res.wantedExtension;
        document.querySelector("#ue").value = res.unwantedExtensio;
        if (typeof res.minAskSize === 'undefined' || res.minAskSize === null)
            document.querySelector("#minsize").value = 1;
        else
            document.querySelector("#minsize").value = res.minAskSize;
        document.querySelector("#dm").value = res.defaultDM || "Thunder";

        if (res.defaultDM == "Customized") {
            document.getElementById("exeFile").removeAttribute("disabled");
            document.getElementById("exeFile").value = res.CustomizedDMs[0].ExecutablePath;
            document.getElementById("exeArgs").removeAttribute("disabled");
            document.getElementById("exeArgs").value = res.CustomizedDMs[0].Arguments;
        }

        document.getElementById("autoClose").checked = res.autoClose;
        document.getElementById("showCenter").checked=res.showCenter;
        document.getElementById("replaceAsk").checked=res.replaceAsk;

        var promises = [];
        var msgFromNative;
        //ask native program
        var dlInfo = {
            RequestType: "Version"
        };
        promises.push(browser.runtime.sendNativeMessage("ThunderCross",
            dlInfo
        ).then((reply) => {
            msgFromNative = browser.i18n.getMessage("Native_Client_Version") + reply.AddtionInfo;
        }, (reason) => {
            msgFromNative = browser.i18n.getMessage("Native_Client_not_Installed_Properly");
        }));

        Promise.all(promises).then(function () {
            document.getElementById("version").removeChild(document.getElementById("version").firstChild);
            document.getElementById("version").appendChild(document.createTextNode(msgFromNative));
        });
    });
}

function checkDM() {
    var promises = [];
    //ask native program
    var dlInfo = {
        RequestType: "CheckDM"
    };
    promises.push(browser.runtime.sendNativeMessage("ThunderCross",
        dlInfo
    ).then((reply) => {
        var cr = document.getElementById("check_result");
        if (cr.childNodes.length == 0)
            cr.appendChild(document.createTextNode(reply.AddtionInfo));
        else
            cr.firstChild.nodeValue = reply.AddtionInfo;
    }));

    return promises;
}

function dmChange() {
    if (this.options[this.selectedIndex].value == "Customized") {
        document.getElementById("exeFile").removeAttribute("disabled");
        document.getElementById("exeArgs").removeAttribute("disabled");
    }
    else {
        document.getElementById("exeFile").setAttribute("disabled", true);
        document.getElementById("exeArgs").setAttribute("disabled", true);
    }
}

function selectDM() {
    var promises = [];
    var dlInfo = {
        RequestType: "SelectDM"
    };
    promises.push(browser.runtime.sendNativeMessage("ThunderCross",
        dlInfo
    ).then((reply) => {
        document.getElementById("exeFile").value = reply.AddtionInfo;
    }));
    return promises;
}

function resetSetting()
{
    browser.runtime.sendMessage(JSON.stringify({
        msg: "reset"
    }));

    window.location.reload();
}

document.getElementById("button_check").addEventListener("click", checkDM);
document.getElementById("dm").addEventListener("change", dmChange);
document.getElementById("exeFile").addEventListener("dblclick", selectDM);
document.getElementById("button_restoreDefault").addEventListener("click",resetSetting);
document.querySelector("form").addEventListener("submit", saveOptions);
document.addEventListener('DOMContentLoaded', restoreOptions);

