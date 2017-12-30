function saveOptions(e) {
    browser.storage.sync.set({
        wantedExtension: document.querySelector("#we").value,
        unwantedExtensio: document.querySelector("#ue").value,
        minAskSize: document.querySelector("#minsize").value,
        defaultDM: document.querySelector("#dm").value,
        CustomizedDMs:[{
            ExecutablePath: document.getElementById("exeFile").value,
            Arguments: document.getElementById("exeArgs").value,
            Name: null
        }],
        autoClose: document.getElementById("autoClose").checked
    });
    e.preventDefault();
}

function restoreOptions() {
    browser.storage.sync.get().then((res) => {
        document.querySelector("#we").value = res.wantedExtension || 'zip|rar|exe';
        document.querySelector("#ue").value = res.unwantedExtensio || 'js|woff2?|ttf|swf|cur|aspx';
        if (typeof res.minAskSize === 'undefined' || res.minAskSize === null)
            document.querySelector("#minsize").value = 1;
        else
            document.querySelector("#minsize").value = res.minAskSize;
        document.querySelector("#dm").value = res.defaultDM || "Thunder";

        if (res.defaultDM == "Customized") {
            document.getElementById("exeFile").removeAttribute("disabled");
            document.getElementById("exeArgs").removeAttribute("disabled");
        }

        document.getElementById("autoClose").checked = res.autoClose;

        var promises = [];
        var msgFromNative;
        //ask native program
        var dlInfo = {
            RequestType: "Version"
        };
        promises.push(browser.runtime.sendNativeMessage("ThunderCross",
            dlInfo
        ).then((reply) => {
            msgFromNative = "Native Client Version: " + reply.AddtionInfo;
        }, (reason) => {
            msgFromNative = "Native Client not Installed Properly.";
            console.log(reason);
        }));

        Promise.all(promises).then(function () {
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

function selectDM()
{
    var promises=[];
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

document.getElementById("button_check").addEventListener("click", checkDM);
document.getElementById("dm").addEventListener("change", dmChange);
document.getElementById("exeFile").addEventListener("dblclick",selectDM);
document.querySelector("form").addEventListener("submit", saveOptions);
document.addEventListener('DOMContentLoaded', restoreOptions);

