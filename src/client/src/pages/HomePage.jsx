import React, { Component } from 'react'
import Cookies from "js-cookie"
import { Navigate } from 'react-router-dom'

const HomePage = () => {
    if(Cookies.get("jwt") == undefined)
      { 
        return(<Navigate to="/signin" replace />) 
      }
    return (
          <main >
          </main>
    )
  }
export default HomePage