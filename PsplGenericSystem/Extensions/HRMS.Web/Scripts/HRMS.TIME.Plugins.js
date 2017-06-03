/*
1. DML and Navigation related funcations.
2. Kendo Controls common functions.
3. Input Dta validations.
*/


function setBaseURL() {
    var BaseURL = 'http://localhost/eTimeTrackerAPI/'
    return BaseURL;
}

//****************************************************************************************
//***DML and Navigation related funcations
//****************************************************************************************
///Creates a New Guid.
function createGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

//Returns the QueryString value.
function GetParameterValues(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1];
        }
    }
}
//*****************************************************************************************
//*****************************************************************************************


//***********************************************************************************************
//Kendo Controls common functions
//***********************************************************************************************
//Verifies the RoleName from the control and hides/shows the controls according to the Role Name.
function setGridControlButtonsByRole(control) {
    var roleName = document.getElementById(control);
    switch ($(roleName).val()) {
        case "Administrator":
            $("#grid").find(".k-toolbar").hide(); //Hides Toolbar
            $(".k-grid-Delete", "#grid").hide();  //Hides Delete Button
            break;
        default:
            $("#grid").find(".k-toolbar").show(); //Shows Toolbar
            $(".k-grid-Delete", "#grid").show();  //Shows Delete Button
            break;
    }
}

//Sets the visibility of Edit and Delete Buttons for Default Roles...Administrator, Supervisor and Employee
function setGridControlButtonsByDefaultRoles(roleName) {
    //var roleName = document.getElementById(control);
    switch (roleName) {
        case "Administrator":
            //$("#grid").find(".k-toolbar").hide(); //Hides Toolbar
            $(".k-grid-Edit", "#grid").hide();      //Hides Delete Button
            $(".k-grid-Delete", "#grid").hide();    //Hides Delete Button
            break;
        default:
            //$("#grid").find(".k-toolbar").show(); //Shows Toolbar
            $(".k-grid-Edit", "#grid").show();      //Shows Delete Button
            $(".k-grid-Delete", "#grid").show();    //Shows Delete Button
            break;
    }
}

//Returns selected values from multiselect...
function getSelectedValues(control) {
    var from = document.getElementById(control);
    var to;
    var v = from.options.length;
    var selectedValues = "";

    //Loop to check whether the item in multiselect is selected.
    for (var i = 0; i < v; i++) {
        if (from.options[i] && from.options[i].selected) {
            var CVal = from.options[i].value;
            var CText = from.options[i].text;

            //If not selected item found in the multiselect
            if (selectedValues == "") {
                //selectedValues = CVal;
                selectedValues = CVal + "-" + CText;
            }
            else {
                //selectedValues = selectedValues + "~" + CVal;
                selectedValues = selectedValues + ";" + CVal + "-" + CText;
            }
        }
    }
    return selectedValues;
}

//Returns Morethan one records inforamtion by seperationg with ";" as a single string.
function getSuccessDataElements(successData) {
    var strUserCompanyDetails = "";
    for (var i = 0; i < successData.length; i++) {
        var CVal = successData[i].CompanyID;
        var CText = successData[i].CompanyCode;

        if (strUserCompanyDetails == "") {
            strUserCompanyDetails = CVal + "-" + CText;
        }
        else {
            strUserCompanyDetails = strUserCompanyDetails + ";" + CVal + "-" + CText;
        }
    }
    return strUserCompanyDetails;
}

//Returns selected values from Kendo-Grid.  NOT IMPLEMENTED
function getGridSelectedValues(control) {
    var strCompanyDetails = "";
    var grid = $(control).data("kendoGrid");
    //var data = grid.dataSource.data();
    $.each(data, function (i, row) {
        var CVal = row.CompanyID;
        var CText = row.CompanyCode;

        if (strCompanyDetails == "") {
            strCompanyDetails = CVal + "-" + CText;
        }
        else {
            strCompanyDetails = strCompanyDetails + ";" + CVal + "-" + CText;
        }
    })
    return strCompanyDetails;
}

//Kendo Date Validator
function validatorr(control) {
    $(control).kendoValidator({
        rules: {
            dateValidation: function (element) {
                var value = $(element).val();

                var date = kendo.parseDate(value);
                if (!date) {
                    return false;
                }

                return true;
            }
        },
        messages: {
            dateValidation: "Enter Date in Correct format"
        }
    });
}

