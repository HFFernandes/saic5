var __userAgent = navigator.userAgent;
var __isIE =  navigator.appVersion.match(/MSIE/) != null;

function __getIEVersion() {
    var rv = -1; // Return value assumes failure.
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}


var __IEVersion = __getIEVersion();

var __isFireFox = __userAgent.match(/firefox/i) != null;
var __isFireFoxOld = __isFireFox && ((__userAgent.match(/firefox\/2./i) != null) || (__userAgent.match(/firefox\/1./i) != null));
var __isFireFoxNew = __isFireFox && !__isFireFoxOld;


function __parseBorderWidth(width) {
    var res = 0;
    if (typeof(width) == "string" && width != null && width != "" ) {
        var p = width.indexOf("px");
        if (p >= 0) {
            res = parseInt(width.substring(0, p));
        }
        else {
     		//do not know how to calculate other values (such as 0.5em or 0.1cm) correctly now
    		//so just set the width to 1 pixel
            res = 1; 
        }
    }
    return res;
}


//returns border width for some element
function kGetBorderWidth(element) {
	var res = new Object();
	res.left = 0; res.top = 0; res.right = 0; res.bottom = 0;
	if (window.getComputedStyle) {
		//for Firefox
		var elStyle = window.getComputedStyle(element, null);
		res.left = parseInt(elStyle.borderLeftWidth.slice(0, -2));  
		res.top = parseInt(elStyle.borderTopWidth.slice(0, -2));  
		res.right = parseInt(elStyle.borderRightWidth.slice(0, -2));  
		res.bottom = parseInt(elStyle.borderBottomWidth.slice(0, -2));  
	}
	else {
		//for other browsers
		res.left = __parseBorderWidth(element.style.borderLeftWidth);
		res.top = __parseBorderWidth(element.style.borderTopWidth);
		res.right = __parseBorderWidth(element.style.borderRightWidth);
		res.bottom = __parseBorderWidth(element.style.borderBottomWidth);
	}
   
	return res;
}


//returns the absolute position of some element within document
function kGetAbsolutePos(element) {
	var res = new Object();
	res.x = 0; res.y = 0;
	if (element !== null) {
        if (__isIE && __IEVersion >= 8.0) {
	    	res.x = element.scrollLeft;
		    res.y = element.scrollTop;
		}
		else {
	    	res.x = element.offsetLeft;
		    res.y = element.offsetTop;
		}
    	
		var offsetParent = element.offsetParent;
		var parentNode = element.parentNode;
		var borderWidth = null;

		while (offsetParent != null) {
			res.x += offsetParent.offsetLeft;
			res.y += offsetParent.offsetTop;
			
			var parentTagName = offsetParent.tagName.toLowerCase();	

			if ((__isIE && __IEVersion < 8.0 && parentTagName != "table") || (__isFireFoxNew && parentTagName == "td")) {		    
				borderWidth = kGetBorderWidth(offsetParent);
				res.x += borderWidth.left;
				res.y += borderWidth.top;
			}
		    
			if (offsetParent != document.body && offsetParent != document.documentElement) {
				res.x -= offsetParent.scrollLeft;
				res.y -= offsetParent.scrollTop;
			}

			//next lines are necessary to support FireFox problem with offsetParent
   			if (!__isIE || __IEVersion >= 8.0) {
    			while (offsetParent != parentNode && parentNode !== null) {
					res.x -= parentNode.scrollLeft;
					res.y -= parentNode.scrollTop;
					
					if (__isFireFoxOld) {
						borderWidth = kGetBorderWidth(parentNode);
						res.x += borderWidth.left;
						res.y += borderWidth.top;
					}
    				parentNode = parentNode.parentNode;
    			}    
			}

   			parentNode = offsetParent.parentNode;
    		offsetParent = offsetParent.offsetParent;
		}
	}
    return res;
}


