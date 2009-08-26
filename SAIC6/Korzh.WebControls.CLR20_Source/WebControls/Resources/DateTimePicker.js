// ===================================================================
// Author: Matt Kruse <matt@mattkruse.com>
// WWW: http://www.mattkruse.com/
//
// modified by Korzh.com
// ===================================================================

var MONTH_NAMES=new Array('January','February','March','April','May','June','July','August','September','October','November','December','Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec');var DAY_NAMES=new Array('Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sun','Mon','Tue','Wed','Thu','Fri','Sat');
function LZ(x){return(x<0||x>9?"":"0")+x}
function isDate(val,format){var date=getDateFromFormat(val,format);if(date==0){return false;}return true;}
function compareDates(date1,dateformat1,date2,dateformat2){var d1=getDateFromFormat(date1,dateformat1);var d2=getDateFromFormat(date2,dateformat2);if(d1==0 || d2==0){return -1;}else if(d1 > d2){return 1;}return 0;}
function formatDate(date,format){format=format+"";var result="";var i_format=0;var c="";var token="";var y=date.getYear()+"";var M=date.getMonth()+1;var d=date.getDate();var E=date.getDay();var H=date.getHours();var m=date.getMinutes();var s=date.getSeconds();var yyyy,yy,MMMM,MMM,MM,dd,hh,h,mm,ss,ampm,HH,H,KK,K,kk,k;var value=new Object();if(y.length < 4){y=""+(y-0+1900);}value["y"]=""+y;value["yyyy"]=y;value["yy"]=y.substring(2,4);value["M"]=M;value["MM"]=LZ(M);value["MMMM"]=MONTH_NAMES[M-1];value["MMM"]=MONTH_NAMES[M+11];value["d"]=d;value["dd"]=LZ(d);value["E"]=DAY_NAMES[E+7];value["EE"]=DAY_NAMES[E];value["H"]=H;value["HH"]=LZ(H);if(H==0){value["h"]=12;}else if(H>12){value["h"]=H-12;}else{value["h"]=H;}value["hh"]=LZ(value["h"]);if(H>11){value["K"]=H-12;}else{value["K"]=H;}value["k"]=H+1;value["KK"]=LZ(value["K"]);value["kk"]=LZ(value["k"]);if(H > 11){value["a"]="PM";}else{value["a"]="AM";}value["m"]=m;value["mm"]=LZ(m);value["s"]=s;value["ss"]=LZ(s);while(i_format < format.length){c=format.charAt(i_format);token="";while((format.charAt(i_format)==c) &&(i_format < format.length)){token += format.charAt(i_format++);}if(value[token] != null){result=result + value[token];}else{result=result + token;}}return result;}
function _isInteger(val){var digits="1234567890";for(var i=0;i < val.length;i++){if(digits.indexOf(val.charAt(i))==-1){return false;}}return true;}
function _getInt(str,i,minlength,maxlength){for(var x=maxlength;x>=minlength;x--){var token=str.substring(i,i+x);if(token.length < minlength){return null;}if(_isInteger(token)){return token;}}return null;}
function getDateFromFormat(val,format){val=val+"";format=format+"";var i_val=0;var i_format=0;var c="";var token="";var token2="";var x,y;var now=new Date();var year=now.getYear();var month=now.getMonth()+1;var date=1;var hh=now.getHours();var mm=now.getMinutes();var ss=now.getSeconds();var ampm="";while(i_format < format.length){c=format.charAt(i_format);token="";while((format.charAt(i_format)==c) &&(i_format < format.length)){token += format.charAt(i_format++);}if(token=="yyyy" || token=="yy" || token=="y"){if(token=="yyyy"){x=4;y=4;}if(token=="yy"){x=2;y=2;}if(token=="y"){x=2;y=4;}year=_getInt(val,i_val,x,y);if(year==null){return 0;}i_val += year.length;if(year.length==2){if(year > 70){year=1900+(year-0);}else{year=2000+(year-0);}}}else if(token=="MMMM"||token=="MMM"){month=0;for(var i=0;i<MONTH_NAMES.length;i++){var month_name=MONTH_NAMES[i];if(val.substring(i_val,i_val+month_name.length).toLowerCase()==month_name.toLowerCase()){if(token=="MMMM"||(token=="MMM"&&i>11)){month=i+1;if(month>12){month -= 12;}i_val += month_name.length;break;}}}if((month < 1)||(month>12)){return 0;}}else if(token=="EE"||token=="E"){for(var i=0;i<DAY_NAMES.length;i++){var day_name=DAY_NAMES[i];if(val.substring(i_val,i_val+day_name.length).toLowerCase()==day_name.toLowerCase()){i_val += day_name.length;break;}}}else if(token=="MM"||token=="M"){month=_getInt(val,i_val,1,2);if(month==null||(month<1)||(month>12)){return 0;}i_val+=month.length;}else if(token=="dd"||token=="d"){date=_getInt(val,i_val,1,2);if(date==null||(date<1)||(date>31)){return 0;}i_val+=date.length;}else if(token=="hh"||token=="h"){hh=_getInt(val,i_val,token.length,2);if(hh==null||(hh<1)||(hh>12)){return 0;}i_val+=hh.length;}else if(token=="HH"||token=="H"){hh=_getInt(val,i_val,token.length,2);if(hh==null||(hh<0)||(hh>23)){return 0;}i_val+=hh.length;}else if(token=="KK"||token=="K"){hh=_getInt(val,i_val,token.length,2);if(hh==null||(hh<0)||(hh>11)){return 0;}i_val+=hh.length;}else if(token=="kk"||token=="k"){hh=_getInt(val,i_val,token.length,2);if(hh==null||(hh<1)||(hh>24)){return 0;}i_val+=hh.length;hh--;}else if(token=="mm"||token=="m"){mm=_getInt(val,i_val,token.length,2);if(mm==null||(mm<0)||(mm>59)){return 0;}i_val+=mm.length;}else if(token=="ss"||token=="s"){ss=_getInt(val,i_val,token.length,2);if(ss==null||(ss<0)||(ss>59)){return 0;}i_val+=ss.length;}else if(token=="a"){if(val.substring(i_val,i_val+2).toLowerCase()=="am"){ampm="AM";}else if(val.substring(i_val,i_val+2).toLowerCase()=="pm"){ampm="PM";}else{return 0;}i_val+=2;}else{if(val.substring(i_val,i_val+token.length)!=token){return 0;}else{i_val+=token.length;}}}if(i_val != val.length){return 0;}if(month==2){if( ((year%4==0)&&(year%100 != 0) ) ||(year%400==0) ){if(date > 29){return 0;}}else{if(date > 28){return 0;}}}if((month==4)||(month==6)||(month==9)||(month==11)){if(date > 30){return 0;}}if(hh<12 && ampm=="PM"){hh=hh-0+12;}else if(hh>11 && ampm=="AM"){hh-=12;}var newdate=new Date(year,month-1,date,hh,mm,ss);return newdate;}
function parseDate(val){var preferEuro=(arguments.length==2)?arguments[1]:false;generalFormats=new Array('y-M-d','MMM d, y','MMM d,y','y-MMM-d','d-MMM-y','MMM d');monthFirst=new Array('M/d/y','M-d-y','M.d.y','MMM-d','M/d','M-d');dateFirst =new Array('d/M/y','d-M-y','d.M.y','d-MMM','d/M','d-M');var checkList=new Array('generalFormats',preferEuro?'dateFirst':'monthFirst',preferEuro?'monthFirst':'dateFirst');var d=null;for(var i=0;i<checkList.length;i++){var l=window[checkList[i]];for(var j=0;j<l.length;j++){d=getDateFromFormat(val,l[j]);if(d!=0){return new Date(d);}}}return null;}


