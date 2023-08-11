function encodeAndDecodeMessages() {
    const [messageArea, receiveArea] = Array.from(document.getElementsByTagName("textarea"));
    const [encodeBtn, decodeBtn] = Array.from(document.getElementsByTagName("button"));

    encodeBtn.addEventListener("click", encode);
    decodeBtn.addEventListener("click", decode);

    function encode() {
        receiveArea.value = String.fromCharCode(...messageArea.value
            .split("")
            .map(c => c.charCodeAt(0) + 1)
        );

        messageArea.value = "";
    }

    function decode() {
        receiveArea.value = String.fromCharCode(...receiveArea.value
            .split("")
            .map(c => c.charCodeAt(0) - 1)
        );
    }
}