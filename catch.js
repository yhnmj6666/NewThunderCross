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
            var asking=browser.runtime.sendNativeMessage("ThunderCross",
                dlInfo
            );
            asking.then(onResponse,onError);
            //if external
            //redirect to http://downloadhandled
            //else
            //let it go
        }
        //not downloaded items, let it go
    },

    onResponse : function(response)
    {
        
    },

    onError : function(error)
    {
        console.log(`Error: ${error}`);
    },
    
    fliter : {
        urls : ["<all_urls>"]
    },

    extraInfoSpec : ["blocking","responseHeaders"]
}