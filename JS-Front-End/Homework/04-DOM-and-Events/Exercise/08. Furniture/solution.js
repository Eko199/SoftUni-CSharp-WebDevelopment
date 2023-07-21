function solve() {
  document.getElementsByTagName("button")[0].addEventListener("click", generateFurniture);
  document.getElementsByTagName("button")[1].addEventListener("click", buyFurniture);

  function generateFurniture() {
    const furniture = JSON.parse(document.querySelector("textarea").value);

    furniture.forEach(f => {
      const tr = document.createElement("tr");

      const imageTd = document.createElement("td");
      const image = document.createElement("img");
      image.src = f.img;
      imageTd.appendChild(image);

      const nameTd = document.createElement("td");
      const name = document.createElement("p");
      name.innerText = f.name;
      nameTd.appendChild(name);

      const priceTd = document.createElement("td");
      const price = document.createElement("p");
      price.innerText = f.price;
      priceTd.appendChild(price);

      const decFactorTd = document.createElement("td");
      const decFactor = document.createElement("p");
      decFactor.innerText = f.decFactor;
      decFactorTd.appendChild(decFactor);

      const checkboxTd = document.createElement("td");
      const checkbox = document.createElement("input");
      checkbox.type = "checkbox";
      checkboxTd.appendChild(checkbox);

      tr.appendChild(imageTd);
      tr.appendChild(nameTd);
      tr.appendChild(priceTd);
      tr.appendChild(decFactorTd);
      tr.appendChild(checkboxTd);

      document.querySelector("tbody").appendChild(tr);
    });
  }

  function buyFurniture() {
    const furnitureRows = Array.from(document.querySelectorAll("tbody tr"))
      .filter(tr => tr.querySelector("input[type='checkbox']").checked);

    const result = furnitureRows.reduce((acc, curr) => {
        const [name, price, decFactor] = curr.querySelectorAll("td p");

        acc.names.push(name.innerText);
        acc.price += Number(price.innerText);
        acc.avgDecFactor += Number(decFactor.innerText) / furnitureRows.length;

        return acc;
      }, {
        names: [],
        price: 0,
        avgDecFactor: 0
      });

    document.querySelector("textarea[disabled]").value = `Bought furniture: ${result.names.join(", ")}
Total price: ${result.price.toFixed(2)}
Average decoration factor: ${result.avgDecFactor}`;
  }
}