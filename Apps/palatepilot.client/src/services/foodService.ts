import authAxios from "@/interceptors/authAxios";
import type { Food } from "@/models/food";

export default {
    
  async getAll(): Promise<Food[] | undefined> {
    try {
      const response = await authAxios("/Food");
      console.log(response.data.data);
      return response.data.data
    }

    catch (error: any) {
      const response = error.response;
      console.error(response.data);
    }
  },
}
