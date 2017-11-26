var lastFileName;

function isDownloadable(rhDetails) {
    var isAttachment = false;
    var isTypeApplication = false;
    var isUnwantedFileType = false;
    var isWantedFileType = false;
    var isFileTooSmall = false;
    var isPartialContent=false;

    if(rhDetails.statusCode==206)
        isPartialContent=true;

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
    }

    var filename = getFileName(rhDetails.url);
    lastFileName = filename;
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
            if (matchInfo !== null) {
                lastFileName = matchInfo[1].replace(/"/g, '').replace(';', '');
            }
            isAttachment = true;
        }
        else {
            isAttachment = false;
        }
    }

    var clIndex = rhDetails.responseHeaders.findIndex((element) => {
        return element.name.toLowerCase() == "content-length";
    });
    if (clIndex === -1) {
        isFileTooSmall = true;
    }
    else {
        isFileTooSmall = (parseInt(rhDetails.responseHeaders[clIndex].value) < minAskSize);
    }

    //Debug
    console.log("url: " + rhDetails.url + "\nstatus code=" + rhDetails.statusLine +
        "\nfilename: " + filename + 
        ((clIndex===-1) ? "" : ("\nContent-Type: " + rhDetails.responseHeaders[ctIndex].value)) +
        ((cdIndex===-1) ? "" : ("\nContent-Disposition: " + rhDetails.responseHeaders[cdIndex].value)));
    //Debug

    return !isUnwantedFileType && !isFileTooSmall && !isPartialContent
        && (isAttachment || isTypeApplication || isWantedFileType);
}