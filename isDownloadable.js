function isDownloadable(rhDetails)
{
    var cdIndex=rhDetails.responseHeaders.findIndex( (element) => 
    {
        return element.name === "Content-Disposition";
    });

    //no Content-Disposition, needs additional judges
    if(cdIndex === -1)
    {
        var ctIndex=rhDetails.responseHeaders.findIndex( (element) => 
        {
            return element.name === "Content-Type";
        });
        //see whether it is font or something that not need download.
        var filename=getFileName(rhDetails.url);
        if(filename === null || ctIndex === -1)
            return false;
        if(rhDetails.responseHeaders[ctIndex].value.startsWith("application") && 
            filename.match(fileExtCatch) !== null)
        {
            lastFileName=getFileName(rhDetails.url);
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        if(rhDetails.responseHeaders[cdIndex].value.startsWith("attachment"))
        {
            var matchInfo=rhDetails.responseHeaders[cdIndex].value.match(/filename=(.*)$/i);
            if(matchInfo !== null)
            {
                lastFileName=matchInfo[1].replace(/"/g,'');
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}