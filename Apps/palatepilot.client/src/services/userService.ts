import baseAxios from "@/interceptors/baseAxios";
import type { RegisterRequest } from "@/requests/registerRequest";

export default {

  // Generate new user
  async registration(registerRequest: RegisterRequest): Promise<string> {
    try{
      const url = '/User/Registration'
      const response = await baseAxios.post(url, registerRequest);
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