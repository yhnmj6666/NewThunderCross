class StntsDownload
{
    constructor() {
    }

    static judge(details) {
        if(/.*\.stnts\.com\/download\/file\/matrix/.test(details.url) && details.method=="POST")
            return true;
        else
            return false;
    }
};