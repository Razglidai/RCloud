import axios from "axios";
import Cookies from "js-cookie";

axios.defaults.baseURL = 'http://localhost:5017'
axios.defaults.headers.common = {Authorization: "Bearer " + Cookies.get("jwt")}

export const getDataDir = async (path) => {
    try{
        return await axios.get("/data/dir", {
            params:{
                path: path
            }
        })
    }catch(e){
        return e;
    }
}

export const createDir = async () => {
    try{
        return await axios.post("/data/dir",
        )
    }catch(e){
        return e;
    }
}

export const getFile = async (path) => {
    try{
        return await axios.get("/data/file", 
            {
            responseType: 'arraybuffer',
            params:{
                path: path
            }
        })
    }catch(e){
        return e;
    }
}

export const uploadFile = async (path) => {
    try{
        return await axios.post("/data/file",
            {params:{
                path: path
            }}
        )
    }catch(e){
        return e;
    }
}


