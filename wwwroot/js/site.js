$(function () {
    $("#btnBuscar").click(function () {

        var txtPais = $("#txtPais").val()

        if (txtPais != "" || txtPais != null) {
            $.ajax({
                type: "GET",
                url: "/Home/GetPais",
                data: { Pais: txtPais },
                async: true,
                success: function (res) {
                    //console.log(res);
                    $("#contenido").html("<div class=caja> <div> <img class=bandera src> </div> <div> <p> <span class=negrita>Name: </span> <span class=name></span> </p> <p> <span class=negrita>Region: </span> <span class=region></span> </p> <p> <span class=negrita>Capital: </span> <span class=capital></span> </p> </div> </div>")
                    $(".name").append(res.name); $(".region").append(res.region); $(".capital").append(res.capital);
                    $(".bandera").attr("src", res.flag)
                }
            })
        }
    })

    function GetPaises() {
        $.ajax({
            type: "GET",
            url: "https://restcountries.com/v2/all",
            async: true,
            success: function (res) {
                console.log(res)
                var total = res.length
                for (var i = 0; i < total; i++) {
                    $("#contenido").append("<div id=" + i + " class=caja> <div> <img class=bandera src=" + res[i].flags.svg + "> </div> <div> <p> <span class=negrita>Name: </span> <span class=name>" + res[i].name + "</span> </p> <p> <span class=negrita>Region: </span> <span class=region>" + res[i].region + "</span> </p> <p> <span class=negrita>Capital: </span> <span class=capital>" + res[i].capital + "</span> </p> </div> </div>")
                }
            }
        })
    }

    GetPaises();
})
