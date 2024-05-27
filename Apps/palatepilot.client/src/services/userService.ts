import type { RegisterRequest } from "@/requests/registerRequest";
import axios from "axios";

const AUTH_URL = "https://localhost:7200/api/User";

export default {

  // Generate new user
  async registration(registerRequest: RegisterRequest): Promise<string> {
    try{
      const url = AUTH_URL + "/Registration"
      const response = await axios.post(url, registerRequest);
      console.log(response.data);
      return response.data.message;
    } 
    
    catch (error: any) {
        const response = error.response;
        console.error(response.data);
        return response.data.errors;
    }
  },
};