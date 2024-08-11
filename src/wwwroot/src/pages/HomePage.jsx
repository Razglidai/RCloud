import React, { Component } from 'react'
import Cookies from "js-cookie"
import { Navigate } from 'react-router-dom'
import Layout from './components/Layout'

class HomePage extends Component {
  render() {
    if(Cookies.get("jwt") == undefined){ return(<Navigate to="/signin" replace />) }
    return (
      <Layout>
        <main>
          
        </main>
      </Layout>
    )
  }
}

export default HomePage