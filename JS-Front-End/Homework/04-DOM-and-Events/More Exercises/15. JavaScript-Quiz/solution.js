function solve() {
  let answers = new Set(["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"]);
  let correctAnswers = 0, questionsAnswered = 0;

  const sections = Array.from(document.getElementsByTagName("section"));

  Array.from(document.querySelectorAll(".answer-text"))
    .forEach(p => p.addEventListener("click", clickAnswer));

  function clickAnswer(ev) {
    if (answers.delete(ev.target.textContent)) {
      correctAnswers++;
    }

    sections[questionsAnswered++].style.display = "none";

    if (questionsAnswered === 3) {
      document.getElementById("results").style.display = "block";
      document.querySelector("#results h1").textContent = correctAnswers === 3
        ? "You are recognized as top JavaScript fan!"
        : `You have ${correctAnswers} right answers`;

      return;
    }

    sections[questionsAnswered].style.display = "block";
  }
}