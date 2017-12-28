class ActionRule {
    constructor() {
    }

    static addRule(host, extension, mime, action) {
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

        console.log(this.hosts);

        browser.storage.local.set({
            actionRules: this.hosts
        });
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
    ActionRule.hosts = res.actionRules || ActionRule.hosts;
    console.log(res.actionRules);
    console.log(ActionRule.hosts);
});