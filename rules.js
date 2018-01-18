function loadRuleSet()
{
    var table=document.getElementById("ruleset");
    browser.storage.local.get().then((res) => {
        console.log(res);        
        if(res.actionRule != null)
        {
            for(var r of res.actionRule.acc_ext)
            {
                var row=table.insertRow();
                //acc or deny
                var cell=row.insertCell();
                cell.appendChild(document.createTextNode("Accept"));
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(r));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(""));
                //host
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //operation
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("No operation"));
            }
            for(var r of res.actionRule.acc_mime)
            {
                var row=table.insertRow();
                //acc or deny
                var cell=row.insertCell();
                cell.appendChild(document.createTextNode("Accept"));
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(""));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(r));
                //host
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //operation
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("No operation"));
            }
            for(var r of res.actionRule.deny_ext)
            {
                var row=table.insertRow();
                //acc or deny
                var cell=row.insertCell();
                cell.appendChild(document.createTextNode("Deny"));
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(r));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(""));
                //host
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //operation
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("No operation"));
            }
            for(var r of res.actionRule.deny_mime)
            {
                var row=table.insertRow();
                //acc or deny
                var cell=row.insertCell();
                cell.appendChild(document.createTextNode("Deny"));
                //extension
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(""));
                //mime
                cell=row.insertCell();
                cell.appendChild(document.createTextNode(r));
                //host
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("*"));
                //operation
                cell=row.insertCell();
                cell.appendChild(document.createTextNode("No operation"));
            }
        }
        var _properties=Object.keys(res);
        for(var i=_properties.length-1;i>=0;i--)
        {
            var i_value=_properties[i];
            if(i_value != "actionRule")
            {
                for(var r of res[i_value].acc_ext)
                {
                    var row=table.insertRow();
                    //acc or deny
                    var cell=row.insertCell();
                    cell.appendChild(document.createTextNode("Accept"));
                    //extension
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(r));
                    //mime
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(""));
                    //host
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(i_value));
                    //operation
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode("No operation"));
                }
                for(var r of res[i_value].acc_mime)
                {
                    var row=table.insertRow();
                    //acc or deny
                    var cell=row.insertCell();
                    cell.appendChild(document.createTextNode("Accept"));
                    //extension
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(""));
                    //mime
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(r));
                    //host
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(i_value));
                    //operation
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode("No operation"));
                }
                for(var r of res[i_value].deny_ext)
                {
                    var row=table.insertRow();
                    //acc or deny
                    var cell=row.insertCell();
                    cell.appendChild(document.createTextNode("Deny"));
                    //extension
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(r));
                    //mime
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(""));
                    //host
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(i_value));
                    //operation
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode("No operation"));
                }
                for(var r of res[i_value].deny_mime)
                {
                    var row=table.insertRow();
                    //acc or deny
                    var cell=row.insertCell();
                    cell.appendChild(document.createTextNode("Deny"));
                    //extension
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(""));
                    //mime
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(r));
                    //host
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode(i_value));
                    //operation
                    cell=row.insertCell();
                    cell.appendChild(document.createTextNode("No operation"));
                }
            }
        }
    });
}

document.addEventListener('DOMContentLoaded', loadRuleSet);