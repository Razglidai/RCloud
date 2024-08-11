import axios from "axios";

axios.defaults.baseURL = 'http://localhost:5017'


export const authUser = async (signinData) => {
    try
    {
        const response = await axios.get("/user",
            {
                params: 
                {
                    username: signinData.username,
                    password: signinData.password
                }
            }
        );
        return response.data;
    } 
    catch(e) {
        return e;
    }
}

export const createUser = async (signupData) => {
    try{
        return await axios.post("/user", signupData
        );
    } 
    catch(e) {
        return e;
    }
    
}