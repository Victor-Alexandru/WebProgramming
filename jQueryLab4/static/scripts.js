$(document).ready(function () {
    // all custom jQuery will go here
    function highlightSelected() {
        let selectedText = window.getSelection().toString();
        let allText = $('body').text();
        allText = allText.split(' ');

        allText.forEach((element) => {
            if (element.toLowerCase() == selectedText.toLowerCase()) {
                element = "<span class=\"highlighted\">" + element + "</span>"
            };
        })

        $('body').text(allText.join(' '));

    }
    $(document).on('mouseup', highlightSelected)
});