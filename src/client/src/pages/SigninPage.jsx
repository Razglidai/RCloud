import React from "react";
import { Link } from "react-router-dom";
import { authUser } from "../services/user";
import { Navigate } from 'react-router-dom'
import Cookies from "js-cookie"

class SigninPage extends React.Component
 {
  constructor(props)
  {
    super(props);
    this.state = {
      username:"",
      password:"",    
    };
  }

  async Signin()
  {
    if(this.state.username == "" || this.state.password == "")
      {
        alert("Введите данные для авторизации");
      }
    else
    {
      
      await authUser(
        {
          username: this.state.username,
          password: this.state.password
      },
      (resolve) => {Cookies.set("jwt", resolve.data); ; window.location.reload();},
      (reject) => { alert("Ошибка " + reject.response.status)}
    );
    }
  }

  render()
  {
    if(Cookies.get("jwt") != undefined){ return(<Navigate to="/" replace />) }
    return(
        <div className="Form">
          <p>Логин</p>
          <input type="text" onChange={e => (this.setState({username: e.target.value}))} className="el"/>
          <p>Пароль</p>
          <input type="text" onChange={e => (this.setState({password: e.target.value}))} className="el"/>
          <Link to="/signup" className="link">Регистрация</Link>
          <button onClick={() =>  this.Signin()} className="elButton">Войти</button>
        </div>
    )
  }
 }

export default SigninPage
