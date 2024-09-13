function openTab(menu) {
    var i;
    var x = document.getElementsByClassName("taps");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    document.getElementById(menu).style.display = "block";
}

function addQ(productID) {
    var num = parseInt(document.getElementById(productID).value);
    if (num < 5)
        num += 1;
    document.getElementById(productID).value = num;
}

function minusQ(productID) {
    var num = parseInt(document.getElementById(productID).value);
    if (num > 1)
        num -= 1;
    document.getElementById(productID).value = num;
}

function deleteItem(productID){
    window.location.href = "Catalog.aspx?Del=" + productID;
}

function updateQuanity(productID){
    quantity = document.getElementById(productID).value;
    window.location.href = "Catalog.aspx?prodID=" + productID + "&prodQty=" + quantity;
}

function openCart() {
    document.getElementById("cart").style.width = "330px";
}

/* Set the width of the side navigation to 0 */
function closeCart() {
    document.getElementById("cart").style.width = "0";
}

function checkOut(){
    window.location.href = "Checkout.aspx";
}

function search(){
    var text = document.getElementById("txtSearch").value + '';
    if(text != '')
        window.location.href = "SearchResults.aspx?Query=" + text;
    else if(text.length <= 0)
        alert("Search field empty");
}

function signOut(){
    window.location.href = "Profile.aspx?SignOut=true";
}

function order(){
    window.location.href = "Checkout.aspx?Transact=true"
}


function moreLess(orderID) {

    var moreText = document.getElementById(orderID);
	var btnText = document.getElementById(orderID + "1");

    if (moreText.style.display === "none") {
        moreText.style.display = "inline";
        btnText.innerHTML = "Show less";

    } else {
        moreText.style.display = "none";
        btnText.innerHTML = "Show less";
    }

}