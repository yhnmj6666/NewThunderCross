function handleDelete(clickEvent)
{
    var row=clickEvent.target.parentNode.parentNode;
    browser.runtime.sendMessage(JSON.stringify({
        msg: "delete",
        action: row.cells[0].firstChild.textContent,
        extension: row.cells[1].firstChild.textContent,
        mime: row.cells[2].firstChild.textContent,
        host: row.cells[3].firstChild.textContent,
        defaultAction: null
    }));
    row.parentNode.removeChild(row);
}

function loadRuleSet()
{
    var table=document.getElementById("ruleset");
    browser.storage.local.get().then((res) => {
        if(res.actionRule != null)
        {
            var _hosts=Object.keys(res.actionRule.hosts);
            _hosts.forEach((value,key,map) => {
                res.actionRule.hosts[value].rules.forEach((value1,index,set) => {
                    var row=table.insertRow();
                    //acc or deny
                    var cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value1.action));
                    //extension
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value1.extension || ""));
                    //mime
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(value1.mime || ""));
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
            res.actionRule.global.rules.forEach((value1, index, set) => {
                var row=table.insertRow();
                //acc or deny
                var cell=row.insertCell();
                cell.appendChild(document.createTextNode(value1.action));
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(value1.extension || ""));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(value1.mime || ""));
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
            {
                var row=table.insertRow();
                //acc or deny
                var sel=document.createElement("select");
                {
                    var opt=document.createElement("option");
                    opt.value="ask";
                    opt.text="ask";
                    sel.add(opt);
                }
                {
                    var opt=document.createElement("option");
                    opt.value="accept";
                    opt.text="accept";
                    sel.add(opt);
                }
                {
                    var opt=document.createElement("option");
                    opt.value="deny";
                    opt.text="deny";
                    sel.add(opt);
                }
                switch(res.actionRule.global.defaultAction)
                {
                    case "ask":
                        sel.selectedIndex=0;
                        break;
                    case "accept":
                        sel.selectedIndex=1;
                        break;
                    case "deny":
                        sel.selectedIndex=2;
                        break;
                }
                cell=row.insertCell();
                cell.appendChild(sel);
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //host
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //operation
                cell=row.insertCell();
                var but=document.createElement("button");
                but.appendChild(document.createTextNode("Save"));
                but.addEventListener("click",(clickEvent) => {
                    var row=clickEvent.target.parentNode.parentNode;
                    browser.runtime.sendMessage(JSON.stringify({
                        msg: "edit",
                        action: null,
                        extension: null,
                        mime: null,
                        host: null,
                        defaultAction: row.cells[0].firstChild.selectedOptions[0].value
                    }));
                });
                cell.appendChild(but);
            }
        }
    });
}

document.addEventListener('DOMContentLoaded', loadRuleSet);