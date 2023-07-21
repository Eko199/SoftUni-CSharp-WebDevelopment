function create(words) {
   const content = document.getElementById("content");

   words.forEach(w => {
      const p = document.createElement("p");
      p.innerText = w;
      p.style.display = "none";

      const div = document.createElement("div");
      div.appendChild(p);
      div.addEventListener("click", () => p.style.display = "block");

      content.appendChild(div);
   });
}