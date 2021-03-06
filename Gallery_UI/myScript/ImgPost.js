﻿$(document).ready(function() {

    //Create
    $("#btnSavePhotoC").on("click",
        function(e) {

            //$(this).submit(function() {});

            var form = $("#myFormPhoto");
            form.submit(function(e) {
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
                        url: "/Photo/Create",
                        //enctype: 'multipart/form-data',
                        //async: true,
                        contentType: false,
                        processData: false, // PREVENT AUTOMATIC DATA PROCESSING.
                        cache: false,
                        data: formdata,
                        success: function(data) {
                            if (data.status > 0) {
                                $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                                setTimeout(function() {
                                        $("#myModal2").modal("hide");

                                        //ShowList();
                                    },
                                    900);
                                setTimeout(function() {
                                        $(".ShowList").hide();
                                        $(".ShowListAlbum").hide();
                                        $("#loading").show();
                                    },
                                    900);


                                setTimeout(function() {
                                        $("#loading").hide();
                                        $(".ShowList").show();
                                        $(".ShowListAlbum").show();
                                    },
                                    5000);
                                //showing();
                            } else {
                                $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                            }
                            //$('.btnSave').reset();
                            //$('#loadDiv').hide();
                        },
                        error: function(xmlHttpRequest, textStatus, errorThrown) {
                            alert(textStatus + ": " + errorThrown);
                        },
                    });
                }
            });
        });
    //Add Comment
    $("#AddCommentPhoto").on("click",
        function(e) {
            //debugger;
            e.preventDefault();
            var myformPhoto = $("#myAddForm").serialize();
            $.ajax({
                method: "POST",
                cash: false,
                url: "/Photo/AddCom",
                data: myformPhoto,
                success: function() {
                    $("#myModal2").modal("hide");
                    ShowList();

                },
                error: function(status) {
                    alert(status);
                },
                processData: false
                //contentType: false

            });
            //$('#load').hide();
            //$('div#load').show().fadeIn(2000).delay(2000).fadeOut(2000);

        });
    //Delete
    $("#btnDelete").on("click",
        function(e) {
            //debugger;
            e.preventDefault();
            var id = $("#Pid").val();
            var aid = $("#AlbId").val();

            $.ajax({
                method: "POST",
                cash: false,
                url: "/Photo/Delete?id=" + id,
                //data: myformD,
                success: function(data) {
                    $("#myModal2").modal("hide");
                    $(".DetailsAlbum").hide();
                    $("#loading").show();
                    setTimeout(function() {
                            $("#loading").hide();
                            $(".DetailsAlbum").show();
                            showAlbDetails(aid);
                        },
                        5000);
                },
                error: function(status) {
                    alert(status);

                }

            });
        });
    //Edit
    $("#btnSavePhotoE").on("click",
        function() {
            //debugger;
            var aid = $("#AlbId").val();
            var form = $("#myEForm");

            form.submit(function(e) {
                e.preventDefault();

                //var myformPhoto = $("#myEForm");
                $.ajax({
                    method: "POST",
                    url: "/Photo/Edit",
                    contentType: false,
                    processData: false,
                    data: new FormData(form[0]),
                    success: function(data) {
                        if (data.status > 0) {
                            $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);

                            $("#myModal2").modal("hide");


                            $(".DetailsAlbum").hide();
                            $("#loading").show();


                            setTimeout(function() {
                                    $("#loading").hide();
                                    $(".DetailsAlbum").show();
                                    showAlbDetails(aid);
                                },
                                5000);
                        } else {
                            $("#notify").text(data.Message).fadeIn(100).delay().fadeOut(700);
                        }
                    },
                    error: function(status) {
                        alert(status);
                    }
                });
            });
        });
    //Add Photo from folder to Album
    $("#AddtPhotoToAlb").on("click",
        function(e) {
            //debugger;
            e.preventDefault();
            var photos = $("#myAddFormtoAlbum").serialize();

            $.ajax({
                method: "POST",
                cash: false,
                url: "/Album/AddPhotoToAlbum",
                data: photos,
                success: function() {
                    $("#myModal2").modal("hide");
                    ShowList();

                },
                error: function(status) {
                    //alert(status);
                },
                processData: false,
                contentType: false

            });
            //$('#load').hide();
            //$('div#load').show().fadeIn(2000).delay(2000).fadeOut(2000);

        });
});