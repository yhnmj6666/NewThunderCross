class BaiduyunDownload {
    constructor() {
    }

    judge(details) {
        if (details.statusCode == 302) {
            if (/pcs\.baidu\.com/i.test(new URL(details.url).hostname))
            {
                BaiduyunDownload.reqID = details.requestID;
                BaiduyunDownload.reqBaiduUrl = details.url;
            }
        }
        else if (details.statusCode == 200 && BaiduyunDownload.reqID != 0) {
            if (details.requestID == BaiduyunDownload.reqID)
            //  || /baidupcs\.com/i.test(new URL(rhDetails.url).hostname)
            {
                BaiduyunDownload.reqID = 0;
                return true;
            }
        }
        return false;
    }
};

BaiduyunDownload.reqID=0;
BaiduyunDownload.reqBaiduUrl="";