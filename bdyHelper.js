var codeToInject = "try{Object.defineProperty(navigator,'platform',{get:function(){return 'Android';}});}catch(e){}";
var script = document.createElement('script');
script.appendChild(document.createTextNode(codeToInject));
(document.head || document.documentElement).appendChild(script);
script.parentNode.removeChild(script);
undefined;