function kShowElementAt(elementId, parentId, offsetX, offsetY) {
	var element = document.getElementById(elementId);
	var parent = document.getElementById(parentId);

	var pos = kGetAbsolutePos(parent);
    //window.alert(" " + pos.x + ", " + pos.y);
	
	var offsetParent = element.offsetParent;
	var res = new Object();
	if (offsetParent != null) {
	    ppos = kGetAbsolutePos(offsetParent);
	}
	else {
	    ppos.x = 0;
	    ppos.y = 0;
	}

	element.style.left = (pos.x - ppos.x + offsetX) + 'px';
	element.style.top = (pos.y - ppos.y + offsetY) + 'px';

	element.style.visibility = 'visible';

	return true;
}

function kFocusElement(elementId) {
	var element = document.getElementById(elementId);

	if (element != null){
		element.focus();
		return true;
	}
	else
		return false;
}

function kHideElement(elementId) {
	var element = document.getElementById(elementId);
	if (element != null) {
	    element.style.visibility = 'hidden';
	}
	return true;
}

function kAddEventListener(el, type, listener) {
	if (el.addEventListener){
  		el.addEventListener(type, listener, false); 
	} else if (el.attachEvent){
  		el.attachEvent('on' + type, listener);
	}
}

function kGetWinHeight(){
	var winHeight = 800;
	if (window.innerHeight) {
		winHeight = window.innerHeight;
	}
	else {
		winHeight = document.documentElement.clientHeight; 
		if (winHeight  == 0) {
		    winHeight = document.body.clientHeight; 
	    }
	}
	return winHeight;
}


