function solve(commands) {
    const users = new Set();

    const articles = commands.reduce((acc, curr) => {
        if (curr.includes(":")) {
            const [action, comment] = curr.split(": ");
            const [user, ...postOnArticle] = action.split(" ");
            const article = postOnArticle.pop();

            if (!users.has(user) || !acc.hasOwnProperty(article)) {
                return acc;
            }

            const [title, content] = comment.split(", ");
            acc[article].push({ user, title, content });
        } else {
            const [type, name] = curr.split(" ");

            if (type === "user") {
                users.add(name);
            } else if (type === "article") {
                acc[name] = [];
            }
        }

        return acc;
    }, {});

    Object.entries(articles)
        .sort((a, b) => b[1].length - a[1].length)
        .forEach(([article, comments]) => {
            console.log(`Comments on ${article}`);
            comments
                .sort((a, b) => a.user.localeCompare(b.user))
                .forEach(c => console.log(`--- From user ${c.user}: ${c.title} - ${c.content}`));
        });
}