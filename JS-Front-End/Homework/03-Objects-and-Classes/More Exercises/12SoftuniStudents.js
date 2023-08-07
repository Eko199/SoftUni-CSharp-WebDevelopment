function solve(commands) {
    const courses = commands.reduce((acc, curr) => {
        if (curr.includes(": ")) {
            const [courseName, courseCapacity] = curr.split(": ");

            if (!acc.hasOwnProperty(courseName)) {
                acc[courseName] = { 
                    capacity: Number(courseCapacity), 
                    students: []
                };
            } else {
                acc[courseName].capacity += Number(courseCapacity);
            }
        } else {
            const [_, username, credits, email, course] = curr.match(/^(.+)\[(\d+)] with email (.+) joins (.+)$/);
            
            if (!acc.hasOwnProperty(course) || acc[course].capacity <= acc[course].students.length) {
                return acc;
            }

            acc[course].students.push({
                username,
                email,
                credits: Number(credits)
            });
        }

        return acc;
    }, {});

    Object.entries(courses)
        .sort((a, b) => b[1].students.length - a[1].students.length)
        .forEach(([courseName, courseInfo]) => {
            console.log(`${courseName}: ${courseInfo.capacity - courseInfo.students.length} places left`);
            courseInfo.students
                .sort((a, b) => b.credits - a.credits)
                .forEach(s => console.log(`--- ${s.credits}: ${s.username}, ${s.email}`));
        });
}