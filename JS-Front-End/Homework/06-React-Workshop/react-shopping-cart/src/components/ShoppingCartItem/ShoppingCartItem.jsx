import { toast } from "react-toastify";
import { ReactComponent as BuyIcon } from "../../assets/buy.svg";
import { ReactComponent as RemoveIcon } from "../../assets/remove.svg";
import { buyProduct, removeProduct } from "../../services/products-service";

export default function ShoppingCartItem({ item, f, setF }) {
    function handleBuyItem() {
        const promise = buyProduct(item._id)
            .then(() => setF(!f))
            .catch(toast.error);

        toast.promise(promise, {
            pending: "Processing request...",
            success: "Bought item successfuly!",
            error: "Error buying item!"
        });
    }

    function handleRemoveItem() {
        const promise = removeProduct(item._id)
            .then(() => setF(!f))
            .catch(console.log);

        toast.promise(promise, {
            pending: "Processing request...",
            success: "Item removed successfuly!",
            error: "Error removing item!"
        });
    }

    return <article className="shopping-cart__item-container" style={{ textDecoration: item.isBought ? "line-through" : "none" }}>
        <img className="shopping-cart__item-img" src={item.imgUrl} alt="Item image" />
        <p className="shopping-cart__item-name">{item.name}</p>
        <p className="shopping-cart__item-cost">{item.cost}$</p>
        <div className="shopping-cart__item-actions">
            {!item.isBought &&
                <button className="shopping-cart__item--buy-btn" onClick={handleBuyItem}>
                    <span>Buy</span>
                    <BuyIcon />
                </button>
            }
            <button className="shopping-cart__item--remove-btn" onClick={handleRemoveItem}>
                <span>Remove</span>
                <RemoveIcon />
            </button>
        </div>
    </article>;
}