//Change the colour on the selected Row when selection of checkBox on Grid .
function setSelectedForCheckBox(control, gridName) {
    var cntrTR = $(control);
    if (control.checked) {
        $(cntrTR.closest('tr'), '#' + gridName + '').addClass('k-state-selected');
    }
    else
        $(cntrTR.closest('tr'), '#' + gridName + '').removeClass('k-state-selected');
}
//Changes the colour on the selected Row when Clicking on Button on Grid .
function setRowSelectionForButton(row, gridName) {
    $('#' + gridName + ' tbody tr').removeClass('k-state-selected');
    $(row, '#' + gridName).addClass('k-state-selected');
}
//*****************************************************************************************
//*****************************************************************************************

//Returns the Day of the Week
function DayOfWeek(dayValue) {
    switch (dayValue) {
        case 1:
            dayValue = "Monday";
            break;
        case 2:
            dayValue = "Tuesday";
            break;
        case 3:
            dayValue = "Wednesday";
            break;
        case 4:
            dayValue = "Thursday";
            break;
        case 5:
            dayValue = "Friday";
            break;
        case 6:
            dayValue = "Saturday";
            break;
        case 0:
            dayValue = "Sunday";
            break;
    }
    return dayValue;
}

//Removing time from datetime and only date(mm/dd/yyyy) is saved here
function ReturnOnlyDate(dataItemDate) {
    var date = dataItemDate.split('-');
    return date = date[1] + '/' + date[2].substring(0, 2) + '/' + date[0];
}

//for displaying datetime like mm/dd/yyyy hh:mm:ss
function ReturnDateTime(dataItemDate) {
    var dateSplit = dataItemDate.split('-');
    var Time = dateSplit[2].substring(3, 11);
    var date = dateSplit[1] + '/' + dateSplit[2].substring(0, 2) + '/' + dateSplit[0];
    return date + " " + Time;
}

//*****************************************************************************************
//Input Dta validations.
//*****************************************************************************************
//Show/Hides the given Control
function toggleComponent(control) {
    var component = document.getElementById(control);
    $(component).toggle(); 
    //$(component).fadeToggle(2000);
}

//Shows the Component
function showComponent(control) {
    var component = document.getElementById(control);
    $(component).show();
}

//Hides the Component
function hideComponent(control) {
    var component = document.getElementById(control);
    $(component).hide();
}

//Handles Checkbox event. And returns the checked/unchecked value.
function getCheckboxValue(control) {
    var checkBoxControl = document.getElementsByTagName(control);
    //$(checkBoxControl).click(function () {
    var inputs = document.getElementsByTagName("input");
    var flag = false;
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            if (inputs[i].checked) {
                flag = true;
                $(checkBoxControl).val(flag);
                break;
            }
        }
    }
    return flag;
    //})
}

//Null Values
function validateNullValue(controlId) {
    if ($('#' + controlId + '').val() != null && $('#' + controlId + '').val() != "")
        return true;
    else
        return false;
}

//Hours validation
function validateHours(control) {
    if (control.value != "") {
        if (control.value > 24) {
            control.value = "";
            alert("Hours should be less than 24");
            return false;
        }
        else
            return true;
    }
}

//Numeric values
function validateNumarics(event, control) {
    // Get the ASCII value of the key that the user entered
    var key = event.keyCode;
    // Verify if the key entered was a numeric character (0-9) or a decimal (.) or BackSpace
    if ((key > 47 && key < 58) || key == 46 || key == 8)
        // If it was, then allow the entry to continue
        return true;
    else
        // If it was not, then dispose the key and continue with entry
        //                event.returnValue = null; 
        return false;
}

//Email validation
function validateEmail(control) {
    if (control.value != "") {
        //Regular Expression for Email
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (!filter.test(control.value)) {
            alert("Enter valid Email Address.");
            control.value = "";
            return false;
        }
        return true;
    }
}

//PhoneFormat
function phoneFormat(event, control) {
    if (validateNumarics(event, control)) {
        if (control.value.length == 3 || control.value.length == 7)
            control.value = control.value + "-";
        if (control.value.length > 11)
            return false;
    }
    else
        return false;
}

