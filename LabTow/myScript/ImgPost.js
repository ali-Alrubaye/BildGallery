$(document).ready(function () {

    //Create
    $("#btnSavePhotoC").on('click', function (e) {

    //$(this).submit(function() {});

    var form = $("#myFormPhoto");
    form.submit(function (e) {
        //debugger;

        e.preventDefault();
        if (form.valid()) {
            var formdata = new FormData(form[0]);
            //    var file = $("#txtUploadFile").get(0).files;
            //    var name = $("#txtName").val();
            //    var datet = $("#txtDate").val();
            //    var des = $("#txtDesc").val();
            //    var alb = $("#AlbumId").val();
            //var formData = new FormData();
            //formData.append('PhotoName', $("#txtName").val());
            //formData.append('PhotoDate', $("#txtDate").val());
            //formData.append('Description', $("#txtDesc").val());
            //formData.append('PhotoPath', $("#txtUploadFile")[0].files[0]);
            //formData.append('AlbumId', $("#AlbumId").val());
            $.ajax({
                method: "POST",
                url: '/Photo/Create',
                //enctype: 'multipart/form-data',
                //async: true,
                contentType: false,
                processData: false,         // PREVENT AUTOMATIC DATA PROCESSING.
                cache: false,
                data: formdata,
                success: function (data) {
                    if (data.status > 0) {
                        $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                        setTimeout(function () {
                            $("#myModal1").modal("hide");
                            showing();
                        }, 900);
                        setTimeout(function() {
                            $(".ShowList").hide();
                            $('#loading').show();
                        },900);
                       

                        setTimeout(function() {
                            $('#loading').hide();
                            $(".ShowList").show();
                        }, 5000);
                        //showing();
                    } else {
                        $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                    }
                    //$('.btnSave').reset();
                    //$('#loadDiv').hide();
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ': ' + errorThrown);
                },
            });
        }
        });
    });
    //Add Comment
    $("#AddCommentPhoto").on('click', function (e) {
        //debugger;
        e.preventDefault();
        var myformPhoto = $("#myAddForm").serialize();
        $.ajax({
            method: "POST",
            cash: false,
            url: "/Photo/AddCom",
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
            url: "/Photo/Delete?id=" + id,
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
    $("#btnSavePhotoE").on('click', function () {
        //debugger;
        var form = $("#myEForm");
     
        //var file = $("#txtUpload").get(0).files;
        //var oldPhotoPath = $("#oldPath").attr("value");
        //    var name = $("#txtName").val();
        //    var datet = $("#txtDate").val();
        //    var des = $("#txtDesc").val();
        //    var alb = $("#AlbumId").val();
        //var formData = new FormData;
        //formData.append('PhotoName', name);
        //formData.append('PhotoDate', datet);
        //formData.append('Description', des);
        //formData.append('AlbumId', alb);
        //if (file == null) {
        //    formData.append('PhotoPath', oldPhotoPath);
        //} else {
        //    formData.append('PhotoPath',file[0]);
        //}
        form.submit(function (e) {
            e.preventDefault();
            
        //var myformPhoto = $("#myEForm");
        $.ajax({
            method: "POST",
            url: "/Photo/Edit",
            contentType: false,
            processData: false,
            data: new FormData(form[0]),
            success: function (data) {
                if (data.status > 0) {
                    $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                    setTimeout(function () {
                        $("#myModal1").modal("hide");
                        showing();
                    }, 900);
                    setTimeout(function () {
                        $(".ShowList").hide();
                        $('#loading').show();
                    }, 900);


                    setTimeout(function () {
                        $('#loading').hide();
                        $(".ShowList").show();
                    }, 5000);
                    //showing();
                } else {
                    $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                }
            },
            error: function (status) {
                alert(status);
            }
        });
        });
    });
});