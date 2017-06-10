var newDetailsCount = 1;
var rowDetailsCount = 0;
var removeCount = 0;


function CreateEditBlanks(rowCount) {
    rowDetailsCount = rowCount;
    var detailsCount = rowDetailsCount + newDetailsCount - removeCount;

    var divEdit = document.getElementById("divEdit");
    var divNewEdit = document.createElement("div");

    var brEnd1 = document.createElement("br");
    var brEnd2 = document.createElement("br");

    var labelDishName = document.createElement("label");
    var inputDishName = document.createElement("input");
    var labelAmount = document.createElement("label");
    var inputAmount = document.createElement("input");

    var buttonDelete = document.createElement("input");

    divNewEdit.id = "divNewEdit" + detailsCount;

    labelDishName.innerHTML = "Dish name";
    labelDishName.id = "LabelDishName" + detailsCount;

    inputDishName.id = "Details_" + detailsCount + "__DishName";
    inputDishName.name = "Details[" + detailsCount + "].DishName";
    inputDishName.type = "text";
    inputDishName.className = "inputEdit";
    inputDishName.setAttribute("data-val", "true");
    inputDishName.setAttribute("data-val-required", "Missing dish name");

    labelAmount.innerHTML = "Quantity";
    labelAmount.id = "LabelAmount" + detailsCount;

    inputAmount.id = "Details_" + detailsCount + "__Amount";
    inputAmount.name = "Details[" + detailsCount + "].Amount";
    inputAmount.type = "text";
    inputAmount.className = "inputEdit";
    inputAmount.setAttribute("data-val", "true");
    inputAmount.setAttribute("data-val-required", "Missing Quantity");
    inputAmount.setAttribute("data_val_number", "The number requires a valid number");

    buttonDelete.value = "delete";
    buttonDelete.id = "buttonDelete" + detailsCount;
    buttonDelete.name = detailsCount.toString();
    buttonDelete.type = "button";
    buttonDelete.className = "inputSubmit";
    buttonDelete.onclick = function () { DeleteEditBlanks(buttonDelete.name, rowCount) };

    divNewEdit.appendChild(labelDishName);
    divNewEdit.appendChild(inputDishName);
    divNewEdit.appendChild(labelAmount);
    divNewEdit.appendChild(inputAmount);
    divNewEdit.appendChild(buttonDelete);
    divNewEdit.appendChild(brEnd1);
    divNewEdit.appendChild(brEnd2);

    divEdit.appendChild(divNewEdit);

    newDetailsCount++;

    $('#' + inputDishName.id).autocomplete({
        serviceUrl: '/autocomplete/dishes',
        deferRequestBy: 100,
        noCache: true,
        showNoSuggestionNotice: true,
        noSuggestionNotice: 'The query results are empty',
    });
}

function DeleteEditBlanks(detailsID, rowCount) {
    removeCount++;
    rowDetailsCount = rowCount;

    var divNewEdit = document.getElementById("divNewEdit" + detailsID);
    divNewEdit.parentNode.removeChild(divNewEdit);

    if (detailsID == rowDetailsCount + newDetailsCount - 1) {
        return;
    }

    for (var i = parseInt(detailsID) + 1; i <= rowDetailsCount + newDetailsCount; i++) {
        var divNextEdit = document.getElementById("divNewEdit" + i);
        divNextEdit.id = "divNewEdit" + (i - 1).toString();

        var inputDishName = document.getElementById("Details_" + i + "__DishName");
        var inputAmount = document.getElementById("Details_" + i + "__Amount");
        var buttonDelete = document.getElementById("buttonDelete" + i);

        inputDishName.id = "Details_" + (i - 1).toString() + "__DishName";
        inputDishName.name = "Details[" + (i - 1).toString() + "].DishName";


        inputAmount.id = "Details_" + (i - 1).toString() + "__Amount";
        inputAmount.name = "Details[" + (i - 1).toString() + "].Amount";

        buttonDelete.id = "buttonDelete" + (i - 1).toString();
        buttonDelete.name = i - 1;
    }
}


function GoToPage(controller, action, pageIndex) {
    var formQuery = document.getElementById("formQuery");
    var queryConditions = new Array();

    if (pageIndex == null) {
        pageIndex = document.getElementById("inputPageIndex").value;
    }

    for (var i = 0; i < formQuery.length; i++) {
        if (formQuery[i].type == "text" || formQuery[i].type == "select-one") {
            queryConditions[formQuery[i].name] = formQuery[i].value;
        }
    }

    var queryURL = "/" + controller + "/" + action + "?";
    for (var key in queryConditions) {
        queryURL += key + "=" + queryConditions[key] + "&";
    }

    queryURL += "pageindex" + "=" + pageIndex;

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("get", queryURL, false);
    xmlhttp.setRequestHeader("Content-Type", "text/html; charset=utf-8");
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            document.body.innerHTML = xmlhttp.response;
        }
    }

    xmlhttp.send();
}


function EncryptPassword() {
    if (!CheckForm())
        return false;

    if (!CheckRepeat())
        return false;

    var inputPassword = document.getElementById("Password");
    var inputUserName = document.getElementById("UserName");

    var password = inputPassword.value;
    var userName = inputUserName.value;

    inputPassword.value = hex_sha1(userName + password);

    var inputOldPassword = document.getElementById("OldPassword");
    if (inputOldPassword == null)
        return;

    var oldPassword = inputOldPassword.value;
    inputOldPassword.value = hex_sha1(userName + oldPassword);
}


