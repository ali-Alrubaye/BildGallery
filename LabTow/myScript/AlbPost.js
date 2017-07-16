﻿//Start Album Script Post Methods
$(document).ready(function() {

    //Create
    $("#btnSaveAlbumC").on("click",
        function(e) {
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
                success: function(data) {
                    if (data.status > 0) {
                        $("#notify").text(data.Message).fadeIn(200).delay().fadeOut(4000);
                        $("#myModal2").modal("hide");
                        $(".ShowListAlbum").hide();
                        $("#loading").show();
                        setTimeout(function () {
                                $("#loading").hide();
                                $(".ShowListAlbum").show();
                                showingAlb();
                            },
                            5000);
                        
                    } else {
                        $("#notify").text(data.Message).fadeIn(200).fadeOut(4000);
                    }
                    //$('.btnSave').reset();

                },
                error: function(status) {
                    alert(status);
                },
                processData: false,
                contentType: false
            });

        });
    //Add Comment
    $("#AddCommAlbum").on("click",
        function(e) {
            debugger;
            e.preventDefault();
            var com = $('#mycommform').serialize();
            $.ajax({
                method: "POST",
                //cash: false,
                url: "/Comment/CreateComment",
                data: com,
                success: function() {
                    $("#myModal2").modal("hide");
                    $(".ShowListAlbum").hide();
                    $("#loading").show();
                    setTimeout(function () {
                            $("#loading").hide();
                            $(".ShowListAlbum").show();
                            showingAlb();
                        },
                        5000);

                },
                error: function(status) {
                    alert(status);
                },
                processData: false

            });
            //$('#load').hide();
            //$('div#load').show().fadeIn(2000).delay(2000).fadeOut(2000);

        });
    //Delete
    $("#btnDeleteA").on("click",
        function(e) {
            //debugger;
            e.preventDefault();
            var id = $("#Pid").val();

            $.ajax({
                method: "POST",
                cash: false,
                url: "/Album/Delete?id=" + id,
                //data: myformD,
                success: function(data) {
                    $("#myModal2").modal("hide");
                    $(".ShowListAlbum").hide();
                    $("#loading").show();

                    setTimeout(function () {
                            $("#loading").hide();
                            $(".ShowListAlbum").show();
                            showingAlb();
                        },
                        5000);
                },
                error: function(status) {
                    alert(status);

                }

            });
        });
    //Edit
    $("#btnAlbumE").on("click",
        function(e) {
            //debugger;
            e.preventDefault();
            var myformAlbum = $("#myEFormAlb").serialize();
            $.ajax({
                method: "POST",
                cash: false,
                url: "/Album/Edit",
                data: myformAlbum,
                success: function(data) {
                    $("#myModal2").modal("hide");
                    $(".ShowListAlbum").hide();
                    $("#loading").show();



                    setTimeout(function () {
                            $("#loading").hide();
                            $(".ShowListAlbum").show();
                            showingAlb();
                        },
                        5000);
                    
                },
                error: function(status) {
                    alert(status);
                },
                processData: false
            });
        });
    //Add Photo from folder to Album
    $("#AddtPhotoToAlb").on("click",
        function(e) {
            e.preventDefault();
            var photos = $("#myAddFormtoAlbum").serialize();
          
            $.ajax({
                method: "POST",
                cash: false,
                url: "/Album/AddPhotoToAlbum",
                data: photos,
                success: function () {
                    $("#myModal2").modal("hide");
                    
                            $(".ShowListAlbum").hide();
                            $("#loading").show();
                        


                    setTimeout(function () {
                            $("#loading").hide();
                            $(".ShowListAlbum").show();
                        },
                        5000);
                   
                    //showing();

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
});