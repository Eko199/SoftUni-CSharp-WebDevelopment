function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      Array.from(document.querySelectorAll("tbody tr"))
         .forEach(tr => tr.className = "");

      const text = document.getElementById("searchField").value;
      Array.from(document.querySelectorAll("tbody td"))
         .filter(td => td.innerText.includes(text))
         .forEach(td => td.parentElement.className = "select");
   }
}