MenuLevel.prototype = {
	showAt: function(x, y, adjustTopPos) {
	    this.initLevelDiv();
		var levelStyle = this.levelDiv.style;
    	levelStyle.left = x + 'px';	
		levelStyle.top = y + 'px';
		
		levelStyle.visibility = 'visible';

    	this.scrollDiv.style.width = "auto";
		this.scrollDiv.style.height = "auto";

        //adjusting level top position
        if (adjustTopPos) {
  			y = this.adjustTopPos(y);
    		levelStyle.top = y + 'px';
		}

		//setting minimal level width if it is defined
		var minItemWidth = this.parentMenu.minItemWidth;
		if (minItemWidth > 0 && this.scrollDiv.offsetWidth < minItemWidth) {
		    for (var i = 0; i < this.items.length; i++) {
    		    this.items[i].itemDiv.style.width = minItemWidth + "px";
		    }
	    }
	    
	    var maxItemWidth = this.parentMenu.maxItemWidth;
	    if (maxItemWidth > 0  && this.scrollDiv.offsetWidth > maxItemWidth) {
		    for (var i = 0; i < this.items.length; i++) {
    		    this.items[i].itemDiv.style.width = maxItemWidth + "px";
		    }
	    }

        //adjustinng maximum height of the menu level if it does not fit to browser window
		var winHeight = kGetWinHeight()
		
		var maxHeight = winHeight - (y - document.documentElement.scrollTop) - 10;
		if (this.levelDiv.offsetHeight > maxHeight) {
			var newHeight = maxHeight;
			if (newHeight < 50) { newHeight = 50; }
			this.scrollDiv.style.height = newHeight + "px"; 
			if (__isFireFoxNew && this.scrollDiv.offsetWidth < this.itemsTable.offsetWidth + 20 ) {
			    //this row is necessary to remove a horizontal bar that appears in FireFox 3.x 
			    //if we decrese menu height to fit the browser window
			    this.scrollDiv.style.width = this.itemsTable.offsetWidth + 20 + "px";
			}
		}
		else {
			this.scrollDiv.style.height = "auto"; 
		}

	},
	

	hide: function() {
		if (this.activeItem !== null) {
			if (typeof(this.activeItem.subLevel) != 'undefined') {
				this.activeItem.subLevel.hide(); 	
			}
		}
		var levelStyle = this.levelDiv.style;
		levelStyle.visibility = 'hidden';
	},
	
	adjustTopPos: function(top) {
	    var winHeight = kGetWinHeight();
	    var res = top;
	    var levelBottom = top - document.documentElement.scrollTop + this.levelDiv.offsetHeight;
	    if ( levelBottom > winHeight - 10) {
	        res -= levelBottom - winHeight + 10;
	        if (res < document.documentElement.scrollTop) {
	            res = document.documentElement.scrollTop + 10;
	        }
	    }
	    return res;
	},
	
	initLevelDiv: function() {
	    if (!this.initialized) {
       		document.body.appendChild(this.levelDiv);
       		this.initialized = true;
	    }	
	},

	renderContent: function() {
		//define internal variables used in this function
		var itemBgColor = this.parentMenu.style.colors.bgON;
		var itemFgColor = this.parentMenu.style.colors.fgON;
		var itemOverBgColor = this.parentMenu.style.colors.bgOVER;    	
		var itemOverFgColor = this.parentMenu.style.colors.fgOVER;    	
		var itemFontFamily = this.parentMenu.style.itemStyle.fontFamily || "";
		var itemFontSize = this.parentMenu.style.itemStyle.fontSize;
		var itemClass = this.parentMenu.style.itemClass || "";
		var itemClassOver = this.parentMenu.style.itemClassOver || "";
		var commandTemplate = this.parentMenu.commandTemplate;  
		var multiselect = this.parentMenu.multiselect; 
		

		//add base DIV element which is also used to show the shadow
    	var baseDiv = document.createElement("div");
    	//baseDiv.id = this.parentMenu.id + "Level" + this.levelIndex;
    	baseDiv.style.backgroundColor = this.parentMenu.style.colors.shadow;
    	baseDiv.style.position = "absolute";
    	baseDiv.style.visibility = "hidden";
    	baseDiv.style.zIndex = this.parentMenu.zIndex;
		baseDiv.style.width = "auto";
		baseDiv.style.height = "auto";
    	baseDiv.menuLevel = this;

		//add main content table (with one row and one cell)
		//it shows border around the menu level and contains all other elements of this level  
    	var contentTable = document.createElement("table");
    	contentTable.style.backgroundColor = itemBgColor; 
    	contentTable.style.position = "relative"; 
    	contentTable.style.border = "1px solid";
    	contentTable.style.borderColor = this.parentMenu.style.colors.border;
    	contentTable.style.margin = "-2px 2px 2px -2px";
    	contentTable.cellPadding = "0";
    	contentTable.cellSpacing = "0";
    	baseDiv.appendChild(contentTable);
    	
    	var contentRow = contentTable.insertRow(-1);
	    var contentCell = contentRow.insertCell(-1);

    	var _parentMenu = this.parentMenu;
    	var _thisLevel = this;
		var _applyItem = this.applyItem;

		//here we define the event listeners for items
		var mouseListener = function () { 
			var e = window.event || arguments[0];
        	var o = e.srcElement || e.target;
        	
        	//find parent div object
        	while (o.tagName.toLowerCase() != 'div' && o !== null) {
        		o = o.parentNode;
        	}
        	
        	if (o !== null) {
	       		var menuItem = o.menuItem;
        		var rowElement = (menuItem != _applyItem) ? menuItem.itemRow : menuItem.itemDiv;
       	        
	        	if (e.type == 'mouseover') {
	        		if (_thisLevel.activeItem !== null) {
	        			var activeRow = _thisLevel.activeItem.itemRow;
                    	if (itemClass != "") { 
	        		        activeRow.style.backgroundColor = "";
	        		        activeRow.style.color = "";
                    	    activeRow.className = itemClass; 
                    	} 
                    	else {
                    	    activeRow.className = "";
		       			    activeRow.style.backgroundColor = itemBgColor;
		        		    activeRow.style.color = itemFgColor;
		        		}
        				if (typeof(_thisLevel.activeItem.subLevel) != 'undefined') {
	        				_thisLevel.activeItem.subLevel.hide();
        				} 
	        		}
	        		_thisLevel.activeItem = menuItem;
	        		
                  	if (itemClassOver != "") { 
	        		    rowElement.style.backgroundColor = "";
	        		    rowElement.style.color = "";
                  	    rowElement.className = itemClassOver;
                  	}
                  	else {
                  	    rowElement.className = "";
	        		    rowElement.style.backgroundColor = itemOverBgColor;
	        		    rowElement.style.color = itemOverFgColor;
	        		}
	        		
	        		
	        		if (typeof(menuItem.sub) != 'undefined') {
	        			if (typeof(menuItem.subLevel) == 'undefined') {
	        				menuItem.subLevel = new MenuLevel(_parentMenu, menuItem.sub, _thisLevel.levelIndex + 1);
	        			}
	        			
	        			var pos = kGetAbsolutePos(menuItem.itemDiv);
	        			pos.x += menuItem.itemDiv.offsetWidth - 2;
	        			pos.y += 1; 
	        			menuItem.subLevel.showAt(pos.x, pos.y, true);
	        		} 
	       		}
	       		else if (e.type == 'mouseout') {
        			if (typeof(menuItem.subLevel) == 'undefined') {
                    	if (itemClass != "") { 
    	        		    rowElement.style.backgroundColor = "";
	            		    rowElement.style.color = "";
                    	    rowElement.className = itemClass; 
                    	} 
                    	else {
                    	    rowElement.className = "";
		       			    rowElement.style.backgroundColor = itemBgColor;
	        			    rowElement.style.color = itemFgColor;
		        		}
		        		_thisLevel.activeItem = null;
        			}
	       		} 
       		}
        };

		var itemClickListener = function () { 
			var e = window.event || arguments[0];
        	var o = e.srcElement || e.target;

        	//find parent div object
        	while (o.tagName.toLowerCase() != 'div' && o !== null) {
        		o = o.parentNode;
        	}
        	
        	if (o !== null) {
        		_parentMenu.hide();
        		var  menuItem = o.menuItem;
        		if (typeof(menuItem.sub) != 'undefined') return; //do nothing if menu item has sub-items;
        		        		        		
        		var parentElementId = _parentMenu.parentElement !== null ? _parentMenu.parentElement.id : "";  
        		var args = _parentMenu.args;

        		var __parentElement = document.getElementById(parentElementId);
        		var command = commandTemplate.replace("${parentElement}", "__parentElement");
        		command = command.replace("${parentElementId}", parentElementId);
        		
        		for (var i = 0; i < args.length; i++) {
        		    command = command.replace("${arg" + i + "}", args[i]);
        		}
        		
        		if (menuItem == _applyItem) {
        			var selectedIDs = "";
        			for (var j = 0; j < _thisLevel.items.length; j++) {
        				var item = _thisLevel.items[j];
        				item.sel = item.itemCheckbox.checked;
        				if (item.sel) {
        					if (selectedIDs !== "") { selectedIDs += ",";} 
        					selectedIDs += item.id;
        				}
        			}
        			command = command.replace("${itemId}", selectedIDs);
        		}
        		else {
        			command = command.replace("${itemId}", menuItem.id);
        		}
        		//window.alert(command);
        		eval(command);
        	}        	
        };
	
		//if multiselect option is on - then we should add special "apply" item
		if (multiselect && this.levelIndex === 0) { 
   			var applyDiv = document.createElement("div");
   			applyDiv.menuItem = _applyItem;
    	    applyDiv.style.borderBottom = "1px solid";
   			applyDiv.style.backgroundColor = itemBgColor;
    		applyDiv.style.borderColor = this.parentMenu.style.colors.border;
    		if (itemFontFamily != "") { applyDiv.style.fontFamily = itemFontFamily; }
    		applyDiv.style.fontSize = itemFontSize;
	    	applyDiv.style.color = itemFgColor;
	    	applyDiv.style.cursor = "pointer";
	    	applyDiv.style.textAlign = "center"; 
	    	applyDiv.style.paddingLeft = "4px";
	    	applyDiv.style.paddingRight = "6px";
	    	
		    var applyText = document.createTextNode("[Apply selection]");
	    	applyDiv.appendChild(applyText);
	    	contentCell.appendChild(applyDiv);

			_applyItem.itemDiv = applyDiv;

    	    kAddEventListener(applyDiv, 'click' , itemClickListener);			
	    	kAddEventListener(applyDiv, 'mouseover' , mouseListener);			
	    	kAddEventListener(applyDiv, 'mouseout' , mouseListener);
    	}

    	var scrollDiv = document.createElement("div");
		//scrollDiv.style.width = "auto";
		//scrollDiv.style.height = "auto";
    	scrollDiv.style.overflow = "auto";
		contentCell.appendChild(scrollDiv);
		 

		//now we add a table which will contain all items
		//each item takes one row in this table.    	
    	var table = document.createElement("table");
    	scrollDiv.appendChild(table);
    	this.itemsTable = table;
    	table.style.backgroundColor = itemBgColor;
    	table.cellSpacing = "0";
    	table.cellPadding = "0";
    	
		var i;
		for (i=0; i < this.items.length; i++) {
			var item = this.items[i];
			if (typeof(item.sel) == "undefined") {
				item.sel = false;
			}
			if (item.sel && this.selectedItem == null) {
			    this.selectedItem = item;
			}
		    var itemRow = table.insertRow(-1);
	    	itemRow.menuItem = item;
	    	item.itemRow = itemRow;

   	        var markCell = itemRow.insertCell(0);
	    	markCell.style.paddingLeft = "4px";
   	        markCell.style.textAlign = "center";
   	        markCell.style.verticalAlign = "middle";
    		if (itemFontFamily != "") { markCell.style.fontFamily = itemFontFamily; }	    	
	    	markCell.style.fontSize = itemFontSize;

		    var itemCell  = itemRow.insertCell(-1);
   	        itemCell.style.verticalAlign = "middle";

	    	var itemDiv = document.createElement("div");
	    	itemCell.appendChild(itemDiv);
	    	
	    	itemDiv.menuItem = item;
	    	item.itemDiv = itemDiv;
	    	
        	if (itemClass != "") { 
        	    itemRow.className = itemClass; 
        	} 
        	else {
        	    if (itemFontFamily != "") { itemRow.style.fontFamily = itemFontFamily; }	    	
	    	    itemRow.style.fontSize = itemFontSize;
	    	    itemRow.style.color = itemFgColor;
	    	}
	    	
    	    itemDiv.style.paddingLeft = "4px";
    	    itemDiv.style.paddingRight = "6px";
	    	if (multiselect) {
	    		var cb = document.createElement("input");
	    		cb.type = "checkbox";
	    		cb.id = "cb" + item.id;
	    		cb.checked = item.sel; 
	    		cb.defaultChecked = item.sel;
		    	markCell.appendChild(cb);
		    	item.itemCheckbox = cb;
		    	itemDiv.style.cursor = "default";
	    	}
	    	else {
   	            if (item.sel) {
           	        var markText = document.createTextNode("\u25CF");
   	                markCell.appendChild(markText);    	    
                }
		    	itemDiv.style.cursor = "pointer";
	    	}

		    var itemText = document.createTextNode(item.text);
	    	itemDiv.appendChild(itemText);
	    	if (!multiselect) {
	    	    kAddEventListener(itemDiv, 'click' , itemClickListener);			
		    	kAddEventListener(itemDiv, 'mouseover' , mouseListener);			
		    	kAddEventListener(itemDiv, 'mouseout' , mouseListener);
	    	}
		}	
        
		this.levelDiv = baseDiv;		
		this.scrollDiv = scrollDiv;
	},
	
	remove: function () {
	    //remove old level elements
	    for (var i = 0; i < this.items.length; i++) {
            var item = this.items[i];
   			if (typeof(item.subLevel) != 'undefined') {
   			    item.subLevel.remove();
            }
	    }
	    
	    this.levelDiv.innerHtml = "";
	    var parentNode = this.levelDiv.parentNode;
	    if (parentNode != null) { 
	        parentNode.removeChild(this.levelDiv); 
	    }
	    this.levelDiv = null;
	},
	
	update: function(newItems) {
        this.remove();

	    //create new level
	    this.items = newItems;
	    this.activeItem = null;
	    this.selectedItem = null;
    	this.applyItem.itemDiv = null;
    	this.initialized = false;
        this.updated++;	     
    	     
	    this.renderContent();
	}
}; 

