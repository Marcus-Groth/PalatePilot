import axios from "axios";
import type { User } from "@/models/user";

const AUTH_URL = "https://localhost:7200/api/User";

export default {

  // Generate new user
  async register(newUser: User) {
    try {
      await axios.post(AUTH_URL + "/Registration", newUser);
      return "Account successfully created";
    } catch (e) {
      return "Account already exist!";
    }
  },
};