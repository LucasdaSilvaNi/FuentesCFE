
function OnEliminarAct(result) {
    
    var varEmpleado = $("#id_empleado").val();
    var varOficina = $("#id_oficina").val();

    $.ajax({
        url: '/CapturaWeb/RefrescaTotales',
        type: 'POST',
        data: { id_empleado: varEmpleado, id_oficina: varOficina },
        success: function (result) {
            $("#TotalCargable").text(result.Cargable);
            $("#TotalNoCargable").text(result.NoCargable);
            $("#TotalHoras").text(result.Horas);
            $("#TotalGastos").text(result.Gastos);
        },
        error: function (result) {

            //alert(result.MensajeError);
        }
    });
}

function OnSuccessSave(result) {
    jQuery.noConflict();
    if (result.Resultado == 'S_OK') {
        
        if (result.Modulo == 'GrabarCaptura') {
            $("#TotalCargable").text(result.Cargable);
            $("#TotalNoCargable").text(result.NoCargable);
            $("#TotalHoras").text(result.Horas);
            $("#TotalGastos").text(result.Gastos);

            $("#Concepto").prop('selectedIndex', 0);
            $("#Horas").val('0');
            $("#Trabajo").val('');
            $("#NoCargableTrabajo").val('');            
            $("#ClienteC").val('');
            $("#NombreCliente").text('');
            $("#ServicioCaptura").empty();
            $("#ServicioCaptura").val('-1');
            $("#JobCaptura").empty();
            $("#JobCaptura").val('-1');
            $("#Gastos").val('0');

        }
        if (result.Modulo == 'GrabarCambioClave') {
            $("#PasswordActual").val('');
            $("#Password").val('');
            $("#ConfPassword").val('');
        }

        $("#lblAlertSuccessModal").text(result.MensajeError);
        if (result.Modulo == 'GrabarCaptura') {
            var varEmpleado = $("#id_empleado").val();
            var varOficina = $("#id_oficina").val();

            $.ajax({
                url: '/CapturaWeb/RegistroCargable',
                type: 'POST',
                data: { id_empleado: varEmpleado, id_oficina: varOficina },
                beforeSend: function () {
                    $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                    $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                    $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
                },
                success: function (result) {
                    $("#divCargableGrid").html(result);
                    $("#divCargableGridPanel").show();
                    $("#myModalVerifica").modal('hide');
                },
                error: function (result) {

                    //alert(result.MensajeError);
                }
            });

            $.ajax({
                url: '/CapturaWeb/RegistroNoCargable',
                type: 'POST',
                data: { id_empleado: varEmpleado, id_oficina: varOficina },
                beforeSend: function () {
                    $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                    $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                    $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
                },
                success: function (result) {
                    $("#divNoCargableGrid").html(result);
                    $("#divNoCargableGridPanel").show();
                    $("#myModalVerifica").modal('hide');
                },
                error: function (result) {
                    //alert(result.MensajeError);
                }
            });
        }
        $("#myModalSuccess").modal("show");
        setTimeout(function () { $("#myModalSuccess").modal('hide'); }, 3500);
        /*
        $("#lblAlertSuccess").text(result.MensajeError);
        //window.location = result.Archivo;
        $("#alert_success").removeClass('hide').addClass('hide', 5000).fadeOut("slow");
        $("#alert_warning").addClass('hide');
        $("#alert_error").addClass('hide');*/        
    }
    else {
        
        if (result.Resultado == 'S_ADVERTENCIA') {
            $("#lblAlertWarningModal").text(result.MensajeError);
            $("#myModalWarning").modal("show");
            setTimeout(function () { $("#myModalWarning").modal('hide'); }, 5000);
            //$("#lblAlertWarning").text(result.MensajeError);
            //$("#alert_warning").removeClass('hide').addClass('hide', 5000).fadeOut("slow");
        }
        else {
            $("#lblAlertDangerModal").text(result.MensajeError);
            $("#myModalDanger").modal("show");
            setTimeout(function () { $("#myModalDanger").modal('hide'); }, 5000);
            /*$("#lblAlertError").text(result.MensajeError);
            $("#alert_error").removeClass('hide').addClass('hide', 5000).fadeOut("slow");*/
            
        }
    }
    $(".preloader").hide();
}

function OnBeginSave() {
    /*$("#alert_warning").addClass('hide');
    $("#lblAlertWarning").text('');

    $("#alert_error").addClass('hide');
    $("#lblAlertError").text('');*/

    $(".preloader").show();
}

function OnFailureSave(e) {
    $("#lblAlertDangerModal").text(e.responeText);
    $("#myModalDanger").modal("show");
    /*$("#lblAlertError").text(e.responeText);
    $("#alert_error").removeClass('hide').addClass('hide', 5000);;
    */
    $(".preloader").hide();
}

// forceNumeric() plug-in implementation
jQuery.fn.forceNumericDecimal = function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.which || e.keyCode;            
            //alert(key);
            if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
                // numbers   
                key >= 48 && key <= 57 ||
                // Numeric keypad
                key >= 96 && key <= 105 ||
                // comma, period and minus, . on keypad
               key == 190 || key == 110 || key == 109 || key == 173 || key == 189 || //key == 190 || key == 188  || key == 110 ||
                // Backspace and Tab and Enter
               key == 8 || key == 9 || key == 13 ||
                // Home and End
               key == 35 || key == 36 ||
                // left and right arrows
               key == 37 || key == 39 ||
                // Del and Ins
               key == 46 || key == 45) {
                    var vIn = $(this).val().indexOf('.');
                    if ((key == 190 || key == 110) && vIn > 0) {
                        return false;
                    }
                    var vLen = $(this).val().length;
                    if (vIn > 0) {
                        if (((vLen - vIn) > 2) && ((key >= 48 && key <= 57) || (key >= 96 && key <= 105)))
                            return false;
                    }
                    return true;
                }

            return false;
        });
    });
};

