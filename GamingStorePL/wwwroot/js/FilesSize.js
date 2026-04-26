$.validator.addMethod('filesize', function (value, element, param) {

    if (this.optional(element) || !element.files.length)
        return true;

    var maxSizeInBytes = param * 1024 * 1024;

    return element.files[0].size <= maxSizeInBytes;
});