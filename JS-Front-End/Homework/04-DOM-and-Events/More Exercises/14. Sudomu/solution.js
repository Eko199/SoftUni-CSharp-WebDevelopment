function solve() {
    const matrix = Array.from(document.querySelectorAll("tbody tr"))
        .map(tr => Array.from(tr.getElementsByTagName("input")));

    const [checkBtn, clearBtn] = Array.from(document.getElementsByTagName("button"));
    const table = document.querySelector("table");
    const checkResult = document.querySelector("#check p");

    checkBtn.addEventListener("click", check);
    clearBtn.addEventListener("click", clear);

    function check() {
        const matrixNumbers = matrix.map(tr => tr.map(i => i.value));
        let isCompleted = true;

        for (const row of matrixNumbers) {
            const set = new Set(["1", "2", "3"]);
            row.forEach(set.delete.bind(set));

            if (set.size > 0) {
                isCompleted = false;
                break;
            }
        }

        if (isCompleted) {
            for (let i = 0; i < 3; i++) {
                const set = new Set(["1", "2", "3"]);

                set.delete(matrixNumbers[0][i]);
                set.delete(matrixNumbers[1][i]);
                set.delete(matrixNumbers[2][i]);

                if (set.size > 0) {
                    isCompleted = false;
                    break;
                }
            }
        }

        table.style.border = `2px solid ${isCompleted ? "green" : "red"}`;
        checkResult.style.color = isCompleted ? "green" : "red";
        checkResult.textContent = isCompleted 
            ? "You solve it! Congratulations!"
            : "NOP! You are not done yet...";
    }

    function clear() {
        matrix.forEach(tr => tr.forEach(i => i.value = ""));
        checkResult.textContent = "";
        table.style.border = "";
    }
}