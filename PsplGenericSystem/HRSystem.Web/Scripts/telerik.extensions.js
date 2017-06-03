/*
* @Copyright (c) 2011 John DeVight
* Permission is hereby granted, free of charge, to any person
* obtaining a copy of this software and associated documentation
* files (the "Software"), to deal in the Software without
* restriction, including without limitation the rights to use,
* copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following
* conditions:
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
* OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
* WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.
*/

/// <summary>
/// Extend the Telerik Extensions for ASP.NET MVC.
/// </summary>
(function ($) {
    // Was the telerik.list.min.js added to the page by the telerik scrip registrar?
    if ($.telerik.dropDownList != undefined || $.telerik.combobox != undefined) {
        // Extend the dropDownList plugin.
        var dropDownListExtensions = {
            /// <summary>
            /// Bind a list of json objects as a table in the dropdownlist items.
            /// </summary>
            /// <param type="json object" name="o">json object with the following attributes:
            /// 1. data: list of json objects to bind to the dropdownlist.
            /// 2. displayFields: an array of json objects with the following attributes:
            ///    - fieldName: name of the field in the json object defined in the data attribute.
            ///    - style: style to be applied to the table cell.
            /// 3. seperator: character to use for a seperator between fields in the table.
            ///               If not set, then no seperator is displayed.
            /// 4. selectedField: the field to be displayed in the dropdown when an item is selected.
            /// 5. valueField: the field containing the value associated with the selected item.
            /// </param>
            /// <example>
            /// $('#dropdownlist').data('tDropDownList').dataBindAsTable({
            ///     data: [{
            ///         Id: 1,
            ///         Vegetable: "Broccoli",
            ///         Color: "Green"
            ///     },{
            ///         Id: 2,
            ///         Vegetable: "Carrot",
            ///         Color: "Orange",
            ///         Disable: true
            ///     },{
            ///         Id: 3,
            ///         Vegetable: "Green Beans",
            ///         Color: "Green"
            ///     }],
            ///     displayFields: [{ 
            ///         fieldName: "Vegetable", 
            ///         style: "font-weight:bold" 
            ///     },{
            ///         fieldName: "Color"
            ///     }],
            ///     separator: { visible: true, color: 'Blue' },
            ///     selectedField: "Vegetable",
            ///     valueField: "Id",
            ///     initialValue: 1,
            ///     onSelect: function (e) { alert(e.value + ' ' + e.text); }
            /// </example>
            dataBindAsTable: function (o) {
                var dropdown = this;
                var name = this.element.id;

                var data = [];
                dropdown._isDropDown = $(dropdown.element).parent().hasClass('t-dropdown');
                dropdown._listAsTable = [];

                // For each json object in the o.data array, build a table to display in the dropdown list as well as a hidden field with the value for the item.
                $.each(o.data, function (idx, item) {
                    var html = "", style = "";
                    $.each(o.displayFields, function (fdx, field) {
                        if (html.length > 0) {
                            style = "padding-right:2px;";
                            if (o.separator == undefined || (o.separator != undefined && (o.separator.visible == undefined || o.separator.visible == true))) {
                                style += "border-right:1px solid ";
                                style += (o.separator != undefined && o.separator.color != undefined) ? o.separator.color : "Grey";
                                style += ";";
                            }
                            html += "<td style='" + style + "'>&nbsp;</td>";
                        }
                        style = field.style != undefined ? field.style : "";
                        html += "<td style='padding-left:5px;" + style + "'>" + item[field.fieldName] + "</td>";
                    })
                    html = "<table cellpading='0' cellspacing='0'><tr style='vertical-align:top'>" + html + "</tr></table><input type='hidden' value='" + item[o.selectedField] + "' />";
                    // The dropdown list contains a list of "placeholder" items.  The actual items and inserted into the dropdown list when the user opens the dropdown.
                    data.push({ Text: item[o.selectedField], Value: item[o.valueField] });
                    dropdown._listAsTable.push({ Html: html, Value: item[o.valueField], Disable: item.Disable == undefined ? false : item.Disable });
                    // If an initial value was passed in and it is for this item, then get the text to be initially displayed in the dropdown.
                    if (o.initialValue != undefined && o.initialValue == item[o.valueField]) {
                        o.initialText = item[o.selectedField];
                        o.initialIndex = idx;
                    }
                });

                dropdown.dataBind(data);

                // If there is an initial value to display for the dropdown, then display it.
                if (o.initialText != undefined && o.initialText.length > 0) {
                    $(dropdown).select(o.initialIndex);
                    $(dropdown.element).prev().children()[0].innerHTML = o.initialText;
                }

                // When the value changes display the selected text and set the value.
                $(dropdown.element).bind('valueChange', function (e) {
                    var item = null;
                    $.each(dropdown._listAsTable, function (idx, obj) {
                        if (obj.Value.toString() == e.value.toString()) {
                            item = obj;
                        }
                    });
                    var displayValue = $($(item.Html)[1]).val();
                    if (dropdown._isDropDown) {
                        if (displayValue.length == 0) { displayValue = '&nbsp;'; }
                        $(dropdown.element).prev('div.t-dropdown-wrap').find('span.t-input').html(displayValue);
                    } else {
                        $(dropdown.element).prev('div.t-dropdown-wrap').find('span.t-input').value(displayValue);
                    }
                    if (o.onSelect != undefined) {
                        o.onSelect({ value: item.Value, text: displayValue });
                    }
                });
                $(dropdown.element).bind('open', function (e) {
                    setTimeout("$('#" + name + "').data('" + (dropdown._isDropDown ? "tDropDownList" : "tComboBox") + "').formatDropDownAsTable();", 50);
                });
            },
            /// <summary>
            /// When the dropdown is displayed in a dropdownlist; for each item, format the cells in each table
            /// so that each column has the same width and allow the table to be as wide as it needs to be.
            ///
            /// THIS IS AN INTERNAL FUNCTION AND IS NOT MEANT TO BE CALLED FROM ANYWHERE BESIDES THE dataBindAsTable
            /// FUNCTION.
            /// </summary>
            formatDropDownAsTable: function () {
                var dropdown = this;
                $('div.t-animation-container').css('width', '');
                $('div.t-popup.t-group').css('width', '');
                var widths = [];
                var height = 0;
                $.each($('div.t-popup.t-group').find('li'), function (idx, item) {
                    item.innerHTML = dropdown._listAsTable[idx].Html;
                    if (dropdown._listAsTable[idx].Disable == true) $(item).removeClass('t-item').css('color', 'Grey');
                    $(item).css("padding", "0px");
                    $.each($(item).find('td'), function (tdx, td) {
                        var w = $(td).width() + 1;
                        if (tdx >= widths.length) {
                            widths.push(w);
                        } else {
                            if (widths[tdx] < w) {
                                widths[tdx] = w;
                            }
                        }
                    });
                    height += $(item).height();
                });
                $.each($('div.t-popup.t-group').find('li'), function (idx, item) {
                    $.each($(item).find('td'), function (tdx, td) {
                        $(td).width(widths[tdx]);
                    });
                });
                if ($('div.t-popup.t-group').get(0).scrollHeight > $('div.t-popup.t-group').height()) {
                    $('div.t-popup.t-group').css('width', $('div.t-popup.t-group').width() + 20);
                    $('div.t-popup.t-group').height(height + 3);
                }
            },
            /// <summary>
            /// Disable list items in the dropdown list.
            /// </summary>
            /// <param type="array" name="items">Array of json objects where each json object has the following attributes:
            /// 1. text: the text that is displayed for a dropdown list item.
            /// OR
            /// 2. value: the value for a dropdown list item. 
            /// </param>
            /// <example>
            /// $('#dropdownlist').data('tDropDownList').dataBind(
            ///   { Text:'Red', Value:'1' },
            ///   { Text:'Green', Value:'2' },
            ///   { Text:'Blue', Value:'3' },
            ///   { Text:'Yellow', Value:'4' },
            ///   { Text:'Orange', Value:'5' },
            /// );
            ///
            /// $('#dropdownlist').data('tDropDownList').disableListItems([{ text:'Red' },{ text:'Orange' }]);
            /// 
            /// $('#dropdownlist').data('tDropDownList').disableListItems([{ value:'1' },{ text:'5' }]);
            /// </example>
            disableListItems: function (items) {
                var dropdown = this;
                var name = this.element.id;
                dropdown._isDropDown = $(dropdown.element).parent().hasClass('t-dropdown');
                if (dropdown._disabledItems == undefined) {
                    $(dropdown.element).bind('open', function (e) {
                        setTimeout("$('#" + name + "').data('" + (dropdown._isDropDown ? "tDropDownList" : "tComboBox") + "').disableItems();", 50);
                    });
                }
                $.each(items, function (idx, item) {
                    if (item.text == undefined) {
                        $.each(dropdown.data, function (ddx, dataItem) {
                            if (item.value == dataItem.Value) {
                                item.text = dataItem.Text;
                                return;
                            }
                        });
                    }
                });
                dropdown._disabledItems = items;
            },
            /// <summary>
            /// When the dropdown is displayed in a dropdownlist; disable items in the list.
            ///
            /// THIS IS AN INTERNAL FUNCTION AND IS NOT MEANT TO BE CALLED FROM ANYWHERE BESIDES THE disableListItems
            /// FUNCTION.
            /// </summary>
            disableItems: function () {
                var dropdown = this;
                $.each($('div.t-popup.t-group').find('li'), function (idx, item) {
                    $.each(dropdown._disabledItems, function (ddx, disabledItem) {
                        if (disabledItem.text == $(item).text()) {
                            $($(item)).removeClass('t-item').css('color', 'Grey');
                        }
                    });
                });
            }
        };

        if ($.telerik.dropDownList != undefined) {
            // Add the extensions to the dropDownList plugin.
            $.extend(true, $.telerik.dropDownList.prototype, dropDownListExtensions);
        }
        if ($.telerik.combobox != undefined) {
            // Add the extensions to the combobox plugin.
            $.extend(true, $.telerik.combobox.prototype, dropDownListExtensions);
        }
    }

    // Was the telerik.combobox.min.js added to the page by the telerik script registrar?
    if ($.telerik.combobox != undefined) {
        // Extend the combobox plugin.
        var comboboxExtensions = {
            /// <summary>
            /// Subscribe to the onblur event that is raised when the combobox looses focus.
            /// </summary>
            /// <param type="function pointer" name="handler">
            /// JavaScript code that will be executed when the onblur event is raised.
            /// </param>
            onBlur: function (handler) {
                $('#' + $(this.element).attr('id') + '-input').bind('blur', handler);
            }
        };

        $.extend(true, $.telerik.combobox.prototype, comboboxExtensions);
    }

    if ($.telerik.dropDownList != undefined) {
        // Extend the dropDownList plugin.
        var dropDownListExtensions = {
            /// <summary>
            /// Subscribe to the onblur event that is raised when the combobox looses focus.
            /// </summary>
            /// <param type="function pointer" name="handler">
            /// JavaScript code that will be executed when the onblur event is raised.
            /// </param>
            setText: function (text) {
                $(this.element).prev().find('.t-input').text(text);
            }
        };

        $.extend(true, $.telerik.dropDownList.prototype, dropDownListExtensions);
    }

    // Was the tekerik.tabstrip.min.js added to the page by the telerik script registrar?
    if ($.telerik.tabstrip != undefined) {
        // Extend the tabstrip plugin.
        var tabstripExtensions = {
            /// <summary>
            /// Get a tab.
            /// </summary>
            /// <param type="json object" name="o">json object with either the text or the index of the tab.</param>
            /// <return>jQuery object of the tab [li.t-item]</return>
            /// <example>
            /// var tab = $('#MyTabStrip').data('tTabStrip').getTab({ text: 'Tab 2' })
            /// var tab = $('#MyTabStrip').data('tTabStrip').getTab({ index: 1 })
            /// </example>
            getTab: function (o) {
                var tab = null;
                if (o.text != null) {
                    tab = $(this.element).find('.t-item').find("a:contains('" + o.text + "')").parent();
                }
                else if (o.index != null) {
                    tab = $($(this.element).find('.t-item')[o.index]);
                }
                return tab;
            },
            /// <summary>
            /// Get index of tab.
            /// </summary>
            /// <param type="string" name="t">text of a tab.</param>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').getTabIndex('Tab 2')
            /// </example>
            getTabIndex: function (t) {
                var idx = 0;
                $.each($(this.element).find('.t-tabstrip-items a.t-link'), function (i, a) {
                    if ($(a).text() == t) {
                        idx = i;
                        return false;
                    }
                })
                return idx;
            },
            /// <summary>
            /// Return a count on the number of tabs in the tabstrip.
            /// </summary>
            getTabCount: function () {
                return $(this.element).find('.t-tabstrip-items').find('a').length;
            },
            /// <summary>
            /// Hide a tab.
            /// </summary>
            /// <param type="json object" name="o">json object with either the text or the index of the tab.</param>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').hideTab({ text: 'Tab 2' })
            /// $('#MyTabStrip').data('tTabStrip').hideTab({ index: 1 })
            /// </example>
            hideTab: function (o) {
                var tab = this.getTab(o);
                if (tab != null) {
                    tab.css('visibility', 'hidden');
                    tab.css('display', 'none');
                }
            },
            /// <summary>
            /// Show a tab.
            /// </summary>
            /// <param type="json object" name="o">json object with either the text or the index of the tab.</param>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').showTab({ text: 'Tab 2' })
            /// $('#MyTabStrip').data('tTabStrip').showTab({ index: 1 })
            /// </example>
            showTab: function (o) {
                var tab = this.getTab(o);
                if (tab != null) {
                    tab.css('visibility', '');
                    tab.css('display', '');
                }
            },
            /// <summary>
            /// Select a tab.
            /// </summary>
            /// <param type="json object" name="o">json object with either the text or the index of the tab.</param>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').selectTab({ text: 'Tab 2' })
            /// $('#MyTabStrip').data('tTabStrip').selectTab({ index: 1 })
            /// </example>
            selectTab: function (o) {
                var tab = this.getTab(o);
                if (tab != null) {
                    this.select(tab);
                }
            },
            /// <summary>
            /// Change the text of a tab.
            /// </summary>
            /// <param type="json object" name="o">json object with either the text or the index of the tab and the newText for the tab.</param>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').setTabText({ text: 'Tab 2', newText: 'Second Tab' })
            /// $('#MyTabStrip').data('tTabStrip').setTabText({ index: 1, newText: 'Second Tab' })
            /// </example>
            setTabText: function (o) {
                var tab = this.getTab(o);
                if (tab != null) {
                    tab.find('a').text(o.newText);
                }
            },
            /// <summary>
            /// Add a tab.
            /// </summary>
            /// <param type="json object" name="t">json object with text and html for the tab.</param>
            /// <example>
            /// $.ajax({
            ///     url: '/Home/GetTabThree/',
            ///     contentType: 'application/html; charset=utf-8',
            ///     type: 'GET',
            ///     dataType: 'html'
            /// })
            /// .success(function(result) {
            ///     $('#MyTabStrip').data('tTabStrip').addTab({ text: 'Tab Three', html: result });
            /// });
            /// </example>
            addTab: function (t) {
                var tabstrip = $(this.element);
                var tabstripitems = tabstrip.find('.t-tabstrip-items');
                var cnt = tabstripitems.children().length;
                var tabname = tabstrip.attr('id');

                tabstripitems.append(
                    $('<li />')
                        .addClass('t-item')
                        .addClass('t-state-default')
                        .append(
                            $('<a />')
                                .attr('href', '#' + tabname + '-' + (cnt + 1))
                                .addClass('t-link')
                                .text(t.text)
                        )
                    );

                var $contentElement =
                    $('<div />')
                        .attr('id', tabname + '-' + (cnt + 1))
                        .addClass('t-content')
                        .append(t.html)

                tabstrip.append($contentElement);

                tabstrip.data('tTabStrip').$contentElements.push($contentElement[0]);
            },
            /// <summary>
            /// Remove a tab.
            /// </summary>
            /// <param type="json object" name="o">json object with either the text or the index of the tab.</param>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').removeTab({ text: 'Tab 2' })
            /// $('#MyTabStrip').data('tTabStrip').removeTab({ index: 1 })
            /// </example>
            removeTab: function (o) {
                var tabstrip = $(this.element);
                var tabname = tabstrip.attr('id');
                var tabstripitems = tabstrip.find('.t-tabstrip-items');
                var i = 0;

                if (o.index == undefined || o.index == null) {
                    i = this.getTabIndex(o.text);
                } else {
                    i = o.index;
                }

                // There must be atleast two tabs to remove a tab.
                if (tabstripitems.children().length > 1) {
                    var tab = this.getTab({ index: i });
                    // If the active tab is being removed, set another tab as active.
                    if (tab.hasClass('t-state-active') == true) {
                        var j = i == 0 ? 1 : (i - 1);
                        this.activateTab(this.getTab({ index: j }));
                    }
                    tab.remove();

                    // Remove the tab contents.
                    $(tabstrip.children()[i + 1]).remove();
                    tabstrip.data('tTabStrip').$contentElements.splice(i, 1);

                    // Rename the tab href.
                    $.each(tabstripitems.children(), function (idx, tab) {
                        $($(tab).children()[0]).attr('href', '#' + tabname + '-' + (idx + 1));
                    });

                    // Rename tab contents.
                    $.each(tabstrip.children(), function (idx, contentElement) {
                        if ($(contentElement).is('div')) {
                            $(contentElement).attr('id', tabname + '-' + idx);
                        }
                    })
                }
            },
            /// <summary>
            /// Hide the contents for all tabs in the tabstrip.
            /// </summary>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').hideContent()
            /// </example>
            hideContent: function () {
                this.activateTab = function (d) {
                    //var f=d.parent().children().removeClass("t-state-active").addClass("t-state-default").index(d);
                    d.removeClass("t-state-default").addClass("t-state-active");
                };
                $(this.element).height($(this.element).find('.t-tabstrip-items').css('height'));
                $.each($(this.element).find('.t-content'), function (idx, content) {
                    $(content).css('display', 'none')
                });
            },
            /// <summary>
            /// Show the contents for all tabs in the tabstrip.
            /// </summary>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').showContent()
            /// </example>
            showContent: function () {
                this.activateTab = $.telerik.tabstrip.prototype.activateTab;
                $(this.element).css('height', '');
                var t = this.getTab({ index: $(this.element).find('li.t-state-active').index() });
                this.activateTab(t);
            },
            /// <summary>
            /// Remove the contents for all tabs in the tabstrip.
            /// Once this is done, there is no way of restoring the 
            /// tab contents.
            /// </summary>
            /// <example>
            /// $('#MyTabStrip').data('tTabStrip').removeContent()
            /// </example>
            removeContent: function () {
                $(this.element).find('div.t-content', '.t-tabstrip').remove();
                $(this.element).height($(this.element).find('.t-tabstrip-items').css('height'));
            }
        };

        // Add the extensions to the tabstrip plugin.
        $.extend(true, $.telerik.tabstrip.prototype, tabstripExtensions);
    }



    // Was the tekerik.grid.min.js added to the page by the telerik script registrar?
    if ($.telerik.grid != undefined) {
        // Extend the grid plugin.
        var gridExtensions = {
            /// <summary>
            /// Hide a column in the grid.
            /// </summary>
            /// <param type="int" name="i">Zero based index for the column.</param>
            /// <example>
            /// $('#MyGrid').data('tGrid').hideColumn(1);
            /// </example>
            hideColumn: function (i) {
                var table = $(this.element).find('table');

                if (table.find('thead tr th').length > i) {
                    $($(table).find('thead tr th')[i]).css('display', 'none');
                }

                var rows = $(table).find('tbody tr:[class!=t-grouping-row]');
                if (rows.length >= 1) {
                    $.each(rows, function (idx, row) {
                        if ($(row).children().length > i) {
                            $($(row).children()[i]).css('display', 'none');
                        }
                    });
                }
            },
            /// <summary>
            /// Show a column in the grid.
            /// </summary>
            /// <param type="int" name="i">Zero based index for the column.</param>
            /// <example>
            /// $('#MyGrid').data('tGrid').showColumn(1);
            /// </example>
            showColumn: function (i) {
                var table = $(this.element).find('table');

                if (table.find('thead tr th').length > i) {
                    $($(table).find('thead tr th')[i]).css('display', '');
                }

                var rows = $(table).find('tbody tr');
                if (rows.length >= 1) {
                    $.each(rows, function (idx, row) {
                        if ($(row).find('td').length > i) {
                            $($(row).find('td')[i]).css('display', '');
                        }
                    });
                }
            },
            showAllColumnHeaders: function () {
                var table = $(this.element).find('table');
                //var cnt=$(this.element).find('thead tr th').length;
                var rows = $(table).find('tr');

                $.each(rows, function (rdx, row) {
                    $.each($(row).find('th'), function (hdx, th) {
                        $(th).css('display', '');
                    });
                });
            },
            /// <summary>
            /// Enable client side sorting in the grid.
            /// </summary>
            /// <param type="json" name="o">JSON object with the following attributes:
            /// onlyColsDefinedInMarkup (defaults to true) [optional]:
            //      true - sorting should only be enabled for columns 
            ///         that have Sortable set to true for columns defined in the HTML markup.
            ///     false - sorting should be enabled for all columns regardless of what
            ///         columns have Sortable set in the HTML markup.
            /// </param>
            /// <example>
            /// $('#MyGrid').data('tGrid').enableClientSort();
            /// $('#MyGrid').data('tGrid').enableClientSort({ onlyColsDefinedInMarkup:false });
            /// </example>
            enableClientSort: function (o) {
                o = $.extend({
                    onlyColsDefinedInMarkup: true
                }, o);
                var $grid = this;
                if (o.onlyColsDefinedInMarkup == false) {
                    var headerCells = $(this.element).find('.t-header');
                    $.each(headerCells, function (idx, cell) {
                        var tlink = $(cell).children('a.t-link');
                        if (tlink.length == 0) {
                            var $a = $('<a />')
                            .attr('class', 't-link t-state-default')
                            .css('padding-right', '0px');
                            $a.text($(cell).text());
                            cell.innerHTML = $('<div>').append($a.clone()).html();
                        }
                    })
                }
                this.sort = function (h) {
                    var data = $grid.data;

                    var sort_by = function (reverse, primer, displayFor) {
                        reverse = (reverse) ? -1 : 1;
                        return function (a, b) {
                            a = displayFor(a);
                            b = displayFor(b);

                            if (typeof (primer) != 'undefined') {
                                a = primer(a);
                                b = primer(b);
                            }

                            if (a < b) return reverse * -1;
                            if (a > b) return reverse * 1;
                            return 0;
                        }
                    }

                    if (h.length > 0) {
                        this.orderBy = h;
                        $.each($grid.sorted, function (idx, col) {
                            var datatype = col.type == undefined ? "String" : col.type;
                            var handler = datatype == "Number"
                                ? col.format == "{0:c}"
                                    ? function (a) { if (a != undefined && a != null) { return parseFloat(a.replace('$', '')); } return a; }
                                    : function (a) { if (a != undefined && a != null) { return parseFloat(a); } return a; }
                                : datatype == "Date"
                                    ? function (a) { if (a != undefined && a != null) { return new Date(a).getTime(); } return a; }
                                    : function (a) { if (a == undefined || a == null) { a = ""; } return a.toString().toUpperCase() }; /* Default is String */
                            data.sort(sort_by(col.order == 'desc', handler, col.display));
                        });
                        $grid.dataBind(data);
                    }
                }
            },
            /// <summary>
            /// Hide columns that are grouped.
            /// </summary>
            /// <example>
            /// $('#MyGrid').data('tGrid').hideGroupColumns();
            /// </example>
            hideGroupColumns: function () {
                var grid = this;
                grid.columnstyles = [];
                $(grid.element).find('div.t-grid-header table col').each(function (idx, col) {
                    grid.columnstyles.push($(col).attr('style'));
                });

                $.telerik.bind(this, {
                    dataBound: function (e) {
                        var grid = $(e.target).data('tGrid');
                        var cnt = grid.groups.length;
                        var hCols = $(grid.element).find('div.t-grid-header table col');
                        var cCols = $(grid.element).find('div.t-grid-content table col');
                        var gridUsesDivs = $(grid.element).find('div.t-grid-header').length == 1;

                        grid.showAllColumnHeaders();

                        if (gridUsesDivs) {
                            $.each(grid.columnstyles, function (idx, columnstyle) {
                                if (columnstyle == undefined) {
                                    $(hCols[idx + cnt]).removeAttr('style');
                                    $(cCols[idx + cnt]).removeAttr('style');
                                } else {
                                    $(hCols[idx + cnt]).attr('style', columnstyle);
                                    $(cCols[idx + cnt]).attr('style', columnstyle);
                                }
                            });
                        }

                        if (cnt > 0) {
                            var width = 0;
                            $.each(grid.groups, function (gdx, group) {
                                var columnTitle = group.title;
                                $.each(grid.columns, function (idx, col) {
                                    if (col.title == columnTitle) {
                                        width += $(hCols[idx + cnt]).width();
                                        grid.hideColumn(idx + cnt);
                                        if (gridUsesDivs) {
                                            for (var cdx = idx; cdx < grid.columns.length; cdx++) {
                                                $(hCols[cdx + cnt]).attr('style', $(hCols[cdx + cnt + 1]).attr('style'));
                                                $(cCols[cdx + cnt]).attr('style', $(cCols[cdx + cnt + 1]).attr('style'));
                                            }
                                        }
                                    }
                                });
                            });
                            if (gridUsesDivs) {
                                width += $(hCols[cnt]).width();
                                for (var cdx = 1; cdx <= cnt; cdx++) {
                                    $(hCols[hCols.length - cdx]).css('width', '0px');
                                    $(cCols[cCols.length - cdx]).css('width', '0px');
                                }
                                $(hCols[cnt]).width(width);
                                $(cCols[cnt]).width(width);
                            }
                        }
                    }
                });
            },
            /// <summary>
            /// Show a cell as a textbox in the grid.  Only availabe for grids that are
            /// populated using AJAX data binding or client-side data binding.
            /// </summary>
            /// <example>
            /// $('#MyGrid').data('tGrid').showCellAsTextBox({ row: 1, column: 2 });
            ///
            /// $('#MyGrid').data('tGrid').showCellAsTextBox({ 
            ///     row: 1, 
            ///     column: 2, 
            ///     textBoxId: 'textBox_1_2', 
            ///     onChange: function(param) {
            ///         if (rowData.NotNegative == true) {
            ///             if (rowData.value < 0) {
            ///                 textBox.css('color', 'red');
            ///             }
            ///             else {
            ///                 textBox.css('color', 'black');
            ///             }
            ///         }
            ///     }, 
            ///     formatDisplay: function(textBox, rowData) {
            ///         if (rowData.NotNegative == true) {
            ///             if (rowData.value < 0) {
            ///                 textBox.css('color', 'red');
            ///             }
            ///         }
            ///     },
            ///     formatPersist: function(textBox, rowData) {
            ///         return parseInt(textBox.val());
            ///     }
            /// });
            /// </example>
            showCellAsTextBox: function (o) {
                if (this._editableCells == undefined) {
                    this._editableCells = [];
                }

                if (o.textBoxId == undefined) {
                    o.textBoxId = $(this.element).attr('id') + '_' + o.row + '_' + o.column;
                }

                var $input = $('<input type="text" />')
                    .attr('id', o.textBoxId)
                    .css('text-align', 'right')
                    .css('width', '100px')
                    .attr('onblur', '$("#' + $(this.element).attr('id') + '").data("tGrid").textBox_OnCellBlur($("#' + o.textBoxId + '"));');
                var table = $(this.element).find('table');
                var rows = $(table).find('tbody tr');
                rows[o.row].cells[o.column].innerHTML = $('<div>').append($input.clone()).html();

                var textBox = $('#' + o.textBoxId);

                if (o.formatDisplay != undefined) {
                    o.formatDisplay(textBox, this.data[o.row]);
                }
                else {
                    textBox.val(this.data[o.row][this.columns[o.column].member]);
                }

                this._editableCells.push(o);

                return textBox;
            },
            textBox_OnCellBlur: function (textBox) {
                var column = textBox.parent('td');
                var row = $(column).parent('tr');

                var grid = this;

                $.each(this._editableCells, function (idx, editableCell) {
                    if (editableCell.row == row[0].sectionRowIndex && editableCell.column == column[0].cellIndex) {
                        var newValue = textBox.val();
                        var rowData = grid.data[row[0].sectionRowIndex];
                        if (editableCell.formatPersist != undefined) {
                            newValue = editableCell.formatPersist(textBox, rowData);
                        }
                        var oldValue = rowData[grid.columns[column[0].cellIndex].member];
                        if (oldValue != newValue) {
                            var params = { textBox: textBox, row: row[0].sectionRowIndex, column: column[0].cellIndex, rowData: rowData, oldValue: oldValue, newValue: newValue, cancel: false };
                            if (editableCell.onChange != undefined) {
                                editableCell.onChange(params);
                            }
                            if (params.cancel) {
                                textBox.val(oldValue);
                            } else {
                                rowData[grid.columns[column[0].cellIndex].member] = newValue;
                            }
                        }
                        return;
                    }
                });
            },
            /// <summary>
            /// Show a cell as a dropdown in the grid.  Only availabe for grids that are
            /// populated using AJAX data binding or client-side data binding.
            /// </summary>
            /// <return>jQuery object of the dropdown that was created.</return>
            /// <example>
            /// // Change the cell in the second row, second column into a dropdown.
            /// $('#PersonGrid').data('tGrid').showCellAsDropDown({
            ///         row: 1,
            ///         column: 1,
            ///         options: {
            ///             textField: 'Color',
            ///             valueField: 'Id',
            ///             data: [
            ///                 { Id: '1',Color: 'Brown' },
            ///                 { Id: '2',Color: 'Black' },
            ///                 { Id: '3',Color: 'Red' },
            ///                 { Id: '4',Color: 'Blond' }
            ///             ]
            ///         },
            ///         textField: 'HairColor',
            ///         valueField: 'HairColorId',
            ///         onChange: function (o) {
            ///             if(typeof console!="undefined") { console.log(o); }
            ///             o.cancel=(o.newText=='Blond');
            ///         }
            ///     }
            /// );
            /// </example>
            showCellAsDropDown: function (o) {
                o = $.extend({
                    width: '100px'
                }, o);

                var grid = this;

                // Get the row.
                var tr = $(grid.element).find('table tbody tr')[o.row];

                // Define the Id for the DropDown.
                if (o.DropDownId == undefined) {
                    o.DropDownId = $(grid.element).attr('id') + '_' + o.row + '_' + o.column;
                }

                // Create a dropdown.
                var $dropdown = $('<select />').attr('id', o.DropDownId).css('width', o.width);

                // Add the dropdown options.
                $.each(o.options.data, function (idx, item) {
                    $dropdown.append($('<option />').val(item[o.options.valueField]).text(item[o.options.textField]));
                });

                // Get the current text.
                var text = $(tr.cells[o.column]).text();

                // Set the dropdown in the grid cell.
                tr.cells[o.column].innerHTML = $('<div>').append($dropdown.clone()).html();

                // Get a reference to the dropdwn in the grid cell.
                $dropdown = $('#' + o.DropDownId);

                // Set the selected item using the text displayed in the cell.
                $dropdown.find('option').each(function () { this.selected = (this.text == text || this.value == text) });

                // When an option is selected in the dropdown...
                $dropdown.change(function () {
                    var oldText = o.textField != undefined ? grid.data[o.row][o.textField] : '';
                    var oldValue = grid.data[o.row][o.valueField];
                    var newText = $($dropdown.find('option:selected')).text();
                    var newValue = $($dropdown.find('option:selected')).val();
                    var params = { grid: grid, row: o.row, column: o.column, oldText: oldText, oldValue: oldValue, newText: newText, newValue: newValue, dropdown: $dropdown, cancel: false };
                    // If an onChange function was passed in...
                    if (o.onChange != undefined) { o.onChange(params) }
                    // If the change was canceled...
                    if (params.cancel == true) {
                        // Rollback to the previous selected option.
                        $dropdown.find('option').each(function () { this.selected = (this.text == oldText) });
                    }
                    else {
                        // Store the selected option in the grid data.
                        if (o.textField != undefined) { grid.data[o.row][o.textField] = $($dropdown.find('option:selected')).text(); }
                        if (o.valueField != undefined) { grid.data[o.row][o.valueField] = $($dropdown.find('option:selected')).val(); }
                    }
                });

                return $dropdown;
            },
            /// <summary>
            /// Search a cell in a grid column with text equal to the text passed in.
            /// </summary>
            /// <param type="json object" name="o">
            ///  json object with 2 attributes:
            ///    column: zero based index of the column to search.
            ///    text: text to search for in each cell in the column.
            /// </param>
            /// <return>Zero based index of the row where the cell was found containing the text, or -1 if not found.</return>
            /// <example>
            /// var rowIndex = $('#MyGrid').data('tGrid').columnCellTextEquals({ column: 1,text: 'Black' });
            /// </example>
            columnCellTextEquals: function (o) {
                var row = -1;
                $(this.element).find('tbody tr').each(function (idx, tr) {
                    if ($($(tr).find('td')[o.column]).text() == o.text) {
                        row = idx;
                        return;
                    }
                });
                return row;
            },
            /// <summary>
            /// Enable or disable row selection.
            /// </summary>
            /// <param type="bool" name="enable">true to enable row selection.  false to disable row selection.</param>
            /// <example>
            /// var $('#MyGrid').data('tGrid').enableSelect(true);
            /// var $('#MyGrid').data('tGrid').enableSelect(false);
            /// </example>
            enableSelect: function (enable) {
                var p = this;
                if (p.selectable != enable) {
                    var s = "tr:not(.t-grouping-row,.t-detail-row,.t-no-data,:has(>.t-edit-container))";
                    var n = this.$tbody[0];
                    p.selectable = enable;
                    $(p.element).find('tr.t-state-selected').removeClass('t-state-selected');
                    this.$tbody.undelegate(s, "click")
                    this.$tbody.undelegate(s, "hover");
                    if (p.selectable) {
                        this.$tbody.delegate(s, "click", function (t) {
                            if (this.parentNode == n) {
                                p.rowClick(t)
                            }
                        });
                        this.$tbody.delegate(s, "hover", function (t) {
                            if (this.parentNode == n) {
                                if (t.type == "mouseenter") {
                                    jQuery(this).addClass("t-state-hover")
                                }
                                else {
                                    jQuery(this).removeClass("t-state-hover")
                                }
                            }
                        });
                    }
                }
            },
            /// <summary>
            /// Bind a value to a specific field in the grid without having to call dataBind to display
            /// the changes.  Note: Does not work with "scrollable" grids yet.
            /// </summary>
            /// <param type="json" name="o">JSON object with the following parameters:
            ///		- row: zero based index of the row to update.
            /// 	- member: name of the model property bound to a column.
            ///		- value: the new value for the field.
            ///		- displayValue [optional]: true to immediately display the new value in the grid.
            /// </param>
            /// <example>
            /// var $('#MyGrid').data('tGrid').dataBindField({ row: 1, member:'FirstName', value:'John', displayValue:true });
            /// </example>
            dataBindField: function (o) {
                var grid = this;
                if (o.member == undefined) {
                    o.member = grid.columns[o.col].member;
                } else if (o.col == undefined) {
                    $.each(grid.columns, function (cdx, column) {
                        if (column.member === o.member) {
                            o.col = cdx;
                            return false;
                        }
                    });
                }
                grid.data[o.row][o.member] = o.value;
                if (o.displayValue != undefined && o.displayValue == true) {
                    $($(grid.element).find('tbody tr')[o.row].cells[o.col]).text(o.value);
                }
            }
        };

        // Add the extensions to the grid plugin.
        $.extend(true, $.telerik.grid.prototype, gridExtensions);
    }

    // Was the tekerik.treeview.min.js added to the page by the telerik script registrar?
    if ($.telerik.treeview != undefined) {
        // Extend the treeview plugin.
        var treeviewExtensions = {
            /// <summary>
            /// Add a context menu to the treeview.
            /// </summary>
            /// <param type="json object" name="o">
            /// json object with a function to determine whether the context menu should be displayed 
            /// for a node and a list of menu items for the context menu.
            /// </param>
            /// <example>
            ///     $('#MyTreeView').data('tTreeView').addContextMenu({
            /// 	    evaluateNode: function(treeview, node) {
            /// 		    var nodeValue = treeview.getItemValue(node);
            /// 		    return (nodeValue == 'editable');
            /// 	    },
            ///         contextMenuOpening: function (menu, node) {
            ///             // Find the 'Edit' context menu option and disable it.
            ///             $.each(menu.menuItems, function (idx, item) {            
            ///                 if (item.text == 'Edit') {
            ///                     item.disabled = true;
            ///                     return false;
            ///                 }
            ///             });
            /// 	    },
            /// 	    menuItems: [{
            /// 		        text: 'Edit',
            /// 		        onclick: function(e) {
            ///                     alert('You Clicked ' + e.item.text() + ' for ' + e.treeview.getItemText(e.node) + ' with a value of ' + e.treeview.getItemValue(e.node));
            ///                 }
            /// 	        }, {
            ///                 separator: true
            ///             }, {
            /// 		        text: 'Delete',
            /// 		        onclick: function(e) {
            ///                     alert('You Clicked ' + e.item.text() + ' for ' + e.treeview.getItemText(e.node) + ' with a value of ' + e.treeview.getItemValue(e.node));
            ///                 },
            ///                 disabled: true
            /// 	        }]
            ///     });
            /// </example>
            addContextMenu: function (o) {
                if (this._contextMenus == undefined) {
                    this._contextMenus = [];

                    // subscribe to the contextmenu event to show a contet menu
                    $('.t-in', this.element).live('contextmenu', function (e) {
                        var treeview = $(e.liveFired).data('tTreeView');

                        var span = $(this);

                        // prevent the browser context menu from opening
                        e.preventDefault();

                        // Remove any contect menus that are still being displayed.
                        var fx = $.telerik.fx.slide.defaults();
                        $('div#contextMenu').each(function (index) {
                            $.telerik.fx.rewind(fx, $(this).find('.t-group'), { direction: 'bottom' }, function () {
                                $(this).remove();
                            });
                        });

                        // the node for which the 'contextmenu' event has fired
                        var $node = span.closest('.t-item');

                        // default "slide" effect settings
                        /*var*/fx = $.telerik.fx.slide.defaults();

                        // Identify which context menu to use.
                        $.each(treeview._contextMenus, function (mdx, menu) {
                            // Does this context menu apply to this node?
                            if (menu.evaluateNode(treeview, $node) == true) {
                                if (menu.contextMenuOpening != undefined) {
                                    menu.contextMenuOpening(menu, $node);
                                }
                                var menuItems = '';
                                $.each(menu.menuItems, function (idx, item) {
                                    if (item.separator != undefined && item.separator == true) {
                                        menuItems += '<li class="t-item"><hr/></li>';
                                    } else {
                                        menuItems += '<li class="t-item' + (item.disabled != undefined ? ' t-state-disabled' : '') + '"><a href="#" class="t-link">' + item.text + '</a></li>';
                                    }
                                });
                                if (menuItems.length > 0) {
                                    // context menu definition - markup and event handling
                                    var $contextMenu =
                                        $('<div class="t-animation-container" id="contextMenu">' +
                                            '<ul class="t-widget t-group t-menu t-menu-vertical" style="display:none">' +
                                                menuItems +
                                            '</ul>' +
                                        '</div>')
                                        .css( //positioning of the menu
                                        {
                                        position: 'absolute',
                                        left: e.pageX, // x coordinate of the mouse
                                        top: e.pageY   // y coordinate of the mouse
                                    })
                                        .appendTo(document.body)
                                        .find('.t-item') // select the menu items
                                        .mouseenter(function () {
                                            if ($(this).hasClass('t-state-disabled') == false) {
                                                // hover effect
                                                span.addClass('t-state-hover');
                                            }
                                        })
                                        .mouseleave(function () {
                                            // remove the hover effect
                                            span.removeClass('t-state-hover');
                                        })
                                        .click(function (e) {
                                            e.preventDefault();
                                            var li = $(this);
                                            if (li.hasClass('t-state-disabled') == false) {
                                                // dispatch the click
                                                $.each(menu.menuItems, function (idx, item) {
                                                    if (item.text == li.text()) {
                                                        item.onclick({ item: li, treeview: treeview, node: $node });
                                                        return;
                                                    }
                                                });
                                            }
                                        })
                                        .end();

                                    // show the menu with animation
                                    $.telerik.fx.play(fx, $contextMenu.find('.t-group'), { direction: 'bottom' });

                                    // handle globally the click event in order to hide the context menu
                                    $(document).click(function (e) {
                                        // hide the context menu and remove it from DOM
                                        $.telerik.fx.rewind(fx, $contextMenu.find('.t-group'), { direction: 'bottom' }, function () {
                                            $contextMenu.remove();
                                        });
                                    });
                                }
                                return;
                            }
                        });
                    });
                }
                this._contextMenus.push(o);
            },
            findNodeByText: function (text) {
                var element = $(this.element).find('.t-in:contains("' + text + '")');
                if (element.length > 0) {
                    return this.createNode(this, element);
                } else {
                    return [];
                }
            },
            findNodeByValue: function (value) {
                var element = $(this.element).find('input.t-input[name="itemValue"][value="' + value + '"]').prev();
                if (element.length > 0) {
                    return this.createNode(this, element);
                } else {
                    return [];
                }
            },
            findNodeContainsValue: function (value) {
                var element = $(this.element).find('input.t-input[name="itemValue"][value*="' + value + '"]').prev();
                if (element.length > 0) {
                    return this.createNode(this, element);
                } else {
                    return null;
                }
            },
            createNode: function (treeview, element) {
                var node = {
                    treeview: treeview,
                    element: element,
                    select: function () {
                        element.click();
                        return this;
                    },
                    deselect: function () {
                        element.removeClass('t-state-selected');
                        return this;
                    },
                    selected: function () {
                        return this.element.hasClass('t-state-selected');
                    },
                    highlight: function () {
                        element.addClass('t-state-selected');
                        return this;
                    },
                    unhighlight: function () {
                        element.removeClass('t-state-selected');
                        return this;
                    },
                    expand: function () {
                        treeview.expand(element.closest('li'));
                        return this;
                    },
                    collapse: function () {
                        treeview.collapse(element.closest('li'));
                        return this;
                    },
                    enable: function () {
                        treeview.enable(element.closest('li'));
                        return this;
                    },
                    disable: function () {
                        treeview.disable(element.closest('li'));
                        return this;
                    },
                    check: function () {
                        treeview.nodeCheck(element.closest('li'), true);
                        return this;
                    },
                    uncheck: function () {
                        treeview.nodeCheck(element.closest('li'), false);
                        return this;
                    },
                    text: function () {
                        return element.text();
                    },
                    value: function () {
                        return element.next('input.t-input').val();
                    },
                    setText: function (text) {
                        element.text(text);
                        return this;
                    },
                    parent: function () {
                        var parentElement = element.closest('ul.t-group').prev('div').find('.t-in');
                        if (parentElement.length > 0) {
                            return treeview.createNode(treeview, parentElement);
                        } else {
                            return [];
                        }
                    },
                    children: function () {
                        var childNodes = [];
                        var childrenElements = node.parent().element.closest('div').next().children().children('div').find('.t-in');
                        $.each(childrenElements, function (idx, childElement) {
                            childNodes.push(treeview.createNode(treeview, $(childElement)));
                        });
                        return childNodes;
                    },
                    /// <summary>
                    /// Add a node to the tree.
                    /// </summary>
                    /// <param type='json object' name='attributes'>JSON object with the following parameters:
                    ///     - text: text for the node.
                    ///     - value: value for the node.
                    ///     - spriteCssClass [Optional]: css class for the node image.
                    ///     - image [Optional]: json object that contains the image attributes:
                    ///         - src: url for the image.
                    ///         - alt: alternate text for the image.
                    /// </param>
                    /// <example>
                    /// var node = $('#MyTreeView').data('tTreeView').findNodeByText('Free Tools');
                    /// var newNode = node.addNode({
                    ///     text:'New Node Text 1',
                    ///     value:101,
                    ///     spriteCssClass:'my-sprite-class'
                    /// });
                    /// </example>
                    /// <example>
                    /// var node = $('#MyTreeView').data('tTreeView').findNodeByText('Free Tools');
                    /// var newNode = node.addNode({
                    ///     text:'New Node Text 2',
                    ///     value:102,
                    ///     image: {
                    ///         src: 'http://demos.telerik.com/aspnet-mvc/Content/PanelBar/FirstLook/notesItems.gif',
                    ///         alt:'test'
                    ///     }
                    /// });
                    /// <example>
                    /// var node = $('#MyTreeView').data('tTreeView').findNodeByText('Free Tools');
                    /// var newNode = node.addNode({
                    ///     text:'New Node Text 2',
                    ///     value:102,
                    //      url: 'http://demos.telerik.com/aspnet-mvc/Content/PanelBar/FirstLook'
                    ///     image: {
                    ///         src: 'http://demos.telerik.com/aspnet-mvc/Content/PanelBar/FirstLook/notesItems.gif',
                    ///         alt:'test'
                    ///     }
                    /// });
                    /// </example>
                    addNode: function (attributes) {
                        var div = element.closest('div');
                        var ul = div.next('ul.t-group');

                        // If there are no child nodes for this parent node, then create the unordered list that will contain the child nodes.
                        if (ul.length == 0) {
                            ul = $('<ul/>').attr('class', 't-group');
                            div.closest('li.t-item').append(ul);
                            div.prepend($('<span/>').attr('class', 't-icon t-minus'));
                            // Alter the last child node to no longer be the last child node.
                        } else {
                            var lastChild = ul.children('li.t-last');
                            lastChild.removeClass('t-last').children('div.t-bot').removeClass('t-bot').addClass('t-mid');
                        }

                        // Create the child
                        var newChild = $('<li/>')
                            .attr('class', 't-item t-last')
                            .append($('<div/>')
                                .attr('class', 't-bot')
                                .append(attributes.url != undefined
                                    ? $('<a/>')
                                        .attr('class', 't-link t-in')
                                        .attr('href', attributes.url)
                                        .text(attributes.text)
                                    : $('<span/>')
                                        .attr('class', 't-in')
                                        .text(attributes.text)
                                )
                                .append($('<input/>')
                                    .attr('type', 'hidden')
                                    .attr('value', attributes.value)
                                    .attr('name', 'itemValue')
                                    .attr('class', 't-input')
                                )
                            );

                        // Was a sprite css class attribute passed in?
                        if (attributes.spriteCssClass != undefined) {
                            newChild.find('span.t-in').prepend($('<span/>').addClass('t-sprite').addClass(attributes.spriteCssClass));
                            // Was a image attribute passed in?
                        } else if (attributes.image != undefined) {
                            var img = $('<img/>').addClass('t-image').attr('src', attributes.image.src);
                            if (attributes.image.alt != undefined) {
                                img.attr('alt', attributes.image.alt);
                            }
                            newChild.find('span.t-in').prepend(img);
                        }
                        // Add the child node.
                        ul.append(newChild);

                        return treeview.createNode(treeview, newChild.find('span.t-in'));
                    },
                    remove: function () {
                        var parent = this.parent();
                        element.closest('li.t-item').remove();

                        var children = parent.element.closest('div').next().children('li');

                        if (children.length > 0) {
                            var lastChild = $(children[children.length - 1]);
                            lastChild.addClass('t-last');
                            lastChild.children('div').attr('class', 't-bot');
                        } else {
                            parent.element.closest('div').next().remove();
                            parent.element.closest('div').children('span.t-icon').remove();
                        }
                        return parent;
                    }
                }
                return node;
            }
        };

        // Add the extensions to the treeview plugin.
        $.extend(true, $.telerik.treeview.prototype, treeviewExtensions);
    }



    // Was the tekerik.window.min.js added to the page by the telerik script registrar?
    if ($.telerik.window != undefined) {
        // Extend the window plugin.
        var windowExtensions = {
            /// <summary>
            /// Set a new height for the window.
            /// </summary>
            /// <param type="int" name="h">New height for the window.</param>
            setHeight: function (h) {
                $(this.element).find('.t-window-content').height(h);
                return this;
            },
            /// <summary>
            /// Set a new width for the window.
            /// </summary>
            /// <param type="int" name="w">New width for the window.</param>
            setWidth: function (w) {
                $(this.element).find('.t-window-content').width(w);
                return this;
            },
            /// <summary>
            /// Set a new title for the window.
            /// </summary>
            /// <param type="string" name="t">New title for the window.</param>
            setTitle: function (t) {
                $(this.element).find('span.t-window-title').text(t);
                return this;
            }
        };

        // Add the extensions to the window plugin.
        $.extend(true, $.telerik.window.prototype, windowExtensions);
    }

    $.telerikExtensionsIncluded = true;
})(jQuery);