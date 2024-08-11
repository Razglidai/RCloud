import React from "react";
import {Route, Routes} from "react-router-dom";
import SigninPage from "./pages/SigninPage";
import HomePage from "./pages/HomePage";
import SignupPage from "./pages/SignupPage";
import EmptyPage from "./pages/EmptyPage";

class App extends React.Component
 {
  render()
  {
    return(
      <Routes>
        <Route path="/" element={<HomePage/>}/>
        <Route path="/signin" element={<SigninPage />}/>
        <Route path="/signup" element={<SignupPage />}/>
        <Route path="*" element={<EmptyPage />}/>
      </Routes>
    )
  }
 }

export default App
