function getHeroes(heroStrings) {
    heroStrings
        .map(str => {
            const [name, level, items] = str.split(" / ");

            return { 
                name, 
                level: Number(level), 
                items 
            };
        })
        .sort((h1, h2) => h1.level - h2.level)
        .forEach(h => console.log(`Hero: ${h.name}\nlevel => ${h.level}\nitems => ${h.items}`));
}