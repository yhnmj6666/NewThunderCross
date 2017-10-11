var lastFileName;

function getFileName(url) {
    return url ? url.split('/').pop().split('#').shift().split('?').shift() : null;
}
