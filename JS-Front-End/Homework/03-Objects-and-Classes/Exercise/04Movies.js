function getMovies(commands) {
    const movies = [];

    for (let command of commands) {
        if (command.includes("addMovie")) {
            movies.push({ name: command.replace("addMovie ", "") });
        } else if (command.includes("directedBy")) {
            const [movieName, director] = command.split(" directedBy ");
            const movie = movies.filter(m => m.name === movieName);

            if (movie.length > 0) {
                movie[0].director = director;
            }
        } else if (command.includes("onDate")) {
            const [movieName, date] = command.split(" onDate ");
            const movie = movies.filter(m => m.name === movieName);

            if (movie.length > 0) {
                movie[0].date = date;
            }
        }
    }

    movies
        .filter(m => m.hasOwnProperty("name") && m.hasOwnProperty("director") && m.hasOwnProperty("date"))
        .forEach(m => console.log(JSON.stringify(m)));
}