//  ==============================================================================


/**
version 1.5
December 4, 2005
Julian Robichaux -- http://www.nsftools.com

-- version 1.6 (Apr 27, 2007)
Modified by Korzh.com
*/

var datePickerDivID = "datepicker";
var iFrameDivID = "datepickeriframe";
var style="Colorful";

var dayArrayShort = new Array('Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa');
var dayArrayMed = new Array('Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat');
var dayArrayLong = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
var monthArrayShort = new Array('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec');
var monthArrayMed = new Array('Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec');
var monthArrayLong = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');
 
//var defaultDateSeparator = "/";        // common values would be "/" or "."
var defaultDateFormat = "MM/dd/yyyy";    // valid values are short date format strings
var defaultTimeFormat = "HH:mm";   
//var dateSeparator = defaultDateSeparator;
var dateFormat = defaultDateFormat;
var timeFormat = defaultTimeFormat;

var currentDate;

/**
This is the main function you'll call from the onClick event of a button.

This would display the datepicker beneath the StartDate field (because the
displayBelowThisObject parameter was false), and update the StartDate field with
the chosen value of the datepicker using a date format of dd.mm.yyyy
*/
function displayDatePicker(dateFieldName, displayBelowThisObject, dtFormat, tmFormat)
{
  var targetDateField = document.getElementsByName(dateFieldName).item(0);
 
  // if we weren't told what node to display the datepicker beneath, just display it
  // beneath the date field we're updating
  if (!displayBelowThisObject)
    displayBelowThisObject = targetDateField;
 
  // if a date format was given, update the dateFormat variable
  dateFormat = dtFormat;
  timeFormat = tmFormat;
 
  var x = displayBelowThisObject.offsetLeft;
  var y = displayBelowThisObject.offsetTop + displayBelowThisObject.offsetHeight + 4;
 
  // deal with elements inside tables and such
  var parent = displayBelowThisObject;
  while (parent.offsetParent) {
    parent = parent.offsetParent;
    x += parent.offsetLeft;
    y += parent.offsetTop ;
  }
 
  drawDatePicker(targetDateField, x, y);
}


