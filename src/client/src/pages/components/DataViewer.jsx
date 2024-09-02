import React, { Component } from 'react'
import { getDataDir, getFile } from '../../services/data';
import DirComponent from './DirComponent';
import FileComponent from './FileComponent';




class DataViewer extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
      dirData: {dirs:[],files:[]},
      dirPath: []
    };
    this.dirIn = this.dirIn.bind(this);
    this.dirOut = this.dirOut.bind(this)
  }

  async dirIn(data)
  { 
    this.state.dirPath.push(data);
    await this.fetchData();
  }

  async dirOut()
  {
    this.state.dirPath.pop();
    await this.fetchData();
  }

  async fetchData()
  {
    let data = await getDataDir(this.state.dirPath.join("/"));
    this.setState({dirData: data.data})
  }

  async componentDidMount() 
  {
    await this.fetchData();    
  }

  render() {
    return (
      <div className='DataViewer'>
        <DirComponent data=".." dirChanger={this.dirOut} /> 
        {
      this.state.dirData.dirs.map((data) => 
          (<DirComponent data={data} dirChanger={this.dirIn}/>)
        )}
        {
        this.state.dirData.files.map((data) => 
          (<FileComponent data={data} filepath={this.state.dirPath.join("\\") + data}/>)
        )}
      </div>
    )
  }
}

export default DataViewer