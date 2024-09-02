import React, { Component } from 'react'
import icon from "../../assets/file.svg"
import { AiFillDelete } from "react-icons/ai";
import { getFile } from '../../services/data';
import { saveAs } from 'file-saver';

class FileComponent
 extends Component {
  dowloandData(filename, filepath)
  {
    getFile(filepath)
    .then(res => {

  const blob = new Blob([res.data], {
      type: 'application/octet-stream'
  })

  saveAs(blob, filename)
    })
  
  }
  render() {
    return (
      <div className='ViewerBlock'onClick={()=>{this.dowloandData(this.props.data,this.props.filepath)}}>
        <img src={icon} alt="file" />
        <p> {this.props.data}</p>
        <AiFillDelete />
      </div>
    )
  }
}

export default FileComponent
