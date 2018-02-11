//

window.onload = function () {

    document.getElementById("getCoord").onclick = function (evt) {
        getCoord()
    }

    document.getElementById("getRowCol").onclick = function (evt) {
        getRowCol()
    }
}


function getCoord() {

    try {
        var strRowCol = document.getElementById("strRowCol").value;
        if (strRowCol != "") {
            var response = callRest("http://localhost:61693/Triangles/getcoordinates/" + strRowCol);

            document.getElementById("outCoord").innerHTML = JSON.stringify(response);
            document.getElementById("outCoord").style.display = 'block';
        }
    }
    catch (err) {
        document.getElementById("outCoord").innerHTML = err.message;
        document.getElementById("outCoord").style.display = 'block';
    }
}


function getRowCol() {

    try {
        var v1x = document.getElementById("v1x").value;
        var v1y = document.getElementById("v1y").value;
        var v2x = document.getElementById("v2x").value;
        var v2y = document.getElementById("v2y").value;
        var v3x = document.getElementById("v3x").value;
        var v3y = document.getElementById("v3y").value;

        if (strRowCol != "") {
            var response = callRest("http://localhost:61693/Triangles/getrowcol/"
                + v1x + "/"
                + v1y + "/"
                + v2x + "/"
                + v2y + "/"
                + v3x + "/"
                + v3y);

            document.getElementById("outRowCol").innerHTML = JSON.stringify(response);
            document.getElementById("outRowCol").style.display = 'block';
        }
    }
    catch (err) {
        document.getElementById("outRowCol").innerHTML = err.message;
        document.getElementById("outRowCol").style.display = 'block';
    }
}


function callRest(url) {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", url, false);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
    var response = JSON.parse(xhttp.responseText);
    return response;
}
