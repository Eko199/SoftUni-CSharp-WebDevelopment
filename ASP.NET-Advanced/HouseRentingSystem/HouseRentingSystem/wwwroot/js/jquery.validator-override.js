jQuery(function ($) {
    $.validator.addMethod('number', (value, element) =>
        this.optional(element) || /^-?(?:\d+)(?:(\.|,)\d+)?$/.test(value)
    );

    $.validator.methods.range = function (value, element, param) {
        var number = Number(value.replace(',', '.'));
        return this.optional(element) || number >= Number(param[0]) && number <= Number(param[1]);
    };
});