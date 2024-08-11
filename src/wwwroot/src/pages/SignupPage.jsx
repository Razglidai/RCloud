import React, { Component } from 'react';
import { Link } from "react-router-dom";
import { createUser } from '../services/user';

class SignupPage extends Component {
  constructor(props)
  {
    super(props);
    this.state = {
      username:"",
      password:"",
      email: ""
    };
  }

  Signup()
  {
    if(this.state.username == "" || this.state.password == "" || this.state.email == "")
      {
        alert("Введите данные для регистрации");
      }
    else
    {
      console.log(
      createUser(
        {
          username: this.state.username,
          password: this.state.password,
          email: this.state.email
      })
      );
    }
  }

  render() {
    return (
        <div className="Form">
          <p>Логин</p>
          <input type="text" onChange={e => (this.setState({username: e.target.value}))} className="el"/>
          <p>Email</p>
          <input type="text" onChange={e => (this.setState({email: e.target.value}))} className="el"/>
          <p>Пароль</p>
          <input type="text" onChange={e => (this.setState({password: e.target.value}))} className="el"/>
          <Link to="/signin" className="link">Авторизация</Link>
          <button type="sumbit" onClick={() => this.Signup()} className="elButton">Зарегистрироваться</button>
        </div>
    )
  }
}

export default SignupPage
