class Downloadable {
    constructor() {
        this.isBaiduLink = false;
        this.baiduDownloadLink = "";
        this.lastFileName = "";
    }


    judge(rhDetails) {
        var isAttachment = false;
        var isTypeApplication = false;
        var isUnwantedFileType = false;
        var isWantedFileType = false;
        var isFileTooSmall = false;
        var is200Code = false;
        var bdyDown = new BaiduyunDownload();
        var isStDown=StntsDownload.judge(rhDetails);

        if (bdyDown.judge(rhDetails)) {
            this.isBaiduLink = true;
            this.baiduDownloadLink = BaiduyunDownload.reqBaiduUrl;
        }

        if (rhDetails.statusCode == 200)
            is200Code = true;

        var filename = getFileName(rhDetails.url);
        this.lastFileName = filename;
        if (filename.match(fileExtDiscard) !== null) {
            isUnwantedFileType = true;
        }
        if (unWantedDocumentType.includes(rhDetails.type)) { //if not sub_frame or main_frame or object or other
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
                            var matchInfo = rhDetails.responseHeaders[i].value.match(/filename=(.*?)($|;)/i);
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

        return is200Code && (!isUnwantedFileType && (isWantedFileType || (!isFileTooSmall &&
            (isTypeApplication || isAttachment))) || isStDown);
    }
};