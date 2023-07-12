function createDictionary(terms) {
    const dictionary = {};

    terms.forEach(t =>
        Object.entries(JSON.parse(t))
            .forEach(([name, definition]) => dictionary[name] = definition)
    );

    Object.entries(dictionary)
        .sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(([term, definition]) => console.log(`Term: ${term} => Definition: ${definition}`));
}