/**
Draw the datepicker object (which is just a table with calendar elements) at the
specified x and y coordinates, using the targetDateField object as the input tag
that will ultimately be populated with a date.

This function will normally be called by the displayDatePicker function.
*/
function drawDatePicker(targetDateField, x, y)
{
  currentDate = getFieldDate(targetDateField.value );
  
  if (currentDate == 0)
    currentDate = new Date();
 
  // the datepicker table will be drawn inside of a <div> with an ID defined by the
  // global datePickerDivID variable. If such a div doesn't yet exist on the HTML
  // document we're working with, add one.
  if (!document.getElementById(datePickerDivID)) {
    // don't use innerHTML to update the body, because it can cause global variables
    // that are currently pointing to objects on the page to have bad references
    //document.body.innerHTML += "<div id='" + datePickerDivID + "' class='dpDiv'></div>";
    var newNode = document.createElement("div");
    newNode.setAttribute("id", datePickerDivID);
    newNode.setAttribute("class", "dpDiv");
    newNode.setAttribute("style", "visibility:hidden");
    document.body.appendChild(newNode);
  }
 
  // move the datepicker div to the proper x,y coordinate and toggle the visiblity
  var pickerDiv = document.getElementById(datePickerDivID);
  pickerDiv.style.position = 'absolute';
  pickerDiv.style.left = x + 'px';
  pickerDiv.style.top = y + 'px';
  pickerDiv.style.visibility = (pickerDiv.style.visibility == "visible" ? "hidden" : "visible");
  pickerDiv.style.display = (pickerDiv.style.display == "block" ? "none" : "block");
  pickerDiv.style.zIndex = 10000;
 
  // draw the datepicker table
  refreshDatePicker(targetDateField.name);
}


function setCurrentDateStr(dateString)
{
  if (dateString)
    return setCurrentDate(getFieldDate(dateString));
  else
    return setCurrentDate();
}

function setCurrentDate(dt)
{
  if (dt)
    currentDate.setTime(dt.getTime());
  else
    currentDate = new Date();  
    
  return updateCurrentTimePart();
}

function updateCurrentTimePart()
{
  if (timeFormat != "") {
    var timeField = document.getElementsByName("__time_editor").item(0);
    if (timeField != null) {
      var dtTime = getDateFromFormat(timeField.value, timeFormat);
      if (dtTime != 0) {    
        currentDate.setHours(dtTime.getHours(), dtTime.getMinutes(), dtTime.getSeconds(), dtTime.getMilliseconds());
      }
      else {
        return false;
      }
    }
  }    
  return true;
}

