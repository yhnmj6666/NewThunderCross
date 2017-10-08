var downloadCatcher={
    listener : function(rhDetails){
        console.log(rhDetails.url);
        //console.log(rhDetails.responseHeaders.length)
        var cdIndex=rhDetails.responseHeaders.findIndex( (element) => {
            if(element.name === "Content-Disposition")
                return true;
            else
                return false;
        });
        if(cdIndex !== -1  && 
            rhDetails.responseHeaders[cdIndex].value.startsWith("attachment"))
        {
            console.log("act download");
        }

    },
    
    fliter : {
        urls : ["<all_urls>"]
    },

    extraInfoSpec : ["blocking","responseHeaders"]
}