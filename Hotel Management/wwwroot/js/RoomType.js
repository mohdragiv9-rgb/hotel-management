<script>

    function Save(){

    var obj={

    RoomTypeId:$("#RoomTypeId").val(),

    RoomTypeName:$("#RoomTypeName").val(),

    Price:$("#Price").val(),

    Description:$("#Description").val()

    };

    $.ajax({

        url:'/RoomType/Save',

    type:'POST',

    data:obj,

    success:function(res){

        alert(res.message);

    location.reload();

        }

    });

}
    function Edit(id){

        $.get('/RoomType/GetById?id=' + id, function (data) {

            $("#RoomTypeId").val(data.roomTypeId);

            $("#RoomTypeName").val(data.roomTypeName);

            $("#Price").val(data.price);

            $("#Description").val(data.description);

        });

}

    function Delete(id){

    if(confirm("Delete Record?")){

        $.ajax({

            url: '/RoomType/Delete',

            type: 'POST',

            data: { id: id },

            success: function (res) {

                alert(res.message);

                location.reload();

            }

        });

    }

}
    function ClearData(){

    $("#RoomTypeId").val("");

    $("#RoomTypeName").val("");

    $("#Price").val("");

    $("#Description").val("");

}

</script>