jQuery.fn.forceNumericInteger = function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.which || e.keyCode;
            
            if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
                // numbers   
                key >= 48 && key <= 57 ||
                // Numeric keypad
                key >= 96 && key <= 105 ||
                // comma, period and minus, . on keypad
               key == 109 || key== 173 || key== 231 || key== 189 ||//key == 190 || key == 110 || //key == 190 || key == 188 ||  key == 110 ||
                // Backspace and Tab and Enter
               key == 8 || key == 9 || key == 13 ||
                // Home and End
               key == 35 || key == 36 ||
                // left and right arrows
               key == 37 || key == 39 ||
                // Del and Ins
               key == 46 || key == 45) 
                return true;
            

            return false;
        });
    });
};

jQuery.fn.forceNumericDecimal5 = function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.which || e.keyCode;
            //alert(key);
            if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
                // numbers   
                key >= 48 && key <= 57 ||
                // Numeric keypad
                key >= 96 && key <= 105 ||
                // comma, period and minus, . on keypad
               key == 190 || key == 110 || key == 109 || key == 173 || key == 189 || //key == 190 || key == 188  || key == 110 ||
                // Backspace and Tab and Enter
               key == 8 || key == 9 || key == 13 ||
                // Home and End
               key == 35 || key == 36 ||
                // left and right arrows
               key == 37 || key == 39 ||
                // Del and Ins
               key == 46 || key == 45) {
                var vIn = $(this).val().indexOf('.');
                if ((key == 190 || key == 110) && vIn > 0) {
                    return false;
                }
                var vLen = $(this).val().length;
                if (vIn > 0) {
                    if (((vLen - vIn) > 5) && ((key >= 48 && key <= 57) || (key >= 96 && key <= 105)))
                        return false;
                }
                return true;
            }

            return false;
        });
    });
};


