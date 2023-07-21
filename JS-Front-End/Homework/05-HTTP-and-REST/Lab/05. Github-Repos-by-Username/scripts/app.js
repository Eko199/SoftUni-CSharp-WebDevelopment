function loadRepos() {
	const username = document.getElementById("username").value;

	const list = document.getElementById("repos");
	list.innerHTML = "";

	fetch(`https://api.github.com/users/${username}/repos`)
		.then(res => res.json())
		.then(repos => repos.forEach(repo => {
			const li = document.createElement("li");

			const a = document.createElement("a");
			a.innerText = repo.full_name;
			a.href = repo.html_url;

			li.appendChild(a);
			list.appendChild(li);
		}))
		.catch(() => list.innerHTML = "<a href='{repo.html_url}'>{repo.full_name}</a>");
}