/**
This is the function that actually draws the datepicker calendar.
*/
function refreshDatePicker(dateFieldName, dateString)
{
  // if no arguments are passed, use today's date; otherwise, month and year
  // are required (if a day is passed, it will be highlighted later)
  var thisDay = new Date();
  if (dateString)
    setCurrentDateStr(dateString);
//    currentDate.setTime(getFieldDate(dateString).getTime());
    
  thisDay.setTime(currentDate.getTime());

  day = thisDay.getDate();
  thisDay.setDate(1);
    
/* 
  if ((month >= 0) && (year > 0)) {
    thisDay = new Date(year, month, 1);
  } else {
    day = thisDay.getDate();
    thisDay.setDate(1);
  }
*/
  // the calendar will be drawn as a table
  // you can customize the table elements with a global CSS style sheet,
  // or by hardcoding style and formatting elements below
  var crlf = "\r\n";
  var TABLE_base = "<table cellspacing=\"0\" cellpadding=\"2\" border=\"0\" style=\"width:200px;border-width:1px;border-style:Solid;background-color:White;\">" + crlf;
  var TABLE = "<table cols=\"7\" cellspacing=\"0\" cellpadding=\"2\" class=\"dpTable\" border=\"0\" style=\"width:100%;background-color:White;font-family:Verdana,Arial;font-size:8pt;\" >" + crlf;
  var xTABLE = "</table>" + crlf;
  var TR = "<tr class=\"dpTR\" align=\"center\">";
  var TR_title = "<tr class=\"dpTitleTR\" align=\"center\" style=\"background-color:Silver;\" >";
  var TR_weekdays = "<tr class=\"dpDayTR\">";
  var TR_todaybutton = "<tr class=\"dpTodayButtonTR\">";
  var TR_closebutton = "<tr class=\"dpCloseButtonTR\">";
  var xTR = "</tr>" + crlf;
  var TD = "<td class=\"dpTD\" onMouseOut=\"this.style.backgroundColor='#ffffff';\" onMouseOver=\"this.style.backgroundColor='#ffffcc'\" >";    // leave this tag open, because we'll be adding an onClick event
  var TD_title = "<td colspan=\"3\" class=\"dpTitleTD\" align=\"center\">";
  var TD_prevbutton = "<td align=\"left\">";
  var TD_nextbutton = "<td align=\"right\">";
  var TD_todaybutton = "<td colspan=\"7\" align=\"center\" class=\"dpTodayButtonTD\">";  
  var TD_closebutton = "<td colspan=\"7\" align=\"right\" class=\"dpCloseButtonTD\">"; 
  
  var TH_weekdays = "<th align=\"center\" >";
  var xTH = "</th>" + crlf;
  var TD_selected = "<td class=\"dpDayHighlightTD\" align=\"center\" onMouseOut=\"this.className='dpDayHighlightTD';\" onMouseOver=\"this.className='dpTDHover';\" >";    
  var xTD = "</td>" + crlf;
  var DIV_title = "<div class=\"dpTitleText\">";
  var DIV_selected = "<div class='dpDayHighlight'>";
  var xDIV = "</div>";
 
 
  var TR_timer = "<tr class=\"dpTitleTR\" align=\"center\" style=\"background-color:Silver;\" >";
  var TD_timer = "<td colspan=\"7\" class=\"dpTimerTD\" align=\"center\">";
  
  // start generating the code for the calendar table
  var html = TABLE_base + "<tr><td align=\"center\">" + crlf + TABLE;
 
  // add a button to allow the user to close the calendar
  html += TR_closebutton + TD_closebutton;
//  html += "<button class=\"dpCloseButton\" onClick=\"updateDateField('" + dateFieldName + "');\">&nbsp;X&nbsp;</button>";
  html += "<a href=\"javascript:void(0)\" class=\"dpCloseButton\" onClick=\"closeDatePicker('" + dateFieldName + "');\">&nbsp;X&nbsp;</a>";//updateDateField('" + dateFieldName + "')
  html += xTD + xTR;
 
  // this is the title bar, which displays the month and the buttons to
  // go back to a previous month/year or forward to the next month/year
  html += TR_title;
  html += TD_prevbutton + getButtonCode(dateFieldName, thisDay, -12, "&lt;&lt;") + xTD;
  html += TD_prevbutton + getButtonCode(dateFieldName, thisDay, -1, "&nbsp;&lt;&nbsp;") + xTD;
  html += TD_title + DIV_title + monthArrayLong[ thisDay.getMonth()] + " " + thisDay.getFullYear() + xDIV + xTD;
  html += TD_nextbutton + getButtonCode(dateFieldName, thisDay, 1, "&nbsp;&gt;&nbsp;") + xTD;
  html += TD_nextbutton + getButtonCode(dateFieldName, thisDay, 12, "&gt;&gt;") + xTD;
  html += xTR;
 
  // add a button to allow the user to easily return to today
  var today = new Date();
  var todayString = "Today is " + dayArrayMed[today.getDay()] + ", " + monthArrayMed[ today.getMonth()] + " " + today.getDate();
  html += TR_todaybutton + TD_todaybutton;
  html += "<a href=\"javascript:void(0)\" class=\"dpTodayButton\" onClick=\"setCurrentDate(); refreshDatePicker('" + dateFieldName + "');updateDateField('" + dateFieldName + "');\">Today</a> ";
  html += xTD + xTR;
 
  // this is the row that indicates which day of the week we're on
  html += TR_weekdays;
  for(i = 0; i < dayArrayShort.length; i++)
    html += TH_weekdays + dayArrayMed[i] + xTH;
  html += xTR;
 
  // now we'll start populating the table with days of the month
  html += TR;
 
  // first, the leading blanks
  for (i = 0; i < thisDay.getDay(); i++)
    html += TD + "&nbsp;" + xTD;
 
  // now, the days of the month
  do {
    dayNum = thisDay.getDate();
    // TD_onclick = " onclick=\"updateDateField('" + dateFieldName + "', '" + getDateString(thisDay) + "');\">";
    Day_onclick = "<a href=\"javascript:void(0)\" onClick=\"refreshDatePicker('" + dateFieldName + "', '" + getDateString(thisDay) + "');updateDateField('" + dateFieldName + "');\">";
    
    if (dayNum == day)
//      html += TD_selected + TD_onclick + DIV_selected + dayNum + xDIV + xTD;
      html += TD_selected + DIV_selected + dayNum + xDIV + xTD;
    else
//      html += TD + TD_onclick + "<a href=\"javascript:void(0);\">" + dayNum + "</a>" + xTD;
      html += TD + Day_onclick + dayNum + "</a>" + xTD;
      
    
    // if this is a Saturday, start a new row
    if (thisDay.getDay() == 6)
      html += xTR + TR;
    
    // increment the day
    thisDay.setDate(thisDay.getDate() + 1);
  } while (thisDay.getDate() > 1)
 
  // fill in any trailing blanks
  if (thisDay.getDay() > 0) {
    for (i = 6; i > thisDay.getDay(); i--)
      html += TD + "&nbsp;" + xTD;
  }
  html += xTR;
 
  // add a timer control
  if (timeFormat != "") {
      strTime = formatDate(currentDate, timeFormat);
      html += TR_timer + TD_timer;
      html += "<input id=\"__time_editor\" name=\"__time_editor\" class=\"dpTimer\" value=\""+strTime+"\"></input>";
      html += xTD + xTR;
  }
 
  // and finally, close the table
  html += xTABLE + xTD + xTR + xTABLE;
 
  document.getElementById(datePickerDivID).innerHTML = html;
  // add an "iFrame shim" to allow the datepicker to display above selection lists
  adjustiFrame();
}

