class ActionRule {
    constructor() {
    }

    static add(host, extension, mime, action) {
        if (host != null) {
            if (this.hosts[host] == null)
                this.hosts[host] = {
                    acc_mime: new Set(),
                    deny_mime: new Set(),
                    acc_ext: new Set(),
                    deny_ext: new Set()
                };
            if (action == true) {
                if (extension != null)
                    this.hosts[host].acc_ext.add(extension);
                this.hosts[host].acc_mime.add(mime);
            }
            else {
                if (extension != null)
                    this.hosts[host].deny_ext.add(extension);
                this.hosts[host].deny_mime.add(mime);
            }
        }
        else {
            if (action == true) {
                if (extension != null)
                    this.hosts.acc_ext.add(extension);
                this.hosts.acc_mime.add(mime);
            }
            else {
                if (extension != null)
                    this.hosts.deny_ext.add(extension);
                this.hosts.deny_mime.add(mime);
            }
        }
        var _save={
            actionRule: {
                acc_mime: Array.from(this.hosts.acc_mime),
                acc_ext: Array.from(this.hosts.acc_ext),
                deny_mime: Array.from(this.hosts.deny_mime),
                deny_ext: Array.from(this.hosts.deny_ext),
                defaultAction: this.hosts.defaultAction
            }
        };
        var _properties=Object.keys(this.hosts);
        for(var i=_properties.length-1;i>=0;i--)
        {
            var i_value=_properties[i];
            if(! new Set(["acc_mime","acc_ext","deny_mime","deny_ext","defaultAction"]).has(i_value))
            {
                Object.defineProperty(_save,i_value,{
                    configurable: true,
                    enumerable: true,
                    writable: true,
                    value: {
                        acc_mime: Array.from(this.hosts[i_value].acc_mime),
                        acc_ext: Array.from(this.hosts[i_value].acc_ext),
                        deny_mime: Array.from(this.hosts[i_value].deny_mime),
                        deny_ext: Array.from(this.hosts[i_value].deny_ext)
                    }
                });
            }
        }
        browser.storage.local.set(_save);
    }

    static delete(host, extension, mime, action)
    {
        ;
    }

    static match(host, extension, mime) {
        if (this.hosts[host] != null) {
            if (this.hosts[host].deny_mime.has(mime))
                return false;
            else if (this.hosts[host].acc_mime.has(mime))
                return true;
            else if (this.hosts[host].deny_ext.has(extension))
                return false;
            else if (this.hosts[host].acc_ext.has(extension))
                return true;
        }
        if (this.hosts.deny_mime.has(mime))
            return false;
        else if (this.hosts.acc_mime.has(mime))
            return true;
        else if (this.hosts.deny_ext.has(extension))
            return false;
        else if (this.hosts.acc_ext.has(extension))
            return true;
        else
            return this.hosts.defaultAction;
    }
};

ActionRule.hosts = {
    acc_mime: new Set(),
    deny_mime: new Set(),
    acc_ext: new Set(),
    deny_ext: new Set(),
    defaultAction: null
};

browser.storage.local.get().then((res) => {
    if(res.actionRule != null)
    {
        ActionRule.hosts.acc_ext= new Set(res.actionRule.acc_ext);
        ActionRule.hosts.acc_mime=new Set(res.actionRule.acc_mime);
        ActionRule.hosts.deny_ext=new Set(res.actionRule.deny_ext);
        ActionRule.hosts.deny_mime=new Set(res.actionRule.deny_mime);
        ActionRule.hosts.defaultAction=res.actionRule.defaultAction;
    }
    var _properties=Object.keys(res);
    for(var i=_properties.length-1;i>=0;i--)
    {
        var i_value=_properties[i];
        if(i_value != "actionRule")
        {
            ActionRule.hosts[i_value]={
                acc_mime: new Set(res[i_value].acc_mime),
                deny_mime: new Set(res[i_value].deny_mime),
                acc_ext: new Set(res[i_value].acc_ext),
                deny_ext: new Set(res[i_value].deny_ext)
            };
        }
    }
});