//SSNFormat
function SSNFormat(event, control) {
    if (validateNumarics(event, control)) {
        if (control.value.length == 3 || control.value.length == 6)
            control.value = control.value + "-";
        if (control.value.length > 10)
            return false;
    }
    else
        return false;
}

//Phone Numbers
function validatePhoneNumber(control) {
    if (control.value != "") {
        if (control.value.length != 12) {
            alert('Enter Valid Phone Numbers');
            control.value = "";
            return false;
        }
        return true;
    }
}

//SSN Validation
function validateSSN(control) {
    if (control.value != "") {
        if (control.value.length != 11) {
            alert('Enter valid SSN Number.');
            control.value = "";
            return false;
        }
        return true;
    }
}

//ZipCode Validation
function validateZipcode(control) {
    if (control.value != "") {
        var zipFilter = /(^\d{5}$)/;
        if (!zipFilter.test(control.value)) {
            alert('Enter valid ZIPcode (12345).');
            control.value = "";
            return false;
        }
        return true;
    }
}

//Date Format for MM-DD-YYYY
function dateFormat(event, control) {
    if (validateNumarics(event, control)) {
        if (control.value.length == 2 || control.value.length == 5)
            control.value = control.value + "/";
        if (control.value.length > 9)
            return false;
    }
}

//Validates Date Format
function isValidDate(control) {
    if (control.value != "")
        var mo, day, yr;
    var entry = control.value;
    var reLong = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
    var reShort = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{2}\b/;
    var valid = (reLong.test(entry)); //|| (reShort.test(entry));
    if (valid) {
        var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
        var delim1 = entry.indexOf(delimChar);
        var delim2 = entry.lastIndexOf(delimChar);
        mo = parseInt(entry.substring(0, delim1), 10);
        day = parseInt(entry.substring(delim1 + 1, delim2), 10);
        yr = parseInt(entry.substring(delim2 + 1), 10);
        // handle two-digit year
        if (yr < 100) {
            alert("Check the year entry.Enter as mm/dd/yyyy.");
            control.value = "";
            return false
            //var today = new Date();
            //// get current century floor (e.g., 2000)
            //var currCent = parseInt(today.getFullYear() / 100) * 100;
            //// two digits up to this year + 15 expands to current century
            //var threshold = (today.getFullYear() + 15) - currCent;
            //if (yr > threshold) {
            //    yr += currCent - 100;
            //} else {
            //    yr += currCent;
            //}
        }
        var testDate = new Date(yr, mo - 1, day);
        if (testDate.getDate() == day) {
            if (testDate.getMonth() + 1 == mo) {
                if (testDate.getFullYear() == yr) {
                    // fill field with database-friendly format
                    return true;
                } else {
                    alert("Check the year entry.Enter as mm/dd/yyyy.");
                    control.value = "";
                    return false;
                }
            } else {
                alert("Check the month entry.Enter as mm/dd/yyyy.");
                control.value = "";
                return false;

            }
        } else {
            alert("Check the date entry.Enter as mm/dd/yyyy.");
            control.value = "";
            return false;
        }
    } else {
        if (entry != "") {
            alert("Invalid date format. Enter as mm/dd/yyyy.");
            control.value = "";
            return false;
        }
        else { }
    }
    return true;
}

//Compare Password
function comparePasswordValidation(cmprPswdCntrId, pswdCntrId) {
    var passwordControl = $(pswdCntrId).val();
    var cmprPasswordControl = $(cmprPswdCntrId).val();
    if (passwordControl != cmprPasswordControl) {
        alert('Password does not match. Password and Confirm Password should be same.');
        $(pswdCntrId)[0].value = "";
        $(cmprPswdCntrId)[0].value = "";
        $(pswdCntrId)[0].focus();
        return false;
    }
}
//*****************************************************************************************
//*****************************************************************************************


//Not accepts Special Characters. NOT IMPLEMENTED
function validate(control) {
    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";
    for (var i = 0; i < control.length ; i++) {
        if (iChars.indexOf(control.value.charAt(i)) != -1) {
            alert("You are using special characters. \nThese are not allowed.\n Please remove them and try again.");
            control.focus();
            return false;
        }
    }
}