function MenuLevel(menu, items, levelIndex) {
	this.parentMenu = menu; 
	this.levelIndex = levelIndex;
	this.levelDiv = null;

	//we need to define special "apply" item for this level
	this.applyItem  = new Object(); 
	this.applyItem.itemDiv = null;

	this.items = items;
	this.activeItem = null;
	this.selectedItem = null;
	this.initialized = false;

    this.updated = 0;	     
	     
	this.renderContent();
}


PopupMenu.prototype = {
	showAt: function(x, y, args) {
    	this.active = true;
	    this.args = args;
		this.rootLevel.showAt(x, y, false);
	},

	showAtEx: function(x, y, args, _event) {
		if (_event !== null) {
			_event.cancelBubble = true;
		}
		this.showAt(x, y, args);
	},

	showUnder: function(el, dx, dy, args) {
	    if (typeof(el) == "string") {
	        el = document.getElementById(el);
	    }  
	  
		var pos = kGetAbsolutePos(el);
		//window.alert(" " + pos.x + ", " + pos.y);
		pos.x += dx + 2;
		pos.y += el.scrollHeight + dy + 2;  
		//window.alert(" " + pos.x + ", " + pos.y);
		this.parentElement = el;
		this.showAt(pos.x, pos.y, args);
	},
	
	showUnderEx: function(el, dx, dy, args, _event) { 
		if (_event !== null) {
			_event.cancelBubble = true;
		}
		this.showUnder(el, dx, dy, args);
	},

	hide: function() { 
		this.rootLevel.hide();
	},
	
	updateProps: function(menuProps) {
	    this.style = menuProps.style;
	    if (typeof(this.style.colors) == "undefined") {
	        this.style.colors = new Object();
		    this.style.colors.bgON = "white";
		    this.style.colors.fgON = "black";
		    this.style.colors.bgOVER = "#B6BDD2";    	
		    this.style.colors.fgOVER = "black";    	
	    }
    	
	    if (typeof(this.style.itemStyle) == "undefined") {
	        this.style.itemStyle = new Object();
	        this.style.itemStyle.fontSize = "12pt";
	    }
    	
	    this.minItemWidth = menuProps.minItemWidth || 0;
	    this.maxItemWidth = menuProps.maxItemWidth || 0;
	    this.zIndex = menuProps.zIndex || 1000;

	    this.commandTemplate = menuProps.commandTemplate || "";
	    this.multiselect = menuProps.multiselect || false;  
	    this.parentElement = null;
	    this.args = [];
	    this.active = false;	    	
	},
	
	updateItems: function(menuItems) {
	    this.rootLevel.update(menuItems);
	}
	
};


