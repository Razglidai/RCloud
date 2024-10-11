import React, { useState } from "react";
import { Link } from "react-router-dom";
import { authUser } from "../services/user";
import { Navigate } from 'react-router-dom'
import Cookies from "js-cookie"
import "./css/SignPage.css"

const SigninPage = () =>
 {
    if(Cookies.get("jwt") != undefined){ return(<Navigate to="/" replace />) }
    return(
        <form>
          <label>Логин</label>
          <input type="username" className="el"/>
          <label>Пароль</label>
          <input type="password" className="el"/>
          <Link to="/signup">Регистрация</Link>
          <button type="sumbit">Войти</button>
        </form>
    )
 }
export default SigninPage
