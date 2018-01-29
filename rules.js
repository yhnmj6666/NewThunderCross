function handleDelete(clickEvent)
{
    console.log(this);
    var row=clickEvent.target.parentNode.parentNode;
    console.log(row.cells[0].firstChild);
    browser.runtime.sendMessage(JSON.stringify({
        msg: "delete",
        action: row.cells[0].firstChild.textContent,
        extension: row.cells[1].firstChild.textContent,
        mime: row.cells[2].firstChild.textContent,
        host: row.cells[3].firstChild.textContent
    }));
    row.parentNode.removeChild(row);
}

function loadRuleSet()
{
    var table=document.getElementById("ruleset");
    browser.storage.local.get().then((res) => {
        console.log(res);        
        if(res.actionRule != null)
        {
            res.actionRule.global.rules.forEach((value1, index, set) => {
                var row=table.insertRow();
                //acc or deny
                var cell=row.insertCell();
                cell.appendChild(document.createTextNode(value1.action));
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(value1.extension));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(value1.mime));
                //host
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //operation
                cell=row.insertCell();
                var but=document.createElement("button");
                but.appendChild(document.createTextNode("Delete"));
                but.addEventListener("click",handleDelete);
                cell.appendChild(but);
            });
            var _hosts=Object.keys(res.actionRule.hosts);
            _hosts.forEach((value,key,map) => {
                res.actionRule.hosts[value].rules.forEach((value1,index,set) => {
                    var row=table.insertRow();
                    //acc or deny
                    var cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value1.action));
                    //extension
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value1.extension));
                    //mime
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value1.mime));
                    //host
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value));
                    //operation
                    cell=row.insertCell();
                    var but=document.createElement("button");
                    but.appendChild(document.createTextNode("Delete"));
                    but.addEventListener("click",handleDelete);
                    cell.appendChild(but);
                });
            });
        }
    });
}

document.addEventListener('DOMContentLoaded', loadRuleSet);