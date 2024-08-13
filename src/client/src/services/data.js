import axios from "axios";
import Cookies from "js-cookie";

axios.defaults.baseURL = 'http://localhost:5017'
axios.defaults.headers.common = {Authorization: "Bearer " + Cookies.get("jwt")}

export const getData = async () => {
    try{
        const response = await axios.get("/data")
    }catch(e){
        return e;
    }
}

export const postData = async () => {
    try{
        const response = await axios.post("/data",
        )
    }catch(e){
        return e;
    }
}