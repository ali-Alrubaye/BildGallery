$(document).ready(function() {

    showingAlb();
    //setInterval(reloadAlbum, 5000);
});

function close() {
    displayListAlb();
}

var reloadAlbum = function() {

    $.ajax({
        type: "GET",
        url: "/Album/List",
        success: function(data) {
            $(".ShowListAlbum").html(data);
            displayListAlb();
        }
    });

};

function showingAlb() {
    //Start Function Upload Album to Index View.........

    $.ajax({
        url: "/Album/List",
        method: "GET",
        cash: false,
        dataType: "html",
        success: function(data) {
            $("#addAlbumbtn").show();
            $(".ShowListAlbum").html(data);
            //Call Function to display Albums in Index View.......
            displayListAlb();
        }
        //})
    });
}

function showAlbDetails(id) {
    //Start Function Show Album Details to Index View.........
    //debugger;

    //location.href = "/Album/Details?id=" + id;
    $.ajax({
        url: "/Album/Details?id=" + id,
        method: "GET",
        cash: false,
        dataType: "html",
        success: function(data) {
            $(".ShowListPhoto").show();
            $("#addPhotobtn").hide();
            $("#addAlbumbtn").hide();
            $(".ShowListAlbum").hide();
            $(".ShowListPhoto").html(data);
            //Call Function to display Albums in Index View.......
            displayList();
        }
        //})
    });

}

function BacktoGallery() {
    $(".ShowListPhoto").hide();
    $(".ShowListAlbum").show();
    $("#addPhotobtn").show();
    $("#addAlbumbtn").show();
}

//Function to Show add new Album .. Show in Poppup Modal....
function CreateNAlbum() {
    $(".modal-body").removeAttr("id");
    $(".modal-body").attr("id", "showCreateAlb");
    var div = $("#showCreateAlb");

    $.ajax({
        url: "/Album/Create",
        method: "GET",
        dataType: "html",
        success: function(data) {
            div.html(data);
        }
    });
}

function AddPhotoToAlbum(id) {
    //debugger;
    $(".modal-body").removeAttr("id");
    $(".modal-body").attr("id", "showAddPhoto");
    var div = $("#showAddPhoto");

    $.ajax({
        url: "/Album/AddPhotoToAlbum?id=" + id,
        method: "GET",
        dataType: "html",
        success: function(data) {
            div.html(data);
        }
    });
}

//Function to Add Comment to Album .. Show in Poppup Modal....
function AddCommenttoAlb(id) {
    $(".modal-body").removeAttr("id");
    $(".modal-body").attr("id", "addComment");
    var div = $("#addComment");
    //div.load("/Home/Edit?AlbumIdGuid=" + id);
    $.ajax({
        url: "/Comment/CreateComment?id=" + id,
        method: "GET",
        dataType: "html",
        success: function(data) {
            div.html(data);
        }
    });
}

//Function to Show Edit Album .. Show in Poppup Modal....
function EditAlb(id) {
    $(".modal-body").removeAttr("id");
    $(".modal-body").attr("id", "showEdit");
    var div = $("#showEdit");
    $.ajax({
        url: "/Album/Edit?id=" + id,
        method: "GET",
        dataType: "html",
        success: function(data) {
            div.html(data);
        }
    });
}

//Function to Show Delete Album .. Show in Poppup Modal....
function DeleteAlb(id) {

    $(".modal-body").removeAttr("id");
    $(".modal-body").attr("id", "showDelete");
    var div = $("#showDelete");
    $.ajax({
        url: "/Album/Delete?id=" + id,
        method: "GET",
        dataType: "html",
        success: function(data) {
            div.html(data);
        }
    });
}

function displayListAlb() {
    //setTimeout(function () {
    //debugger;
    $("[rel='tooltip']").tooltip();

    $(".albums").hover(
        function() {
            $(this).find(".caption").slideDown(250); //.fadeIn(250)
        },
        function() {
            $(this).find(".caption").slideUp(250); //.fadeOut(205)
        }
    );
    //},1500);
}