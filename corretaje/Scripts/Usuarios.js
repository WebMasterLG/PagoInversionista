//// <reference path="../jquery-2.1.1.intellisense.js" />
var indexActualiza;

$(document).ready(function () {
    $("#divItemDialog").dialog({ autoOpen: false, width: 'auto', modal: true });
    CargarPantalla();
    $("#tblUsuarios").dataTable();
    //$("#txtRutUsuario").Rut({
    //    on_error: function () { $("#txtRutUsuario").removeClass().addClass("input-error"); },
    //    on_success: function () { $("#txtRutUsuario").removeClass(); }
    //});

    $("body").on("click", "#divNuevoItem", function () {
        LimpiarPantalla();

        $("#btnAccionRegistro").val("Grabar");
        $("#btnAccionRegistro").addClass("btnGrabarRegistro");
        $("#btnAccionRegistro").removeClass("btnActualizarRegistro");
        $("#divItemDialog").dialog("open");
    });


 


    $("body").on("blur", "#txtEmail", function () {
        if (!validarEmail($(this).val())) $(this).addClass("input-error");
        else $(this).removeClass("input-error");
    });
    
    $("body").on("click", "#imgEditarRegistro", function () {
        LimpiarPantalla();
        indexActualiza = $(this).closest("tr").index();
        //var rut = $(this).attr("rut_usuario");
        $("#btnAccionRegistro").val("Actualizar");
        $("#btnAccionRegistro").removeClass("btnGrabarRegistro");
        $("#btnAccionRegistro").addClass("btnActualizarRegistro");
        $.ajax({
            type: "POST",
            url: "Usuarios/CargarUsuario",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ "Usuario": $(this).closest("tr").find("#hdnIdUsuario").val() }),
            dataType: "json",
            async: false,
            success: function (data) {
                $("#txtNombre").val(data.Usuario.Nombre);
                $("#txtPaterno").val(data.Usuario.Paterno);
                $("#txtMaterno").val(data.Usuario.Materno);
                $("#txtRutUsuario").val(data.Usuario.Rut);
                $("#ddlPerfil").val(data.Usuario.IdPerfil);
                $("#ddlSubperfil").val(data.Usuario.IdSubPerfil);
                $("#ddlArea").val(data.Usuario.IdArea);
                $("#ddlCargo").val(data.Usuario.IdCargo);
                $("#txtEmail").val(data.Usuario.Email);
                $("#hdnIdUsuarioRegistro").val(data.Usuario.Id);
                $("#ddlSupervisor").val(data.Usuario.IdSupervisor);
                $("#ddlSucursal").val(data.Usuario.idSucursal);
                $("#divItemDialog").dialog("open");
            },
            error: function (request, status, error) {
                alert(error);
            }
        });
    });

    $("body").on("click", "#imgEliminarRegistro", function () {
        var elem = this;
        if (confirm("Confirma que desea borrar a " + $.trim($(elem).closest("tr").find("td:eq(0)").text() + " (Id: " + $.trim($(elem).closest("tr").find("#hdnIdUsuario").val()) + ")"))) {
            $.ajax({
                type: "POST",
                url: "Usuarios/EliminarUsuario",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ "Usuario": $(elem).closest("tr").find("#hdnIdUsuario").val() }),
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.Exitoso == 1) {                        
                        $(elem).closest("tr").remove();
                        $("#tblUsuarios").dataTable();
                        alert("Usuario Eliminado exitosamente");
                    }
                    else alert("Hubo un error al eliminar el usuario");
                },
                error: function (request, status, error) {
                    alert(error);
                }
            });
        }
    });

    $("body").on("click", ".btnActualizarRegistro", function () {
        ValidarFormulario();
        if ($("#tblItemUsuario .input-error").length > 0) alert("Los Campos en rojo son obligatorios");
        else {
            var strRut = $.trim($("#txtRutUsuario").val()).split('-');
            var jUsuario = {
                "Nombre": $.trim($("#txtNombre").val()),
                "Paterno": $.trim($("#txtPaterno").val()),
                "Materno": $.trim($("#txtMaterno").val()),
                "Rut": strRut[0].split('.').join(''),
                "DV": strRut[1],
                "idSucursal": $.trim($("#ddlSucursal").val()),
                "IdPerfil": $.trim($("#ddlPerfil").val()),
                "IdSubPerfil": $.trim($("#ddlSubperfil").val()),
                "Perfil": $("#ddlPerfil").find("option:selected").text(),
                "Pass": $.trim($("#txtPass").val()),
                "Area": $("#ddlArea").find("option:selected").text(),
                "IdArea": $.trim($("#ddlArea").val()),
                "Cargo": $("#ddlCargo").find("option:selected").text(),
                "IdCargo": $.trim($("#ddlCargo").val()),
                "Email": $.trim($("#txtEmail").val()),
                "Id": $.trim($("#hdnIdUsuarioRegistro").val()),
                "IdSupervisor": $.trim($("#ddlSupervisor").val())
            };
            $.ajax({
                type: "POST",
                url: "Usuarios/ActualizarUsuario",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ "Usuario": jUsuario }),
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.Exitoso > 0) {
                        //$("#divItemDialog").dialog("close");                        
                        //$("#tblUsuarios tbody tr:eq(" + indexActualiza + ")").html("<td>" + jUsuario.Nombre + "</td><td>" + jUsuario.Usuario + "</td><td>" + jUsuario.Perfil + "</td><td>" + jUsuario.Area + "</td><td>" + jUsuario.Cargo + "</td><td>" + jUsuario.Email + "</td><td> <img src='/Images/editar.png' id='imgEditarRegistro' /><img src='/Images/borrar.png' id='imgEliminarRegistro' /><input type='hidden' value='" + jUsuario.Id + "' id='hdnIdUsuario' /></td>")
                        //indexActualiza = 0;
                        //$("#tblUsuarios").dataTable();
                        alert("Usuario actualizado exitosamente");
                        window.location.href = 'Usuarios';
                    }
                    else alert("Hubo un error al actualizar el registro");
                },
                error: function (request, status, error) {
                    alert(error);
                }
            });
        }
    });
});

