import type { LoginRequest } from "@/requests/loginRequest";
import localService from "./localService";
import baseAxios from "@/interceptors/baseAxios";

export default {
    
  async login(loginRequest: LoginRequest): Promise<string> {
    try {
      const url = '/Auth/Login'
      const response = await baseAxios.post(url, loginRequest);
      console.log(response.data)
      localService.set("jwt", response.data.data);
      return response.data.message;
    } 
    
    catch (error: any) {
      const response = error.response;
      console.error(response.data);
      return response.data.errors;
    }
  },

  logout(): void {
    localService.delete("jwt");
    console.log("Logout was Successfull")
  }
}