$(document).ready(function () {

    $(".inputDecimal").forceNumericDecimal();
    $(".inputInteger").forceNumericInteger();
    $(".inputDecimal5").forceNumericDecimal5();
    

    $("#btnBusquedaClie").click(function (event) {
        event.preventDefault();
        var url = "/CapturaWeb/Captura?id_cliente=" + $("#id_cliente_sel").val();
        window.location.href = url;
    });

    $("#ClienteC").blur(function () {
        var vCl = $("#ClienteC").val();
        var vSrv = '';
        if (vCl.length > 0) {
            $.ajax({
                url: "/CapturaWeb/ConsultarCliente",
                type: 'POST',
                data: { id_cliente: vCl },
                success: function (result) {
                    if (result.NombreCliente.length > 0) {
                        $("#NombreCliente").text(result.NombreCliente);

                        var selectedEntidadModel = $('#Id_EntidadCaptura');
                        selectedEntidadModel.empty();

                        //selectedDeviceModel.removeAttr('disabled');
                        $.each(result.Entidades, function (index, item) {

                            selectedEntidadModel.append(
                                $('<option/>', {
                                    value: item.id,
                                    text: item.descripcion
                                })
                            );
                        });

                        $.ajax({
                            url: '/Maestros/ServiciosGetDepto',
                            type: 'POST',
                            data: { id_cliente: vCl, id_socio: 'TODOS', id_encargado: 'TODOS', todos: value },
                            success: function (result) {
                                var selectedDeviceModel = $('#ServicioCaptura');
                                selectedDeviceModel.empty();

                                //selectedDeviceModel.removeAttr('disabled');
                                $.each(result, function (index, item) {
                                    if (index == 0)
                                        vSrv = item.id_servicio;

                                    selectedDeviceModel.append(
                                        $('<option/>', {
                                            value: item.id_servicio,
                                            text: item.Nombre_largo
                                        })
                                    );
                                });

                                $.ajax({
                                    url: '/Maestros/JobsGetDepto',
                                    type: 'POST',
                                    data: { id_cliente: vCl, id_socio: 'TODOS', id_encargado: 'TODOS', id_servicio: vSrv, todos: '' },
                                    beforeSend: function () {
                                        $('#JobCaptura').attr("disabled", "disabled");
                                    },
                                    success: function (result) {
                                        // when the AJAX succeeds refresh the dropdown list with 
                                        // the JSON values returned from the controller action
                                        var selectedDeviceModel = $('#JobCaptura');
                                        selectedDeviceModel.empty();

                                        selectedDeviceModel.removeAttr('disabled');
                                        $.each(result, function (index, item) {

                                            selectedDeviceModel.append(
                                                $('<option/>', {
                                                    value: item.id_job,
                                                    text: item.descripcion
                                                })
                                            );
                                        });

                                    }
                                });

                            }
                        });

                        $('#btnBusquedaClIda').removeAttr('disabled');
                        $("#ServicioCaptura").val('-1');
                        $("#JobCaptura").val('-1');
                    }
                    
                },
                error: function (result) {
                    alert(result.MensajeError);
                }
            });
        }

        $("#ServicioCaptura").val('-1');
        $("#JobCaptura").val('-1');
    });

    $("#btnBusquedaClIda").click(function (event) {

        var vCl = $("#ClienteC").val();
        event.preventDefault();
        var vSrv = '';
        if (vCl.length == 0) {
            var form = $('#form0');
            $.ajax({
                url: "/CapturaWeb/GrabaPantalla",
                type: 'POST',
                data: form.serialize(),
                beforeSend: function () {
                },
                success: function (result) {
                }
            });

            var url = "/CapturaWeb/BusquedaClientes"//?id_oficina=" + $("#Oficina_Busqueda").val();
            window.location.href = url;
        }
        else {
            $.ajax({
                url: "/CapturaWeb/ConsultarCliente",
                type: 'POST',
                data: { id_cliente:vCl},
                beforeSend: function () {
                    $('#btnBusquedaClIda').attr("disabled", "disabled");
                },
                success: function (result) {
                    if (result.NombreCliente.length > 0) {
                        $("#NombreCliente").text(result.NombreCliente);

                        var selectedEntidadModel = $('#Id_EntidadCaptura');
                        selectedEntidadModel.empty();

                        //selectedDeviceModel.removeAttr('disabled');
                        $.each(result.Entidades, function (index, item) {

                            selectedEntidadModel.append(
                                $('<option/>', {
                                    value: item.id,
                                    text: item.descripcion
                                })
                            );
                        });

                        $.ajax({
                            url: '/Maestros/ServiciosGetDepto',
                            type: 'POST',
                            data: { id_cliente: vCl, id_socio: 'TODOS', id_encargado: 'TODOS', todos: value },
                            success: function (result) {
                                var selectedDeviceModel = $('#ServicioCaptura');
                                selectedDeviceModel.empty();

                                //selectedDeviceModel.removeAttr('disabled');
                                $.each(result, function (index, item) {
                                    if (index == 0)
                                        vSrv = item.id_servicio;

                                    selectedDeviceModel.append(
                                        $('<option/>', {
                                            value: item.id_servicio,
                                            text: item.Nombre_largo
                                        })
                                    );
                                });

                                $.ajax({
                                    url: '/Maestros/JobsGetDepto',
                                    type: 'POST',
                                    data: { id_cliente: vCl, id_socio: 'TODOS', id_encargado: 'TODOS', id_servicio: vSrv, todos: '' },
                                    beforeSend: function () {
                                        $('#JobCaptura').attr("disabled", "disabled");
                                    },
                                    success: function (result) {
                                        // when the AJAX succeeds refresh the dropdown list with 
                                        // the JSON values returned from the controller action
                                        var selectedDeviceModel = $('#JobCaptura');
                                        selectedDeviceModel.empty();

                                        selectedDeviceModel.removeAttr('disabled');
                                        $.each(result, function (index, item) {

                                            selectedDeviceModel.append(
                                                $('<option/>', {
                                                    value: item.id_job,
                                                    text: item.descripcion
                                                })
                                            );
                                        });

                                    }
                                });

                            }
                        });                       

                        $('#btnBusquedaClIda').removeAttr('disabled');
                        $("#ServicioCaptura").val('-1');
                        $("#JobCaptura").val('-1');
                    }
                    else {
                        var url = "/CapturaWeb/BusquedaClientes"//?id_oficina=" + $("#Oficina_Busqueda").val();
                        window.location.href = url;
                    }
                },
                error: function (result) {
                    alert(result.MensajeError);
                }
            });
        }
        $("#ServicioCaptura").val('-1');
        $("#JobCaptura").val('-1');
    });

    $("#bntEliminarCapturaPrevia").click(function (event) {
        var varEmpleado = $("#id_empleado").val();
        var varOficina = $("#id_oficina").val();

        $.ajax({
            url: '/CapturaWeb/EliminarTodos',
            type: 'POST',
            data: { id_empleado: varEmpleado, id_oficina:varOficina },
            beforeSend: function () {
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntGrabarCapturaPrevia').attr("disabled", "disabled");
                $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
            },
            success: function (result) {
                if (result.Resultado == 'S_OK') {
                    $("#TotalCargable").text(result.Cargable);
                    $("#TotalNoCargable").text(result.NoCargable);
                    $("#TotalHoras").text(result.Horas);
                    $("#TotalGastos").text(result.Gastos);

                    $("#myModalVerifica").modal('hide');
                }
                else
                    alert(result.MensajeError);
            },
            error: function(result) {
                alert(result.MensajeError);
            }
        });
    });
    
    $("#btnGuardarDatosAll").click(function (event) {
        var varEmpleado = $("#id_empleado").val();
        var varOficina = $("#id_oficina").val();

        $.ajax({
            url: '/CapturaWeb/GrabarTodos',
            type: 'POST',
            data: { id_empleado: varEmpleado, id_oficina: varOficina },
            beforeSend: function () {
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
            },
            success: function (result) {
                if (result.Resultado == 'S_OK') {
                    $("#TotalCargable").text(result.Cargable);
                    $("#TotalNoCargable").text(result.NoCargable);
                    $("#TotalHoras").text(result.Horas);
                    $("#TotalGastos").text(result.Gastos);

                    $("#divCargableGridPanel").hide();
                    $("#divNoCargableGridPanel").hide();
                    $("#myModalVerifica").modal('hide');
                }
                else
                    alert(result.MensajeError);
            },
            error: function (result) {
                alert(result.MensajeError);
            }
        });
    });

    $("#bntGrabarCapturaPrevia").click(function (event) {
        var varEmpleado = $("#id_empleado").val();
        var varOficina = $("#id_oficina").val();

        $.ajax({
            url: '/CapturaWeb/GrabarTodos',
            type: 'POST',
            data: { id_empleado: varEmpleado, id_oficina: varOficina },
            beforeSend: function () {
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
            },
            success: function (result) {
                if (result.Resultado == 'S_OK') {
                    $("#TotalCargable").text(result.Cargable);
                    $("#TotalNoCargable").text(result.NoCargable);
                    $("#TotalHoras").text(result.Horas);
                    $("#TotalGastos").text(result.Gastos);

                    $("#divCargableGridPanel").hide();
                    $("#divNoCargableGridPanel").hide();

                    $("#myModalVerifica").modal('hide');
                }
                else
                    alert(result.MensajeError);
            },
            error: function (result) {
                alert(result.MensajeError);
            }
        });
    });

    $("#bntContinuarCapturaPrevia").click(function (event) {
        var varEmpleado = $("#id_empleado").val();
        var varOficina = $("#id_oficina").val();

        $.ajax({
            url: '/CapturaWeb/RegistroCargable',
            type: 'POST',
            data: { id_empleado: varEmpleado, id_oficina: varOficina },
            beforeSend: function () {
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
            },
            success: function (result) {
                $("#divCargableGrid").html(result);
                $("#divCargableGridPanel").show();
                $("#myModalVerifica").modal('hide');
            },
            error: function (result) {

                //alert(result.MensajeError);
            }        
        });

        $.ajax({
            url: '/CapturaWeb/RegistroNoCargable',
            type: 'POST',
            data: { id_empleado: varEmpleado, id_oficina: varOficina },
            beforeSend: function () {
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
            },
            success: function (result) {
                $("#divNoCargableGrid").html(result);
                $("#divNoCargableGridPanel").show();
                $("#myModalVerifica").modal('hide');
            },
            error: function (result) {
                //alert(result.MensajeError);
            }
        });

    });

    $("#bntCambiarCaptura").click(function (event) {
        jQuery.noConflict();

        if ($("#DiaDelInput").val() <= 0) {
            alert("Rango de Dias Invalido");

            $("#DiaDelInput").val($("#DiaDel").val());
            $("#DiaAlInput").val($("#DiaAl").val());
            return;
        }

        if ($("#DiaAlInput").val() > $("#DiaDelInput").val()) {
            alert("Rango de Dias Invalido");
            $("#DiaDelInput").val($("#DiaDel").val());
            $("#DiaAlInput").val($("#DiaAl").val());
            return;
        }

        $("#DiaDel").val($("#DiaDelInput").val());
        $("#DiaAl").val($("#DiaAlInput").val());
        $("#PeriodoTEP").val($("#PeriodoTEPInput").val());
        $("#myModal").modal("hide");
        event.stopPropagation();
    });

    $(function () {
        if ($("#ClientesGrid")) {
            try
            {
                pageGrids.ClientesGrid.onRowSelect(function (e) {
                    $("#id_cliente_sel").val(e.row.id_cliente);
                });
            }
            catch (err) {

            }
        }
    });

    //Captura Web
    $("#divClienteCaptura").show();
    $("#divServicioCaptura").show();
    $("#divJobCaptura").show();
    $("#divTrabajo").show();

    $("#divConceptoCaptura").hide();
    $("#divTrabajoNoCargable").hide();

    $("input[name=TipoCapturaWeb]:radio").change(function () {
        var value = $(this).val();
        if (value == 1) {
            $("#divClienteCaptura").hide();
            $("#divEntidadCliente").hide();
            $("#divServicioCaptura").hide();
            $("#divJobCaptura").hide();
            $("#divGastosCaptura").hide();            
            $("#divTrabajo").hide();

            $("#divConceptoCaptura").show();
            $("#divTrabajoNoCargable").show();
        }
        else {
            $("#divClienteCaptura").show();
            $("#divServicioCaptura").show();
            $("#divJobCaptura").show();
            $("#divGastosCaptura").show();
            $("#divTrabajo").show();
            $("#divEntidadCliente").show();

            $("#divConceptoCaptura").hide();
            $("#divTrabajoNoCargable").hide();
        }
    });


        

        $("#formData").submit(function () {
            $(".preloader").show();
            return true;
        });

        $("#fecha_a_emitir").datepicker({
            dateFormat: 'dd/mm/yy'
        });

        $("#fecha_tentativa_cobro").datepicker({
            dateFormat: 'dd/mm/yy'
        });

        $("#fecha_solicitud").datepicker({
            dateFormat: 'dd/mm/yy'
        });

        $("#Fecha").datepicker();
        $("#DiaDel").datepicker({
            dateFormat:'d'
        });

        $("#DiaAl").datepicker({
            dateFormat: 'd'
        });

        $(".preloader").hide();
        
       
        
        
        $("#btnBusquedaServIda").click(function (event) {
            jQuery.noConflict();
            var value = $('#ClienteC').val();
            // and send it as AJAX request to the newly created action
            $.ajax({
                url: '/Maestros/ServiciosTodosGet',
                type: 'POST',
                data: { id_socio: $('#Socio').val(), id_encargado: $('#Encargado').val(), id_cliente: value },
                beforeSend: function () {
                    $('#Servicio').attr("disabled", "disabled");
                },
                success: function (result) {
                    // when the AJAX succeeds refresh the dropdown list with 
                    // the JSON values returned from the controller action
                    var selectedDeviceModel = $('#ServicioCaptura');
                    selectedDeviceModel.empty();

                    selectedDeviceModel.removeAttr('disabled');
                    $.each(result, function (index, item) {

                        selectedDeviceModel.append(
                            $('<option/>', {
                                value: item.id_servicio,
                                text: item.Nombre_largo
                            })
                        );
                    });
                    $("#ServicioCaptura").val('-1');
                }
            });
        });

        $('#ServicioCaptura').change(function () {
            var value = $(this).val();
            // and send it as AJAX request to the newly created action
            $.ajax({
                url: '/Maestros/JobsTodosGet',
                type: 'POST',
                data: { id_cliente: $('#ClienteC').val(), id_socio: 'TODOS', id_encargado: 'TODOS', id_servicio: value, todos: 'd' , id_pais: $('#id_pais').val() },
                beforeSend: function () {
                    $('#JobCaptura').attr("disabled", "disabled");
                },
                success: function (result) {
                    // when the AJAX succeeds refresh the dropdown list with 
                    // the JSON values returned from the controller action
                    var selectedDeviceModel = $('#JobCaptura');
                    selectedDeviceModel.empty();

                    selectedDeviceModel.removeAttr('disabled');
                    $.each(result, function (index, item) {

                        selectedDeviceModel.append(
                            $('<option/>', {
                                value: item.id_job,
                                text: item.descripcion
                            })
                        );
                    });
                    $("#JobCaptura").val('-1');
                }
            });
        });

        if ($("#VerificaPendientes").length) {
            jQuery.noConflict();
            
            var pend = $("#VerificaPendientes").val();

            if (pend == 1) {
                $(".preloader").hide();
                $("#myModalVerifica").modal('show');
            }

        }

        if ($("#VerificaPendientesCliente").length) {
            jQuery.noConflict();

            var pend = $("#VerificaPendientesCliente").val();

            if (pend == 1) {
                
                var varEmpleado = $("#id_empleado").val();
                var varOficina = $("#id_oficina").val();

                $.ajax({
                    url: '/CapturaWeb/RegistroCargable',
                    type: 'POST',
                    data: { id_empleado: varEmpleado, id_oficina: varOficina },
                    beforeSend: function () {
                        $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                        $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                        $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
                    },
                    success: function (result) {
                        $("#divCargableGrid").html(result);
                        $("#divCargableGridPanel").show();
                        $("#myModalVerifica").modal('hide');
                    },
                    error: function (result) {

                        //alert(result.MensajeError);
                    }
                });

                $.ajax({
                    url: '/CapturaWeb/RegistroNoCargable',
                    type: 'POST',
                    data: { id_empleado: varEmpleado, id_oficina: varOficina },
                    beforeSend: function () {
                        $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                        $('#bntEliminarCapturaPrevia').attr("disabled", "disabled");
                        $('#bntContinuarCapturaPrevia').attr("disabled", "disabled");
                    },
                    success: function (result) {
                        $("#divNoCargableGrid").html(result);
                        $("#divNoCargableGridPanel").show();
                        $("#myModalVerifica").modal('hide');
                    },
                    error: function (result) {
                        //alert(result.MensajeError);
                    }
                });

                $.ajax({
                    url: '/CapturaWeb/RefrescaTotales',
                    type: 'POST',
                    data: { id_empleado: varEmpleado, id_oficina: varOficina },
                    success: function (result) {
                        $("#TotalCargable").text(result.Cargable);
                        $("#TotalNoCargable").text(result.NoCargable);
                        $("#TotalHoras").text(result.Horas);
                        $("#TotalGastos").text(result.Gastos);
                    },
                    error: function (result) {

                        //alert(result.MensajeError);
                    }
                });
            }

        }
    /*Solicitud*/
        if ($("#id_solicitud_captura").length) {
            jQuery.noConflict();

            var pend = $("#id_solicitud_captura").val() * 1;

            if (pend !== 0) {
                $(".preloader").hide();
                $("#myModalVerifica").modal('show');
            }
        }

        
        if ($("#id_solicitud_captura").length   ) {
            jQuery.noConflict();

            var pend = $("#id_solicitud_captura").val() * 1;
            $("#Detalle_id_solicitud").val(pend);
            if (pend !== 0) {

                $.ajax({
                    url: '/SolicitudFactura/Detalle',
                    type: 'POST',
                    data: { id_solicitud: pend},
                    beforeSend: function () {
                        /*$('#bntContinuarSolPrevia').attr("disabled", "disabled");
                        $('#bntEliminarSolPrevia').attr("disabled", "disabled");
                        $('#bntGrabarSolPrevia').attr("disabled", "disabled");*/
                    },
                    success: function (result) {
                        $("#divSolFacDetLst").html(result);
                        $("#divSolFacDet").show();
                        //$("#myModalVerifica").modal('hide');
                    },
                    error: function (result) {
                        //alert(result.MensajeError);
                    }
                });

                $.ajax({
                    url: '/SolicitudFactura/CabeceraDetalle',
                    type: 'POST',
                    data: { id_solicitud: pend },
                    beforeSend: function () {
                    },
                    success: function (result) {

                        var dtFechaTen = eval(result.Solicitud.fecha_tentativa_cobro.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
                        var dtM = dtFechaTen.getMonth() * 1 + 1;
                        var dtFechaTenS = dtFechaTen.getDate().toString().padStart(2, "0") + "/" + dtM.toString().padStart(2, "0") + "/" + dtFechaTen.getFullYear();
                        $("#fecha_tentativa_cobro").val(dtFechaTenS);

                        dtFechaTen = eval(result.Solicitud.fecha_a_emitir.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
                        dtM = dtFechaTen.getMonth() * 1 + 1;
                        dtFechaTenS = dtFechaTen.getDate().toString().padStart(2, "0") + "/" + dtM.toString().padStart(2, "0") + "/" + dtFechaTen.getFullYear();
                        $("#fecha_a_emitir").val(dtFechaTenS);

                        dtFechaTen = eval(result.Solicitud.fecha_solicitud.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
                        dtM = dtFechaTen.getMonth() * 1 + 1;
                        dtFechaTenS = dtFechaTen.getDate().toString().padStart(2, "0") + "/" + dtM.toString().padStart(2, "0") + "/" + dtFechaTen.getFullYear();
                        $("#fecha_solicitud").val(dtFechaTenS);

                        $("#Cliente").val(result.Solicitud.Cliente);
                        $("#id_cliente").val(result.Solicitud.Cliente);
                        $("#Servicio").val(result.Solicitud.Servicio);
                        $("#id_servicio").val(result.Solicitud.Servicio);
                        $("#Job").val(result.Solicitud.Job);
                        $("#id_entidad").val(result.Solicitud.id_entidad);
                        $("#id_entidad_D").val(result.Solicitud.id_entidad);
                        $("#tipo_entrega").val(result.Solicitud.tipo_entrega);
                        $("#total_solicitud").val(result.Solicitud.total_solicitud);
                        $("#Imprime_Moneda_Tep").val(result.Solicitud.Imprime_Moneda_Tep);
                        $("#tasa_cambio").val(result.Solicitud.tasa_cambio);
                        $("#tasa_cambio_D").val(result.Solicitud.tasa_cambio);                        
                        $("#total_solicitud_moneda_local").val(result.Solicitud.total_solicitud_moneda_local);
                        $("#facturar_en_perido").val(result.Solicitud.facturar_en_perido);
                        $("#codigo_moneda_impresion").val(result.Solicitud.codigo_moneda_impresion);
                        $("#Lenguaje_impresion_spanish").val(result.Solicitud.Lenguaje_impresion_spanish);
                        $("#instrucciones").val(result.Solicitud.instrucciones);
                        $("#Tasa_cambio_fiscal").val(result.Solicitud.Tasa_cambio_fiscal);

                        var Det = result.Detalles * 1;
                        var SelEntidad = '';
                        $.ajax({
                            url: '/Maestros/EntidadesClienteGet',
                            type: 'POST',
                            data: { id_cliente: result.Solicitud.Cliente },
                            beforeSend: function () {
                                $('#Detalle_linea').attr("disabled", "disabled");
                            },
                            success: function (result) {
                                // when the AJAX succeeds refresh the dropdown list with 
                                // the JSON values returned from the controller action
                                var selectedDeviceModel = $('#Detalle_linea');
                                selectedDeviceModel.empty();

                                selectedDeviceModel.removeAttr('disabled');
                                $.each(result, function (index, item) {

                                    /*if (id_linea_detalle == item.id_numerico)
                                        SelEntidad = item.id_numerico;*/

                                    selectedDeviceModel.append(
                                        $('<option/>', {
                                            value: item.id_numerico,
                                            text: item.descripcion
                                        })
                                    );
                                });
                                //$("#Detalle_linea").val(SelS);
                            }
                        });

                        $.ajax({
                            url: '/Maestros/DatosEntidadLegal',
                            type: 'POST',
                            data: { id_entidad: result.Solicitud.id_entidad },
                            beforeSend: function () {
                                $("#valor_impuesto_entidad").val(0);

                            },
                            success: function (result) {
                                if (result) {
                                    $("#valor_impuesto_entidad").val(result.valor_impuesto);
                                }
                            }
                        });

                        if (Det > 0) {
                            $("#Cliente").attr("disabled", "disabled");
                            $("#tasa_cambio").attr("disabled", "disabled");
                            $("#id_entidad").attr("disabled", "disabled");
                        }
                    },
                    error: function (result) {
                        //alert(result.MensajeError);
                    }
                });
            }
        }

        if ($("#CierreSolFac")) {
            $("#CierreSolFac").click(function (event) {
                jQuery.noConflict();

                var id_solicitud = $("#id_solicitud_captura").val();

                $.ajax({
                    url: '/SolicitudFactura/FinalizarCabecera',
                    type: 'POST',
                    data: { id_solicitud: id_solicitud },
                    beforeSend: function () {
                        $(".preloader").show();
                    },
                    success: function (result) {
                        $(".preloader").hide();

                        $("#lblAlertSuccessModal").text(result.MensajeError);

                        $("#myModalSuccess").modal("show");
                        setTimeout(function () { $("#myModalSuccess").modal('hide'); }, 3500);

                        window.location.replace('/SolicitudFactura/Captura');
                    },
                    error: function (result) {
                        $("#lblAlertDangerModal").text(result.MensajeError);

                        $("#myModalDanger").modal("show");
                        setTimeout(function () { $("#myModalDanger").modal('hide'); }, 3500);
                        //alert(result.MensajeError);
                    }
                });

            });
        }

        
        if ($("#bntGrabarSolPrevia")) {
            $("#bntGrabarSolPrevia").click(function (event) {
                jQuery.noConflict();

                var id_solicitud = $("#id_solicitud_captura").val();

                $.ajax({
                    url: '/SolicitudFactura/FinalizarCabecera',
                    type: 'POST',
                    data: { id_solicitud: id_solicitud },
                    beforeSend: function () {
                        $(".preloader").show();
                    },
                    success: function (result) {
                        $(".preloader").hide();

                        $("#lblAlertSuccessModal").text(result.MensajeError);

                        $("#myModalSuccess").modal("show");
                        setTimeout(function () { $("#myModalSuccess").modal('hide'); }, 3500);

                        window.location.replace('/SolicitudFactura/Captura');
                    },
                    error: function (result) {
                        $("#lblAlertDangerModal").text(result.MensajeError);

                        $("#myModalDanger").modal("show");
                        setTimeout(function () { $("#myModalDanger").modal('hide'); }, 3500);
                        //alert(result.MensajeError);
                    }
                });

            });
        }

        if ($("#bntEliminarSolPrevia")) {
            $("#bntEliminarSolPrevia").click(function (event) {
                jQuery.noConflict();

                var id_solicitud = $("#id_solicitud_captura").val();

                $.ajax({
                    url: '/SolicitudFactura/EliminarCabecera',
                    type: 'POST',
                    data: { id_solicitud: id_solicitud },
                    beforeSend: function () {
                        $(".preloader").show();
                    },
                    success: function (result) {
                        $(".preloader").hide();

                        $("#lblAlertSuccessModal").text(result.MensajeError);

                        $("#myModalSuccess").modal("show");
                        setTimeout(function () { $("#myModalSuccess").modal('hide'); }, 3500);

                        window.location.replace('/SolicitudFactura/Captura');
                    },
                    error: function (result) {
                        $("#lblAlertDangerModal").text(result.MensajeError);

                        $("#myModalDanger").modal("show");
                        setTimeout(function () { $("#myModalDanger").modal('hide'); }, 3500);
                        //alert(result.MensajeError);
                    }
                });

            });
        }

        if ($("#NewDetSolFac")) {
            $("#NewDetSolFac").click(function (event) {
                jQuery.noConflict();

                var id_cliente = $("#Cliente").val();
                var id_entidad = $("#id_entidad").val();

                if (id_cliente.length == 0 ||
                    id_cliente == 'TODOS') {
                    alert('Debe seleccionar un cliente valido');
                }
                else if (id_entidad.length == 0 ||
                    id_entidad == -1) {
                    alert('Debe seleccionar una Entidad valida');
                }
                else {
                    $("#Detalle_linea").val('');
                    $("#Detalle_Atencion_a").val('');
                    $("#Detalle_NationalID").val('');
                    $("#Detalle_conceptoS").val('');
                    $("#Detalle_valor").val(0);
                    $("#Detalle_Impuesto").val(0);
                    $("#Detalle_Total").val(0);
                    $("#Detalle_Valor_local").val(0);
                    $("#Detalle_descuento").val(0);
                    $("#Detalle_descripcion_comercial").val('');
                    $("#Detalle_descripcion").val('');
                    $("#myModalNewItem").modal('show');
                }
            });
        }

        if ($("#bntNuevoSolDet")) {
            $("#bntNuevoSolDet").click(function (event) {

                jQuery.noConflict();
                
                var success = 0;

                var id_sol = $("#id_solicitud_captura").val() * 1;

                if (id_sol === 0) {
                    var form = $('#frmCab');

                    $.ajax({
                        url: '/SolicitudFactura/GrabaCabecera',
                        type: 'POST',
                        data: form.serialize(),
                        beforeSend: function () {
                            $(".preloader").show();
                        },
                        success: function (result) {
                            $(".preloader").hide();

                            if (result.Resultado === "S_OK") {

                                var pend = result.id_solicitud;
                                $("#Detalle_id_solicitud").val(pend);
                                $("#id_solicitud_captura").val(pend);
                                $("#id_solicitud").val(pend);

                                $("#id_cliente").val($("#Cliente").val());
                                $("#id_entidad_D").val($("#id_entidad").val());

                                $("#Cliente").attr("disabled", "disabled");
                                $("#tasa_cambio").attr("disabled", "disabled");
                                $("#id_entidad").attr("disabled", "disabled");

                                var form = $('#frmDetalle');

                                $.ajax({
                                    url: '/SolicitudFactura/GrabaDetalle',
                                    type: 'POST',
                                    data: form.serialize(),
                                    beforeSend: function () {
                                        $(".preloader").show();
                                    },
                                    success: function (result) {
                                        $(".preloader").hide();

                                        if (result.Resultado !== "S_OK") {
                                            alert(result.MensajeError);
                                        }
                                        else {
                                            var pend = result.id_solicitud * 1;
                                            var total = result.total_solicitud * 1;
                                            var valorS = $('#tasa_cambio').val();
                                            var valLoc = total * valorS;

                                            $("#total_solicitud_moneda_local").val(valLoc);
                                            $("#total_solicitud").val(total);

                                            $.ajax({
                                                url: '/SolicitudFactura/Detalle',
                                                type: 'POST',
                                                data: { id_solicitud: pend },
                                                beforeSend: function () {
                                                    $('#bntCancelNuevoDet').attr("disabled", "disabled");
                                                    $('#bntNuevoSolDet').attr("disabled", "disabled");
                                                },
                                                success: function (result) {
                                                    $("#divSolFacDetLst").html(result);
                                                    $("#divSolFacDet").show();

                                                    $('#bntCancelNuevoDet').removeAttr('disabled');
                                                    $('#bntNuevoSolDet').removeAttr('disabled');
                                                },
                                                error: function (result) {
                                                    //alert(result.MensajeError);
                                                }
                                            });

                                            $("#myModalNewItem").modal('hide');
                                        }
                                    },
                                    error: function (result) {
                                        alert(result.MensajeError);
                                    }
                                });
                            }
                        },
                        error: function (result) {
                            //alert(result.MensajeError);
                        }
                    });
                }
                else {
                    var form = $('#frmDetalle');

                    $.ajax({
                        url: '/SolicitudFactura/GrabaDetalle',
                        type: 'POST',
                        data: form.serialize(),
                        beforeSend: function () {
                            $(".preloader").show();
                        },
                        success: function (result) {
                            $(".preloader").hide();

                            if (result.Resultado !== "S_OK") {
                                alert(result.MensajeError);
                            }
                            else {
                                var pend = result.id_solicitud;
                                var total = result.total_solicitud * 1;
                                var valorS = $('#tasa_cambio').val();
                                var valLoc = total * valorS;

                                $("#total_solicitud_moneda_local").val(valLoc);
                                $("#total_solicitud").val(total);

                                $.ajax({
                                    url: '/SolicitudFactura/Detalle',
                                    type: 'POST',
                                    data: { id_solicitud: pend },
                                    beforeSend: function () {
                                        $('#bntCancelNuevoDet').attr("disabled", "disabled");
                                        $('#bntNuevoSolDet').attr("disabled", "disabled");
                                    },
                                    success: function (result) {
                                        $("#divSolFacDetLst").html(result);
                                        $("#divSolFacDet").show();

                                        $('#bntCancelNuevoDet').removeAttr('disabled');
                                        $('#bntNuevoSolDet').removeAttr('disabled');
                                    },
                                    error: function (result) {
                                        //alert(result.MensajeError);
                                    }
                                });

                                $("#myModalNewItem").modal('hide');
                            }
                        },
                        error: function (result) {
                            alert(result.MensajeError);
                        }
                    });
                }

                

                if (success == 1) {

                }
                

            });
        }

        if ($("#GrabaSolFac")) {
            $("#GrabaSolFac").click(function (event) {
                jQuery.noConflict();
                
                var success = 0;

                var id_sol = $("#id_solicitud_captura").val() * 1;
                $("#Detalle_id_solicitud").val(id_sol);
                var form = $('#frmCab');

                $.ajax({
                    url: '/SolicitudFactura/GrabaCabecera',
                    type: 'POST',
                    data: form.serialize(),
                    beforeSend: function () {
                        $(".preloader").show();
                    },
                    success: function (result) {
                        $(".preloader").hide();

                        if (result.Resultado === "S_OK") {

                            var pend = result.id_solicitud;
                            $("#Detalle_id_solicitud").val(pend);
                            $("#id_solicitud_captura").val(pend);

                            $("#Cliente").attr("disabled", "disabled");
                            $("#tasa_cambio").attr("disabled", "disabled");
                            $("#id_entidad").attr("disabled", "disabled");

                            $("#lblAlertSuccessModal").text(result.MensajeError);

                            $("#myModalSuccess").modal("show");
                            setTimeout(function () { $("#myModalSuccess").modal('hide'); }, 3500);
                        }
                    },
                    error: function (result) {
                        alert(result.MensajeError);
                    }
                });
            });
        }
        $('#Detalle_conceptoS').change(function () {
            /*var val = $(this).val();
            var cliente = $("#Cliente").val();

            if ($("#Cliente").length == 0)
                cliente = $("#id_cliente").val();

            $.ajax({
                url: '/Maestros/DatosEntidadCliente',
                type: 'POST',
                data: { id_cliente: cliente, id_entidad: val },
                beforeSend: function () {
                    $("#Detalle_Atencion_a").val('');
                    $("#Detalle_NationalID").val('');

                },
                success: function (result) {
                    if (result) {
                        $("#Detalle_Atencion_a").val(result.atencion_a);
                        $("#Detalle_NationalID").val(result.nit);
                    }
                }
            });*/
        });

        $('#id_entidad').change(function () {
            var val = $(this).val();

            $.ajax({
                url: '/Maestros/DatosEntidadLegal',
                type: 'POST',
                data: { id_entidad: val },
                beforeSend: function () {
                    $("#valor_impuesto_entidad").val(0);

                },
                success: function (result) {
                    if (result) {
                        $("#valor_impuesto_entidad").val(result.valor_impuesto);
                    }
                }
            });
        });
        $('#Detalle_linea').change(function () {
            var value = $(this).val();
            var cliente = $("#Cliente").val();

            // and send it as AJAX request to the newly created action
            $.ajax({
                url: '/Maestros/DatosEntidadCliente',
                type: 'POST',
                data: { id_cliente: cliente, id_entidad: value },
                beforeSend: function () {
                    $("#Detalle_Atencion_a").val('');
                    $("#Detalle_NationalID").val('');
                },
                success: function (result) {
                    if (result) {
                        $("#Detalle_Atencion_a").val(result.atencion_a);
                        $("#Detalle_NationalID").val(result.nit);
                    }
                }
            });
        });

        $('#Detalle_valor').change(function () {
            var valorS = $('#Detalle_valor').val();
            var valorI = $('#valor_impuesto_entidad').val();
            var Tasa = $('#tasa_cambio_D').val();

            var valorImp = valorS * valorI / 100;
            $('#Detalle_Impuesto').val(valorImp);

            var valorT = (valorImp + (valorS*1)) * Tasa;
            $("#Detalle_Valor_local").val(valorT);

        });

        $('#tasa_cambio').change(function () {
            var valorS = $('#tasa_cambio').val();
            $('#tasa_cambio_D').val(valorS);
            var valorT = $("#total_solicitud").val();
            var valLoc = valorT * valorS;

            $("#total_solicitud_moneda_local").val(valLoc);
        });

        $('#total_solicitud').change(function () {
            var valorS = $('#tasa_cambio').val();
            var valorT = $("#total_solicitud").val();
            var valLoc = valorT * valorS;

            $("#total_solicitud_moneda_local").val(valLoc);
        });
    /**/

        $('#DiaDel').change(function () {
            var val = $(this).val();
            $('#DiaAl').val(val);

        });

        
        $('#id_oficina0').change(function () {
            var value = $(this).val();
            // and send it as AJAX request to the newly created action
            $.ajax({
                url: '/CapturaWeb/AsignaOficinaCaptura',
                type: 'POST',
                data: { id_oficina: value },
            });
        });

        $("#Socio").val('TODOS');
        $("#Encargado").val('TODOS');
        $("#Cliente").val('TODOS');
        $("#Servicio").val('TODOS');
        $("#Job").val('TODOS');

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

            var SelEntidad = '';
            var id_linea_detalle = $('#Detalle_linea').val();
            $.ajax({
                url: '/Maestros/EntidadesClienteGet',
                type: 'POST',
                data: { id_cliente: value },
                beforeSend: function () {
                    $('#Detalle_linea').attr("disabled", "disabled");
                },
                success: function (result) {
                    // when the AJAX succeeds refresh the dropdown list with 
                    // the JSON values returned from the controller action
                    var selectedDeviceModel = $('#Detalle_linea');
                    selectedDeviceModel.empty();

                    selectedDeviceModel.removeAttr('disabled');
                    $.each(result, function (index, item) {

                        if (id_linea_detalle == item.id_numerico)
                            SelEntidad = item.id_numerico;

                        selectedDeviceModel.append(
                            $('<option/>', {
                                value: item.id_numerico,
                                text: item.descripcion
                            })
                        );
                    });
                    $("#Detalle_linea").val(SelS);
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
                data: { id_job: value },
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
    });