function CheckRepeat() {
    var inputPassword = document.getElementById("Password");
    var inputRepeat = document.getElementById("Repeat");

    if (inputRepeat == null)
        return true;

    var password = inputPassword.value;
    var repeat = inputRepeat.value;

    var ulValidation = document.getElementById("ulValidation");
    if (password == repeat) {
        var passValidation = document.getElementById("liWrongRepeat");
        inputRepeat.style.borderColor = "gray";

        if (passValidation != null)
            passValidation.parentNode.removeChild(passValidation);

        return true;
    }

    inputRepeat.style.borderColor = "red";

    if (document.getElementById("liWrongRepeat"))
        return false;

    var liWrongRepeat = document.createElement("li");

    liWrongRepeat.id = "liWrongRepeat";
    liWrongRepeat.innerHTML = "Two passwords are inconsistent";
    ulValidation.appendChild(liWrongRepeat);

    return false;
}


function CheckForm() {
    var formPost = document.getElementById("formPost");
    var ulValidation = document.getElementById("ulValidation");
    var liValidation = new Array();
    var pass = true;
    var currentPass = true;

    if (formPost == null || ulValidation == null)
        return pass;

    for (var i = 0; i < formPost.length; i++) {
        currentPass = true;

        if (formPost[i].getAttribute("data-val") == null || formPost[i].getAttribute("data-val") == "false")
            continue;

        if (formPost[i].getAttribute("data-val-required") != null && (formPost[i].value == null || formPost[i].value == "")) {
            pass = false;
            currentPass = false;
            formPost[i].style.borderColor = "red";

            if (document.getElementById("validation" + formPost[i].name) == null) {
                liValidation[i] = document.createElement("li");

                liValidation[i].id = "validation" + formPost[i].name;
                liValidation[i].innerHTML = formPost[i].getAttribute("data-val-required");
                ulValidation.appendChild(liValidation[i]);
            }
        }

        if (formPost[i].getAttribute("data-val-number") != null && formPost[i].value != null && isNaN(formPost[i].value)) {
            pass = false;
            currentPass = false;
            $(formPost[i]).style.borderColor = "red";

            if (document.getElementById("validation" + formPost[i].name) == null) {
                liValidation[i] = document.createElement("li");

                liValidation[i].id = "validation" + formPost[i].name;
                liValidation[i].innerHTML = formPost[i].getAttribute("data-val-number");
                ulValidation.appendChild(liValidation[i]);
            }
        }

        if (currentPass == true) {
            var passValidation = document.getElementById("validation" + formPost[i].name);
            formPost[i].style.borderColor = "gray";

            if (passValidation != null)
                passValidation.parentNode.removeChild(passValidation);
        }
    }

    return pass;
}

function GetDishChart(type) {
    var dishNameBlanks = document.getElementsByName("DishName");

    var dishName = "";
    for (var i = 0; i < dishNameBlanks.length; i++) {
        dishName += (dishNameBlanks[i].value);

        if (i < dishNameBlanks.length - 1)
            dishName += ",";
    }

    var dateMin = document.getElementById("inputDateMin").value;

    var dateMax = document.getElementById("inputDateMax").value;

    var address = "";
    if (type == "amount")
        address = "/DishAnalysis/GetAmountChart?";
    else if (type == "money")
        address = "/DishAnalysis/GetMoneyChart?";

    var getChart = address + "dishname=" + dishName + "&datemin=" + dateMin + "&datemax=" + dateMax;
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("get", getChart, false);
    xmlhttp.setRequestHeader("Content-Type", "text/html; charset=utf-8");
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var response = xmlhttp.responseText;
            var responseJson = eval("(" + response + ")");

            var startDate = new Date(responseJson.plotOptions.series.pointStart);

            responseJson.plotOptions.series.pointStart = Date.UTC(startDate.getUTCFullYear(), startDate.getUTCMonth(), startDate.getUTCDate());

            $('#container').highcharts(responseJson);
        }
    }

    xmlhttp.send();
}


function AddDishQueryBlank() {
    var dishBlanks = document.getElementsByName("DishName");
    if (dishBlanks.length > 2)
        return;

    var formQuery = document.getElementById("formQuery");

    var labelDishName = document.createElement("label");
    var inputDishName = document.createElement("input");

    labelDishName.innerHTML = "Dish name";

    inputDishName.name = "DishName";
    inputDishName.type = "text";
    inputDishName.className = "inputEdit";
    inputDishName.setAttribute("data-val", "true");
    inputDishName.setAttribute("data-val-required", "Missing вшыр name");

    formQuery.appendChild(labelDishName);
    formQuery.appendChild(inputDishName);

    $("[name = 'DishName']").autocomplete({
        serviceUrl: '/autocomplete/dishes',
        deferRequestBy: 100,
        noCache: true,
        showNoSuggestionNotice: true,
        noSuggestionNotice: 'The query results are empty',
    });
}


function GetTotalChart(dateMin, dateMax) {
    if (dateMin == null) {
        dateMin = document.getElementById("inputDateMin").value;
    }

    if (dateMax == null) {
        dateMax = document.getElementById("inputDateMax").value;
    }

    var getChart = "/DishAnalysis/GetTotalDailyChart?datemin=" + dateMin + "&datemax=" + dateMax;
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("get", getChart, false);
    xmlhttp.setRequestHeader("Content-Type", "text/html; charset=utf-8");
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            var response = xmlhttp.responseText;
            var responseJson = eval("(" + response + ")");

            var startDate = new Date(responseJson.plotOptions.series.pointStart);

            responseJson.plotOptions.series.pointStart = Date.UTC(startDate.getUTCFullYear(), startDate.getUTCMonth(), startDate.getUTCDate());

            $('#container').highcharts(responseJson);
        }
    }

    xmlhttp.send();
}