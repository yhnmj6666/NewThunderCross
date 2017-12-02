var lastFileName;

function isDownloadable(rhDetails) {
    var isAttachment = false;
    var isTypeApplication = false;
    var isUnwantedFileType = false;
    var isWantedFileType = false;
    var isFileTooSmall = false;
    var isPartialContent = false;

    if (rhDetails.statusCode == 206)
        isPartialContent = true;

    var filename = getFileName(rhDetails.url);
    lastFileName = filename;
    if (filename.match(fileExtDiscard) !== null) {
        isUnwantedFileType = true;
    }
    if (filename.match(fileExtCatch) !== null) {
        isWantedFileType = true;
    }

    for (i = 0; i < rhDetails.responseHeaders.length; i++) {
        switch (rhDetails.responseHeaders[i].name.toLowerCase()) {
            case "content-disposition":
                {
                    if (rhDetails.responseHeaders[i].value.startsWith("attachment")) {
                        var matchInfo = rhDetails.responseHeaders[i].value.match(/filename=(.*)(\b|;)/i);
                        if (matchInfo !== null) {
                            lastFileName = matchInfo[1].replace(/"/g, '').replace(';', '');
                        }
                        isAttachment = true;
                    }
                    else {
                        isAttachment = false;
                    }
                }
                break;
            case "content-type":
                {
                    var mimeType = rhDetails.responseHeaders[i].value.split(';').shift().split('/');
                    if (mimeType[0] == "application" && (mimeType[1] == "octet-stream" == filename.includes(".")))
                        isTypeApplication = true;
                    if (mimeType[1].includes("html") ||
                        mimeType[1].includes("json") ||
                        mimeType[1].includes("xml") ||
                        mimeType[1].includes("javascript")
                    )
                        isUnwantedFileType = true;
                }
                break;
            case "content-length":
                { isFileTooSmall = (parseInt(rhDetails.responseHeaders[i].value) < minAskSize); }
                break;
            default:
                ;
        }
    }

    //Debug
    var ctIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-type";
    });

    var cdIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-disposition";
    });

    var clIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-length";
    });

    if (cdIndex !== -1 && rhDetails.responseHeaders[cdIndex].value.startsWith("attachment")) {
        console.log("url: " + rhDetails.url + "\nstatus code=" + rhDetails.statusLine +
            "\nfilename: " + filename +
            ((ctIndex === -1) ? "" : ("\nContent-Type: " + rhDetails.responseHeaders[ctIndex].value)) +
            ((cdIndex === -1) ? "" : ("\nContent-Disposition: " + rhDetails.responseHeaders[cdIndex].value)));
    }
    //Debug

    return !isUnwantedFileType && (isWantedFileType || (!isFileTooSmall && !isPartialContent &&
        (isTypeApplication || isAttachment)));
}