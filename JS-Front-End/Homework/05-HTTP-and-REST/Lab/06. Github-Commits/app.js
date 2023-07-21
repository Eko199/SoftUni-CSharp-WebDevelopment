async function loadCommits() {
    const username = document.getElementById("username").value;
    const repo = document.getElementById("repo").value;

    const list = document.getElementById("commits");
    list.innerHTML = "";

    try {
        const response = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);

        if (!response.ok) {
            throw new Error("" + response.status);
        }

        const commits = await response.json();

        commits.forEach(({ commit }) => 
            appendListItemToCommits(`${commit.author.name}: ${commit.message}`)
        );
    } catch(error) {
        appendListItemToCommits(`Error: ${error.message} (Not Found)`);
    }

    function appendListItemToCommits(text) {
        const li = document.createElement("li");
        li.innerText = text;

        list.appendChild(li);
    }
}