function editElement(element, matchStr, replaceStr) {
    let text = element.textContent;

    while (text.includes(matchStr)) {
        text = text.replace(matchStr, replaceStr);
    }

    element.textContent = text;
}