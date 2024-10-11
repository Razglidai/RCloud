import React, { useState } from 'react';
import { Link, Navigate, replace } from "react-router-dom";
import "./css/SignPage.css"

const SignupPage = () => {
  const [name, setName] = useState();
  const [password, setPassword] = useState();
  const [email, setEmail] = useState();
    return (
    <div>
    <label>Логин</label>
    <input type="username" name='username'/>
    <label>Email</label>
    <input type="email" name='email'/>
    <label>Пароль</label>
    <input type="password" name='password'/>
    <Link to="/signin">Авторизация</Link>
    <button type="sumbit" onClick={(e)=>console.log(e)}>Зарегистрироваться</button>
  </div>
    )
  
}
export default SignupPage
