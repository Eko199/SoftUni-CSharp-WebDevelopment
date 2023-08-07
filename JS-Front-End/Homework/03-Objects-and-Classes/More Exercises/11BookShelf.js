function solve(commands) {
    const bookShelves = commands.reduce((acc, curr) => {
        if (curr.includes(" -> ")) {
            const [id, genre] = curr.split(" -> ");

            if (acc.hasOwnProperty(id)) {
                return acc;
            }

            acc[id] = { genre, books: [] };
        } else if (curr.includes(": ")) {
            const [title, bookInfo] = curr.split(": ");
            const [author, genre] = bookInfo.split(", ");

            const shelf = Object.values(acc).find(s => s.genre === genre);

            if (!shelf) {
                return acc;
            }

            shelf.books.push({ title, author });
        }

        return acc;
    }, {});

    Object.entries(bookShelves)
        .sort((a, b) => b[1].books.length - a[1].books.length)
        .forEach(([id, shelf]) => {
            console.log(`${id} ${shelf.genre}: ${shelf.books.length}`);
            shelf.books
                .sort((a, b) => a.title.localeCompare(b.title))
                .forEach(b => console.log(`--> ${b.title}: ${b.author}`));
        });
}