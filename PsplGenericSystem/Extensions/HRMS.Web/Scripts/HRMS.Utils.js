$.namespace('HRMS.Utils');

HRMS.Utils = {

    GetStorageItem: function (key) {
        try { return localStorage[key]; } catch (e) { return null; }
    },

    SetStorageItem: function (key, value) {
        try { localStorage[key] = value; } catch (e) { }
    },

    RemoveStorageItem: function (key) {
        try { localStorage.removeItem(key); } catch (e) { }

    },

    LocalStorage: function () {
        try { return localStorage; } catch (e) { return null; }
    },

    SetLocalDate: function (d, ms) {
        var t = new Date();
        t.setTime(ms);
        $("#" + d).text(PWHR.Resource.Months[t.getMonth()] + " " + t.getDate() + ", " + PWHR.Utils.FormatTime(t));
        $("#" + d).text(PWHR.Utils.GetLocalDate(ms));
    },

    GetLocalDate: function (ms) {
        var t = new Date();
        t.setTime(ms);
        return PWHR.Resource.Months[t.getMonth()] + " " + t.getDate() + ", " + Riot.Utils.FormatTime(t);
    },


    FormatTime: function (dt) {
        var a_p = "";
        var d = new Date();
        //        var formatted = d.format("yyyy-M-dd");
        var curr_hour = dt.getHours();
        var curr_date = dt.getDate();
        var curr_month = dt.getMonth() + 1;
        var curr_year = dt.getFullYear();
        if (curr_hour > 11) {
            a_p = "PM"; /////resource
        }
        else {
            a_p = "AM";
        }
        if (curr_hour == 0) {
            curr_hour = 12;
        }
        if (curr_hour > 11) {
            curr_hour = curr_hour - 12;
            if (curr_hour == 0)
                curr_hour = 12;

        }

        var curr_min = dt.getMinutes();

        curr_min = curr_min + "";

        if (curr_min.length == 1) {
            curr_min = "0" + curr_min;
        }
        return curr_month + "/" + curr_date + "/" + curr_year + " " + curr_hour + ":" + curr_min + " " + a_p;
    },

    FormatTimeOnly: function (dt) {
        var a_p = "";
        var d = new Date();
        //        var formatted = d.format("yyyy-M-dd");
        var curr_hour = dt.getHours();
        var curr_date = dt.getDate();
        var curr_month = dt.getMonth() + 1;
        var curr_year = dt.getFullYear();
        if (curr_hour > 11) {
            a_p = "PM"; /////resource
        }
        else {
            a_p = "AM";
        }
        if (curr_hour == 0) {
            curr_hour = 12;
        }
        if (curr_hour > 11) {
            curr_hour = curr_hour - 12;
            if (curr_hour == 0)
                curr_hour = 12;

        }

        var curr_min = dt.getMinutes();

        curr_min = curr_min + "";

        if (curr_min.length == 1) {
            curr_min = "0" + curr_min;
        }
        return curr_hour + ":" + curr_min + " " + a_p;
    },

    FancyTime: function (dt) {
        var a_p = "";
        var d = new Date();
        //        var formatted = d.format("yyyy-M-dd");
        var curr_hour = dt.getHours();
        var curr_date = dt.getDate();
        var curr_month = dt.getMonth() + 1;
        var curr_year = dt.getFullYear();
        if (curr_hour > 11) {
            a_p = "PM"; /////resource
        }
        else {
            a_p = "AM";
        }
        if (curr_hour == 0) {
            curr_hour = 12;
        }
        if (curr_hour > 11) {
            curr_hour = curr_hour - 12;
            if (curr_hour == 0)
                curr_hour = 12;

        }

        var curr_min = dt.getMinutes();

        curr_min = curr_min + "";

        if (curr_min.length == 1) {
            curr_min = "0" + curr_min;
        }
        return curr_date + " " + PWHR.Resource.Months[curr_month - 1] + " " + curr_year + " " + curr_hour + ":" + curr_min + " " + a_p;
    },

    Reset: function () {
        //  
        if ($('#i_r__').length == 0) {
            $('body').append($('<img id="i_r__" />'));
        }

        d = new Date();
        $("#i_r__").attr("src", "../Content/images/tiny.png?" + d.getTime());
    },


    

    //converting UTC time from database to the clienttime   
    calcTime: function (UTC, timeOnly) {
        // create Date object for current location
        //   var d = Date.parse(UTC);

        // convert to msec
        // add local time zone offset
        // get UTCtolocal time in msec
        // var utctolocal = d.getTime() + (d.getTimezoneOffset() * 60000 * -1);

        // create new Date object for different city        
        var nd = PWHR.Utils.ConvertUTCToLocal(UTC); // new Date(utctolocal);

        if (arguments[1] && arguments[1] == true) {
            // return time as a string
            return PWHR.Utils.FormatTimeOnly(nd);
        }
        else {
            return PWHR.Utils.FormatTime(nd);
        }
    },

    ConvertUTCToLocal: function (UTC) {
        var d = Date.parse(UTC);

        // convert to msec
        // add local time zone offset
        // get UTCtolocal time in msec
        var utctolocal = d.getTime() + (d.getTimezoneOffset() * 60000 * -1);

        // create new Date object for different city        
        var nd = new Date(utctolocal);

        return nd;
    },

    SetRootDomain: function () { // Remove subdomain from document.domain
        if (document.domain.split(".").length > 2) {
            document.domain = document.domain.split(".").slice(-2).join(".");
        }
    },

    ShowAlert: function (message) {
        //create div on fly if it does not exist
        if ($('#_utils_dialog_error').length == 0) {
            var html = "<div id='_utils_dialog_error' style='display: none;'>";
            html += "<p>";
            html += "<span class='ui-icon ui-icon-alert' style='float: left; margin: 0 7px 20px 0;'></span>"
            html += "<span id='_utils_dialog_error_message'></span>";
            html += "</p>";
            html += "</div>";

            $("body").append(html);
        }

        $("#_utils_dialog_error").html(message);
        $("#_utils_dialog_error").dialog({
            modal: true,
            draggable: false,
            buttons:
                [
                    {
                        text: HappyFile.Resource.OK,
                        click: function (e) {
                            $(this).dialog("close");
                        }
                    }
                    ]
        });

    },

    IsInt: function (n) {
        return Math.floor(n) == n && $.isNumeric(n);
    }  

}




