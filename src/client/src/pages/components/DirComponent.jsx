import React, { Component } from 'react'
import icon from "../../assets/directory.svg";
import { AiFillDelete } from "react-icons/ai";

class DirComponent
 extends Component {
  render() {
    return (
      <div className='ViewerBlock' onClick={()=>{this.props.dirChanger(this.props.data)}}>
        <img src={icon} alt="directory" />
        <p> {this.props.data}</p>
        <AiFillDelete />
      </div>
    )
  }
}

export default DirComponent
