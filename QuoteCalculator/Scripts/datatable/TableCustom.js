class TableCustom {
    constructor(tablename,formatting, filelist) {
        this.tablename = tablename;
        this.formatting = formatting;
        this.filelist = filelist;
    }
    load() {
        //Create table in table_container
        $(".table_container").append("<table id='" + this.tablename + "' class='table table - hover'><thead></thead><tbody></tbody></table>")

        //generate the table header
        var head = "<tr class='tblcheader'>";
        var row = "";
        const removeordering = [];
        for (var i = 0; i < this.formatting.length; i++) {
            var ordering = "";
            if (this.formatting[i]["Sort"] == 0) {
                ordering = "data-ordering='false'";
                removeordering.push(this.formatting[i]["ordering"] - 1);
            }
            head += "<th id='" + this.formatting[i]["colid"] + "' " + ordering + ">" + this.formatting[i]["Text"];
            head += "</th>";

            row += "<td id='" + this.formatting[i]["colid"] + "'></td>";
        }
        head += "</tr>";
        $('#' + this.tablename + ' thead').append(head); // insert generated table header to the newly created table

        for (i = 0; i < this.filelist.length; i++) {
            $('#' + this.tablename + ' tbody').append("<tr id='" + this.filelist[i]["upldid"] + "'>"
                + row + "</tr>"
            );

            for (var j = 0; j < this.formatting.length; j++) {
                $('#' + this.tablename + ' tbody tr[id=' + this.filelist[i]["upldid"] + '] td[id=' + this.formatting[j]["colid"] + ']').append(this.filelist[i][this.formatting[j]["colid"]]);
            }
        }

        $('#' + this.tablename + '').DataTable({
            "aaSorting": [],
            aoColumnDefs: [
                {
                    bSortable: false,
                    aTargets: removeordering
                }
            ]
        });

        $("input[type='search']").addClass("form-control");
        $("input[type='search']").prop("placeholder", "Enter to search..");
        $("input[type='search']").css("float", "right");
        $("#" + this.tablename +"_filter label").css("width", "300px");
        $("#" + this.tablename +"_filter label").css("display", "flex");
        $("#" + this.tablename +"_filter label").css("align-items", "center");
    }
}

//Removeing table Command: $(".table_container").remove()