function refreshDatePickerMonth(dateFieldName, newYear, newMonth)
{
  var dt = new Date(newYear, newMonth, 1);
  return refreshDatePicker(dateFieldName, getDateString(dt));
}

/**
Convenience function for writing the code for the buttons that bring us back or forward
a month.
*/
function getButtonCode(dateFieldName, dateVal, adjust, label)
{
  var newMonth = (dateVal.getMonth () + adjust) % 12;
  var newYear = dateVal.getFullYear() + parseInt((dateVal.getMonth() + adjust) / 12);
  if (newMonth < 0) {
    newMonth += 12;
    newYear += -1;
  }
  var dt = new Date(newYear, newMonth, 1);
  return "<button class=\"dpButton\" onClick=\"refreshDatePickerMonth('" + dateFieldName + "', " + newYear + ", " + newMonth + ");updateDateField('" + dateFieldName + "');\">" + label + "</button>";
}


/**
Convert a JavaScript Date object to a string, based on the dateFormat and dateSeparator
variables at the beginning of this script library.
*/
function getDateString(dateVal)
{
  if (dateFormat != "" && timeFormat != "") {
    return formatDate(dateVal, dateFormat+" "+timeFormat);
  }
  else if (dateFormat == "") {
    return formatDate(dateVal, timeFormat);
  }  
  else  
    return formatDate(dateVal, dateFormat);
}


