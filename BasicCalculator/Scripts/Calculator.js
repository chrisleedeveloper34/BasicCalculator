function addNumber(number) {
    var received = document.getElementById("received").value;
    if (received === "True") {
        document.getElementById("query").value = '';
        document.getElementById("received").value = "False";
    }
    document.getElementById("query").value += number;
}

function addOperator(oper) {
    var currentContents = document.getElementById("query").value;
    if (currentContents) {
        // check for existing operators
        var opers = currentContents.search(/\+|\-|\*|\//) > 0;
        if (!opers) {
            document.getElementById("query").value += " " + oper + " ";
            document.getElementById("received").value = "False";
        }
    } else {
        alert("Select a number first");
    }
}
