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

        var promises = [];
        var msgFromNative;
            //ask native program
            var dlInfo = {
                RequestType:"Version"
            };
            promises.push(browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            ).then((reply) => {
                msgFromNative = "Native Client Version: " + reply.AddtionInfo;
            },(reason) => {
                msgFromNative= "Native Client not Installed Properly.";
                console.log(reason);
            }));
    
        Promise.all(promises).then(function () {
            document.querySelector("#version").innerHTML=msgFromNative;
        });
    });
}

function checkDM()
{
    var promises = [];
    var msgFromNative;
        //ask native program
        var dlInfo = {
            RequestType:"CheckDM"
        };
        promises.push(browser.runtime.sendNativeMessage("ThunderCross",
            dlInfo
        ).then((reply) => {
            msgFromNative = reply.AddtionInfo;
        }));

    Promise.all(promises).then(function () {
        document.getElementById("check_result").innerHTML="<pre>"+msgFromNative+"<\pre>";
    });
}

document.addEventListener('DOMContentLoaded', restoreOptions);
document.querySelector("form").addEventListener("submit", saveOptions);
document.getElementById("button_check").addEventListener("click", checkDM);