import axios from "axios";

axios.defaults.baseURL = 'http://localhost:5017'


export const authUser = async (signinData, resolve,reject) => {
    try
    {
        const response = await axios.get("/user",
            {
                params: 
                {
                    name: signinData.name,
                    password: signinData.password
                }
            }
        ).then(resolve).catch(reject);
        return response;
    } 
    catch(e) {
        return e;
    }
}

export const createUser = async (signupData, resolve,reject) => {
    try{
        return await axios.post("/user", signupData
        ).then(resolve).catch(reject);
    } 
    catch(e) {
        return e;
    }
    
}