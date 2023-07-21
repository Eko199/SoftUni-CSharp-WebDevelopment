function loadRepos() {
   fetch("https://api.github.com/users/testnakov/repos")
      .then(res => res.text())
      .then(text => document.getElementById("res").innerText = text);
}