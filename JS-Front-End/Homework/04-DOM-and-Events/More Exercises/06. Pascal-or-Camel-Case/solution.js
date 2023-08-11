function solve() {
  const text = document.getElementById("text").value;
  const casing = document.getElementById("naming-convention").value;
  const resultElement = document.getElementById("result");

  if (casing !== "Camel Case" && casing !== "Pascal Case") {
    resultElement.textContent = "Error!";
    return;
  }

  let result = text.toLowerCase()
    .split(" ")
    .map(w => w[0].toUpperCase() + w.slice(1))
    .join("");
  
  if (casing === "Camel Case") {
    result = result[0].toLowerCase() + result.slice(1);
  }

  resultElement.textContent = result;
}