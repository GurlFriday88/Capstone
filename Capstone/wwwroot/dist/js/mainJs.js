
//alternates row colors of table 
function alternate() {

    var row = document.getElementsByClassName("row_items");

    for (i = 0; i < row_items.length; i++) {



        if (i % 2 == 0) {

            row[i].className = "even";
        }else {
            row[i].className = "odd";
        }
    }

}