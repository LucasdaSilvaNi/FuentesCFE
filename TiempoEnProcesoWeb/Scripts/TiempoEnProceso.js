function imprimeBitacoraFact(docto) {
    NoFactura.value = docto;
    formData.submit();
}

$(document).ready(function () {

    $("#Cliente_HistorialCargosAcumulados").select2();

    $("#divEmp_HistorialCargosAcumulados").show();
    $("#divCl_HistorialCargosAcumulados").hide();

    var valEmp = $("#valEmpleado_HistorialCargosAcumulados").val();
    var valCl = $("#valCliente_HistorialCargosAcumulados").val();

    $("#Empleado_HistorialCargosAcumulados").val(valEmp);
    $("#Cliente_HistorialCargosAcumulados").val(valCl);
    $("input[name=Tipo_HistorialCargosAcumulados]:radio").change(function () {
        var value = $(this).val();
        if (value == 1) {
            $("#divEmp_HistorialCargosAcumulados").show();
            $("#divCl_HistorialCargosAcumulados").hide();
        }
        else {
            $("#divCl_HistorialCargosAcumulados").show();

            $("#divEmp_HistorialCargosAcumulados").hide();
        }
    });

    $("#formData").submit(function () {
        $(".preloader").show();
        return true;
    });

    $("#Fecha").datepicker({
        dateFormat: 'dd/mm/yy'
    });

    $(".preloader").hide();

    $("#Socio").val('TODOS');
    $("#Encargado").val('TODOS');
    $("#Cliente").val('TODOS');
    $("#Servicio").val('TODOS');
    $("#Job").val('TODOS');

    var valEs = $("#EsSocio").val();

    if (valEs == 1) {
        var valS = $("#ValSocio").val();

        $("#Socio").val(valS);
        $('#Socio').attr("disabled", "disabled");

        $.ajax({
            url: '/Maestros/EncargadosGet',
            type: 'POST',
            data: { id_socio: valS },
            beforeSend: function () {
                $('#Encargado').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Encargado');
                selectedDeviceModel.empty();

                selectedDeviceModel.removeAttr('disabled');
                $.each(result, function (index, item) {

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_empleado,
                            text: item.nombrecompleto
                        })
                    );
                });

                $("#Encargado").val('TODOS');
            }
        });



    }

    var valEs = $("#EsGerente").val();
    if (valEs == 1) {
        var valE = $("#ValEncargado").val();
        var valS = $("#ValSocio").val();

        $("#Encargado").val(valE);
        $("#Socio").val(valS);

        //$('#Socio').attr("disabled", "disabled");
        $('#Encargado').attr("disabled", "disabled");

        var value = $(this).val();
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/ClientesGet',
            type: 'POST',
            data: { id_socio: valS, id_encargado: valE },
            beforeSend: function () {
                $('#Cliente').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Cliente');
                selectedDeviceModel.empty();

                selectedDeviceModel.removeAttr('disabled');
                $.each(result, function (index, item) {

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_cliente,
                            text: item.razon_social
                        })
                    );
                });
                $("#Cliente").val('TODOS');
            }
        });
    }


    $('#Socio').change(function () {
        var value = $(this).val();
        var id_encargado = $('#Encargado').val();
        var SelEnc = 'TODOS';
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/EncargadosGet',
            type: 'POST',
            data: { id_socio: value },
            beforeSend: function () {
                $('#Encargado').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Encargado');
                selectedDeviceModel.empty();

                var EsGer = $("#EsGerente").val();
                if (EsGer == 0)
                    selectedDeviceModel.removeAttr('disabled');

                $.each(result, function (index, item) {

                    if (id_encargado == item.id_empleado)
                        SelEnc = id_encargado;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_empleado,
                            text: item.nombrecompleto
                        })
                    );

                    if (SelEnc !== "TODOS") {
                        var SelCl = 'TODOS';
                        var id_cliente = $('#Cliente').val();
                        $.ajax({
                            url: '/Maestros/ClientesGet',
                            type: 'POST',
                            data: { id_socio: value, id_encargado: SelEnc },
                            beforeSend: function () {
                                $('#Cliente').attr("disabled", "disabled");
                            },
                            success: function (result) {
                                // when the AJAX succeeds refresh the dropdown list with 
                                // the JSON values returned from the controller action
                                var selectedDeviceModel = $('#Cliente');
                                selectedDeviceModel.empty();

                                selectedDeviceModel.removeAttr('disabled');
                                $.each(result, function (index, item) {

                                    if (id_cliente == item.id_cliente)
                                        SelCl = item.id_cliente;

                                    selectedDeviceModel.append(
                                        $('<option/>', {
                                            value: item.id_cliente,
                                            text: item.razon_social
                                        })
                                    );
                                });
                                $("#Cliente").val(SelCl);
                            }
                        });
                    }
                });

                $("#Encargado").val(SelEnc);
            }
        });

       


    });

    $('#Encargado').change(function () {
        var value = $(this).val();
        var id_socio = $('#Socio').val();
        var id_cliente = $('#Cliente').val();
        var SelCl = 'TODOS';
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/ClientesGet',
            type: 'POST',
            data: { id_socio: id_socio, id_encargado: value },
            beforeSend: function () {
                $('#Cliente').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Cliente');
                selectedDeviceModel.empty();

                var EsGer = $("#EsGerente").val();
                if (EsGer == 0)
                    selectedDeviceModel.removeAttr('disabled');
                
                $.each(result, function (index, item) {

                    if (id_cliente == item.id_cliente)
                        SelCl = item.id_cliente;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_cliente,
                            text: item.razon_social
                        })
                    );
                });
                $("#Cliente").val(SelCl);
            }
        });

        var SelSocio = 'TODOS';
        $.ajax({
            url: '/Maestros/Socios_Encargado',
            type: 'POST',
            data: { id_encargado: value },
            beforeSend: function () {
                $('#Socio').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Socio');
                selectedDeviceModel.empty();

                var EsGer = $("#EsSocio").val();
                if (EsGer == 0)
                    selectedDeviceModel.removeAttr('disabled');

                $.each(result, function (index, item) {

                    if (id_socio == item.id_empleado)
                        SelSocio = item.id_empleado;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_empleado,
                            text: item.nombrecompleto
                        })
                    );
                });
                $("#Socio").val(SelSocio);
            }
        });
    });

    $('#Cliente').change(function () {
        var value = $(this).val();
        var SelS = 'TODOS';
        var id_servicio = $('#Servicio').val();
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/ServiciosGet',
            type: 'POST',
            data: { id_socio: $('#Socio').val(), id_encargado: $('#Encargado').val(), id_cliente: value },
            beforeSend: function () {
                $('#Servicio').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Servicio');
                selectedDeviceModel.empty();

                selectedDeviceModel.removeAttr('disabled');
                $.each(result, function (index, item) {

                    if (id_servicio == item.id_servicio)
                        SelS = item.id_servicio;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_servicio,
                            text: item.Nombre_largo
                        })
                    );
                });
                $("#Servicio").val(SelS);
            }
        });

        var SelEnc = 'TODOS';
        var id_encargado = $('#Encargado').val();
        $.ajax({
            url: '/Maestros/Encargado_Cliente',
            type: 'POST',
            data: { id_cliente: value },
            beforeSend: function () {
                $('#Encargado').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Encargado');
                selectedDeviceModel.empty();

                var EsGer = $("#EsGerente").val();
                if (EsGer == 0)
                    selectedDeviceModel.removeAttr('disabled');

                $.each(result, function (index, item) {

                    if (id_encargado == item.id_empleado)
                        SelEnc = item.id_empleado;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_empleado,
                            text: item.nombrecompleto
                        })
                    );
                });
                $("#Encargado").val(SelEnc);
            }
        });
    });

    $('#Servicio').change(function () {
        var value = $(this).val();
        var id_job = $('#Job').val();
        var SelJ = 'TODOS';
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/JobsGet',
            type: 'POST',
            data: { id_cliente: $('#Cliente').val(), id_socio: $('#Socio').val(), id_encargado: $('#Encargado').val(), id_servicio: value, id_pais: $('#id_pais').val() },
            beforeSend: function () {
                $('#Job').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Job');
                selectedDeviceModel.empty();

                selectedDeviceModel.removeAttr('disabled');
                $.each(result, function (index, item) {

                    if (id_job == item.id_job)
                        SelJ = item.id_job;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_job,
                            text: item.descripcion
                        })
                    );
                });
                $("#Job").val(SelJ);
            }
        });

        var id_cliente = $('#Cliente').val();
        var SelCl = 'TODOS';
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/Cliente_Servicio',
            type: 'POST',
            data: { id_servicio: value },
            beforeSend: function () {
                //$('#Cliente').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Cliente');
                selectedDeviceModel.empty();

                selectedDeviceModel.removeAttr('disabled');
                $.each(result, function (index, item) {

                    if (id_cliente == item.id_cliente)
                        SelCl = item.id_cliente;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_cliente,
                            text: item.razon_social
                        })
                    );
                });
                $("#Cliente").val(SelCl);
            }
        });
    });

    $('#Job').change(function () {
        var value = $(this).val();
        var id_servicio = $('#Servicio').val();
        var SelS = 'TODOS';
        // and send it as AJAX request to the newly created action
        $.ajax({
            url: '/Maestros/Servicio_Job',
            type: 'POST',
            data: { id_job: value},
            beforeSend: function () {
                $('#Servicio').attr("disabled", "disabled");
            },
            success: function (result) {
                // when the AJAX succeeds refresh the dropdown list with 
                // the JSON values returned from the controller action
                var selectedDeviceModel = $('#Servicio');
                selectedDeviceModel.empty();

                selectedDeviceModel.removeAttr('disabled');
                $.each(result, function (index, item) {

                    if (id_servicio == item.id_servicio)
                        SelS = item.id_servicio;

                    selectedDeviceModel.append(
                        $('<option/>', {
                            value: item.id_servicio,
                            text: item.Nombre_largo
                        })
                    );
                });
                $("#Servicio").val(SelS);
            }
        });
    });

    $("#btnFiltroBitacora").click(function () {

        $.ajax({
            url: '/BitacoraCobroFactura/DatosFiltrados',
            type: 'POST',
            data: { EsSocio: EsSocio.value, EsGerente: EsGerente.value, id_entidad: id_entidad.value },
            beforeSend: function () {
                $(".preloader").show();
            },
            success: function (result) {
                $("#divCargableGrid").html(result);
                $("#divCargableGridPanel").show();
                
                $(".preloader").hide();
            },
            error: function (result) {

                //alert(result.MensajeError);
            }
        });
    });
});
