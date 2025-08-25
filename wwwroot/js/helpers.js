(function ($) {

    $.XenoByte_load_view = function (options) {
        /*appendtype : replace | inside | after | popup | before | html*/
        var settings = {
            url: null,
            data: null,
            contentType: null,
            dataType: null,
            processData: null,
            traditional: null,
            methodtype: 'GET',
            /*not ajax setting*/
            target: "",
            appendtype: 'replace',
            modalTitle: "",
            popupHasSave: false,
            errorTarget: "",
            success: function () { },
            onFailFunction: function (xhr, textStatus, errorThrown) { },
            beforeSend: function () {
                $('.preloader.checking').show();
            },
            complete: function () {
                $('.preloader.checking').hide();
            }
        };

        if (options) {
            $.extend(settings, options);
        }

        var request_settings = {
            cache: false,
            url: settings.url,
            type: settings.methodtype,
            data: settings.data,
            contentType: settings.contentType,
            dataType: settings.dataType,
            processData: settings.processData,
            traditional: settings.traditional,
            beforeSend: settings.beforeSend,
            complete: settings.complete
        };

        try {
            var requestxhr = $.ajax(request_settings);

            requestxhr.done(function (response, status, xhr) {

                let jsonRespones;

                try {
                    jsonRespones = jQuery.parseJSON(response);
                } catch (e) {

                }
                if (jsonRespones != undefined && jsonRespones.status != undefined && !jsonRespones.status && jsonRespones.errorMessage != false) {
                    $(settings.errorTarget).removeClass("d-none");


                    var StartMessage = ` <div class="select2-error-container alert alert-danger mb-4 " style="@(Model.IsNotNullOrEmpty()?"":"d-none")" id="main-error-container">
                    <ul class=" filled mb-0" id="parsley-id-7">`;
                    StartMessage += `<li class="parsley-required" id="errormapvalidationmsg"> ${jsonRespones.message} </li>`;
                    let EndMessage = `</ul>
                </div>`;

                    let FinalMessage = StartMessage + EndMessage;

                    $(settings.target).empty();
                    $(settings.errorTarget).empty().html(FinalMessage);
                    return;
                }
                if (settings.appendtype === 'replace') {
                    $(settings.target).empty().html(response);
                } else if (settings.appendtype === 'inside') {
                    $(settings.target).append(response);
                } else if (settings.appendtype === 'after') {
                    $(settings.target).after(response);
                } else if (settings.appendtype === 'before') {
                    $(settings.target).before(response);
                } else if (settings.appendtype === 'html') {
                    return response;
                } else if (settings.appendtype === 'popup') {
                    showPopup(response, settings.modalTitle, settings.popupHasSave); // Handle the 'popup' case
                }

                /* Functions called after view loaded */
                if (typeof settings.success === 'function') {
                    settings.success.call(this);
                }
                if (settings.errorTarget) {
                    $(settings.errorTarget).addClass("d-none");
                }

            });

            requestxhr.fail(function (XMLHttpRequest, textStatus, errorThrown) {
                var obj;
                try {
                    obj = jQuery.parseJSON(XMLHttpRequest.responseText);
                    console.error(obj.Message);
                } catch (e) {
                    console.error("Error parsing response: ", XMLHttpRequest.responseText);
                }

                if (typeof settings.onFailFunction === 'function') {
                    settings.onFailFunction(XMLHttpRequest, textStatus, errorThrown);
                }
            });
        } catch (e) {
            console.error(e.message);
        }
    };

    function showPopup(response, modalTitle, popupHasSave) {
        var modalId = 'modal-' + Date.now();
        var previousModal = $('.modal.fade.show');
        var modal = $('<div class="modal fade" tabindex="-1" role="dialog" id="' + modalId + '"></div>');
        var modalDialog = $('<div class="modal-dialog modal-lg" role="document"></div>');
        var modalContent = $('<div class="modal-content"></div>');
        var modalHeader = $('<div class="modal-header"><h5 class="modal-title">' + modalTitle + '</h5><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>');
        var modalBody = $('<div class="modal-body"></div>').html(response);
        if (popupHasSave == true && response.includes('form')) {
            var modalFooter = $('<div class="modal-footer flex-row-reverse"><button type="button" class="btn btn-secondary" data-dismiss="modal">إغلاق</button><button type="submit" onclick="SubmitClosestForm(this)" class="btn btn-primary">حفظ</button></div>');
        }
        else {
            var modalFooter = $('<div class="modal-footer flex-row-reverse"><button type="button" class="btn btn-secondary" data-dismiss="modal">إغلاق</button></div>');
        }

        modalContent.append(modalHeader, modalBody, modalFooter);
        modalDialog.append(modalContent);
        modal.append(modalDialog);
        var drop = $('.modal-backdrop');

        if (previousModal) {
            var currentZIndex = parseInt(drop.css('z-index'), 10);

            // Increase the z-index value
            var newZIndex = currentZIndex + 31; // Increase by 10 or any desired increment

            // Set the new z-index value
            drop.css('z-index', newZIndex);

        }
        modal.on('hidden.bs.modal', function () {


            var currentZIndex = parseInt(drop.css('z-index'), 10);

            // Increase the z-index value
            var newZIndex = currentZIndex - 31; // Increase by 10 or any desired increment

            // Set the new z-index value
            $('.modal-backdrop').css('z-index', newZIndex);



            $('#' + modalId).remove();
        });
        modal.modal('show');




        modal.on('shown.bs.modal', function () {
            var drop = $('.modal-backdrop');
            var currentZIndex = parseInt(drop.first().css('z-index'), 10);
            $(`#${modalId}`).css('z-index', currentZIndex + 1);
        });

    }

    (function ($) {

        $.XenoByte_call_action = function (options) {
            var settings = {
                url: null,
                data: null,
                contentType: false,
                dataType: null,
                async: true,
                processData: false,
                traditional: null,
                methodtype: 'POST',
                /*not ajax setting*/
                showSuccessmsg: true,
                beforeSend: null,
                success: function (data) { },
                error: function (err) {
                    HandleError(err);
                },
                complete: null,
                invalidCallback: function (data) {
                    HandleError(data);
                }
            };

            if (options) { $.extend(settings, options); }

            var request_settings = {
                async: settings.async,
                cache: false,
                url: settings.url,
                type: settings.methodtype,
                data: settings.data,
                contentType: settings.contentType,
                processData: settings.processData,
                dataType: settings.dataType,
                traditional: settings.traditional,
                beforeSend: function () {
                    if (typeof options.beforeSend === 'function') {
                        options.beforeSend(jqXHR, settings);
                    }
                    else {
                        $('.preloader.checking').show();
                    }
                },
                success: function (response, status, xhr) {
                    if (response.isError) {
                        settings.invalidCallback(response);
                    } else {
                        settings.success(response);
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    $('.preloader.checking').hide();
                    var response = xhr.responseJSON || JSON.parse(xhr.responseText || '{}');
                    console.error(response || errorThrown);
                    settings.error(response);
                },
                complete: function (jqXHR, settings) {
                    if (typeof options.complete === 'function') {
                        options.complete(jqXHR, settings);
                    }
                    else {
                        $('.preloader.checking').hide();
                    }
                }
            };

            try {
                $.ajax(request_settings);
            } catch (e) {
                console.error(e.message);
            }
        };

    }(jQuery));

    function HandleError(data) {
        $('#errorModal').remove()
        $('.preloader.checking').hide();

        $('body').append(data.popup);
        $('#errorModal').modal('show');
    }

}(jQuery));


function showXenoByteAPICallModalWithCallbackFunction(ModalId, warningTitle, warningMessage, okButtonText = "موافق", cancelButtonText = "الغاء", onConfirm, onCancel) {
    ModalId = ModalId || "Modal-XenoByte";

    let modalHtml = `
        <div class="modal fade" id="${ModalId}" tabindex="-1" role="dialog" aria-labelledby="gov-timeline-modal" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">${warningTitle}</h5>
                        <button class="btn btn-close" type="button" data-dismiss="modal" aria-label="Close" id="${ModalId}-close-btn">
                            <svg class="icon-back" width="20" height="20">
                                <use xlink:href="#svg-close-ico"></use>
                            </svg>
                        </button>
                    </div>
                    
                    <div class="modal-body">
                        <div class="px-3 pt-3">
                            <input class="search-input" id="apiCallVelue">
                            <small class="text-danger d-none" id="${ModalId}-error">⚠️ Required</small>
                        </div>
                        <div class="alert alert-info mt-3" role="alert">
                          ${warningMessage}
                        </div>
                    </div>
                    <div class="modal-footer d-flex justify-content-end">
                        <button class="btn btn-primary mx-3" type="button" id="${ModalId}-confirm-btn">${okButtonText}</button>
                        <button class="btn btn-dark" type="button" id="${ModalId}-cancel-btn">${cancelButtonText}</button>
                    </div>
                </div>
            </div>
        </div>
    `;

    $('body').append(modalHtml);

    $(`#${ModalId}`).modal('show');

    $(`#${ModalId}-confirm-btn`).on('click', function () {
        let inputVal = $("#apiCallVelue").val().trim();
        let errorMsg = $(`#${ModalId}-error`);

        if (inputVal === "") {
            $("#apiCallVelue")
                .addClass("is-invalid")
                .css({ border: "1px solid #ff4d4d", boxShadow: "0 0 8px #ff4d4d" });
            errorMsg.removeClass("d-none");
            return;
        }

        if (typeof onConfirm === 'function') {
            onConfirm();
        }
        $(`#${ModalId}`).modal('hide');
    });

    // Cancel button handler
    $(`#${ModalId}-cancel-btn`).on('click', function () {
        if (typeof onCancel === 'function') {
            onCancel();
        }
        $(`#${ModalId}`).modal('hide');
    });

    // X (close) button handler
    $(`#${ModalId}-close-btn`).on('click', function () {
        if (typeof onCancel === 'function') {
            onCancel();
        }
        $(`#${ModalId}`).modal('hide');
    });

    $(`#${ModalId}`).on('hidden.bs.modal', function () {
        $(`#${ModalId}`).remove();
    });
}