function PopupMenu(menuProps, menuItems) {
	this.id = menuProps.id || "";
    this.updateProps(menuProps);

	this.rootLevel = new MenuLevel(this, menuItems, 0);

	var _thisMenu = this;
	
	var globalMouseDownListener = function () {  
	    if (!_thisMenu.active) return;
		var e = window.event || arguments[0];
        var o = e.srcElement || e.target;
        var isOutside = true; 

        while (o) {
        	if (o.tagName && o.tagName.toLowerCase() == 'div') {
        		if (typeof(o.menuLevel) != "undefined") {
        			if (o.menuLevel.parentMenu == _thisMenu) { 
						isOutside = false;
    	             	break;
                 	}
                }
			}
            o = o.parentNode || o.parentElement;
        }
		if (isOutside) {
			_thisMenu.hide();
		}
	};
    kAddEventListener(document, 'mousedown', globalMouseDownListener);		
}

var kPopupMenus = [];

function kFindPopupMenu(id) {
    for (var i = 0; i < kPopupMenus.length; i++) {
        if (kPopupMenus[i].id == id) {
            return kPopupMenus[i];
        }
    }    
    return null;
}
  
function kCreatePopupMenu(menuProps, menuItems) {
    var menuID = menuProps.id || "";
    var menu = kFindPopupMenu(menuID);
    if (menu === null) {
        menu = new PopupMenu(menuProps, menuItems);
        kPopupMenus[kPopupMenus.length] = menu;
    }
    else {
        menu.updateProps(menuProps);
        menu.updateItems(menuItems);
    }
    return menu;
}
