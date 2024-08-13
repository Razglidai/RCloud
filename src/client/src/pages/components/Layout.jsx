import React, { Component } from 'react'
import Cookies from "js-cookie"
import { AiOutlineUser, AiOutlineLogout } from "react-icons/ai";
import { postData } from '../../services/data';

class Layout extends Component {
  render() {
    return (
      <div>
        <header className='Head'>
          <AiOutlineLogout className="CustomButton" onClick={() => {Cookies.remove("jwt"); window.location.reload()}}/>
          <AiOutlineUser className='CustomButton'/>
        </header>
        <button onClick={() => console.log(postData())} />

      </div>
    )
  }
}

export default Layout