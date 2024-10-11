import {Outlet} from "react-router-dom"
import Cookies from "js-cookie"
import { AiOutlineUser, AiOutlineLogout } from "react-icons/ai";

const Layout = () => {
    return (
      <>
        <header>
          <AiOutlineLogout className="CustomButton" onClick={() => {Cookies.remove("jwt"); window.location.reload()}}/>
          <AiOutlineUser className='CustomButton'/>
        </header>
        <Outlet />
        <footer>
          <p>www.github.com/Razglidai</p>
        </footer>
      </>
    )
}

export default Layout