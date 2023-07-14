function scheduleMeetings(arr) {
    Object.entries(arr.reduce((acc, curr) => {
        const [weekday, name] = curr.split(" ");

        if (!acc.hasOwnProperty(weekday)) {
            acc[weekday] = name;
            console.log(`Scheduled for ${weekday}`);
        } else {
            console.log(`Conflict on ${weekday}!`);
        }

        return acc;
    }, {})).forEach(([weekday, name]) => console.log(`${weekday} -> ${name}`));
}