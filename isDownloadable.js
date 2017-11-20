var lastFileName;

function isDownloadable(rhDetails) {
    var isAttachment = false;
    var isTypeApplication = false;
    var isUnwantedFileType = false;
    var isWantedFileType = false;
    var isFileTooSmall = false;

    var ctIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-type";
    });
    //see whether it is font or something that not need download.
    if (ctIndex === -1)
        isTypeApplication = false;
    else {
        var mimeType = rhDetails.responseHeaders[ctIndex].value.split('/');
        if (mimeType[0] == "application" && mimeType[1] != "octet-stream")
            isTypeApplication = true;
        if (mimeType[1].includes("html") ||
            mimeType[1].includes("json") ||
            mimeType[1].includes("xml") ||
            mimeType[1].includes("javascript")
        )
            isUnwantedFileType = true;
        console.log("Content-Type: " + rhDetails.responseHeaders[ctIndex].value);
    }

    var filename = getFileName(rhDetails.url);
    lastFileName = filename;
    // if (filename.includes(".")===false) {
    //    isUnwantedFileType = true;
    // }
    if (filename.match(fileExtDiscard) !== null) {
        isUnwantedFileType = true;
    }
    if (filename.match(fileExtCatch) !== null) {
        isWantedFileType = true;
    }

    var cdIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-disposition";
    });
    //no Content-Disposition
    if (cdIndex === -1) {
        isAttachment = false;
    }
    else {
        if (rhDetails.responseHeaders[cdIndex].value.startsWith("attachment")) {
            var matchInfo = rhDetails.responseHeaders[cdIndex].value.match(/filename=(.*)$/i);
            console.log("matchinfo=" + matchInfo);
            console.log("lastFN=" + lastFileName);
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

    var clIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-length";
    });
    if (clIndex === -1) {
        isFileTooSmall = true;
    }
    else {
        isFileTooSmall = parseInt(rhDetails.responseHeaders[clIndex]) < minAskSize;
    }
    return !isUnwantedFileType && !isFileTooSmall && (isAttachment || isTypeApplication || isWantedFileType);
}