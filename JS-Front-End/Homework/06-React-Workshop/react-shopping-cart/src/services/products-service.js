const BASE_URL = "http://localhost:3030/jsonstore/products";

export async function getAllProducts() {
    return (await fetch(BASE_URL)).json();
}

export async function addProductToCart(name, cost, imgUrl) {
    return (await fetch(BASE_URL, {
        method: "POST",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({ name, cost, imgUrl, isBought: false })
    })).json();
}

export async function buyProduct(productId) {
    return (await fetch(`${BASE_URL}/${productId}`, {
        method: "PATCH",
        headers: { "Content-type": "application/json" },
        body: JSON.stringify({ isBought: true })
    })).json();
}

export async function removeProduct(productId) {
    return (await fetch(`${BASE_URL}/${productId}`, { 
        method: "DELETE" 
    })).json();
}