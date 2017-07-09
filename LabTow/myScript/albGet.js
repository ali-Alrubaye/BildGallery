$(document).ready(function () {

    showingAlb();
});

function close() {
    displayListAlb();
}
function showingAlb() {
    //Start Function Upload Album to Index View.........
    $.ajax({
        url: "/Album/List",
        method: 'GET',
        cash: false,
        dataType: 'html',
        success: function (data) {
            $('#addAlbumbtn').show();
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

    location.href = "/Album/Details?id=" + id;

}
//Function to Show add new Album .. Show in Poppup Modal....
function CreateNAlbum() {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showCreate');
    var div = $("#showCreate");

    $.ajax({
        url: "/Album/Create",
        method: "GET",
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}
//Function to Add Comment to Album .. Show in Poppup Modal....
function AddCommenttoAlb(id) {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'addComment');
    //$(".btnSave").attr('id', 'AddCommentAlbum');
    //$('.btnSave').html('');
    // $('.btnSave').html('Add');
    var div = $("#addComment");
    //div.load("/Home/Edit?AlbumIdGuid=" + id);
    $.ajax({
        url: "/Album/AddCom?id=" + id,
        method: 'GET',
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}
//Function to Show Edit Album .. Show in Poppup Modal....
function EditAlb(id) {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showEdit');
    var div = $("#showEdit");
    $.ajax({
        url: "/Album/Edit?id=" + id,
        method: 'GET',
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}

//Function to Show Delete Album .. Show in Poppup Modal....
function DeleteAlb(id) {

    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showDelete');
    //$(".btnSave").attr('id', 'btnDelete');
    //$('.btnSave').html('Delete');
    var div = $("#showDelete");
    //div.load("/Home/Delete?id=" + id);
    $.ajax({
        url: "/Album/Delete?id=" + id,
        method: 'GET',
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}
function displayListAlb() {
    //setTimeout(function () {
    //debugger;
    $("[rel='tooltip']").tooltip();

    $('.albums').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
    //},1500);
}
