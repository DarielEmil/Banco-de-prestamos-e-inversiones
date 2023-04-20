

//MyProfile Script

function btnManageAcc() {
    document.getElementById("idmaccount").style.transform = "scaleX(1)";
}
function btnManageClose() {
    document.getElementById("idmaccount").style.transform = "scaleX(0)";
}
function btnNewAcc() {
    document.getElementById("idfaccount").style.transform = "scaleX(1)";
}
function btnNewAccClose() {
    document.getElementById("idfaccount").style.transform = "scaleX(0)";
}

//Investment Script

function btnNewInvestment() {
    document.getElementById("idpopup").style.transform = "scaleX(1)";
}
function btnNewInvestmentClose() {
    document.getElementById("idpopup").style.transform = "scaleX(0)";
}

function btnInfoInvestment() {
    document.getElementById("idpop").style.transform = "scaleX(1)";
}

function btnInfoInvestmentClose() {
    document.getElementById("idpop").style.transform = "scaleX(0)";
}

//Loans Script

function btnInfoLoans() {
    document.getElementById("idpop").style.transform = "scaleX(1)";
}

function btnInfoLoansClose() {
    document.getElementById("idpop").style.transform = "scaleX(0)";
}

function btnNewLoans() {
    document.getElementById("idpop-new").style.transform = "scaleX(1)";
}

function btnNewLoansClose() {
    document.getElementById("idpop-new").style.transform = "scaleX(0)";
}

function btnWarranty() {
    document.getElementById("warranty").style.display = "block";
    document.getElementById("guarantor").style.display = "none";
}
function btnGuarantee() {
    document.getElementById("guarantor").style.display = "block";
    document.getElementById("warranty").style.display = "none";
}