function CargarPantalla() {

    ////Sucursal
    //$.ajax({
    //    type: "POST", url: "Usuarios/CargarSucursales", contentType: "application/json; charset=utf-8", dataType: "json", async: false, success: function (data) {
    //        $.each(data.Sucursales, function (i) {
    //            $("#ddlSucursal").append("<option value='" + data.Sucursales[i].IdTabla + "'>" + data.Sucursales[i].GlosaTabla + "</option>");
    //        });
    //    }, error: function (request, status, error) { alert(error); }
    //});

    ////Perfil
    $.ajax({
        type: "POST", url: "Maestros/CargarLista", contentType: "application/json; charset=utf-8", dataType: "json", async: false, data: JSON.stringify({ "idLista": 16 }), success: function (data) {
            $.each(data.Listas, function (i) {
                $("#ddlPerfil").append("<option value='" + data.Listas[i].IdLista + "'>" + data.Listas[i].Descripcion + "</option>");
            });

        }, error: function (request, status, error) { alert(error); }
    });

    ////Perfil
    $.ajax({
        type: "POST", url: "Maestros/CargarLista", contentType: "application/json; charset=utf-8", dataType: "json", async: false, data: JSON.stringify({ "idLista": 17 }), success: function (data) {
            $.each(data.Listas, function (i) {
                $("#ddlSubperfil").append("<option value='" + data.Listas[i].IdLista + "'>" + data.Listas[i].Descripcion + "</option>");
            });

        }, error: function (request, status, error) { alert(error); }
    });

    ////Area
    //$.ajax({
    //    type: "POST", url: "Usuarios/CargarArea", contentType: "application/json; charset=utf-8", dataType: "json", async: false, success: function (data) {
    //        $.each(data.Area, function (i) {
    //            $("#ddlArea").append("<option value='" + data.Area[i].IdTabla + "'>" + data.Area[i].GlosaTabla + "</option>");
    //        });
    //    }, error: function (request, status, error) { alert(error); }
    //});

    ////Cargo
    //$.ajax({
    //    type: "POST", url: "Usuarios/CargarCargo", contentType: "application/json; charset=utf-8", dataType: "json", async: false, success: function (data) {
    //        $.each(data.Cargo, function (i) {
    //            $("#ddlCargo").append("<option value='" + data.Cargo[i].IdTabla + "'>" + data.Cargo[i].GlosaTabla + "</option>");
    //        });
    //    }, error: function (request, status, error) { alert(error); }
    //});

    ////Usuarios
    //$.ajax({
    //    type: "POST", url: "Inspecciones/CargarUsuarios", contentType: "application/json; charset=utf-8", dataType: "json", async: false, success: function (data) {
    //        $.each(data.Usuario, function (i) {
    //            $("#ddlSupervisor").append("<option value='" + data.Usuario[i].Id + "'>" + data.Usuario[i].Nombre + " " + data.Usuario[i].Paterno + " " + data.Usuario[i].Materno + "</option>");
    //        });
    //    }, error: function (request, status, error) { alert(error); }
    //});
}

function ValidarFormulario() {
    $("#tblItemUsuario :text").each(function (i) {
        if ($(this).prop("id") !== "txtMaterno") {
            if ($.trim($(this).val()) == "") $(this).addClass("input-error");
            else {
                if ($(this).prop("id") == "txtEmail") {
                    if (!validarEmail($(this).val())) $(this).addClass("input-error");
                    else $(this).removeClass("input-error");
                } else if ($(this).prop("id") != "txtRutUsuario") $(this).removeClass("input-error");
            }
        }
    });
    $("#tblItemUsuario select").each(function (i) {
        if ($.trim($(this).val()) == "0") $(this).addClass("input-error");
        else $(this).removeClass("input-error");
    });

    /*
    if (($("#txtConfirmPass").val() != $("#txtPass").val()) || ($.trim($("#txtConfirmPass").val()) == "" || $.trim($("#txtPass").val()) == "")) {
        $("#txtPass").addClass("input-error");
        $("#txtConfirmPass").addClass("input-error");
    }
    else {
        $("#txtPass").removeClass("input-error");
        $("#txtConfirmPass").removeClass("input-error");
    }
    */
}

function LimpiarPantalla() {
    $("#tblItemUsuario :text").each(function (i) { $(this).val(""); $(this).removeClass("input-error"); });
    $("#tblItemUsuario select").each(function (i) { $(this).val(0); $(this).removeClass("input-error"); });
    $("#tblItemUsuario :password").each(function (i) { $(this).val(""); $(this).removeClass("input-error"); });
}