//This is a Javascript for bootstrap Created by Jomiel Enriquez

class bsTable {
    constructor(tablename,header,rows,cpage,page, uniqueidentifier) {
        this.tablename = tablename;
        this.header = header;
        this.rows = rows;
        this.cpage = cpage;
        this.page = page;
        this.uniqueidentifier = uniqueidentifier
    }
    loadbsTable() {
        // load search bar for the table
        $(".bstable-container").append('<div class="form-group">'+
            '<input class="form-control" id="focusedInput" type="text" placeholder="Search..">'+
            '</div>');

        // create the table with the body
        $(".bstable-container").append(`<div style="overflow:auto">
                <table class="table table-striped table-hover table-responsive table-jsprop" id="`+ this.tablename +`">
                    <thead>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>`)

        // Generate table header
        var head = "<tr class='tblheader'>";
        var row = "";
        const removeordering = [];
        for (var i = 0; i < this.header.length; i++) {
            var ordering = "";
            if (this.header[i]["Sort"] != 0 || this.header[i]["Sort"] == 1) {
                ordering = "class='orderable'";
            }
            head += "<th id='" + this.header[i]["colid"] + "' " + ordering + ">" + this.header[i]["Text"];
            head += "</th>";

            row += "<td id='" + this.header[i]["colid"] + "'></td>";
        }
        head += "</tr>";
        $('#' + this.tablename + ' thead').append(head); // insert generated table header to the newly created table

        // insert all rows in the table
        for (i = 0; i < this.rows.length; i++) {
            $('#' + this.tablename + ' tbody').append("<tr id='" + this.rows[i][this.uniqueidentifier] + "'>"
                + row + "</tr>"
            );

            for (var j = 0; j < this.header.length; j++) {
                $('#' + this.tablename + ' tbody tr[id=' + this.rows[i][this.uniqueidentifier] + '] td[id=' + this.header[j]["colid"] + ']').append(this.rows[i][this.header[j]["colid"]]);
            }
        }

        // insert pagination
        // generate left arrow in the pagination
        var leftdisabled = this.cpage == 1 ? "disabled" : "";
        $(".bstable-container").append(`<ul class="pagination pagination-sm">
                <li class="`+ leftdisabled +`"><a href="#">&laquo;</a></li>
            </ul>`)

        // generate the pages in the pagination
        for (var i = 1; i <= this.page; i++) {
            var pageclass = this.cpage == i ? "active" : "";
            $(".bstable-container ul.pagination").append(`<li class="` + pageclass + `"><a href="#">` + i + `</a></li>`);
        }

        // generate the right arrow in the pagination
        var rightdisabled = this.cpage == this.page ? "disabled" : "";
        $(".bstable-container ul.pagination").append(`<li class="` + rightdisabled + `"><a href="#">&raquo;</a></li>`);

        $('table.table-jsprop tr.tblheader th').click(function () {
            var tagclass = $(this).attr("class");
            $('table.table-jsprop tr.tblheader th[class="orderable"]').attr("class", "orderable");
            $('table.table-jsprop tr.tblheader th[class="orderable_asc"]').attr("class", "orderable");
            $('table.table-jsprop tr.tblheader th[class="orderable_desc"]').attr("class", "orderable");
            if (tagclass == "orderable") {
                $(this).attr("class", "orderable_asc");
                return;
            }
            if (tagclass == "orderable_asc") {
                $(this).attr("class", "orderable_desc");
                return;
            }
        })
    }
}