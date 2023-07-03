function charsInRange(a, b) {
    const start = Math.min(a.charCodeAt(0), b.charCodeAt(0));
    const end = Math.max(a.charCodeAt(0), b.charCodeAt(0));

    let chars = [];

    for (let i = start + 1; i < end; i++) {
        chars.push(String.fromCharCode(i));
    }

    console.log(chars.join(' '));
}