/**
Convert a string to a JavaScript Date object.
*/
function getFieldDate(dateString)
{
  if (dateFormat != "" && timeFormat != "")
    return getDateFromFormat(dateString, dateFormat+" "+timeFormat);
  else if (dateFormat == "")
    return getDateFromFormat(dateString, timeFormat);
  else  
    return getDateFromFormat(dateString, dateFormat);
}

function updateDateField(dateFieldName)
{
  var targetDateField = document.getElementsByName(dateFieldName).item(0);

  if (updateCurrentTimePart()) 
    targetDateField.value = getDateString(currentDate);
  else {
    alert("Incorrect time format.");
    return false;
  }
  return true;
}

function closeDatePicker(dateFieldName) {
  if (!updateDateField(dateFieldName)) {
    return false;
  }  
  
  var targetDateField = document.getElementsByName(dateFieldName).item(0);

  var pickerDiv = document.getElementById(datePickerDivID);
  pickerDiv.style.visibility = "hidden";
  pickerDiv.style.display = "none";
 
  adjustiFrame();
  targetDateField.focus();
 
  // after the datepicker has closed, optionally run a user-defined function called
  // datePickerClosed, passing the field that was just updated as a parameter
  // (note that this will only run if the user actually selected a date from the datepicker)
//  if (typeof(datePickerClosed) == "function") //(dateString) && (
//    datePickerClosed(targetDateField);
}

/**
Use an "iFrame shim" to deal with problems where the datepicker shows up behind
selection list elements, if they're below the datepicker. The problem and solution are
described at:

http://dotnetjunkies.com/WebLog/jking/archive/2003/07/21/488.aspx
http://dotnetjunkies.com/WebLog/jking/archive/2003/10/30/2975.aspx
*/
function adjustiFrame(pickerDiv, iFrameDiv)
{
  // we know that Opera doesn't like something about this, so if we
  // think we're using Opera, don't even try
  var is_opera = (navigator.userAgent.toLowerCase().indexOf("opera") != -1);
  if (is_opera)
    return;
  
  // put a try/catch block around the whole thing, just in case
  try {
    if (!document.getElementById(iFrameDivID)) {
      // don't use innerHTML to update the body, because it can cause global variables
      // that are currently pointing to objects on the page to have bad references
      //document.body.innerHTML += "<iframe id='" + iFrameDivID + "' src='javascript:false;' scrolling='no' frameborder='0'>";
      var newNode = document.createElement("iFrame");
      newNode.setAttribute("id", iFrameDivID);
//      newNode.setAttribute("src", "javascript:void(0);");
      newNode.setAttribute("scrolling", "no");
      newNode.setAttribute ("frameborder", "0");
      document.body.appendChild(newNode);
    }
    
    if (!pickerDiv)
      pickerDiv = document.getElementById(datePickerDivID);
    if (!iFrameDiv)
      iFrameDiv = document.getElementById(iFrameDivID);
    
    try {
      iFrameDiv.style.position = "absolute";
      iFrameDiv.style.width = pickerDiv.offsetWidth;
      iFrameDiv.style.height = pickerDiv.offsetHeight ;
      iFrameDiv.style.top = pickerDiv.style.top;
      iFrameDiv.style.left = pickerDiv.style.left;
      iFrameDiv.style.zIndex = pickerDiv.style.zIndex - 1;
      iFrameDiv.style.visibility = pickerDiv.style.visibility ;
      iFrameDiv.style.display = pickerDiv.style.display;
    } catch(e) {
    }
 
  } catch (ee) {
  }
 
}
