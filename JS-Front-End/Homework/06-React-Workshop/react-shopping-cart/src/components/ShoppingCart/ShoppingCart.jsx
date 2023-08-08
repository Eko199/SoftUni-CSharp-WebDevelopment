import { useEffect, useState } from "react";
import ShoppingCartItem from "../ShoppingCartItem/ShoppingCartItem";
import ShoppingCartForm from "../ShoppingCartForm/ShoppingCartForm";
import { getAllProducts } from "../../services/products-service";

export default function ShoppingCart() {
    const [products, setProducts] = useState([]);
    const [f, setF] = useState(false);

    useEffect(() => {
        getAllProducts()
            .then(res => setProducts(Object.values(res)))
            .catch(console.log);
    }, [f]);

    const totalPrice = products
        .filter(p => p.isBought)
        .reduce((acc, curr) => acc + curr.cost, 0);

    return <section className="shopping-cart__container">
        <ShoppingCartForm f={f} setF={setF} />

        <section className="shopping-cart__items-list">
            {products.map(p => <ShoppingCartItem key={p._id} item={p} f={f} setF={setF} />)}
        </section>

        <div className="shopping-cart__total-price">
            <h1>Total Price: {totalPrice}$</h1>
        </div>
    </section>;
}