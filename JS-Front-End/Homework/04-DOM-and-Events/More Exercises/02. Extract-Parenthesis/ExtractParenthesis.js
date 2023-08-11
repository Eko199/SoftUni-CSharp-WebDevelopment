function extract(content) {
    const text = Array.from(
        document.getElementById(content).textContent.matchAll(/(.+)/)
    ).join("; ");
    
    return text;
}