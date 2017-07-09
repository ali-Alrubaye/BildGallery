//Start Album Script Post Methods
$(document).ready(function () {

    //Create
    $("#btnSaveAlbumC").on('click', function (e) {
        //debugger;
        //$(this).submit(function() {});

        //var form2= $("#myFormAlbum").serialize();
        e.preventDefault();
        $.ajax({
            method: "POST",
            url: "/Album/Create",
            cash: false,
            data: new FormData(document.getElementsByTagName("form")[0]),
            dataType: "json",
            success: function (data) {
                if (data.status > 0) {
                    $("#notify").text(data.Message).fadeIn(200).delay().fadeOut(4000);
                    $('#myModal2').modal('hide');
                    showingAlb();
                } else {
                    $("#notify").text(data.Message).fadeIn(200).fadeOut(4000);
                }
                //$('.btnSave').reset();

            },
            error: function (status) {
                alert(status);
            },
            processData: false,
            contentType: false
        });

    });
    //Add Comment
    $("#AddCommentAlbum").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var myformAlbum = $("#myAddForm").serialize();
        $.ajax({
            method: "POST",
            cash: false,
            url: "/Album/AddCom",
            data: myformAlbum,
            success: function () {
                $('#myModal2').modal('hide');
                showingAlb();

            },
            error: function (status) {
                alert(status);
            },
            processData: false
            //contentType: false

        });
        //$('#load').hide();
        //$('div#load').show().fadeIn(2000).delay(2000).fadeOut(2000);

    });
    //Delete
    $("#btnDeleteA").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var id = $("#Pid").val();

        $.ajax({
            method: "POST",
            cash: false,
            url: "/Album/Delete?id=" + id,
            //data: myformD,
            success: function (data) {
                $('#myModal2').modal('hide');
                showingAlb();
            },
            error: function (status) {
                alert(status);

            }

        });
    });
    //Edit
    $("#btnAlbumE").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var myformAlbum = $("#myEFormAlb").serialize();
        $.ajax({
            method: "POST",
            cash: false,
            url: "/Album/Edit",
            data: myformAlbum,
            success: function (data) {
                $('#myModal2').modal('hide');
                showingAlb();
            },
            error: function (status) {
                alert(status);
            },
            processData: false
        });
    });
});