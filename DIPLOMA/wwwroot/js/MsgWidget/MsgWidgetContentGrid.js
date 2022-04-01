function RepaintRows(rows) {
    for (let i = 0; i < rows.length; ++i) {

        let currRow = rows[i];
        let rowOuterHtml = currRow.outerHTML;
        let currRowNbr = currRow.id.replace("contenttr-", "")
        console.log(currRowNbr);

        let newLineNbr = i;

        rowOuterHtml = rowOuterHtml.replaceAll('_' + currRowNbr + '_', '_' + newLineNbr + '_');
        rowOuterHtml = rowOuterHtml.replaceAll('[' + currRowNbr + ']', '[' + newLineNbr + ']');
        rowOuterHtml = rowOuterHtml.replaceAll('-' + currRowNbr, '-' + newLineNbr);
        currRow.id = "contenttr-" + newLineNbr;

        currRow.innerHTML = rowOuterHtml;

        document.getElementById('hdnLastIndex').value = newLineNbr;
    }
}
function RepaintRowString(rowstr, currRowNbr, newLineNbr) {
    if (rowstr) {
        rowstr = rowstr.replaceAll('_' + currRowNbr + '_', '_' + newLineNbr + '_');
        rowstr = rowstr.replaceAll('[' + currRowNbr + ']', '[' + newLineNbr + ']');
        rowstr = rowstr.replaceAll('-' + currRowNbr, '-' + newLineNbr);

    }
    return rowstr;
}
function RepaintRowsWidgets(rows) {
    if (rows.length == 0) {

        let addbtnbase = document.getElementById('btnadd-base');
        addbtnbase.classList.add("visible");
        addbtnbase.classList.remove("invisible");
    }
    else {
        let addbtnbase = document.getElementById('btnadd-base');
        addbtnbase.classList.add("invisible");
        addbtnbase.classList.remove("visible");
    }
    for (let i = 0; i < rows.length; ++i) {

        let currRow = rows[i];
        let rowOuterHtml = currRow.outerHTML;
        let currRowNbr = currRow.id.replace("contenttr-", "")

        let newLineNbr = i;

        let allSubNodes = Array.from(currRow.getElementsByTagName("*"));

        for (let i = 0; i < allSubNodes.length; ++i) {

            let e = allSubNodes[i];

            e.id = RepaintRowString(e.id, currRowNbr, newLineNbr);
            e.name = RepaintRowString(e.name, currRowNbr, newLineNbr);


            let attr = e.getAttribute('for');
            if (attr) {
                console.log(attr);
                e.setAttribute("for", RepaintRowString(attr, currRowNbr, newLineNbr))
            }
            attr = e.getAttribute('data-valmsg-for');
            if (attr) {
                e.setAttribute('data-valmsg-for', RepaintRowString(attr, currRowNbr, newLineNbr))
            }


        }
        //rowOuterHtml = rowOuterHtml.replaceAll('_' + currRowNbr + '_', '_' + newLineNbr + '_');
        //rowOuterHtml = rowOuterHtml.replaceAll('[' + currRowNbr + ']', '[' + newLineNbr + ']');
        //rowOuterHtml = rowOuterHtml.replaceAll('-' + currRowNbr, '-' + newLineNbr);

        currRow.id = "contenttr-" + newLineNbr;
        if (i == rows.length - 1 ) {

            let btnAddID = 'btnadd-' + i.toString()
            let btnDeleteid = 'btnremove-' + i.toString();

            let delbtn = document.getElementById(btnDeleteid);
            delbtn.classList.add("invisible");
            delbtn.classList.remove("visible");

            let addbtn = document.getElementById(btnAddID);
            addbtn.classList.add("visible");
            addbtn.classList.remove("invisible");
        }

       
        //currRow.innerHTML = rowOuterHtml;

        console.log(currRow);
        document.getElementById('hdnLastIndex').value = newLineNbr;



    }
}
function DeleteItem(btn) {
    $(btn).closest('tr').remove();

    let table = document.getElementById('ContentTable');
    let tbody = table.getElementsByTagName('tbody')[0];
    let rows = tbody.getElementsByTagName('tr');

    RepaintRowsWidgets(rows);

}
function AddItem(btn) {

    let table = document.getElementById('ContentTable');
    let rows = table.getElementsByTagName('tr');

    let rowOuterHtml = rows[rows.length - 1].outerHTML;

    let lastrowIdx = document.getElementById('hdnLastIndex').value;
    let nextrowIdx = eval(lastrowIdx) + 1;

    document.getElementById('hdnLastIndex').value = nextrowIdx;

    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);
    rowOuterHtml = rowOuterHtml.replaceAll('(event, ' + lastrowIdx, '(event, ' + nextrowIdx);

    let newRow = table.insertRow();
    newRow.id = "contenttr-" + nextrowIdx;
    newRow.innerHTML = rowOuterHtml;

    document.getElementById("output-" + nextrowIdx.toString()).src = "";
    document.getElementById("audiosrc -" + nextrowIdx.toString()).src = "";
    
    let btnAddID = btn.id;
    let btnDeleteid = btnAddID.replaceAll('btnadd', 'btnremove');

    let delbtn = document.getElementById(btnDeleteid);
    delbtn.classList.add("visible");
    delbtn.classList.remove("invisible");


    var addbtn = document.getElementById(btnAddID);
    addbtn.classList.remove("visible");
    addbtn.classList.add("invisible");

}
function AddItemBase(btn) {
    let table = document.getElementById('ContentTable');
    let rows = table.getElementsByTagName('tr');
}
function ValidateSize(e) {
    var count = 1;
    var files = e.currentTarget.files; // puts all files into an array

    // call them as such; files[0].size will get you the file size of the 0th file
    for (var x in files) {

        var filesize = ((files[x].size / 1024) / 1024).toFixed(4); // MB

        if (files[x].name != "item" && typeof files[x].name != "undefined" && filesize <= 10) {

            if (count > 1) {

                approvedHTML += ", " + files[x].name;
            }
            else {

                approvedHTML += files[x].name;
            }

            count++;
        }
    }
}