function solve() {
  const sentences = document.getElementById("input").value
                            .split(".")
                            .filter(s => s.length >= 1);
  let output = "";

  while (sentences.length > 0) {
    output += `<p>${sentences.splice(0, 3).join(".")}.</p>`;
  }

  document.getElementById("output").innerHTML = output;
}