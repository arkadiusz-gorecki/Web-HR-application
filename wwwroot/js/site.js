// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function getJobOffer(jobofferid) {

//    $.ajax({
//        url: '/api/JobOffer/GetJobOffer',
//        type: 'GET',
//        data: { jobofferid: jobofferid},
//        //contentType: "application/json",
//        //dataType: "json",
//        success: function (data) {
//            $.each(data, function (key, item) {
//                //generateComment(item);
//                console.log(data);
//            });

//            //var voteLabel = commentContainer.getElementById("comment-rating");
//            //voteLabel.innerHTML = data;
//            alert('Fetch comments succeeded.');
//        },
//        error: function () {
//            alert('Error! Could not fetch the comments for joboffer with id = ' + jobofferid + '. Please try again.');
//        }
//    }).done(function () {

//        //$loading.remove();
//    });
//}

function validateCompany() {
    if (document.getElementById("Name").value == "") {
        alert("Please enter company name.");
        document.getElementById("Name").focus();
        return false;
    }
    if (document.getElementById("Name").value.length < 3) {
        alert("Company name length can't be less than 3 characters.");
        document.getElementById("Name").focus();
        return false;
    }
    if (document.getElementById("Name").value.length > 30) {
        alert("Company name length can't be more than 30 characters.");
        document.getElementById("Name").focus();
        return false;
    }
    return true;
}

function sendCompany() {

    if (validateCompany() === false)
        return false;
    const item = { //najlepiej nazwać go tak samo jak argument w metodzie na backendzie, tego nie ruszaj
        name: document.getElementById("Name").value,
    };
    document.getElementById("Name").value = ""; // wyczyszczenie komórki formularza

    console.log(item);

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: "/api/company/SendCompany",
        contentType: "application/json",
        data: JSON.stringify(item), // <-- to jest wazne, tutaj sie JSONuje nasz obiekt
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            alert("New company added successfully!");
        }
    });
}

function validateJobOffer() {
    if (document.getElementById("JobTitle").value == "") {
        alert("Please insert job title.");
        document.getElementById("JobTitle").focus();
        return false;
    }
    if (document.getElementById("JobTitle").value.length < 3) {
        alert("Job title length can't be less than 3 characters.");
        document.getElementById("JobTitle").focus();
        return false;
    }
    if (document.getElementById("JobTitle").value.length > 25) {
        alert("Job title length can't be more than 25 characters.");
        document.getElementById("JobTitle").focus();
        return false;
    }
    if (document.getElementById("Location").value == "") {
        alert("Please insert job location.");
        document.getElementById("Location").focus();
        return false;
    }
    if (/^[a-zA-Z][a-z]*([ ][a-zA-Z][a-z]*)*$/.test(document.getElementById("Location").value) === false) {
        alert("Location name must consist of letters only. Location name cannot start and/or end with space and cannot contain upper case letters inside the words.");
        document.getElementById("Location").focus();
        return false;
    }
    if (document.getElementById("Location").value.length < 3) {
        alert("Location name length can't be less than 3 characters.");
        document.getElementById("Location").focus();
        return false;
    }
    if (document.getElementById("Location").value.length > 25) {
        alert("Location name length can't be more than 25 characters.");
        document.getElementById("Location").focus();
        return false;
    }
    if (document.getElementById("SalaryFrom").value && document.getElementById("SalaryTo").value) {
        if (parseInt(document.getElementById("SalaryFrom").value, 10) > parseInt(document.getElementById("SalaryTo").value, 10)) {
            alert("Minimal salary cannot be greater than maximal salary");
            document.getElementById("SalaryFrom").focus();
            return false;
        }
    }
    if (document.getElementById("ValidUntil").value == "") {
        alert("Please choose a date.");
        document.getElementById("ValidUntil").focus();
        return false;
    }
    if (document.getElementById("Description").value == "") {
        alert("Please write job description.");
        document.getElementById("Description").focus();
        return false;
    }
    if (document.getElementById("Description").value.length < 3) {
        alert("Description length can't be less than 5 characters.");
        document.getElementById("Description").focus();
        return false;
    }
    if (document.getElementById("Description").value.length > 250) {
        alert("Description length can't be more than 250 characters.");
        document.getElementById("Description").focus();
        return false;
    }
    return true;
}

function sendJobOffer() {

    if (validateJobOffer() === false)
        return false;
    const item = {
        jobTitle: document.getElementById("JobTitle").value,
        companyId: document.getElementById("CompanyId").value,
        salaryFrom: document.getElementById("SalaryFrom").value,
        salaryTo: document.getElementById("SalaryTo").value,
        location: document.getElementById("Location").value,
        description: document.getElementById("Description").value,
        validUntil: document.getElementById("ValidUntil").value,
    };
    document.getElementById("JobTitle").value = ""; // wyczyszczenie komórki formularza
    //document.getElementById("CompanyId").value = 0; // 
    document.getElementById("SalaryFrom").value = "";
    document.getElementById("SalaryTo").value = "";
    document.getElementById("Location").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("ValidUntil").value = "";

    console.log(item);

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: "/api/jobOffer/sendJobOffer",
        contentType: "application/json",
        data: JSON.stringify(item), // <-- to jest wazne, tutaj sie JSONuje nasz obiekt
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            alert("New job offer added successfully!");
        }
    });
}
