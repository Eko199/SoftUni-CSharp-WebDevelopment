import { ToastContainer } from 'react-toastify';
import ShoppingCart from './components/ShoppingCart/ShoppingCart';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return <>
    <ShoppingCart />
    <ToastContainer />
  </>;
}

export default App;