import React, { Component } from 'react'
import Cookies from "js-cookie"
import { AiOutlineUser, AiOutlineLogout } from "react-icons/ai";

class Layout extends Component {
  render() {
    return (
      <div>
        <header className='Head'>
          <AiOutlineLogout className="CustomButton" onClick={() => {Cookies.remove("jwt"); window.location.reload()}}/>
          <AiOutlineUser className='CustomButton'/>
        </header>
      </div>
    )
  }
}

export default Layout