var Ambiente = 'Desarrollo/';

$(document).ready(function () {
    $("body").on("change", ".txtDecimalFormato", function () {
        $(this).val($(this).val().replace(",", "."));
        if ($.trim($(this).val()) == "") $(this).val("");
        else {
            if (isNaN($(this).val())) $(this).val("0");
            else $(this).val(parseFloat($(this).val()).toFixed($(this).attr("data-decimales")));
        }
    });

    //Default Action
    $(".tab_content").hide(); //Hide all content
    $("ul.tabs li:first").addClass("active").show(); //Activate first tab
    $(".tab_content:first").show(); //Show first tab content

    //On Click Event
    $("ul.tabs li").click(function () {
        $("ul.tabs li").removeClass("active"); //Remove any "active" class
        $(this).addClass("active"); //Add "active" class to selected tab
        $(".tab_content").hide(); //Hide all tab content
        var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
        $(activeTab).fadeIn(); //Fade in the active content
        return false;
    });

    $("body").on("click", "[src*=plus]", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "../Images/minus.png");
    });

    $("body").on("click", "[src*=minus]", function () {
        $(this).attr("src", "../Images/plus.png");
        $(this).closest("tr").next().remove();
    });

    CargaMenu();
});

function validarEmail(email) {
    expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!expr.test(email))
        return false
    else return true
}

function CargaMenu() {
    //CargaPerfilUsuario
    $.ajax({
        type: "POST", url: $("#hdnAmbiente").val()+"/Home/CargaPerfilUsuario", contentType: "application/json; charset=utf-8", dataType: "json", async: false, success: function (data) {
            $.each(data.Usuario, function (i) {
                $("#hdnIdPerfil").val(data.Usuario[i].IdPerfil);
                $("#hdnIdSucursal").val(data.Usuario[i].idSucursal);
                $("#hdnIdCargo").val(data.Usuario[i].IdCargo);
            });
            
            if ($.trim($("#hdnIdPerfil").val()) === "1") $(".perfilNoAdmin").remove();
            else $(".perfilConsulta").remove();
            //if ($.trim($("#hdnIdPerfil").val()) == "3") else $(".perfilAdmin").remove();
            
        },
        error: function (request, status, error) {
            alert(error);
        }
    });
}

