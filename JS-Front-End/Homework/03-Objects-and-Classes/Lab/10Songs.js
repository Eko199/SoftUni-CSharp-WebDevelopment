function printTypeSongs([count, ...songs]) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const typeToPrint = songs.pop();

    songs
        .map(s => {
            const [typeList, name, time] = s.split("_");
            return new Song(typeList, name, time);
        })
        .filter(s => typeToPrint === "all" || s.typeList === typeToPrint)
        .forEach(s => console.log(s.name));
}