import { useState } from "react";
import { toast } from "react-toastify";
import { ReactComponent as CartIcon } from "../../assets/cart.svg";
import { addProductToCart } from "../../services/products-service";

export default function ShoppingCartForm({ f, setF }) {
    const [itemName, setItemName] = useState("");
    const [itemCost, setItemCost] = useState("");
    const [itemImgUrl, setItemImgUrl] = useState("");

    function handleSubmit(ev) {
        ev.preventDefault();

        const promise = addProductToCart(itemName, itemCost, itemImgUrl)
            .then(() => {
                setItemName("");
                setItemCost("");
                setItemImgUrl("");

                setF(!f);
            })
            .catch(toast.error);

        toast.promise(promise, {
            pending: "Processing request...",
            success: "Item added successfuly!",
            error: "Error adding item!"
        });
    }

    return <form onSubmit={handleSubmit}>
        <div className="shopping-cart__form-control">
            <input type="text" name="item-name" placeholder="Name" value={itemName} onChange={ev => setItemName(ev.target.value)} />
        </div>

        <div className="shopping-cart__form-control">
            <input type="number" name="item-cost" placeholder="Cost" value={itemCost} onChange={ev => setItemCost(Number(ev.target.value))} />
        </div>

        <div className="shopping-cart__form-control">
            <input type="text" name="item-image" placeholder="Place image url here" value={itemImgUrl} onChange={ev => setItemImgUrl(ev.target.value)} />
        </div>

        <div className="shopping-cart__form-control">
            <button type="submit" disabled={itemName === "" || itemCost === "" || itemImgUrl === ""}>
                <span>Add</span>
                <CartIcon />
            </button>
        </div>
    </form>;
}