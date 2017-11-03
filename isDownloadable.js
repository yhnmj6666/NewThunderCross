var lastFileName;
var fileType;

function isDownloadable(rhDetails) {
    var isAttachment = false;
    var isTypeApplication = false;
    var isUnwantedFileType = false;
    var isWantedFileType = false;

    var ctIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name === "Content-Type";
    });
    //see whether it is font or something that not need download.
    if (ctIndex === -1)
        isTypeApplication = false;
    else {
        fileType=rhDetails.responseHeaders[ctIndex].value;
        var mimeType = rhDetails.responseHeaders[ctIndex].value.split('/');
        if (mimeType[0] === "application")
            isTypeApplication = true;
        if (mimeType[1].includes("html")||
            mimeType[1].includes("json") ||
            mimeType[1].includes("xml")  ||
            mimeType[1].includes("javascript")
            )
            isUnwantedFileType = true;
        console.log("Content-Type: " + rhDetails.responseHeaders[ctIndex].value);
    }

    var filename = getFileName(rhDetails.url);
    if (filename.includes(".")===false) {
       isUnwantedFileType = true;
    }
    if (filename.match(fileExtDiscard) !== null) {
        isUnwantedFileType = true;
    }
    if (filename.match(fileExtCatch) !== null) {
        lastFileName = filename;
        isWantedFileType = true;
    }

    var cdIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name === "Content-Disposition";
    });
    //no Content-Disposition
    if (cdIndex === -1) {
        isAttachment = false;
    }
    else {
        if (rhDetails.responseHeaders[cdIndex].value.startsWith("attachment")) {
            var matchInfo = rhDetails.responseHeaders[cdIndex].value.match(/filename=(.*)$/i);
            if (matchInfo !== null) {
                lastFileName = matchInfo[1].replace(/"/g, '').replace(';', '');
            }
            isAttachment = true;
        }
        else {
            isAttachment = false;
        }
        console.log("Content-Disposition: " + rhDetails.responseHeaders[cdIndex].value);
    }

    console.log("url: " + rhDetails.url);
    console.log("filename: " + filename);

    return !isUnwantedFileType && (isAttachment || isTypeApplication || isWantedFileType);
}