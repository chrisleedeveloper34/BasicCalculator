function addNumber(number) {
    var received = document.getElementById("received").value;
    if (received === "True") {
        document.getElementById("query").value = '';
        document.getElementById("received").value = "False";
    }
    document.getElementById("query").value += number;
    document.getElementById("query").focus();
}

function addOperator(oper) {
    var currentContents = document.getElementById("query").value;
    if (currentContents) {
        // check for existing operators, should replace really
        var opers = currentContents.search(/\+|\-|\*|\//) > 0;
        if (!opers) {
            document.getElementById("query").value += oper;
            document.getElementById("received").value = "False";
        }
    } else {
        alert("Select a number first");
    }
    document.getElementById("query").focus();
}


$(function () {
    $('#query').focus();
    $('#query').keypress(function (event) {
        var code = event.keyCode || event.which;
        if (code == 43) { //Enter keycode
            // + sign
            event.preventDefault();
            addOperator('+');
        } else if (code == 45) {
            event.preventDefault();
            addOperator('-');
        } else if (code == 42) {
            event.preventDefault();
            addOperator('*');
        } else if (code == 47) {
            event.preventDefault();
            addOperator('/');
        }
    });
    $('#query').keyup(function () {
        var $t = $(this);
        $t.val($t.val().replace(/[^0-9.\+\-*\/]/g, function (str) { return ''; }));
    });
    $('#clear').click(function () {
        $('#query').val('');
        $('#query').focus();
    });
});