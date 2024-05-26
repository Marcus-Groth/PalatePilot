import axios from "axios";
import type { User } from "@/models/user";

const AUTH_URL = "https://localhost:7200/api/User";

export default {

  // Generate new user
  async registration(user: User): Promise<string> {
    try{
        const url = AUTH_URL + "/Registration"
        const response = await axios.post(url, user);
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