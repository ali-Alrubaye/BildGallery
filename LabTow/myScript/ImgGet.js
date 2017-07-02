$(document).ready(function () {

    showing();
});

function close() {
    displayList();
}
function showing() {
    //Start Function Upload Photo to Index View.........
    $.ajax({
        url: "/Photo/List",
        method: 'GET',
        cash: false,
        async: false,
        dataType: 'html',
        success: function (data) {
            $(".ShowList").html(data);
            //Call Function to display photos in Index View.......
            displayList();
        }
        //})
    });
}

//Function to Show add new Photo .. Show in Poppup Modal....
function CreateNPhoto() {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showCreate');
    //$(".btnSave").attr('id', 'btnSavePhotoC');
    //$('.btnSave').html('');
    //$('.btnSave').html('Create');
    var div = $("#showCreate");
    //div.load("/Photo/Create");

    $.ajax({
        url: "/Photo/Create",
        method: "GET",
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}
//Function to Add Comment to Photo .. Show in Poppup Modal....
function AddCommenttoPhoto(id) {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'addComment');
    //$(".btnSave").attr('id', 'AddCommentPhoto');
    //$('.btnSave').html('');
    // $('.btnSave').html('Add');
    var div = $("#addComment");
    //div.load("/Photo/Edit?photoIdGuid=" + id);
    $.ajax({
        url: "/Photo/AddCom?id=" + id,
        method: 'GET',
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}
//Function to Show Edit Photo .. Show in Poppup Modal....
function EditPhoto(id) {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showEdit');
    //$(".btnSave").attr('id', 'btnSavePhotoE');
    //$('.btnSave').html('');
    // $('.btnSave').html('Edit');
    var div = $("#showEdit");
    //div.load("/Photo/Edit?photoIdGuid=" + id);
    $.ajax({
        url: "/Photo/Edit?id=" + id,
        method: 'GET',
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}

//Function to Show Delete Photo .. Show in Poppup Modal....
function DeletePhoto(id) {

    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showDelete');
    //$(".btnSave").attr('id', 'btnDelete');
    //$('.btnSave').html('Delete');
    var div = $("#showDelete");
    //div.load("/Photo/Delete?id=" + id);
    $.ajax({
        url: "/Photo/Delete?id=" + id,
        method: 'GET',
        dataType: 'html',
        success: function (data) {
            div.html(data);
        }
    });
}
function displayList() {
    //setTimeout(function () {
    //debugger;
    $("[rel='tooltip']").tooltip();

    $('.thumbnail').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
    //},1500);
}
