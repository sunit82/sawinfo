function setImgProfileHeight(h) {
    var imgProfile = document.getElementById("imgProfile");
    if (imgProfile !== null && imgProfile !== undefined) {
        imgProfile.style.height = h;
    }
}

function OnOut() {
    setImgProfileHeight("180px");
}

function OnOver() {
    setImgProfileHeight("500px");
}