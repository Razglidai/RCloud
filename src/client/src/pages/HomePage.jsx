import React, { Component } from 'react'
import Cookies from "js-cookie"
import { Navigate } from 'react-router-dom'
import Layout from './components/Layout'
import DataViewer from './components/DataViewer'

class HomePage extends Component {
  render() {
    if(Cookies.get("jwt") == undefined){ return(<Navigate to="/signin" replace />) }
    return (
        <div>
          <Layout />
          <main >
            <DataViewer />
          </main>
        </div>
    )
  }
}

export default HomePage