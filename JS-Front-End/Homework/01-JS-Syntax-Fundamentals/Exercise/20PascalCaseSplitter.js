function pascalSplit(text) {
    console.log(text.split(/(?=[A-Z])/).join(', '));
}