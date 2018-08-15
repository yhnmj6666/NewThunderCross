class ActionRule {
    constructor() {
    }

    static _keyComparer(left, right)
    {
        var l=left.split(".");
        var r=right.split(".");
        while(l.length>0 && r.length>0)
        {
            var ls=l.pop();
            var rs=r.pop();
            if(ls<rs)
                return -1;
            else if(ls>rs)
                return 1;
        }
        if(l.length>0)
            return 1;
        else if (r.length>0)
            return -1;
        else
            return 0;
    }

    static _hostMatch(source, target)
    {
        var shost=source.split(".");
        var thost=target.split(".");
        while(shost.length>0 && thost.length>0)
        {
            var s=shost.pop();
            var t=thost.pop();
            if(s==t || s=="*")
                continue;
            else
                return false;
        }
        return true;
    }

    static save()
    {
        var _save = {
            actionRule: {
                global: {
                    rules: Array.from(this.global.rules),
                    defaultAction: this.global.defaultAction
                },
                hosts: {}
            }
        };
        var _properties = Array.from(this.hosts.keys());
        for (var i = _properties.length - 1; i >= 0; i--) {
            var i_value = _properties[i];
            Object.defineProperty(_save.actionRule.hosts, i_value, {
                configurable: true,
                enumerable: true,
                writable: true,
                value: {
                    rules: Array.from(this.hosts.get(i_value).rules),
                    defaultAction: this.hosts.get(i_value).defaultAction
                }
            });
        }
        browser.storage.local.set(_save);
        console.log(_save);
    }

    static add(host, extension, mime, action, dm="default") {
        if (host == null || host=="*") {
            this.global.rules.add({
                extension: extension,
                mime: mime,
                action: action
            });
        }
        else {
            if (this.hosts.has(host)) {
                this.hosts.get(host).rules.add({
                    extension: extension,
                    mime: mime,
                    action: action
                });
            }
            else {
                this.hosts.set(host,{
                        rules: new Set(),
                        defaultAction: "ask"
                    });
                this.hosts.get(host).rules.add({
                    extension: extension,
                    mime: mime,
                    action: action
                });
            }
        }
        this.save();
    }

    static delete(host, extension, mime, action) {
        if(host == null || host == "*")
        {
            this.global.rules.forEach((value1,value2,set)=>{
                if(value1.extension==extension && value1.mime==mime && value1.action==action)
                {
                    set.delete(value1);
                }
            });
        }
        else if(this.hosts.has(host))
        {
            this.hosts.get(host).rules.forEach((value1,value2,set)=>{
                if(value1.extension==extension && value1.mime==mime && value1.action==action)
                {
                    set.delete(value1);
                }
            });
            if(this.hosts.get(host).defaultAction == this.global.defaultAction)
            {
                this.hosts.delete(host);
            }
        }
        this.save();
    }

    // static modify(host, extension, mime, action)
    // {
    //     unimplemented;
    // }

    static modify(host, defaultAction)
    {
        if(host==null || host=="*")
        {
            this.global.defaultAction=defaultAction;
        }
        this.save();
    }

    static match(host, extension, mime) {
        var hasMatch=this.global.defaultAction;
        this.global.rules.forEach((value1, value2, set)=>{
            if((value1.extension==null || value1.extension==extension) &&
                (value1.mime==null || value1.mime==mime))
            hasMatch=value1.action;
        });
        var _properties = Array.from(this.hosts.keys()).sort(ActionRule._keyComparer);
        for(var i=0;i<_properties.length;i++)
        {
            var i_value=_properties[i];
            if(this._hostMatch(i_value,host))
            {
                this.hosts.get(i_value).rules.forEach((value1, value2, set)=>{
                    if((value1.extension==null || value1.extension==extension) &&
                        (value1.mime==null || value1.mime==mime))
                    hasMatch=value1.action;
                });
                break;
            }
        }
        return hasMatch;
    }
};

ActionRule.global = {
    rules: new Set(),
    defaultAction: "ask"
};

ActionRule.hosts = new Map();

browser.storage.local.get().then((res) => {
    if (res.actionRule.global != null) {
        ActionRule.global.rules = new Set(res.actionRule.global.rules),
        ActionRule.global.defaultAction = res.actionRule.global.defaultAction
    }
    var _properties = Object.keys(res.actionRule.hosts);
    for (var i = _properties.length - 1; i >= 0; i--) {
        var i_value = _properties[i];
        ActionRule.hosts.set(i_value,{
            rules: new Set(res.actionRule.hosts[i_value].rules),
            defaultAction: res.actionRule.hosts[i_value].defaultAction
        });
    }
});