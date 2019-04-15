$(document).ready(function () {
    // all custom jQuery will go here
    function highlightSelected() {
        let selectedText = window.getSelection().toString();
        selectedText = selectedText.replace(/\s/g, '')
        if (!selectedText)
            return

        console.log(selectedText);
        $("h1,h2,h3,h4,h5,h6,br,p").each((index, elem) => {
            let elementTextArray = elem.innerText.split(" ");
            for (let i = 0; i < elementTextArray.length; i++) {
                if (elementTextArray[i].toLowerCase() == selectedText.toLowerCase()) {
                    elementTextArray[i] = "<span class=\"highlighted\">" + elementTextArray[i] + "</span>";
                }

            }

            elem.innerHTML = elementTextArray.join(" ");

        });

    }
    $(document).on('mouseup', highlightSelected)
});