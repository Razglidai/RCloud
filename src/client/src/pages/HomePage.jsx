import React, { Component } from 'react'
import Cookies from "js-cookie"
import { Navigate } from 'react-router-dom'
import Layout from './components/Layout'
import { postData, getData } from '../services/data'

class HomePage extends Component {
  render() {
    if(Cookies.get("jwt") == undefined){ return(<Navigate to="/signin" replace />) }
    return (
      <Layout>
        <main>
          <button onClick={() => console.log(postData)} />
        </main>
      </Layout>
    )
  }
}

export default HomePage