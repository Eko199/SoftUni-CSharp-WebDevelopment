function solve([n, ...rest]) {
    n = Number(n);

    const tasks = rest.slice(0, n)
        .reduce((acc, curr) => {
            const [assignee, taskId, title, status, points] = curr.split(":");

            if (!acc.hasOwnProperty(assignee)) {
                acc[assignee] = [];
            }

            acc[assignee].push({ taskId, title, status, points: Number(points) });
            return acc;
        }, {});

    const commandExecutor = {
        "Add New": addTask,
        "Change Status": changeStatus,
        "Remove Task": removeTask
    };
    
    rest.slice(n).forEach(cmd => {
        const [command, assignee, ...rest] = cmd.split(":");
        commandExecutor[command](assignee, ...rest);
    });

    const statusPoints = Object.values(tasks)
        .flat()
        .reduce((acc, curr) => {
            acc[curr.status] += curr.points;
            return acc;
        }, {
            "ToDo": 0,
            "In Progress": 0,
            "Code Review": 0,
            "Done": 0
        });
    
    console.log(`ToDo: ${statusPoints["ToDo"]}pts`);
    console.log(`In Progress: ${statusPoints["In Progress"]}pts`);
    console.log(`Code Review: ${statusPoints["Code Review"]}pts`);
    console.log(`Done Points: ${statusPoints["Done"]}pts`);

    const allPoints = Object.values(statusPoints).reduce((acc, curr) => acc + curr, 0);

    console.log(statusPoints["Done"] >= allPoints / 2 
        ? "Sprint was successful!" 
        : "Sprint was unsuccessful...");

    function addTask(assignee, taskId, title, status, points) {
        if (!tasks.hasOwnProperty(assignee)) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        tasks[assignee].push({ taskId, title, status, points: Number(points) });
    }

    function changeStatus(assignee, taskId, newStatus) {
        if (!tasks.hasOwnProperty(assignee)) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        const task = tasks[assignee].find(t => t.taskId === taskId);

        if (!task) {
            console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
            return;
        }

        task.status = newStatus;
    }

    function removeTask(assignee, index) {
        if (!tasks.hasOwnProperty(assignee)) {
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        if (index < 0 || index >= tasks[assignee].length) {
            console.log("Index is out of range!");
            return;
        }

        tasks[assignee].splice(index, 1);
    }
}

solve([
 '5','Kiril:BOP-1209:Fix MinorBug:ToDo:3','Mariya:BOP-1210:Fix MajorBug:In Progress:3','Peter:BOP-1211:POC:Code Review:5','Georgi:BOP-1212:InvestigationTask:Done:2','Mariya:BOP-1213:New AccountPage In Progress:13','Add New:Kiril:BOP-1217:AddInfo Page:In Progress:5','Change Status:Peter:BOP1290:ToDo','Remove Task:Mariya:1','Remove Task:Joro:1',
 ]);