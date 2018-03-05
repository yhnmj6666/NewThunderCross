function createMenu()
{
    browser.menus.create({
        contexts:["audio","image","link","video"],
        id:"contextDownloadLink",
        onclick:contextMenuOnClick,
        title:"Download using ThunderCross"
    });
}

function contextMenuOnClick(info, tab)
{
    console.log(info);
}