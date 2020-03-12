
var editor, viewer, formatId;

function format() {
    'use strict';
    if (formatId) {
        window.clearTimeout(formatId);
    }
    formatId = window.setTimeout(function () {
        var options, raw, beautified;

        options = {
            indent: '    '
        };

        options.indent = '  ';

        raw = document.getElementById('raw').value;

        beautified = cssbeautify(raw, options);

        document.getElementById('beautified').value = beautified;

        formatId = undefined;
    }, 42);
}

window.onload = function () {
    'use strict';
 
    format();
};

