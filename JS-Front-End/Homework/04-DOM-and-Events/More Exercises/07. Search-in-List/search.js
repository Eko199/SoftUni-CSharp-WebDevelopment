function search() {
   const search = document.getElementById("searchText").value;
   let count = 0;

   Array.from(document.querySelectorAll("#towns li")).forEach(li => {
      if (li.textContent.includes(search)) {
         li.style.fontWeight = "bold";
         li.style.textDecoration = "underline";
         count++;
      } else {
         li.style.fontWeight = "normal";
         li.style.textDecoration = "none";
      }
   })

   document.getElementById("result").textContent = `${count} matches found`;
}