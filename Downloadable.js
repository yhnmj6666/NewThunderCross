class Downloadable {
    constructor() {
        this.isBaiduLink = false;
        this.baiduDownloadLink="";
        this.lastFileName = "";
    }
    

    judge(rhDetails) {
        var isAttachment = false;
        var isTypeApplication = false;
        var isUnwantedFileType = false;
        var isWantedFileType = false;
        var isFileTooSmall = false;
        var is200Code = true;
        var bdyDown=new BaiduyunDownload();

        if (bdyDown.judge(rhDetails))
        {
            this.isBaiduLink = true;
            this.baiduDownloadLink=BaiduyunDownload.reqBaiduUrl;
        }

        if (rhDetails.statusCode != 200)
            is200Code = false;

        var filename = getFileName(rhDetails.url);
        this.lastFileName = filename;
        if (filename.match(fileExtDiscard) !== null) {
            isUnwantedFileType = true;
        }
        if (filename.match(fileExtCatch) !== null) {
            isWantedFileType = true;
        }

        for (var i = 0; i < rhDetails.responseHeaders.length; i++) {
            switch (rhDetails.responseHeaders[i].name.toLowerCase()) {
                case "content-disposition":
                    {
                        if (rhDetails.responseHeaders[i].value.startsWith("attachment")) {
                            var matchInfo = rhDetails.responseHeaders[i].value.match(/filename=(.*)(\b|;)/i);
                            if (matchInfo !== null) {
                                this.lastFileName = matchInfo[1].replace(/"/g, '').replace(';', '');
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
                        if (mimeType[0] == "application") {
                            if (mimeType[1] == "octet-stream" && filename.includes("."))
                                isTypeApplication = true;
                            else if (mimeType[1] != "octet-stream")
                                isTypeApplication = true;
                        }
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

        //if (cdIndex !== -1 && rhDetails.responseHeaders[cdIndex].value.startsWith("attachment")) 
        {
            console.log("url: " + rhDetails.url + "\nstatus code=" + rhDetails.statusLine +
                "\nfilename: " + filename +
                ((ctIndex === -1) ? "" : ("\nContent-Type: " + rhDetails.responseHeaders[ctIndex].value)) +
                "\nContent-Disposition: " +
                ((cdIndex === -1) ? "none" : (rhDetails.responseHeaders[cdIndex].value)));
        }
        //Debug

        return !isUnwantedFileType && (isWantedFileType || (!isFileTooSmall && is200Code &&
            (isTypeApplication || isAttachment)));
    }
};