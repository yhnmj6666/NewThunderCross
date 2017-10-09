var downloadCatcher={
    listener : function(rhDetails){
        if(isDownloadable(rhDetails))
        {
            //ask native program
            console.log("call Native");
            var dlInfo={
                Url : rhDetails.url
            }
            console.log(dlInfo);
            console.log(dlInfo.Url);
            browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            );
            //if external
            //redirect to http://downloadhandled
            //else
            //let it go
        }
        //not downloaded items, let it go
    },
    
    fliter : {
        urls : ["<all_urls>"]
    },

    extraInfoSpec : ["blocking","responseHeaders"]
}