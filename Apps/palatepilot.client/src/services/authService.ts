import type { LoginRequest } from "@/requests/loginRequest";
import axios from "axios";
import localService from "./localService";


const AUTH_URL = "https://localhost:7200/api/Auth";

export default {
    
  async login(loginRequest: LoginRequest): Promise<string> {
    try {
      const url = AUTH_URL + "/Login";
      const response = await axios.post(url, loginRequest);
      console.log(response.data)
      localService.set("jwt token", response.data.data);
      return response.data.message;
    } 
    
    catch (error: any) {
      const response = error.response;
      console.error(response.data);
      return response.data.errors;
    }
  },
}
