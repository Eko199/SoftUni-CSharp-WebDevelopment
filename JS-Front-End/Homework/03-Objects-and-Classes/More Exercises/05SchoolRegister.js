function solve(studentsLastYear) {
    const studentsNextYear = studentsLastYear.reduce((acc, curr) => {
        let [student, grade, score] = curr
            .split(", ")
            .map(x => x.split(" ").pop());

        grade = Number(grade) + 1;
        score = Number(score);

        if (grade > 12 || score < 3) {
            return acc;
        }

        if (!acc.hasOwnProperty(grade)) {
            acc[grade] = {
                students: [],
                avgScore: 0
            };
        }

        acc[grade].students.push(student);
        acc[grade].avgScore += score;

        return acc;
    }, {});

    Object.keys(studentsNextYear)
        .sort((a, b) => Number(a) - Number(b))
        .forEach(grade => 
            console.log(`${grade} Grade
List of students: ${studentsNextYear[grade].students.join(", ")}
Average annual score from last year: ${(studentsNextYear[grade].avgScore / studentsNextYear[grade].students.length).toFixed(2)}\n`)
        );
}