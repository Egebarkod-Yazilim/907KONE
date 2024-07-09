$(document).ready(function () {
    const multipleCancelButton = new Choices(
        '.role-select',
        {
            allowHTML: true,
            removeItemButton: true,
        }
    );

    const multipleCancelButton2 = new Choices(
        '.firm-select',
        {
            allowHTML: true,
            removeItemButton: true,
        }
    );


    //let image;
    //let width;
    //let height;

    //let cropper;

    //function cropPicture(obj) {
    //    document.getElementById('userPicture').src = window.URL.createObjectURL(obj.files[0]);

    //    image = document.getElementById('userPicture');

    //    width = image.clientWidth;
    //    height = width / 3.5;

    //    console.log(width);

    //    cropper = new Cropper(image, {
    //        viewMode: 3,
    //        dragMode: 'move',
    //        aspectRatio: width / height,
    //        autoCropArea: 0.90,
    //        restore: false,
    //        guides: false,
    //        center: false,
    //        highlight: false,
    //        cropBoxMovable: false,
    //        cropBoxResizable: false,
    //        toggleDragModeOnDblclick: false,
    //        ready: function () {
    //            croppable = true;
    //        }
    //    });

    //    image.addEventListener('cropstart', (event) => {
    //        console.log(event.detail.originalEvent);
    //        console.log(event.detail.action);
    //    });
    //}

    //document.getElementById('btn-crop').addEventListener('click', function () {
    //    var initialAvatarURL;
    //    var canvas;

    //    if (cropper) {
    //        canvas = cropper.getCroppedCanvas();
    //        var canvas;
    //        var result = document.getElementById('result');

    //        canvas = cropper.getCroppedCanvas({
    //            width: width,
    //            height: height,
    //        });
    //        var roundedCanvas = getRoundedCanvas(canvas);

    //        initialAvatarURL = image.src;
    //        image.src = roundedCanvas.toDataURL();

    //        fetch(image.src)
    //            .then(res => res.blob())
    //            .then(blob => {
    //                const file = new File([blob], "userImage.png", {
    //                    type: 'image/png'
    //                });
    //                var formData = new FormData();
    //                formData.append("userImage", file);
    //                formData.append('UserName', $('#UserName').val());

    //                result.appendChild(cropper.getCroppedCanvas());

    //                $.ajax({
    //                    dataType: 'json',
    //                    type: 'POST',
    //                    url: '/User/AddOrUpdateUser',
    //                    data: formData,
    //                    processData: false,
    //                    contentType: false,
    //                    enctype: 'multipart/form-data',
    //                    success: function (data) {
    //                        var result = jQuery.parseJSON(data);

    //                        if (result.ResultStatus == 0) {
    //                            toastr.success(`${result.Message}`);
    //                            setTimeout(
    //                                function () {
    //                                    location.reload();
    //                                }, 2000);
    //                        }
    //                        else {
    //                            toastr.error(`${result.Message}`);
    //                        }
    //                    },
    //                    error: function (err) {
    //                        console.log(err);
    //                        toastr.error(`Bir hata oldu.`)
    //                    }
    //                });
    //            });
    //    }

    //});

    //function getRoundedCanvas(sourceCanvas) {
    //    var canvas = document.createElement('canvas');
    //    var context = canvas.getContext('2d');
    //    var width = sourceCanvas.width;
    //    var height = sourceCanvas.height;

    //    canvas.width = width;
    //    canvas.height = height;
    //    context.imageSmoothingEnabled = true;
    //    context.drawImage(sourceCanvas, 0, 0, width, height);
    //    context.globalCompositeOperation = 'destination-in';
    //    context.beginPath();

    //    CanvasRenderingContext2D.prototype.roundRect = function (x, y, width, height, radius) {
    //        if (width < 2 * radius) radius = width / 2;
    //        if (height < 2 * radius) radius = height / 2;
    //        this.beginPath();
    //        this.moveTo(x + radius, y);
    //        this.arcTo(x + width, y, x + width, y + height, radius);
    //        this.arcTo(x + width, y + height, x, y + height, radius);
    //        this.arcTo(x, y + height, x, y, radius);
    //        this.arcTo(x, y, x + width, y, radius);
    //        this.closePath();
    //        return this;
    //    }

    //    var posX = (canvas.width / 2) - 100;
    //    var posY = (canvas.height / 2) - 100;

    //    context.roundRect(0, 0, width, height, 15);
    //    context.fill();

    //    return canvas;
    //}
});