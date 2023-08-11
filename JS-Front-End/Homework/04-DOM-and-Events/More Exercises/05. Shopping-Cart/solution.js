function solve() {
   const textArea = document.querySelector("textarea");

   const cartList = new Set();
   let totalPrice = 0;

   Array.from(document.querySelectorAll(".add-product"))
      .forEach(btn => btn.addEventListener("click", addProduct));

   document.querySelector(".checkout").addEventListener("click", checkout);

   function addProduct(ev) {
      const productDiv = ev.target.parentNode.parentNode;
      const productName = productDiv.querySelector(".product-title").textContent;
      const productPrice = Number(productDiv.querySelector(".product-line-price").textContent);

      cartList.add(productName);
      totalPrice += productPrice;

      textArea.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
   }

   function checkout() {
      textArea.textContent += `You bought ${Array.from(cartList).join(", ")} for ${totalPrice.toFixed(2)}.`;

      Array.from(document.getElementsByTagName("button"))
         .forEach(btn => btn.disabled = true);
   }
}