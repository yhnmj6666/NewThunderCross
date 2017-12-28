class BaiduyunDownload {
    constructor() {
    }

    judge(rhDetails) {
        if (rhDetails.statusCode == 302) {
            if (! /pcs\.baidu\.com/i.test(new URL(rhDetails.url).hostname))
                return false;
            else {
                BaiduyunDownload.reqID = rhDetails.requestID;
                BaiduyunDownload.reqBaiduUrl = rhDetails.url;
            }
        }
        else if (rhDetails.statusCode == 200 && BaiduyunDownload.reqID != 0) {
            if (/baidupcs\.com/i.test(new URL(rhDetails.url).hostname)) {
                BaiduyunDownload.reqID = 0;
                return true;
            }
        }
        return false;
    }
};

BaiduyunDownload.reqID=0;
BaiduyunDownload.reqBaiduUrl="";