$(document).ready(function () {
    $('#CoverImage').on('change', function () {

        if (this.files && this.files[0]) {
            $('.CoverImage-preview')
                .attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
        }

    });
});