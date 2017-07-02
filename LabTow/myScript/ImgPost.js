$(document).ready(function() {

    //Create
    //$("#btnSavePhotoC").on('click', function (e) {
    //debugger;
    //$(this).submit(function() {});
    
    var form = $("#myFormPhoto");
    form.submit(function(e) {


        e.preventDefault();
        if (form.valid()) {
          
        //var formData = new FormData(document.getElementsByTagName("form")[0]);
        //formData.append('PhotoName', $("#txtName").val());
        //formData.append('PhotoDate', $("#txtDate").val());
        //formData.append('Description', $("#txtDesc").val());
        //formData.append('PhotoPath', $("#txtUploadFile")[0].files[0]);
        //formData.append('AlbumId', $("#AlbumId").val());
        //var myformPhoto = $("#myFormPhoto").serialize();
        $.ajax({
            method: "POST",
            url: "/Home/Create",
            cash: false,
            data: new FormData(document.getElementsByTagName("form")[0]),
            dataType: "json",
            success: function(data) {
                if (data.status > 0) {
                    $("#notify").text(data.Message).fadeIn(200).fadeOut(1000);
                    $('#loadDiv').show();
                    setTimeout(function () {
                       
                        $("#myModal1").modal("hide");
                        showing();
                    }, 5000);
                    
                    //showing();
                } else {
                    $("#notify").text(data.Message).fadeIn(200).fadeOut(4000);
                }
                //$('.btnSave').reset();
             $('#loadDiv').hide();
            },
            error: function(status) {
                alert(status);
            },
            processData: false,
            contentType: false
        });
    }
    //});
    });
    //Add Comment
    $("#AddCommentPhoto").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var myformPhoto = $("#myAddForm").serialize();
        $.ajax({
            method: "POST",
            cash: false,
            url: "/Home/AddCom",
            data: myformPhoto,
            success: function () {
                $('#myModal1').modal('hide');
                showing();

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
    $("#btnDelete").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var id = $("#Pid").val();

        $.ajax({
            method: "POST",
            cash: false,
            url: "/Home/Delete?id=" + id,
            //data: myformD,
            success: function (data) {
                $('#myModal1').modal('hide');
                showing();
            },
            error: function (status) {
                alert(status);

            }

        });
    });
    //Edit
    $("#btnSavePhotoE").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var myformPhoto = $("#myEForm").serialize();
        $.ajax({
            method: "POST",
            cash: false,
            url: "/Home/Edit",
            data: myformPhoto,
            success: function (data) {
                $('#myModal1').modal('hide');
                showing();
            },
            error: function (status) {
                alert(status);
            },
            processData: false
        });
    });
});